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
    public static class AdministradorUsuarios
    {
        public static Usuario usuarioActual = new Usuario();
        public static List<Usuario> usuariosRegistrados = new List<Usuario>();


        public static void RegistrarUsuarioBD(Usuario nuevoUsuario)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_insertar_usuario", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_nombre", nuevoUsuario.NombreUsuario);
                cmd.Parameters.AddWithValue("p_password", nuevoUsuario.Password);
                cmd.Parameters.AddWithValue("p_email", nuevoUsuario.Email);
                cmd.Parameters.AddWithValue("p_avatar", null);
                cmd.Parameters.AddWithValue("p_fecha_registro", nuevoUsuario.FechaRegistro);
                cmd.Parameters.AddWithValue("p_id_rol", ObtenerRolUsuario(nuevoUsuario.RolUsuario));

                cmd.ExecuteNonQuery();

                CargarUsuario();
            }
        }

        public static void ModificarUsuarioBD(DataGridView data)
        {
            string nombreUsuario = data.CurrentRow.Cells["NombreUsuario"].Value.ToString();

            if (nombreUsuario == usuarioActual.NombreUsuario)
            {
                MessageBox.Show("No puedes modificar tu propio rol mientras estás logueado.", "Modificación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (MySqlCommand cmd = new MySqlCommand("sp_modificar_rol_usuario", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre_usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("p_id_rol", data.Tag.ToString());

                cmd.ExecuteNonQuery();
            }
        }
        private static string ObtenerRolUsuario(string rol)
        {
            switch (rol)
            {
                case "Admin":
                    return "1";
                case "Usuario":
                    return "2";
                default:
                    return "2";
            }
        }
        public static void CargarUsuario()
        {
            usuariosRegistrados.Clear();

            using (MySqlCommand cmd = new MySqlCommand("sp_listar_usuarios", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario u = new Usuario()
                        {
                            Id = reader.GetInt32("id_usuario"),
                            NombreUsuario = reader.GetString("nombre_usuario"),
                            Password = reader.GetString("password_usuario"),
                            Email = reader.GetString("email_usuario"),
                            RolUsuario = reader.GetString("nombre_rol"),
                            FechaRegistro = reader.GetDateTime("fecha_registro"),
                            Avatar = reader.IsDBNull(reader.GetOrdinal("avatar")) ? null : reader.GetString("avatar"),
                        };

                        usuariosRegistrados.Add(u);
                    }
                }
            }
        }

        public static void CambiarAvatar(int idUsuario, string URL, PictureBox pnl)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_actualizar_avatar_usuario", UtilsBD.Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);
                    cmd.Parameters.AddWithValue("p_url", URL);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Imagen actualizada con éxito", "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    AdministradorUsuarios.usuarioActual.Avatar = URL;
                    pnl.Image = Utils.DescargarImagenDesdeURL(URL);
                    pnl.Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la imagen: " + ex.Message);
            }
        }

    }
}
