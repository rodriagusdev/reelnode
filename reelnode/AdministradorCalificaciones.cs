using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Reelnode
{
    public static class AdministradorCalificaciones
    {
        public static event Action OnCalificacionActualizada;

        public static List<AudiovisualMiniatura> CargarCalificacionesUsuarioPeliculas()
        {
            return AdministradorAudiovisual.CargarMiniaturaAudiovisual(
                "sp_obtener_calificaciones_x_usuario_pelis",
                EnumTipoId.id_pelicula,
                true,
                EnumTipoId.p_id_usuario
            );
        }

        public static List<AudiovisualMiniatura> CargarCalificacionesUsuarioSeries()
        {
            return AdministradorAudiovisual.CargarMiniaturaAudiovisual(
                "sp_obtener_calificaciones_x_usuario_serie",
                EnumTipoId.id_serie,
                true,
                EnumTipoId.p_id_usuario
            );
        }

        public static double ObtenerCalificacionPromedio(string procedimiento, int id, EnumTipoId p_id)
        {
            double calificacionPromedio = 0;

            try {
                using (
                    MySqlCommand cmd = new MySqlCommand(
                        procedimiento,
                        UtilsBD.Conexion.GetConnection()
                    )
                )
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(p_id.ToString(), id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            calificacionPromedio = reader.IsDBNull(reader.GetOrdinal("promedio_calificacion"))
                            ? 0
                            : reader.GetDouble(reader.GetOrdinal("promedio_calificacion"));

                            return calificacionPromedio;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al obtener promedio de calificacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return calificacionPromedio;
        }

        public static void Calificar(int idMedia, int puntuacion, EnumTipoId p_id)
        {
            string procedure =
                p_id == EnumTipoId.p_id_pelicula ? "sp_calificar_pelicula" : "sp_calificar_serie";

            try
            {
                using (
                    MySqlCommand cmd = new MySqlCommand(procedure, UtilsBD.Conexion.GetConnection())
                )
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(p_id.ToString(), idMedia);
                    cmd.Parameters.AddWithValue("p_calificacion", puntuacion);
                    cmd.Parameters.AddWithValue(
                        "p_id_usuario",
                        AdministradorUsuarios.usuarioActual.Id
                    );

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Calificacion enviada",
                        "Calificación Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    OnCalificacionActualizada?.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al calificar",
                    ex.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
