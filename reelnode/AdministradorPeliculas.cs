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
    public static class AdministradorPeliculas
    {
        public static List<Pelicula> peliculasCargadas = new List<Pelicula>();
        public static Pelicula peliculaSeleccionada = new Pelicula();

        /* !--- OPERACIONES CRUD PELICULAS ---! */
        public static List<AudiovisualMiniatura> CargarPeliculasPreview()
        {
            return AdministradorAudiovisual.CargarMiniaturaAudiovisual("sp_listar_peliculas_preview", EnumTipoId.id_pelicula, false , EnumTipoId.null_param);
        }
        public static void CargarPeliculas()
        {
            peliculasCargadas.Clear();

            var listAudiovisual = 
                AdministradorAudiovisual
                .CargarAudiovisualCompleto
                ("sp_listar_peliculas", EnumTipoId.id_pelicula);

            foreach (var item in listAudiovisual)
            {
                if (item is Pelicula pelicula)
                {
                    peliculasCargadas.Add(pelicula);
                }
            }
        }

        public static bool InsertarPeliculaBD(Pelicula nuevaPelicula)
        {
            bool insertacionExitosa = 
                AdministradorAudiovisual.
                InsertarAudiovisual
                (nuevaPelicula, "sp_insertar_pelicula", EnumTipoId.p_id_pelicula);

            if (insertacionExitosa)
            {
                RecargarPeliculas();
            }

            return insertacionExitosa;
        }

        public static bool ActualizarPelicula(Pelicula actualizarPelicula)
        {
            bool actualizacionExitosa = 
                AdministradorAudiovisual.ActualizarAudiovisual
                (actualizarPelicula, "sp_actualizar_pelicula", EnumTipoId.p_id_pelicula);

            if (actualizacionExitosa)
            {
                RecargarPeliculas();
            }

            return actualizacionExitosa;
        }

        public static void EliminarPelicula(int id)
        {
            bool eliminacionExitosa = 
                AdministradorAudiovisual.
                EliminarAudiovisual
                ("sp_eliminar_pelicula", id, "Película eliminada con exito");

            if (eliminacionExitosa)
            {
                RecargarPeliculas();
            }
        }

        public static void RecargarPeliculas()
        {
            peliculasCargadas.Clear();
            CargarPeliculas();
        }

        public static List<Comentario> CargarComentariosPelicula(int idPelicula)
        {
            List<Comentario> listaComentarios = new List<Comentario>();

            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_comentarios_pelis", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_pelicula", idPelicula);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Comentario c = new Comentario
                        {
                            Usuario = reader.GetString("nombre_usuario"),
                            UsuarioAvatar = reader.IsDBNull(reader.GetOrdinal("avatar")) ? null : reader.GetString("avatar"),
                            Texto = reader.GetString("texto"),
                            Fecha = reader.GetDateTime("fecha_comentario"),
                        };

                        listaComentarios.Add(c);
                    }
                }

                return listaComentarios;
            }
        }

        /* FIN OPERACIONES CRUD PELICULAS */


        /* !--- CARGA DE DATOS PARA METRICAS ---! */
        public static MetricaAudiovisual CargarUltimaPeliculaRegistrada()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ultima_pelicula_cargada", UtilsBD.Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MetricaAudiovisual ultimaPeliculaCargada = new MetricaAudiovisual
                            (
                                reader.GetString("nombre"),
                                reader.GetString("imagenURL")
                            );

                            return ultimaPeliculaCargada;
                        }
                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la última película: " + ex.Message);
            }
           
            return null;
        }

        public static List<AudiovisualMiniatura> CargarPeliculasMejorCalificadas(int limit)
        {
            List<AudiovisualMiniatura> list = new List<AudiovisualMiniatura>();

            using (MySqlCommand cmd = new MySqlCommand("sp_top_calificaciones_peliculas", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_limite", limit);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AudiovisualMiniatura peliMiniatura = new AudiovisualMiniatura
                        {
                            Id = reader.GetInt32("id_pelicula"),
                            Nombre = reader.GetString("nombre"),
                            CalificacionPromedio = reader.GetDecimal("promedio_calificacion"),
                        };

                        list.Add(peliMiniatura);
                    }
                }
            }

            return list;
        }

        public static List<AudiovisualMiniatura> CargarPeliculasMasVistas(int limit)
        {
            List<AudiovisualMiniatura> list = new List<AudiovisualMiniatura>();

            using (MySqlCommand cmd = new MySqlCommand("sp_historial_peliculas", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_limite", limit);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AudiovisualMiniatura p = new AudiovisualMiniatura
                        {
                            Id = reader.GetInt32("id_pelicula"),
                            Nombre = reader.GetString("nombre"),
                            CantidadVistas = reader.GetInt32("veces_visto"),
                        };

                        list.Add(p);
                    }
                }
            }

            return list;
        }

        /* !--- FIN CARGA DE DATOS PARA METRICAS ---! */
    }
}
