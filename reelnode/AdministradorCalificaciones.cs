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
        public static void CargarCalificacionesUsuarioPeliculas()
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_calificaciones_x_usuario_pelis", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_usuario", AdministradorUsuarios.usuarioActual.Id);

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

                        peliculasCalificadasUsuario.Add(pelicula);
                    }
                }
            }
        }

        public static void CargarCalificacionesUsuarioSeries()
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_calificaciones_x_usuario_serie", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_usuario", AdministradorUsuarios.usuarioActual.Id);

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

                        seriesCalificadasUsuario.Add(serie);
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
                    cmd.Parameters.AddWithValue("p_id_usuario", AdministradorUsuarios.usuarioActual.Id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Calificacion enviada", "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if(tipo == "Pelicula")
                    {
                        peliculasCalificadasUsuario.Clear();
                        CargarCalificacionesUsuarioPeliculas();
                    }
                    else 
                    {
                        seriesCalificadasUsuario.Clear();
                        CargarCalificacionesUsuarioSeries();
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
