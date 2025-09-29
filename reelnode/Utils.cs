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
        public static void RedondearBordes(Panel panel, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddLine(radio, 0, panel.Width - radio, 0);
            path.AddArc(new Rectangle(panel.Width - radio, 0, radio, radio), -90, 90);
            path.AddLine(panel.Width, radio, panel.Width, panel.Height - radio);
            path.AddArc(new Rectangle(panel.Width - radio, panel.Height - radio, radio, radio), 0, 90);
            path.AddLine(panel.Width - radio, panel.Height, radio, panel.Height);
            path.AddArc(new Rectangle(0, panel.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }

        public static void ShowControl(UserControl controlToShow, Panel panel)
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
    }
}
