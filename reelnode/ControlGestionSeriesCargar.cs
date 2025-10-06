using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionSeriesCargar : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        private bool trailerCargadoExitosamente = false;
        public ControlGestionSeriesCargar()
        {
            InitializeComponent();

            BtnCargar.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);
            BtnPrevisualizar.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);

            Utils.TemaControles(PanelMain, PicSerie);
        }



        private void PanelMain_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelMain.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelMain.ClientRectangle);
            }
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelMain.Invalidate();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            if (PicSerie.Image != null && trailerCargadoExitosamente == true) { 
                Serie nuevaSerie = new Serie
                {
                    Nombre = TxtNombre.Text,
                    Director = TxtDirector.Text,
                    FechaEstreno = DtpFechaEstreno.Value,
                    FechaFin = DtpFechaFin.Value,
                    Descripcion = TxtDescripcion.Text,
                    ImagenURL = TxtURLImagen.Text,
                    TrailerURL = TxtURLTrailer.Text
                };

                UtilsBD.InsertarSerieBD(nuevaSerie);
            }
            else
            {
                MessageBox.Show("Imagen o trailer invalida.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnPrevisualizar_Click(object sender, EventArgs e)
        {
            Utils.CargarImagenDesdeURL(PicSerie, TxtURLImagen.Text);
        }

        // Uso una funcion asincrona (async) porque la URL del trailer necesita hacer una peticion a la internet que toma un tiempo
        // y no quiero que la interfaz de usuario se congele mientras espera la respuesta. Ademas, no quiero que la funcion avance
        // hasta que la peticion se complete, por eso uso 'await'.
        private async void BtnPrevisualizarTrailer_Click(object sender, EventArgs e)
        {
            PanelTrailerSerie.Controls.Clear();
            trailerCargadoExitosamente = false;

            WebView2 trailer = new WebView2
            {
                Dock = DockStyle.Fill
            };
            PanelTrailerSerie.Controls.Add(trailer);

            // Aca espero que el WebView2 este listo para cargar contenido web. Await = esperando
            await trailer.EnsureCoreWebView2Async(null);

            trailer.NavigationCompleted += (trailerSender, trailerArgs) =>
            {
                WebView2 webView = trailerSender as WebView2;
                // Es una propiedad del WebView2 que indica si la navegacion fue exitosa o no
                // Si fue exitosa, la variable trailerCargadoExitosamente se pone en true y el usuario podra cargar la serie
                trailerCargadoExitosamente = trailerArgs.IsSuccess;

                if (!trailerArgs.IsSuccess)
                {
                    MessageBox.Show($"Error al cargar el trailer: {trailerArgs.WebErrorStatus}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (webView != null)
                        webView.Source = null;
                }
            };



            string videoId = Utils.ExtraerVideoId(TxtURLTrailer.Text);

            if (string.IsNullOrEmpty(videoId))
            {
                MessageBox.Show("No se pudo extraer el ID del video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //?rel=0&controls=1&autoplay=1 ->
            //rel=0 evita videos relacionados al finalizar, controls=1 muestra controles, autoplay=1 reproduce automaticamente
            //Separar con "?"

            string embedUrl = $"https://www.youtube.com/embed/{videoId}?rel=0&controls=1&autoplay=1";
            trailer.Source = new Uri(embedUrl);

            PanelTrailerSerie.Invalidate();
        }

       

    }
}
