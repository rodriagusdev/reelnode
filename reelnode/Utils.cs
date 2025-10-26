using Microsoft.Web.WebView2.WinForms;
using Mysqlx.Datatypes;
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
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace Reelnode
{
    public static class Utils
    {

        // Esta funcion me permite recuperar todos los controles hijos de un control padre.
        // La utilizo para obtener todos los controles hijos de FormMain y asi aplicar el tema a todos los controles.

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

        /* Para formatear la duracion de las peliculas */
        public static string ConvertirAHoras(int minutos)
        {
            int horas = minutos / 60;
            int mins = minutos % 60;
            return $"{horas:D2}h:{mins:D2}m";
        }

        // Metodo para actualizar las grillas de peliculas y series

        // params string [] me permite concatenar algunas string. En este caso la uso para ocultar columnas
        // Por ejemplo si la uso asi: ActualizarListaGrid(grid, list, "Fecha_Estreno, "Fecha_Fin", "Imagen")
        // La funcion va a ocultar las columnas que tengan ese nombre.
        public static void ActualizarListaGrid<T>(DataGridView grid, List<T> list, params string[] ocultarColumnas)
        {
            grid.DataSource = null;
            grid.AutoGenerateColumns = true;
            grid.DataSource = list;

            foreach (var col in ocultarColumnas)
            {
                // Aca las oculto
                if (grid.Columns.Contains(col)) grid.Columns[col].Visible = false;
            }
        }

        public static async Task<string> VerificarTrailer(Panel pnl, string trailerURL)
        {
            pnl.Controls.Clear();

            WebView2 trailer = new WebView2
            {
                Dock = DockStyle.Fill
            };

            pnl.Controls.Add(trailer);

            // Aca espero que el WebView2 este listo para cargar contenido web. Await = esperar
            await trailer.EnsureCoreWebView2Async(null);

            // Es una propiedad del WebView2 que indica si la navegacion fue exitosa o no
            trailer.NavigationCompleted += (trailerSender, trailerArgs) =>
            {
                WebView2 webView = trailerSender as WebView2;

                if (!trailerArgs.IsSuccess)
                {
                    MessageBox.Show($"Error al cargar el trailer: {trailerArgs.WebErrorStatus}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (webView != null)
                        webView.Source = null;
                }
            };

            // Con ExtraerVideo saco una URL validad para usarla en el trailer
            // De no funcionar devuelvo null;
            string videoId = ExtraerVideoId(trailerURL);

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

        public static void LimpiarCampos(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                switch (c)
                {
                    case TextBox txt:
                        txt.Clear();
                        break;
                    case ComboBox cbo:
                        cbo.SelectedIndex = -1;
                        break;
                    case CheckedListBox chk:
                        for (int i = 0; i < chk.Items.Count; i++)
                            chk.SetItemChecked(i, false);
                        break;
                    case PictureBox pic:
                        pic.Image = null;
                        break;                 
                    case DateTimePicker dtp:
                        dtp.Value = DateTime.Now;
                        break;
                }

                if(c is WebView2 w) w.Dispose();

                // Si hay subpaneles dentro de subpaneles
                if (c.HasChildren)
                    LimpiarCampos(c);
            }
        }
    }
}
