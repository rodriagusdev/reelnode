using Microsoft.Web.WebView2.WinForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlVisualizacionSerie : UserControl
    {
        private PanelGradiente PanelMain;
        private ControlComentarios controlComentarios;
        public WebView2 trailer = new WebView2 { Dock = DockStyle.Fill };
        public ControlVisualizacionSerie()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;

            this.Controls.Add(PanelMain);

            PanelMain.Controls.Add(controlComentarios = new ControlComentarios());
            PanelMain.Controls.Add(PanelVisualizar);
            controlComentarios.Visible = false;
        }

        public void CargarSerie(Serie serie)
        {
            if (serie == null)
                return;

            PanelTrailerSerie.Controls.Clear();

            PicSerie.Image = Utils.DescargarImagenDesdeURL(serie.ImagenURL);
            LblDescripcionPeli.Text = serie.Descripcion;
            LblDirector.Text = serie.Director;
            LblTemporadas.Text = serie.Temporadas + " temporadas";
            LblTitulo.Text = serie.Nombre;
            LblGeneros.Text = Utils.ObtenerNombresGeneros(serie.Generos);

            if (!string.IsNullOrEmpty(serie.TrailerURL))
            {
                string trailerURL = serie.TrailerURL;
                if (trailerURL.Contains("watch?v="))
                    trailerURL = trailerURL.Replace("watch?v=", "embed/");

                string URLDefault = $"{trailerURL}?rel=0&controls=1&autoplay=1";

                trailer = new WebView2 { Dock = DockStyle.Fill };
                PanelTrailerSerie.Controls.Add(trailer);
                trailer.Source = new Uri(URLDefault);
            }
            else
            {
                PanelTrailerSerie.Visible = false;
            }
        }

        public void DetenerTrailer()
        {
            try
            {
                if (trailer.CoreWebView2 != null)
                    trailer.CoreWebView2.Navigate("about:blank");
            }
            catch { }
        }

        private void BtnCalificar_Click(object sender, EventArgs e)
        {
            FormCalificar calificar = new FormCalificar();

            calificar.ShowDialog();
        }

        private void BtnComentar_Click(object sender, EventArgs e)
        {
            controlComentarios.CargarComentarios();
            Utils.ShowControl(controlComentarios, PanelVisualizar);
        }
    }
}
