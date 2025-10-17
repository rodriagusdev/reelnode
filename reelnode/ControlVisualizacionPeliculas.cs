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
        private ControlComentarios controlComentarios;
        private PanelGradiente PanelMain;
        public ControlVisualizacionPeliculas()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Tag = "Default";
       
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(controlComentarios = new ControlComentarios());
            PanelVisualizarPeli.Controls.Add(PanelMain);
            controlComentarios.Visible = false;
            this.Controls.Add(PanelMain);
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            PanelMain.Color1 = color1;
            PanelMain.Color2 = color2;
            PanelMain.GradientMode = modo;
            PanelMain.Invalidate();
        }

        public PanelGradiente MainPanel
        {
            get { return PanelMain; }
        }


        private void BtnCalificar_Click(object sender, EventArgs e)
        {
            FormCalificar calificar = new FormCalificar();

            calificar.ShowDialog();
        }

        private void BtnComentar_Click(object sender, EventArgs e)
        {
            controlComentarios.CargarComentarios();
            Utils.ShowControl(controlComentarios, PanelMain);
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

            Utils.ShowControl(PanelVisualizarPeli, PanelMain);
        }


        private void ControlVisualizacionPeliculas_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
