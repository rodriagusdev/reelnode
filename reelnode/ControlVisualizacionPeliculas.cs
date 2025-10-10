using iTextSharp.xmp.impl;
using Microsoft.Web.WebView2.WinForms;
using Org.BouncyCastle.Utilities.Encoders;
using ProjectoNuevo;
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

        private void BtnCalificar_Click(object sender, EventArgs e)
        {
            FormCalificar calificar = new FormCalificar();

            calificar.ShowDialog();
        }

        private void BtnComentar_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlComentarios, PanelVisualizarPeli);
        }

        public void CargarPelicula(Pelicula pelicula)
        {
            if (pelicula == null)
                return;

            PanelTrailerPeli.Controls.Clear();

            PicPeli.Image = Utils.DescargarImagenDesdeURL(pelicula.ImagenURL);
            LblDescripcionPeli.Text = pelicula.Descripcion;
            LblDirector.Text = pelicula.Director;
            LblDuracion.Text = pelicula.Duracion + "m";
            LblTitulo.Text = pelicula.Nombre;
            LblGeneros.Text = Utils.ObtenerNombresGeneros(pelicula.Generos);

            if (!string.IsNullOrEmpty(pelicula.TrailerURL))
            {
                string trailerURL = pelicula.TrailerURL;
                if (trailerURL.Contains("watch?v="))
                    trailerURL = trailerURL.Replace("watch?v=", "embed/");

                string URLDefault = $"{trailerURL}?rel=0&controls=1&autoplay=1";

                WebView2 trailer = new WebView2 { Dock = DockStyle.Fill };
                PanelTrailerPeli.Controls.Add(trailer);
                trailer.Source = new Uri(URLDefault);
            }
            else
            {
                PanelTrailerPeli.Visible = false;
            }
        }


        private void ControlVisualizacionPeliculas_Enter(object sender, EventArgs e)
        {

            PicPeli.Image = Utils.DescargarImagenDesdeURL(Utils.peliculaSeleccionada.ImagenURL);
            LblDescripcionPeli.Text = Utils.peliculaSeleccionada.Descripcion;
            LblDirector.Text = Utils.peliculaSeleccionada.Director;
            LblDuracion.Text = Utils.peliculaSeleccionada.Duracion + "m";
            LblTitulo.Text = Utils.peliculaSeleccionada.Nombre;
            string trailerURL = Utils.peliculaSeleccionada.TrailerURL;

            if (Utils.peliculaSeleccionada.TrailerURL != null)
            {
                WebView2 trailer = new WebView2
                {
                    Dock = DockStyle.Fill
                };

                PanelTrailerPeli.Controls.Add(trailer);

                // Quiero mostrar controles y no comentarios de youtube, asi que le asigno el siguiente formato.

                // Convertir formato "watch?v=" a "embed/" -> embed es necesario para embeber el video y aplicar los parametros
                // ?rel=0&controls=1&autoplay=1";

                if (trailerURL.Contains("watch?v="))
                {
                    trailerURL = trailerURL.Replace("watch?v=", "embed/");
                }

                string URLDefault = $"{trailerURL}?rel=0&controls=1&autoplay=1";

                trailer.Source = new Uri(URLDefault);

                PanelVisualizarPeli.Invalidate();
            }
            else
            {
                PanelTrailerPeli.Controls.Clear();
                PanelTrailerPeli.Visible = false;
            }

            

    }
    }
}
