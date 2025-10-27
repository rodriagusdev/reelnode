using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public static class AdministradorSeries
    {
        public static List<Serie> seriesCargadas = new List<Serie>();
        public static Serie serieSeleccionada = new Serie();

        /* !--- OPERACIONES CRUD SERIES ---! */

        public static List<AudiovisualMiniatura> CargarSeriesPreview()
        {
            return AdministradorAudiovisual.CargarMiniaturaAudiovisual("sp_listar_series_preview", EnumTipoId.id_serie, false, EnumTipoId.null_param);
        }
        public static void CargarSeries()
        {
            seriesCargadas.Clear();

            var listAudiovisual = 
                AdministradorAudiovisual.CargarAudiovisualCompleto
                ("sp_listar_series", EnumTipoId.id_serie);

            foreach (var item in listAudiovisual)
            {
                if (item is Serie serie)
                {
                    seriesCargadas.Add(serie);
                }
            }
        }

        public static bool InsertarSerieBD(Serie nuevaSerie)
        {
            bool insertacionExitosa = 
                AdministradorAudiovisual.InsertarAudiovisual
                (nuevaSerie, "sp_insertar_serie", EnumTipoId.p_id_serie);

            if (insertacionExitosa)
            {
                RecargarSeries();
            }

            return insertacionExitosa;
        }

        public static bool ActualizarSerie(Serie actualizarSerie)
        {
            bool actualizacionExitosa = 
                AdministradorAudiovisual.ActualizarAudiovisual
                (actualizarSerie, "sp_actualizar_serie", EnumTipoId.p_id_serie);

            if (actualizacionExitosa)
                RecargarSeries();

            return actualizacionExitosa;
        }

        public static void EliminarSerie(int id)
        {
            bool eliminacionExitosa = 
                AdministradorAudiovisual.EliminarAudiovisual
                ("sp_eliminar_serie", id, "Serie eliminada con exito");

            if (eliminacionExitosa)
            {
                RecargarSeries();
            }
        }

        public static void RecargarSeries()
        {
            seriesCargadas.Clear();
            CargarSeries();
        }

        /* !--- FIN OPERACIONES CRUD SERIES ---! */

        /* !--- DATOS PARA REPORTES ---! */

        public static List<AudiovisualMiniatura> CargarSeriesMejorCalificadas(int limit)
        {
            List<AudiovisualMiniatura> list = new List<AudiovisualMiniatura>();

            using (MySqlCommand cmd = new MySqlCommand("sp_top_calificaciones_series", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_limite", limit);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AudiovisualMiniatura peliMiniatura = new AudiovisualMiniatura
                        {
                            Id = reader.GetInt32("id_serie"),
                            Nombre = reader.GetString("nombre"),
                            CalificacionPromedio = reader.GetDecimal("promedio_calificacion"),
                        };

                        list.Add(peliMiniatura);
                    }
                }
            }

            return list;
        }

        public static MetricaAudiovisual CargarUltimaSerieRegistrada()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ultima_serie_cargada", UtilsBD.Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            MetricaAudiovisual ultimaSerie = new MetricaAudiovisual
                            (
                                reader.GetString("nombre"),
                                reader.GetString("imagenURL")
                            );

                            return ultimaSerie;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la última serie: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public static List<AudiovisualMiniatura> CargarSeriesMasVistas(int limit)
        {
            List<AudiovisualMiniatura> list = new List<AudiovisualMiniatura>();

            using (MySqlCommand cmd = new MySqlCommand("sp_historial_series", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_limite", limit);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AudiovisualMiniatura p = new AudiovisualMiniatura
                        {
                            Id = reader.GetInt32("id_serie"),
                            Nombre = reader.GetString("nombre"),
                            CantidadVistas = reader.GetInt32("veces_visto"),
                        };

                        list.Add(p);
                    }
                }
            }

            return list;
        }
    }
}
