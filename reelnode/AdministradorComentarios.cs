using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Reelnode
{
    public static class AdministradorComentarios
    {
        public static event Action onComentarioEliminado;
        public static string procedimiento;
        public static string p_id;
        public static int idAudiovisual;

        public static void EliminarComentario(Comentario c)
        {
            if (c.Usuario != AdministradorUsuarios.usuarioActual.NombreUsuario)
            {
                MessageBox.Show(
                    "Error al eliminar el comentario: no puedes eliminar el comentario de otros",
                    "Error eliminacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string procedure =
                p_id == EnumTipoId.p_id_pelicula.ToString()
                    ? "sp_eliminar_comentario_pelicula"
                    : "sp_eliminar_comentario_serie";

            try
            {
                using (
                    MySqlCommand cmd = new MySqlCommand(procedure, UtilsBD.Conexion.GetConnection())
                )
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "p_usuario_id",
                        AdministradorUsuarios.usuarioActual.Id
                    );

                    cmd.Parameters.AddWithValue(
                        "p_comentario_id",
                        c.Id
                    );

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Comentario eliminado!",
                        "Eliminacion exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar el comentario: " + ex.Message,
                    "Error eliminacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            onComentarioEliminado.Invoke();
        }

        public static void Comentar(int idMedia, string comentario, string tipo)
        {
            string procedure = tipo == "Pelicula" ? "sp_comentar_pelicula" : "sp_comentar_serie";

            try
            {
                using (
                    MySqlCommand cmd = new MySqlCommand(procedure, UtilsBD.Conexion.GetConnection())
                )
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(
                        "p_id_usuario",
                        AdministradorUsuarios.usuarioActual.Id
                    );

                    cmd.Parameters.AddWithValue(
                        tipo == "Pelicula" ? "p_id_pelicula" : "p_id_serie",
                        idMedia
                    );

                    cmd.Parameters.AddWithValue("p_texto", comentario);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Comentario enviado",
                        "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    onComentarioEliminado.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al calificar la " + tipo == "Pelicula"
                        ? "pelicula"
                        : "serie" + ex.Message
                );
            }
        }

        public static List<Comentario> ObtenerComentarios(
            string procedimiento,
            string p_id,
            int idAudiovisual
        )
        {
            List<Comentario> comentarios = new List<Comentario>();

            try
            {
                using (
                    MySqlCommand cmd = new MySqlCommand(
                        procedimiento,
                        UtilsBD.Conexion.GetConnection()
                    )
                )
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(p_id, idAudiovisual);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Comentario c = new Comentario
                            {
                                Id = reader.GetInt32("id_comentario"),
                                UsuarioAvatar = reader.GetString("avatar"),
                                Usuario = reader.GetString("nombre_usuario"),
                                Texto = reader.GetString("texto"),
                                Fecha = reader.GetDateTime("fecha_comentario"),
                            };

                            comentarios.Add(c);
                        }
                    }

                    return comentarios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error de pedido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return comentarios;
        }
    }
}
