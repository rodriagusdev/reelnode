using MySql.Data.MySqlClient;
using Reelnode.ProjectoNuevo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Reelnode
{
    public partial class FormMain : Form
    {
        private ControlAdmin controlAdmin;
        private ControlVisualizacionPeliculas controlVisualizacionPeliculas;
        
        private FlowLayoutPanel flowPanel;
        public FormMain()
        {
            InitializeComponent();

            controlAdmin = new ControlAdmin();
            controlVisualizacionPeliculas = new ControlVisualizacionPeliculas();

            PanelMain.Controls.Add(controlAdmin);
            PanelMain.Controls.Add(controlVisualizacionPeliculas);

            controlAdmin.Visible = false;
            controlVisualizacionPeliculas.Visible = false;

            flowPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true,
                AutoSize = false,
                BackColor = Color.Transparent,
                Padding = new Padding(10),
                Location = new Point(10, 50),
                Size = new Size(this.ClientSize.Width - 20, 270),
                VerticalScroll = { Visible = false },
                Tag = "Default"
            };

            PanelMain.Controls.Add(flowPanel);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                PanelMain.ClientRectangle,
                Color.FromArgb(27, 38, 59),
                Color.FromArgb(13, 17, 23),
                LinearGradientMode.BackwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, PanelMain.ClientRectangle);
            }
     
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            UtilsBD.Conexion.AbrirBD();
            UtilsBD.CargarUsuario();
            UtilsBD.CargarPeliculas();
            UtilsBD.CargarSeries();

            // Esta funcion permite cambiar todo el tema del proyecto
            AplicarTema(this);
            // ------------------------------------------------------

            MostrarPeliculas();

            FormLogin login = new FormLogin();

            login.ShowDialog();

            ToolStpMenuAdmin.Visible = UtilsBD.usuarioActual.RolUsuario == "Admin" ? true : false;

        }

        private void AplicarTema(Control parent)
        {
            foreach (Control ctrl in GetAllControls(this))
            {
                if (ctrl is ITemaPersonalizable controlTematico)
                {
                    controlTematico.EstablecerGradiente(
                        Color.FromArgb(27, 38, 59),
                        Color.FromArgb(13, 17, 23),
                        LinearGradientMode.Vertical);
                }

            }

            foreach (Control ctrl in parent.Controls)
            {
                if(ctrl is System.Windows.Forms.Panel pnl) 
                {
                    if(pnl.Tag != "Default") pnl.BackColor = Color.FromArgb(42, 47, 79);

                }
                else if(ctrl is System.Windows.Forms.TextBox txt)
                {

                    txt.BackColor = Color.FromArgb(42, 47, 79);
                    txt.ForeColor = Color.FromArgb(0, 255, 255);
                }
                else if (ctrl is System.Windows.Forms.Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(255,255,255);
                }

                else if (ctrl is System.Windows.Forms.Button btn)
                {
                    btn.BackColor = Color.FromArgb(123, 44, 191);
                    btn.ForeColor = Color.FromArgb(0, 255, 255);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(0, 183, 235);
                }

                else if (ctrl is PictureBox pic)
                {
                    pic.BackColor = Color.FromArgb(42, 47, 79);
                }

                if (ctrl.HasChildren)
                    AplicarTema(ctrl);
            }
        }

        /*private void CargarUsuariosJSON()
        {
            string ruta = Path.Combine(Application.StartupPath, "personas.json");
            string json = File.ReadAllText(ruta);
            UtilsBD.usuariosRegistrados = JsonSerializer.Deserialize<List<Usuario>>(json);
        }
        */

        private void ToolStpMenuAdmin_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlAdmin, PanelMain);
        }
        private void MostrarPeliculas()
        {
            flowPanel.Controls.Clear();

            foreach (var pelicula in UtilsBD.peliculasCargadas)
            {
                Panel panelTemporal = new Panel
                {
                    Size = new Size(220, 220),
                    Margin = new Padding(10),
                    BackColor = Color.Transparent,
                };

                PictureBox poster = new PictureBox
                {
                    Size = new Size(210, 210),
                    Location = new Point(10, 10),
                    Image = Utils.DescargarImagenDesdeURL(pelicula.Imagen),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand
                };

                poster.Click += (s, e) => AbrirPestanaPelicula(pelicula.Id);

                panelTemporal.Controls.Add(poster);
                flowPanel.Controls.Add(panelTemporal);
            }
        }

        private void AbrirPestanaPelicula(int id)
        {
            Utils.peliculaSeleccionada = UtilsBD.peliculasCargadas[id-1];
            Utils.ShowControl(controlVisualizacionPeliculas, PanelMain);
        }
        private void noTocarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneradorPeliculas.Insertar20PeliculasAleatorias();
            UtilsBD.CargarPeliculas();
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
