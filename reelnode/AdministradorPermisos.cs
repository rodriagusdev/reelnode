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
    public static class AdministradorPermisos
    {
        public static void AsignarPermisos(int idUsuario, CheckedListBox ChkListPermisos)
        {
            string procedure = "sp_asignar_permiso";
  
            try
            {
                foreach (string permiso in ChkListPermisos.CheckedItems)
                {
                    using (MySqlCommand cmd = new MySqlCommand(procedure, UtilsBD.Conexion.GetConnection()))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar permisos" + ex.Message);
            }
        }
    }
}
