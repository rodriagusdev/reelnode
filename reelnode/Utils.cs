using Microsoft.Web.WebView2.WinForms;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public static class Utils
    {
        public static Pelicula peliculaSeleccionada = new Pelicula();
        public static Serie serieSeleccionada = new Serie();

        // Esta es la funcion default para decidir que control mostrar en un panel
        public static void ShowControl(Control controlToShow, Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                control.Visible = false;
            }
            controlToShow.Visible = true;
            controlToShow.Dock = DockStyle.Fill;
            panel.Invalidate();
        }

        // Utilidad para cargar una imagen desde una URL recuperada desde una base de datos en un PictureBox
        public static void CargarImagenDesdeURL(PictureBox pictureBox, string url)
        {
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(url);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Utilidad para descargar una imagen de la WEB y devolverla como Image
        public static Image DescargarImagenDesdeURL(string url)
        {
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    byte[] bytes = webClient.DownloadData(url);
                    using (var ms = new MemoryStream(bytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static int ObtenerIdMedia() 
        {
            if(peliculaSeleccionada != null) return peliculaSeleccionada.Id;

            return serieSeleccionada.Id;
        }

        // Utilidad para extraer el ID del video de una URL de YouTube
        public static string ExtraerVideoId(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                string videoId = string.Empty;

                // Maneja URLs de YouTube en diferentes formatos
                if (uri.Host.Contains("youtube.com") || uri.Host.Contains("youtu.be"))
                {
                    if (uri.Host.Contains("youtube.com"))
                    {
                        if (uri.Query.Contains("v="))
                        {
                            var query = uri.Query.TrimStart('?').Split('&');
                            foreach (var param in query)
                            {
                                if (param.StartsWith("v="))
                                {
                                    videoId = param.Substring(2); // Extrae el valor después de "v="
                                    break;
                                }
                            }
                        }
                    }
                    else if (uri.Host.Contains("youtu.be"))
                    {
                        videoId = uri.Segments.Last(); // El ID está en el último segmento
                    }
                }
                return videoId;
            }
            catch
            {
                return string.Empty; // Maneja URLs no válidas
            }
        }

        // Metodo para actualizar las grillas de peliculas y series
        public static void ActualizarListaGrid<T>(DataGridView grid, List<T> list, params string[] ocultarColumnas) 
        {
            grid.DataSource = null;
            grid.AutoGenerateColumns = true;
            grid.DataSource = list;

            foreach(var col in ocultarColumnas) 
            {
                if (grid.Columns.Contains(col)) grid.Columns[col].Visible = false;
            }
        }

        public static void TemaControles(Panel PanelMain, PictureBox pic = null) 
        {
            foreach (Panel pnl in PanelMain.Controls.OfType<Panel>())
            {
                pnl.BackColor = Color.FromArgb(42, 47, 79);

                foreach (TextBox txt in pnl.Controls.OfType<TextBox>())
                {
                    txt.BackColor = Color.FromArgb(42, 47, 79);
                    txt.ForeColor = Color.FromArgb(0, 255, 255);
                }
            }

            foreach (Label lbl in PanelMain.Controls.OfType<Label>())
            {
                lbl.ForeColor = Color.FromArgb(255, 0, 127);
            }

            foreach (Button btn in PanelMain.Controls.OfType<Button>())
            {
                btn.BackColor = Color.FromArgb(123, 44, 191);
                btn.ForeColor = Color.FromArgb(0, 255, 255);
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 183, 235);
            }

            if(pic != null) pic.BackColor = Color.FromArgb(42, 47, 79);

        }

        public static async Task<string> VerificarTrailer(Panel pnl, string trailerURL) 
        {
            pnl.Controls.Clear();

            WebView2 trailer = new WebView2
            {
                Dock = DockStyle.Fill
            };
            pnl.Controls.Add(trailer);

            // Aca espero que el WebView2 este listo para cargar contenido web. Await = esperando
            await trailer.EnsureCoreWebView2Async(null);

            trailer.NavigationCompleted += (trailerSender, trailerArgs) =>
            {
                WebView2 webView = trailerSender as WebView2;
                // Es una propiedad del WebView2 que indica si la navegacion fue exitosa o no

                if (!trailerArgs.IsSuccess)
                {
                    MessageBox.Show($"Error al cargar el trailer: {trailerArgs.WebErrorStatus}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (webView != null)
                        webView.Source = null;
                }
            };

            // Con ExtraerVideo saco una URL validad para usarla en el trailer
            // De no funcionar devuelvo null;
            string videoId = Utils.ExtraerVideoId(trailerURL);

            if (string.IsNullOrEmpty(videoId))
            {
                MessageBox.Show("No se pudo extraer el ID del video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            //?rel=0&controls=1&autoplay=1 ->
            //rel=0 evita videos relacionados al finalizar, controls=1 muestra controles, autoplay=1 reproduce automaticamente
            //Separar con "?"

            string embedUrl = $"https://www.youtube.com/embed/{videoId}?rel=0&controls=1&autoplay=1";
            trailer.Source = new Uri(embedUrl);

            pnl.Invalidate();
            return embedUrl;
        }

        public static int ObtenerNetworkId(string nombreNet) 
        {
            foreach (Network net in UtilsBD.networksCargadas)
            {
                if (net.Nombre == nombreNet) return net.Id;
            }

            return 1;
        }

        public static void CargarNetwork(ComboBox cbo)
        {
            foreach (Network net in UtilsBD.networksCargadas)
            {
                cbo.Items.Add(net.Nombre);
            }
            cbo.SelectedIndex = 0;
        }

        public static void CargarGeneros(CheckedListBox chk)
        {
            foreach (Genero gen in UtilsBD.generosCargados)
            {
                chk.Items.Add(gen.Nombre);
            }
        }

        public static string ObtenerNombresGeneros(List<int> generosId)
        {
            string nombresGeneros = "";
            
            foreach (var id in generosId)
            {
                var genero = UtilsBD.generosCargados.FirstOrDefault(g => g.Id == id);

                if (genero != null)
                {
                    if (nombresGeneros != "")
                        nombresGeneros += ", ";

                    nombresGeneros += genero.Nombre;
                }
            }

            return nombresGeneros;
        }

        public static List<int> ObtenerIdGeneros(CheckedListBox generos) 
        {
            List<int> generosSeleccionados = new List<int>();

            foreach (var gen in generos.CheckedItems)
            { 
                int obtenerId = UtilsBD.generosCargados.First(g => g.Nombre == gen.ToString()).Id;

                generosSeleccionados.Add(obtenerId);
            }

            return generosSeleccionados;
        }
        public static void RellenarFlowPanel<T>(FlowLayoutPanel flowPnl, List<T> list, Action<int> abrirPestana) where T : Media
        {
            flowPnl.Controls.Clear();

            foreach (var media in list)
            {
                // Por cada media (pelicula o serie) creo una tarjeta (Panel) con su poster y titulo
                Panel TarjetaMedia = new Panel
                {
                    Size = new Size(210, 240),
                    Margin = new Padding(10),
                    BackColor = Color.FromArgb(30, 30, 30),
                    Padding = new Padding(5)
                };

                PictureBox poster = new PictureBox
                {
                    Size = new Size(200, 200),
                    Location = new Point(5, 5),
                    Image = Utils.DescargarImagenDesdeURL(media.ImagenURL),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand
                };

                // Evento click para abrir la pestana de detalles
                poster.Click += (s, e) => abrirPestana(media.Id);

                Label titleLabel = new Label
                {
                    Text = media.Nombre,
                    Font = new Font("Courier New", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    Location = new Point((TarjetaMedia.Width - 200) / 2, 210),
                    Size = new Size(200, 20),
                    BackColor = Color.Transparent
                };


                // Los agrego al panel, el cual agrego al FlowLayoutPanel de la interfaz
                TarjetaMedia.Controls.Add(poster);
                TarjetaMedia.Controls.Add(titleLabel);

                flowPnl.Controls.Add(TarjetaMedia);
            }
        }
    }
}
