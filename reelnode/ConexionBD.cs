using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public class ConexionBD
    {
        private MySqlConnection conexion;

        public ConexionBD()
        {
            string connectionParams = "Server=localhost;Port=3306;Database=Reelnode;Uid=root;Password=;SslMode=none;";
            conexion = new MySqlConnection(connectionParams);
        }

        public MySqlConnection GetConnection()
        {
            return conexion;
        }

        public void AbrirBD() 
        {
            if(conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }   
        }

        public void CerrarBD() 
        {
            if(conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
