using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reelnode
{
    public static class AdministradorPermisos
    {
        public static List<string> permisosUsuarioActual = new List<string>();

        public static void mostrar()
        {
            foreach(string permiso in permisosUsuarioActual)
            {
                MessageBox.Show(permiso);
            }
        }
        public static void AsignarPermisos(int idUsuario, CheckedListBox ChkListPermisos)
        {  
            try
            { 
                /* !--- Primero borro todos los permisos asignados al usuario ---! */
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_borrar_todos_permisos_usuario", UtilsBD.Conexion.GetConnection()))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al asignar permisos" + ex.Message);
                }

                /* !--- Fin ---! */

                /* !--- Luego asigno los nuevos permisos ---! */
                foreach (string permiso in ChkListPermisos.CheckedItems)
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_asignar_permiso", UtilsBD.Conexion.GetConnection()))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);
                        cmd.Parameters.AddWithValue("p_tipo_permiso", permiso);

                        cmd.ExecuteNonQuery();
                    }
                }
             
                MessageBox.Show("Permisos asignados", "Operación Exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                /* !--- Fin ---! */
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

            if(permisosUsuario.Count > 0) return permisosUsuario;

            return null;
        }

        public static void CargarPermisosIniciales(int idUsuario)
        {
            permisosUsuarioActual = ObtenerPermisosUsuario(AdministradorUsuarios.usuarioActual.Id);
        }
    }
}
