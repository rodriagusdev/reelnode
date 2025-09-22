using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public partial class ControlGestionPeliculasCargar : UserControl
    {
        public ControlGestionPeliculasCargar()
        {
            InitializeComponent();

            BtnCargarPelicula.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);
            BtnSalir.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);

            foreach (Panel pnl in PanelPeliculaCreacion.Controls.OfType<Panel>()) { 
                Utils.RedondearBordes(pnl, 20);
            }
        }

        private void BtnCargarPelicula_Click(object sender, EventArgs e)
        {
            Pelicula nuevaPelicula = new Pelicula
            {
                Nombre = TxtNombre.Text,
                Director = TxtDirector.Text,
                Duracion = TxtDuracion.Text,
                FechaEstreno = DtpFechaEstreno.Value,
                Descripcion = TxtDescripcion.Text,
                Imagen = PicPelicula.Image
            };

            UtilsBD.InsertarPeliculaBD(nuevaPelicula);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrevisualizar_Click(object sender, EventArgs e)
        {

            string url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSnCWNzOcPXS0uzGe6e3cMRX8NZB-HDMX8nFg&s";
            Image img;

            using (WebClient wc = new WebClient())  // Creamos el cliente web
            {
                byte[] bytes = wc.DownloadData(url);  // Descargamos los datos en bytes
                using (MemoryStream ms = new MemoryStream(bytes))  // Convertimos los bytes en un stream
                {
                    img = Image.FromStream(ms);  // Creamos la imagen en memoria
                }
            }

            PicPelicula.Image = img;

        }
    }
}
