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
    public static class AdministradorReportesAvanzados
    {
        public static void ObtenerReporteAvanzadoPeliculas(
            string nombre,
            string genero,
            string director,
            string network,
            DateTime fechaDesde,
            DateTime fechaHasta,
            DataGridView dataGridReportes)
        {
            UtilsBD.Conexion.AbrirBD();
            MySqlConnection conn = UtilsBD.Conexion.GetConnection();

            using (MySqlCommand cmd = new MySqlCommand("sp_reporte_avanzado_peliculas", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_nombre", string.IsNullOrEmpty(nombre) ? (object)DBNull.Value : nombre);
                cmd.Parameters.AddWithValue("p_genero_nombre", string.IsNullOrEmpty(genero) ? (object)DBNull.Value : genero);
                cmd.Parameters.AddWithValue("p_director", string.IsNullOrEmpty(director) ? (object)DBNull.Value : director);
                cmd.Parameters.AddWithValue("p_network_nombre", string.IsNullOrEmpty(network) ? (object)DBNull.Value : network);


                if (fechaDesde <= fechaHasta)
                {
                    cmd.Parameters.AddWithValue("p_fecha_desde", fechaDesde.Date);
                    cmd.Parameters.AddWithValue("p_fecha_hasta", fechaHasta.Date);
                }
                else
                {
                    cmd.Parameters.AddWithValue("p_fecha_desde", (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("p_fecha_hasta", (object)DBNull.Value);
                }

                // MySqlDataAdapter es una herramienta llenar DataTables.
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    // Ahora relleno el DataGridView que pase por parametro con dataTable.
                    dataGridReportes.DataSource = dataTable;
                }
                
            }
        }

        public static void ObtenerReporteAvanzadoSeries(
           string nombre,
           string genero,
           string director,
           string network,
           DateTime fechaDesde,
           DateTime fechaHasta,
           DataGridView dataGridReportes)
        {
            UtilsBD.Conexion.AbrirBD();
            MySqlConnection conn = UtilsBD.Conexion.GetConnection();

            using (MySqlCommand cmd = new MySqlCommand("sp_reporte_avanzado_series", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_nombre", string.IsNullOrEmpty(nombre) ? (object)DBNull.Value : nombre);
                cmd.Parameters.AddWithValue("p_genero_nombre", string.IsNullOrEmpty(genero) ? (object)DBNull.Value : genero);
                cmd.Parameters.AddWithValue("p_director", string.IsNullOrEmpty(director) ? (object)DBNull.Value : director);
                cmd.Parameters.AddWithValue("p_network_nombre", string.IsNullOrEmpty(network) ? (object)DBNull.Value : network);


                if (fechaDesde <= fechaHasta)
                {
                    cmd.Parameters.AddWithValue("p_fecha_desde", fechaDesde.Date);
                    cmd.Parameters.AddWithValue("p_fecha_hasta", fechaHasta.Date);
                }
                else
                {
                    cmd.Parameters.AddWithValue("p_fecha_desde", (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("p_fecha_hasta", (object)DBNull.Value);
                }

                // MySqlDataAdapter es una herramienta llenar DataTables.
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    // Ahora relleno el DataGridView que pase por parametro con dataTable.
                    dataGridReportes.DataSource = dataTable;
                }

            }
        }
    }
}
