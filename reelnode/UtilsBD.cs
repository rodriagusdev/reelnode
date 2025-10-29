using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Reelnode
{
    public static class UtilsBD
    {
        public static ConexionBD Conexion = new ConexionBD();

        public static List<Network> CargarNetworks()
        {
            List<Network> networks = new List<Network>();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_listar_network", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Network net = new Network(reader.GetInt32("id_network"), reader.GetString("nombre"));
                            networks.Add(net);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return networks;

        }
        public static List<Genero> CargarGeneros()
        {
            List<Genero> generos = new List<Genero>();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_listar_generos", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Genero gen = new Genero(reader.GetInt32("id_genero"), reader.GetString("nombre"));
                            generos.Add(gen);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return generos;
        }

        public static int ObtenerNetworkId(string nombreNet)
        {
            foreach (Network net in UtilsBD.CargarNetworks())
            {
                if (net.Nombre == nombreNet) return net.Id;
            }

            return 1;
        }

        public static string ObtenerNombresGeneros(List<int> generosId)
        {
            string nombresGeneros = "";

            foreach (var id in generosId)
            {
                var genero = CargarGeneros().FirstOrDefault(g => g.Id == id);

                if (genero != null)
                {
                    if (nombresGeneros != "")
                        nombresGeneros += ", ";

                    nombresGeneros += genero.Nombre;
                }
            }

            return nombresGeneros;
        }

        public static List<int> ObtenerIdGeneros(CheckedListBox generos)
        {
            List<int> generosSeleccionados = new List<int>();

            foreach (var gen in generos.CheckedItems)
            {
                int obtenerId = CargarGeneros().First(g => g.Nombre == gen.ToString()).Id;

                generosSeleccionados.Add(obtenerId);
            }

            return generosSeleccionados;
        }
    }
}