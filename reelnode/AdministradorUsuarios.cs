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
    public static class AdministradorUsuarios
    {
        public static Usuario usuarioActual = new Usuario();
        public static List<Usuario> usuariosRegistrados = new List<Usuario>();
        public static List<AudiovisualMiniatura> pelisVistas = new List<AudiovisualMiniatura>();

        /* !--- OPERACIONES CRUD USUARIO ---! */
        public static bool RegistrarUsuarioBD(Usuario nuevoUsuario)
        {
            try
            {
                using (
                    MySqlCommand cmd = new MySqlCommand(
                        "sp_insertar_usuario",
                        UtilsBD.Conexion.GetConnection()
                    )
                )
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_nombre", nuevoUsuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("p_password", nuevoUsuario.Password);
                    cmd.Parameters.AddWithValue(
                     "p_id_rol",
                    ObtenerRolUsuario(nuevoUsuario.RolUsuario)
                    );
                    cmd.Parameters.AddWithValue("p_email", nuevoUsuario.Email);
  

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Usuario registrado con éxito",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    CargarUsuarios();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error registración",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return false;
        }

        public static bool EliminarUsuario(int idUsuario)
        {
            if (
                AdministradorPermisos.permisosUsuarioActual.Contains(
                    EnumPermisos.eliminar_usuario.ToString()
                ) == false
            )
            {
                MessageBox.Show(
                    "No tienes los permisos necesarios para realizar esta operación",
                    "Error eliminación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }

            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_eliminar_usuario",
                    UtilsBD.Conexion.GetConnection()
                )
            )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "¿El usuario seleccionado se ha eliminado!",
                    "Eliminación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return true;
            }
        }

        public static bool ModificarRolUsuario(DataGridView data)
        {
            if (
                AdministradorPermisos.permisosUsuarioActual.Contains(
                    EnumPermisos.administrar_roles.ToString()
                ) == false
            )
            {
                MessageBox.Show(
                    "No tienes permisos para realizar esta operación",
                    "Error de permisos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }

            string nombreUsuario = data.CurrentRow.Cells["NombreUsuario"].Value.ToString();

            if (nombreUsuario == usuarioActual.NombreUsuario)
            {
                MessageBox.Show(
                    "No puedes modificar tu propio rol mientras estás logueado.",
                    "Modificación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            Usuario usuarioModificado = usuariosRegistrados.FirstOrDefault(u =>
                u.NombreUsuario == nombreUsuario
            );

            // En la base de datos Superadmin = 1, admin = 2, usuario = 3. Entonces el mayor es el 1
            // Por eso, si el IdRol es mayor en numero, quiere decir que es de un nivel inferior.
            if (usuarioActual.IdRol >= usuarioModificado.IdRol)
            {
                MessageBox.Show(
                    "No se pueden realizar operaciones entre usuarios del mismo nivel o inferior.",
                    "Error al asignar permisos ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }

            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_modificar_rol_usuario",
                    UtilsBD.Conexion.GetConnection()
                )
            )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre_usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("p_id_rol", data.Tag.ToString());

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "¿El usuario seleccionado se ha modificado!",
                    "Modificación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return true;
            }
        }

        public static bool CambiarPasswordUsuario(
            string nombreUsuario,
            string email,
            string nuevaPassword
        )
        {
            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_actualizar_password",
                    UtilsBD.Conexion.GetConnection()
                )
            )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre_usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("p_email", email);
                cmd.Parameters.AddWithValue("p_nueva_password", nuevaPassword);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public static void CargarUsuarios()
        {
            usuariosRegistrados.Clear();

            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_listar_usuarios",
                    UtilsBD.Conexion.GetConnection()
                )
            )
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
                            Avatar = reader.IsDBNull(reader.GetOrdinal("avatar"))
                                ? null
                                : reader.GetString("avatar"),
                            IdRol = reader.GetInt32("id_rol"),
                        };

                        usuariosRegistrados.Add(u);
                    }
                }
            }
        }

        public static void CambiarAvatarUsuario(int idUsuario, string URL, PictureBox pnl)
        {
            try
            {
                using (
                    MySqlCommand cmd = new MySqlCommand(
                        "sp_actualizar_avatar_usuario",
                        UtilsBD.Conexion.GetConnection()
                    )
                )
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);
                    cmd.Parameters.AddWithValue("p_url", URL);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Imagen actualizada con éxito",
                        "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

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

        /* !--- FIN OPERACIONES CRUD ---! */

        /* !--- DATOS PARA METRICAS ---! */
        public static MetricaUsuario CargarUltimoUsuarioRegistrado()
        {
            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_obtener_ultimo_usuario_registrado",
                    UtilsBD.Conexion.GetConnection()
                )
            )
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MetricaUsuario ultimoRegistrado = new MetricaUsuario(
                            reader.GetString("nombre_usuario"),
                            reader.GetDateTime("fecha_registro").ToString("dd/MM/yyyy"),
                            reader.GetString("avatar")
                        );

                        return ultimoRegistrado;
                    }
                }
            }

            return null;
        } // ToString("dd/MM/yyyy")

        public static int CargarUsuariosRegistradosUltimoMes()
        {
            int usuariosUltimoMes = 0;

            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_obtener_cantidad_usuarios_registrados_ultimo_mes",
                    UtilsBD.Conexion.GetConnection()
                )
            )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuariosUltimoMes = reader.GetInt32("usuarios_registrados");
                    }
                }
            }

            return usuariosUltimoMes;
        }

        public static int CargarUsuariosRegistrados()
        {
            int cantidadUsuarios = 0;

            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_obtener_cantidad_usuarios",
                    UtilsBD.Conexion.GetConnection()
                )
            )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cantidadUsuarios = reader.GetInt32("usuarios_registrados");
                    }
                }
            }

            return cantidadUsuarios;
        }

        public static MetricaUsuario CargarUsuarioMasCalificador()
        {
            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_usuario_mas_calificador",
                    UtilsBD.Conexion.GetConnection()
                )
            )
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MetricaUsuario masCalificador = new MetricaUsuario(
                            reader.GetString("nombre_usuario"),
                            reader.GetInt32("total_calificaciones")
                        );

                        return masCalificador;
                    }
                }
            }

            return null;
        }

        public static MetricaUsuario CargarUsuarioMasComentador()
        {
            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_usuario_mas_comentador",
                    UtilsBD.Conexion.GetConnection()
                )
            )
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MetricaUsuario masComentador = new MetricaUsuario(
                            reader.GetString("nombre_usuario"),
                            reader.GetInt32("total_comentarios")
                        );

                        return masComentador;
                    }
                }
            }

            return null;
        }

        public static Dictionary<string, int> CargarUsuariosMasActivos(int limit)
        {
            Dictionary<string, int> usuariosMasActivos = new Dictionary<string, int>();

            using (
                MySqlCommand cmd = new MySqlCommand(
                    "sp_ranking_usuarios",
                    UtilsBD.Conexion.GetConnection()
                )
            )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_limit", limit);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuariosMasActivos[reader.GetString("nombre_usuario")] = reader.GetInt32(
                            "total_visualizaciones"
                        );
                    }
                }
            }

            return usuariosMasActivos.Count > 0 ? usuariosMasActivos : null;
        }

        /* !--- FIN DATOS PARA METRICAS ---! */

        public static int ObtenerRolUsuario(string rol)
        {
            switch (rol.ToLower())
            {
                case "superadmin":
                    return 1;
                case "admin":
                    return 2;
                case "usuario":
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
