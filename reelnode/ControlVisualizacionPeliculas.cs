using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.xmp.impl;
using Microsoft.Web.WebView2.WinForms;

namespace Reelnode
{
    public partial class ControlVisualizacionPeliculas : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        public ControlVisualizacionPeliculas()
        {
            InitializeComponent();
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelVisualizarPeli.Invalidate();
        }


        private void PanelVisualizarPeli_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelVisualizarPeli.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelVisualizarPeli.ClientRectangle);
            }
        }

        private void ControlVisualizacionPeliculas_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) {
                PicPeli.Image = Utils.DescargarImagenDesdeURL(Utils.peliculaSeleccionada.Imagen);
                LblDescripcionPeli.Text = Utils.peliculaSeleccionada.Descripcion;
                LblDirector.Text = Utils.peliculaSeleccionada.Director;
                LblDuracion.Text = Utils.peliculaSeleccionada.Duracion + "m";
                LblTitulo.Text = Utils.peliculaSeleccionada.Nombre;

                WebView2 trailer = new WebView2
                {
                    Dock = DockStyle.Fill
                };
                PanelTrailerPeli.Controls.Add(trailer);
                trailer.Source = new Uri("https://www.youtube.com/watch?v=EXeTwQWrcwY"); 
                PanelVisualizarPeli.Invalidate();
            }
        }

        private void LblDescripcionPeli_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
