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
    public static class AdministradorCalificaciones
    {
        public static List<MediaMiniatura> seriesCalificadasUsuario = new List<MediaMiniatura>();
        public static List<MediaMiniatura> peliculasCalificadasUsuario = new List<MediaMiniatura>();

        public static event Action OnCalificacionActualizada;
        public static void CargarCalificacionesUsuarioPeliculas(int idUsuario, List<MediaMiniatura> peliculasCalificadas)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_calificaciones_x_usuario_pelis", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MediaMiniatura pelicula = new MediaMiniatura
                        {
                            Id = reader.GetInt32("id_pelicula"),
                            Nombre = reader.GetString("nombre"),
                            ImagenURL = reader.GetString("imagenURL"),
                        };

                        peliculasCalificadas.Add(pelicula);
                    }
                }
            }
        }

        public static void CargarCalificacionesUsuarioSeries(int idUsuario, List<MediaMiniatura> seriesCalificadas)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_calificaciones_x_usuario_serie", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MediaMiniatura serie = new MediaMiniatura
                        {
                            Id = reader.GetInt32("id_serie"),
                            Nombre = reader.GetString("nombre"),
                            ImagenURL = reader.GetString("imagenURL"),
                        };

                        seriesCalificadas.Add(serie);
                    }
                }
            }
        }
        public static void Calificar(int idMedia, int puntuacion, string tipo)
        {
            string procedure = tipo == "Pelicula" ? "sp_calificar_pelicula" : "sp_calificar_serie";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(procedure, UtilsBD.Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(tipo == "Pelicula" ? "p_id_pelicula" : "p_id_serie", idMedia);
                    cmd.Parameters.AddWithValue("p_calificacion", puntuacion);
                    cmd.Parameters.AddWithValue("p_id_usuario", UtilsBD.usuarioActual.Id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Calificacion enviada", "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if(tipo == "Pelicula")
                    {
                        peliculasCalificadasUsuario.Clear();
                        CargarCalificacionesUsuarioPeliculas(UtilsBD.usuarioActual.Id, peliculasCalificadasUsuario);
                    }
                    else 
                    {
                        seriesCalificadasUsuario.Clear();
                        CargarCalificacionesUsuarioSeries(UtilsBD.usuarioActual.Id, seriesCalificadasUsuario);
                    }

                    OnCalificacionActualizada?.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calificar la " + tipo == "Pelicula" ? "pelicula" : "serie" + ex.Message);
            }
        }
    }
}
