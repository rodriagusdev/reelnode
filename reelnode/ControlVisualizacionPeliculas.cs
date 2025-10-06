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
using ProjectoNuevo;

namespace Reelnode
{
    public partial class ControlVisualizacionPeliculas : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        private ControlComentarios controlComentarios;
        public ControlVisualizacionPeliculas()
        {
            InitializeComponent();
            PanelVisualizarPeli.Controls.Add(controlComentarios = new ControlComentarios());
            controlComentarios.Visible = false;
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
                PicPeli.Image = Utils.DescargarImagenDesdeURL(Utils.peliculaSeleccionada.ImagenURL);
                LblDescripcionPeli.Text = Utils.peliculaSeleccionada.Descripcion;
                LblDirector.Text = Utils.peliculaSeleccionada.Director;
                LblDuracion.Text = Utils.peliculaSeleccionada.Duracion + "m";
                LblTitulo.Text = Utils.peliculaSeleccionada.Nombre;

                if(Utils.peliculaSeleccionada.TrailerURL != null)
                {
                    WebView2 trailer = new WebView2
                    {
                        Dock = DockStyle.Fill
                    };

                    PanelTrailerPeli.Controls.Add(trailer);

                    // Este proceso es necesario porque queremos que el trailer se reproduzca automáticamente al cargar el control y ademas
                    // que no muestre videos relacionados al finalizar la reproducción ni comentarios.

                    string videoId = Utils.ExtraerVideoId(Utils.peliculaSeleccionada.TrailerURL);
                    string embedUrl = $"https://www.youtube.com/embed/{videoId}?rel=0&controls=1&autoplay=1";

                    trailer.Source = new Uri(embedUrl);

                    PanelVisualizarPeli.Invalidate();
                }
                else 
                {
                    PanelTrailerPeli.Controls.Clear();
                    PanelTrailerPeli.Visible = false;
                }
                    
            }
        }

        private void BtnCalificar_Click(object sender, EventArgs e)
        {
            FormCalificar calificar = new FormCalificar();

            calificar.ShowDialog();
        }

        private void BtnComentar_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlComentarios, PanelVisualizarPeli);
        }
    }
}
