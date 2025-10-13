using iTextSharp.text;
using MySql.Data.MySqlClient;
using ProjectoNuevo;
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
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Font = System.Drawing.Font;
using Label = System.Windows.Forms.Label;

namespace Reelnode
{
    public partial class FormMain : Form, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;

        private ControlAdmin controlAdmin;   
        private ControlCuentaUsuario controlCuentaUsuario;
        private ControlVisualizacionSerie controlVisualizacionSerie;
        private ControlVisualizacionPeliculas controlVisualizacionPeliculas;

        private FlowLayoutPanel flowPanelPeliculas;
        private FlowLayoutPanel flowPanelSeries;
        private Label lblPeliculas;
        private Label lblSeries;
        private Panel panelContenedor;

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            panelContenedor.Invalidate();
        }
        public FormMain()
        {
            InitializeComponent();

            panelContenedor = new Panel
            {
                Dock = DockStyle.Fill,
            };

            panelContenedor.Paint += panelContenedor_Paint;

            PanelMain.BackColor = Color.Transparent;
            PanelBack.BackColor = Color.Transparent;
            PanelMain.Controls.Add(panelContenedor);

            controlAdmin = new ControlAdmin();
            controlCuentaUsuario = new ControlCuentaUsuario();
            controlVisualizacionSerie = new ControlVisualizacionSerie();
            controlVisualizacionPeliculas = new ControlVisualizacionPeliculas();

            PanelMain.Controls.Add(controlAdmin);
            PanelMain.Controls.Add(controlCuentaUsuario);
            PanelMain.Controls.Add(controlVisualizacionSerie);
            PanelMain.Controls.Add(controlVisualizacionPeliculas);

            controlAdmin.Visible = false;
            controlCuentaUsuario.Visible = false;
            controlVisualizacionSerie.Visible = false;
            controlVisualizacionPeliculas.Visible = false;

            controlAdmin.HomeClicked += (s, e) => {
                Utils.ShowControl(panelContenedor, PanelMain);
            };

            int margenIzquierdo = 10;
            int margenSuperior = 15;
            int espacioEntrePaneles = 10;
            int altoPanel = 280;

            lblPeliculas = new Label
            {
                Text = "🎬 Películas",
                Font = new Font("Courier New", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(margenIzquierdo, margenSuperior),
                BackColor = Color.Transparent,
                Tag = "Titulo"
            };

            flowPanelPeliculas = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true,
                AutoSize = false,
                BackColor = Color.Transparent,
                Padding = new Padding(10),
                Location = new Point(margenIzquierdo, lblPeliculas.Bottom + 10),
                Size = new Size(this.ClientSize.Width - 2 * margenIzquierdo, altoPanel),
                VerticalScroll = { Visible = false },
                Tag = "Default"
            };

            Label lblSeries = new Label
            {
                Text = "📺 Series",
                Font = new Font("Courier New", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(margenIzquierdo, flowPanelPeliculas.Bottom + espacioEntrePaneles),
                BackColor = Color.Transparent,
                Tag = "Titulo"
            };

            flowPanelSeries = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true,
                AutoSize = false,
                BackColor = Color.Transparent,
                Padding = new Padding(10),
                Location = new Point(margenIzquierdo, lblSeries.Bottom + 10),
                Size = new Size(this.ClientSize.Width - 2 * margenIzquierdo, altoPanel),
                VerticalScroll = { Visible = false },
                Tag = "Default"
            };

            panelContenedor.Controls.Add(flowPanelPeliculas);
            panelContenedor.Controls.Add(flowPanelSeries);
            panelContenedor.Controls.Add(lblPeliculas);
            panelContenedor.Controls.Add(lblSeries);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UtilsBD.Conexion.AbrirBD();
            UtilsBD.CargarUsuario();
            UtilsBD.CargarSeries();
            UtilsBD.CargarPeliculas();
            UtilsBD.CargarSeries();
            UtilsBD.CargarNetwork();
            UtilsBD.CargarGeneros();

            // Esta funcion permite cambiar todo el tema del proyecto. Apretar F12 para ver la funcion.
            AplicarTema(this);
            // ------------------------------------------------------

            MostrarPeliculas();
            MostrarSeries();

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
                else if (ctrl is System.Windows.Forms.CheckedListBox chkList)
                {
                    chkList.BackColor = Color.FromArgb(42, 47, 79);
                    chkList.ForeColor = Color.FromArgb(0, 230, 118);
                    chkList.BorderStyle = BorderStyle.FixedSingle;
                }
                else if(ctrl is System.Windows.Forms.TextBox txt)
                {

                    txt.BackColor = Color.FromArgb(42, 47, 79);
                    txt.ForeColor = Color.FromArgb(0, 255, 255);
                    txt.Font = new Font("Consolas", txt.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is System.Windows.Forms.Label lbl)
                {
                    if(lbl.Tag == "Titulo") lbl.ForeColor = Color.FromArgb(0, 230, 118); 
                    if(lbl.Tag == "Default") lbl.ForeColor = Color.FromArgb(255, 255, 255);
                    if(lbl.Tag == null)  lbl.ForeColor = Color.FromArgb(255, 0, 127);

                    lbl.Font = new Font("Courier New", lbl.Font.Size, FontStyle.Bold);
                    lbl.BackColor = Color.Transparent;
                }

                else if (ctrl is System.Windows.Forms.Button btn)
                {
                    btn.BackColor = Color.FromArgb(123, 44, 191);
                    btn.ForeColor = Color.FromArgb(0, 255, 255);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(0, 183, 235);
                    btn.Font = new Font("Consolas", btn.Font.Size, FontStyle.Bold);
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
                    grid.Font = new Font("Courier New", grid.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is FlowLayoutPanel flow)
                {
                    flow.BackColor = Color.Transparent;
                }
                else if (ctrl is System.Windows.Forms.ComboBox cmb)
                {
                    cmb.BackColor = Color.FromArgb(42, 47, 79);
                    cmb.ForeColor = Color.FromArgb(0, 255, 255);
                    cmb.Font = new Font("Courier New", cmb.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is CheckBox chk)
                {
                    chk.ForeColor = Color.FromArgb(255, 0, 127);
                    chk.Font = new Font("Courier New", chk.Font.Size, FontStyle.Bold);

                }
                else if (ctrl is RadioButton rbt)
                {
                    rbt.ForeColor = Color.FromArgb(255, 0, 127);
                    rbt.Font = new Font("Courier New", rbt.Font.Size, FontStyle.Bold);
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
            Utils.RellenarFlowPanel(flowPanelPeliculas, UtilsBD.peliculasCargadas, AbrirPestanaPelicula);
        }

        private void MostrarSeries()
        {
            Utils.RellenarFlowPanel(flowPanelSeries, UtilsBD.seriesCargadas, AbrirPestanaSerie);
        }

        private void AbrirPestanaSerie(int id)
        {
            Utils.peliculaSeleccionada = null;
            Utils.serieSeleccionada = UtilsBD.seriesCargadas[id - 1];
            controlVisualizacionSerie.CargarSerie(Utils.serieSeleccionada);
            Utils.ShowControl(controlVisualizacionSerie, PanelMain);
        }

        private void AbrirPestanaPelicula(int id)
        {
            Utils.serieSeleccionada = null;
            Utils.peliculaSeleccionada = UtilsBD.peliculasCargadas[id - 1];
            controlVisualizacionPeliculas.CargarPelicula(Utils.peliculaSeleccionada);
            Utils.ShowControl(controlVisualizacionPeliculas, PanelMain);
        }

        // Esta funcion me permite recuperar todos los controles hijos de un control padre.
        // La utilizo para obtener todos los controles hijos de FormMain y asi aplicar el tema a todos los controles.
        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }

        public Panel MainPanel
        {
            get { return PanelMain; }
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(panelContenedor.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, panelContenedor.ClientRectangle);
            }
        }

        private void ToolStpMenuCuenta_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlCuentaUsuario, PanelMain);
        }
    }
}
