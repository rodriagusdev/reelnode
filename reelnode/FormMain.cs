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

            controlAdmin.HomeClicked += (s, e) => {
                Utils.ShowControl(flowPanel, PanelMain);
            };

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

        private void FormMain_Load(object sender, EventArgs e)
        {
            UtilsBD.Conexion.AbrirBD();
            UtilsBD.CargarUsuario();
            UtilsBD.CargarPeliculas();
            UtilsBD.CargarSeries();
            UtilsBD.CargarNetwork();

            // Esta funcion permite cambiar todo el tema del proyecto
            AplicarTema(this);
            // ------------------------------------------------------

            MostrarPeliculas();

            FormLogin login = new FormLogin();

            login.ShowDialog();

            ToolStpMenuAdmin.Visible = UtilsBD.usuarioActual.RolUsuario == "Admin" ? true : false;
        }

        private void ToolStpMenuAdmin_Click_1(object sender, EventArgs e)
        {
            Utils.ShowControl(controlAdmin, PanelMain);
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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
                    if(lbl.Tag == "Titulo") lbl.ForeColor = Color.FromArgb(0, 230, 118); 
                    if(lbl.Tag == "Default") lbl.ForeColor = Color.FromArgb(255, 255, 255);
                    if(lbl.Tag == null)  lbl.ForeColor = Color.FromArgb(255, 0, 127);
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

                else if (ctrl is DataGridView grid)
                {
                    grid.BackgroundColor = Color.FromArgb(38, 0, 77);
                    grid.ForeColor = Color.FromArgb(255, 255, 255);
                    grid.GridColor = Color.FromArgb(0, 183, 235);
                    grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 38, 59);
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 255, 255);
                    grid.EnableHeadersVisualStyles = false;
                    grid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 38, 59);
                    grid.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 255, 255);
                    grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(42, 47, 79);
                    grid.RowsDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
                    grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 41, 69);
                    grid.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
                    grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 183, 235);
                    grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 0, 0);
                    grid.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (ctrl is FlowLayoutPanel flow)
                {
                    flow.BackColor = Color.Transparent;
                }
                else if (ctrl is System.Windows.Forms.ComboBox cmb)
                {
                    cmb.BackColor = Color.FromArgb(42, 47, 79);
                    cmb.ForeColor = Color.FromArgb(0, 255, 255);
                }
                else if (ctrl is CheckBox chk)
                {
                    chk.ForeColor = Color.FromArgb(255, 0, 127);
                }
                else if (ctrl is RadioButton rbt)
                {
                    rbt.ForeColor = Color.FromArgb(255, 0, 127);
                }
                else if (ctrl is MenuStrip menu)
                {
                    menu.BackColor = Color.FromArgb(27, 38, 59);
                    menu.ForeColor = Color.FromArgb(255, 255, 255);
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
                    Image = Utils.DescargarImagenDesdeURL(pelicula.ImagenURL),
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
            Utils.serieSeleccionada = null;
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

        private void PanelMain_Paint(object sender, PaintEventArgs e)
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

        public Panel MainPanel
        {
            get { return PanelMain; }
        }
    }
}
