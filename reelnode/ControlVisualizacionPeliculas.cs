using System;
using System.Windows.Forms;
using WebView2 = Microsoft.Web.WebView2.WinForms.WebView2;

namespace Reelnode
{
    public partial class ControlVisualizacionPeliculas : UserControl
    {
        private ControlComentarios controlComentarios;
        private PanelGradiente PanelMain;
        public WebView2 trailer = new WebView2 { Dock = DockStyle.Fill };
        public ControlVisualizacionPeliculas()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            this.Controls.Add(PanelMain);

            PanelMain.Controls.Add(controlComentarios = new ControlComentarios());
            PanelMain.Controls.Add(PanelVisualizar);
            controlComentarios.Visible = false;
        }

        private void BtnCalificar_Click(object sender, EventArgs e)
        {
            FormCalificar calificar = new FormCalificar();

            calificar.ShowDialog();
        }

        private void BtnComentar_Click(object sender, EventArgs e)
        {
            controlComentarios.procedimiento = "sp_obtener_comentarios_pelis";
            controlComentarios.p_id = "p_id_pelicula";
            controlComentarios.idAudiovisual = AdministradorPeliculas.peliculaSeleccionada.Id;
            Utils.ShowControl(controlComentarios, PanelMain);
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

        public void CargarPelicula(Pelicula pelicula)
        {
            if (pelicula == null)
                return;

            PanelTrailerPeli.Controls.Clear();

            PicPeli.Image = Utils.DescargarImagenDesdeURL(pelicula.ImagenURL);
            LblDescripcionPeli.Text = pelicula.Descripcion;
            LblDirector.Text = pelicula.Director;
            LblDuracion.Text = Utils.ConvertirAHoras(pelicula.Duracion);
            LblTitulo.Text = pelicula.Nombre;
            LblGeneros.Text = UtilsBD.ObtenerNombresGeneros(pelicula.Generos);

            if (!string.IsNullOrEmpty(pelicula.TrailerURL))
            {
                string trailerURL = pelicula.TrailerURL;
                if (trailerURL.Contains("watch?v="))
                    trailerURL = trailerURL.Replace("watch?v=", "embed/");

                string URLDefault = $"{trailerURL}?rel=0&controls=1&autoplay=1";

                PanelTrailerPeli.Controls.Add(trailer);
                trailer.Source = new Uri(URLDefault);
            }
            else
            {
                PanelTrailerPeli.Visible = false;
            }

            Utils.ShowControl(PanelVisualizar, PanelMain);
        }
    }
}
