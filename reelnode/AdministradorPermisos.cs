using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Reelnode
{
    public static class AdministradorPermisos
    {
        public static List<string> permisosUsuarioActual = new List<string>();

        public static void AsignarPermisos(int idUsuarioAsignacion, CheckedListBox ChkListPermisos)
        {
            int posUsuarioAsignacion = idUsuarioAsignacion - 1;

            // En la base de datos Superadmin = 1, admin = 2, usuario = 3. Entonces el mayor es el 1
            // Por eso, si el IdRol es mayor en numero, quiere decir que es de un nivel inferior.
            if (
                AdministradorUsuarios.usuarioActual.IdRol
                >= AdministradorUsuarios.usuariosRegistrados[posUsuarioAsignacion].IdRol
            )
            {
                MessageBox.Show(
                    "No se pueden realizar operaciones entre usuarios del mismo nivel o inferior.",
                    "Error al asignar permisos ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            try
            {
                bool borrarPermisos = false;

                /* !--- Primero intento borrar todos los permisos asignados al usuario ---! */
                try
                {
                    using (
                        MySqlCommand cmd = new MySqlCommand(
                            "sp_borrar_todos_permisos_usuario",
                            UtilsBD.Conexion.GetConnection()
                        )
                    )
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_id_usuario", idUsuarioAsignacion);

                        var obtenerRespuesta = new MySqlParameter("p_exito", MySqlDbType.Int32);
                        obtenerRespuesta.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(obtenerRespuesta);

                        cmd.ExecuteNonQuery();

                        int respuesta = Convert.ToInt32(obtenerRespuesta.Value);

                        borrarPermisos = respuesta == 1 ? true : false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error al asignar permisos ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                /* !--- Fin ---! */

                if (borrarPermisos)
                {
                    /* !--- Luego asigno los nuevos permisos ---! */

                    foreach (string permiso in ChkListPermisos.CheckedItems)
                    {
                        if (permisosUsuarioActual.Contains(permiso))
                        {
                            using (
                                MySqlCommand cmd = new MySqlCommand(
                                    "sp_asignar_permiso",
                                    UtilsBD.Conexion.GetConnection()
                                )
                            )
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("p_id_usuario", idUsuarioAsignacion);
                                cmd.Parameters.AddWithValue("p_tipo_permiso", permiso);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                $"Error al asignar '{permiso}': no se encuentra en tus permisos actuales.",
                                "Error de asignación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }

                    MessageBox.Show(
                        "Permisos asignados",
                        "Operación Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    /* !--- Fin ---! */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar permisos" + ex.Message);
            }
        }

        public static List<string> ObtenerPermisosUsuario(int idUsuario)
        {
            List<string> permisosUsuario = new List<string>();
            string procedure = "sp_obtener_permisos_usuario";

            using (MySqlCommand cmd = new MySqlCommand(procedure, UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string permiso = reader.GetString("tipo_permiso");

                        permisosUsuario.Add(permiso);
                    }
                }
            }

            return permisosUsuario;
        }

        public static void CargarPermisosActuales(int idUsuario)
        {
            permisosUsuarioActual = ObtenerPermisosUsuario(AdministradorUsuarios.usuarioActual.Id);
        }

        /* !--- OPERACIONES VISUALES ---! */

        public static void MostrarPermisosEnLista(CheckedListBox ChkList)
        {
            ChkList.Items.AddRange(Enum.GetNames(typeof(EnumPermisos)));
        }
    }
}
