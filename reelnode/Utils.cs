using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // === 1. Limpiar y preparar ===
            grid.ColumnHeaderMouseClick -= Grid_ColumnHeaderMouseClick; // Evitar duplicados
            grid.DataSource = null;
            grid.AutoGenerateColumns = true;

            // === 2. Asignar lista ===
            grid.DataSource = list;

            // === 3. Ocultar columnas especificadas ===
            foreach (var col in ocultarColumnas)
            {
                if (grid.Columns.Contains(col))
                    grid.Columns[col].Visible = false;
            }

            // === 4. Guardar nombres de columnas ocultas en Tag (para restaurar) ===
            var columnasOcultas = ocultarColumnas
                .Where(c => grid.Columns.Contains(c))
                .Select(c => c)
                .ToList();

            // Guardar en Tag del grid (o usa una variable estática si prefieres)
            grid.Tag = columnasOcultas;

            // === 5. Suscribir evento (solo una vez) ===
            grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
        }

        private static void Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null) return;

            var columna = grid.Columns[e.ColumnIndex];
            if (columna == null || !columna.Visible) return;

            var listaOriginal = grid.DataSource as IList;
            if (listaOriginal == null || listaOriginal.Count == 0) return;

            var tipo = listaOriginal[0].GetType();
            var propiedad = tipo.GetProperty(columna.DataPropertyName);
            if (propiedad == null) return;

            // === Obtener columnas ocultas guardadas ===
            var columnasOcultas = grid.Tag as List<string> ?? new List<string>();

            // === Determinar dirección ===
            ListSortDirection direccion = ListSortDirection.Ascending;
            if (grid.SortedColumn?.Name == columna.Name && grid.SortOrder == SortOrder.Ascending)
            {
                direccion = ListSortDirection.Descending;
            }

            // === Ordenar ===
            var listaOrdenada = direccion == ListSortDirection.Ascending
                ? listaOriginal.Cast<object>()
                    .OrderBy(x => propiedad.GetValue(x) ?? "")
                    .ToList()
                : listaOriginal.Cast<object>()
                    .OrderByDescending(x => propiedad.GetValue(x) ?? "")
                    .ToList();

            // === Reasignar SIN perder estado ===
            grid.ColumnHeaderMouseClick -= Grid_ColumnHeaderMouseClick; // Evitar bucle
            grid.DataSource = null;
            grid.DataSource = listaOrdenada;

            // === Restaurar columnas ocultas ===
            foreach (var col in columnasOcultas)
            {
                if (grid.Columns.Contains(col))
                    grid.Columns[col].Visible = false;
            }

            // === Mostrar flecha de orden ===
            foreach (DataGridViewColumn col in grid.Columns)
                col.HeaderCell.SortGlyphDirection = SortOrder.None;

            grid.Columns[columna.Name].HeaderCell.SortGlyphDirection =
                direccion == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

            // === Volver a suscribir ===
            grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
        }

        public static async Task<string> VerificarTrailer(Panel pnl, string trailerURL)
        {
            pnl.Controls.Clear();

            Label lblCargando = new Label
            {
                Text = "Cargando trailer...",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Courier New", 12, FontStyle.Italic),
                ForeColor = Color.Gray
            };
            pnl.Controls.Add(lblCargando);
            pnl.Refresh();

            try
            {
                string videoId = ExtraerVideoId(trailerURL);
                if (string.IsNullOrEmpty(videoId))
                {
                    MessageBox.Show("No se pudo extraer el ID del video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pnl.Controls.Clear();
                    return null;
                }

                string embedUrl = $"https://www.youtube-nocookie.com/embed/{videoId}?rel=0&controls=1&autoplay=1";

                WebView2 trailer = new WebView2 { Dock = DockStyle.Fill };
                var env = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Application.StartupPath, "WebView2Cache"));
                await trailer.EnsureCoreWebView2Async(env);

                bool loaded = false;

                trailer.NavigationCompleted += (sender, args) =>
                {
                    if (args.IsSuccess)
                    {
                        loaded = true;
                        pnl.Controls.Clear();
                        pnl.Controls.Add(trailer);
                    }
                };

                trailer.Source = new Uri(embedUrl);

                // 🔸 Esperar hasta 5 segundos a que cargue
                int waitMs = 0;
                while (!loaded && waitMs < 5000)
                {
                    await Task.Delay(100);
                    waitMs += 100;
                }

                // 🔹 Si no cargó (YouTube bloqueado), abrir navegador externo
                if (!loaded)
                {
                    MessageBox.Show("YouTube bloqueó la reproducción del video embebido. Se abrirá en tu navegador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = trailerURL,
                        UseShellExecute = true
                    });
                    pnl.Controls.Clear();
                }

                return embedUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el trailer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnl.Controls.Clear();
                return null;
            }
        }

        public static string FormatearPuntoPromedio(double n)
        {
            string formatear =
                n > 0
                    ? n.ToString(
                        "F1",
                        System.Globalization.CultureInfo.InvariantCulture
                    )
                    : "";
            return formatear;
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

                if (c is WebView2 w) w.Dispose();

                // Si hay subpaneles dentro de subpaneles
                if (c.HasChildren)
                    LimpiarCampos(c);
            }
        }
    }
}
