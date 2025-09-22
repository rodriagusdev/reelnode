using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
