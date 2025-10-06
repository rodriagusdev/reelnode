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
        }

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
    }
}
