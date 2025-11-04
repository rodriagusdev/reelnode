using MySql.Data.MySqlClient;
using System.Configuration;

namespace Reelnode
{
    public class ConexionBD
    {
        private MySqlConnection conexion;

        public ConexionBD()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionReelnode"].ConnectionString;
            conexion = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            if (conexion.State != System.Data.ConnectionState.Open)
                conexion.Open();
            return conexion;
        }

        public void AbrirBD()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        public void CerrarBD()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
