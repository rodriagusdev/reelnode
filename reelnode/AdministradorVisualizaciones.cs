using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reelnode
{
    public static class AdministradorVisualizaciones
    {
        public static event Action onVisualizacionRegistrada;
        public static int CargarVisualizacionesUltimoMes()
        {
            int total = 0;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_obtener_visualizaciones_ultimo_mes", UtilsBD.Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            total = reader.GetInt32("total_visualizaciones");

                            return total;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return total;
        }
        public static void RegistrarVisualizacion(int idMedia, string tipo)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_registrar_visualizacion", UtilsBD.Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_tipo", tipo);
                    cmd.Parameters.AddWithValue("p_id_media", idMedia);
                    cmd.Parameters.AddWithValue("p_id_usuario", AdministradorUsuarios.usuarioActual.Id);

                    cmd.ExecuteNonQuery();

                    onVisualizacionRegistrada?.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al visualizar la " + tipo == "Pelicula" ? "pelicula" : "serie" + ex.Message);
            }
        }

        public static List<AudiovisualMiniatura> CargarPeliculasVistas()
        {
            return AdministradorAudiovisual
                .CargarMiniaturaAudiovisual("sp_obtener_visualizaciones_peliculas_usuario", EnumTipoId.id_pelicula, true, EnumTipoId.p_id_usuario);
        }

        public static List<AudiovisualMiniatura> CargarSeriesVistas()
        {
            return AdministradorAudiovisual
                .CargarMiniaturaAudiovisual("sp_obtener_visualizaciones_series_usuario", EnumTipoId.id_serie, true, EnumTipoId.p_id_usuario);
        }
    }
}
