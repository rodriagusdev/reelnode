using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionPeliculasCargar : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        public ControlGestionPeliculasCargar()
        {
            InitializeComponent();

            BtnCargar.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);
            BtnSalir.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);
            BtnPrevisualizar.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);

            foreach (Panel pnl in PanelPeliculaCreacion.Controls.OfType<Panel>()) { 
                pnl.BackColor = Color.FromArgb(42, 47, 79);

                foreach (TextBox txt in pnl.Controls.OfType<TextBox>())
                {
                    txt.BackColor = Color.FromArgb(42, 47, 79);
                    txt.ForeColor = Color.FromArgb(0, 255, 255);
                }
            }

            foreach (Label lbl in PanelPeliculaCreacion.Controls.OfType<Label>())
            {
                lbl.ForeColor = Color.FromArgb(255, 0, 127);
            }

            foreach (Button btn in PanelPeliculaCreacion.Controls.OfType<Button>())
            {
                btn.BackColor = Color.FromArgb(123, 44, 191);
                btn.ForeColor = Color.FromArgb(0, 255, 255);
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 183, 235);
            }

            PicPelicula.BackColor = Color.FromArgb(42, 47, 79);
        }
        private void PanelPeliculaCreacion_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelPeliculaCreacion.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelPeliculaCreacion.ClientRectangle);
            }
        }
        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelPeliculaCreacion.Invalidate();
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
            Utils.CargarImagenDesdeURL(PicPelicula, TxtURLImagen.Text);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            Pelicula nuevaPelicula = new Pelicula
            {
                Nombre = TxtNombre.Text,
                Director = TxtDirector.Text,
                Duracion = TxtDuracion.Text,
                FechaEstreno = DtpFechaEstreno.Value,
                Descripcion = TxtDescripcion.Text,
                Imagen = TxtURLImagen.Text
            };

            UtilsBD.InsertarPeliculaBD(nuevaPelicula);
        
        }
    }
}
