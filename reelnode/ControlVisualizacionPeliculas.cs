using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.xmp.impl;

namespace ProjectoNuevo
{
    public partial class ControlVisualizacionPeliculas : UserControl
    {
        public ControlVisualizacionPeliculas()
        {
            InitializeComponent();
        }

        private void BtnBuscarPelicula_Click(object sender, EventArgs e)
        {
            string busqueda = TxtNombrePelicula.Text;

            if (!string.IsNullOrEmpty(busqueda)) 
            { 
                //Query para buscar en YouTube
                string query = busqueda.Replace("", "+") + "+trailer";

                //Url de resultados de YouTube
                string url = "https://www.youtube.com/results?search_query=" + query;

                //Esto es para que el trailer aparezca en el formulario
                WebBrowserPelicula.Navigate(url);
            }

            //Cargar Imagen de la Peli
           

        }
    }
}
