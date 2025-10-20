using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Font = System.Drawing.Font;
using Label = System.Windows.Forms.Label;

namespace Reelnode
{
    public partial class FormMain : Form, ITemaPersonalizable
    {
        // CREACION DE CONTROLES
        private ControlAdmin controlAdmin;
        private ControlCuentaUsuario controlCuentaUsuario;
        private ControlVisualizacionSerie controlVisualizacionSerie;
        private ControlVisualizacionPeliculas controlVisualizacionPeliculas;

        // CREACION DE UI
        private FlowLayoutPanel flowPanelPeliculas;
        private FlowLayoutPanel flowPanelSeries;
        private Label lblPeliculas;
        private Label lblSeries;
        private PanelGradiente panelContenedor;

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            panelContenedor.Color1 = color1;
            panelContenedor.Color2 = color2;
            panelContenedor.GradientMode = modo;
            panelContenedor.Invalidate();
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UtilsBD.Conexion.AbrirBD();

            // CARGA DE DATOS
            UtilsBD.CargarUsuario();
            UtilsBD.CargarSeries();
            UtilsBD.CargarPeliculas();
            UtilsBD.CargarSeries();
            UtilsBD.CargarNetwork();
            UtilsBD.CargarGeneros();
            UtilsBD.ReporteCargarVistas(5, "peliculas");
            UtilsBD.ReporteCargarVistas(5, "series"); 
            UtilsBD.ReporteCargarCalificaciones(5, "peliculas");
            UtilsBD.ReporteCargarCalificaciones(5, "series");

            CrearUI();

            // Esta funcion permite cambiar todo el tema del proyecto. Apretar F12 para ver la funcion.
            AdministradorTema.AplicarTema(this);

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

        private void MostrarPeliculas()
        {
            Utils.RellenarFlowPanel(flowPanelPeliculas, UtilsBD.peliculasCargadas, AbrirPestanaPelicula);
        }

        private void MostrarSeries()
        {
            Utils.RellenarFlowPanel(flowPanelSeries, UtilsBD.seriesCargadas, AbrirPestanaSerie);
        }

        public void AbrirPestanaSerie(int id)
        {
            Utils.peliculaSeleccionada = null;
            Utils.serieSeleccionada = UtilsBD.seriesCargadas[id - 1];

            controlVisualizacionSerie.CargarSerie(Utils.serieSeleccionada);
            UtilsBD.RegistrarVisualizacion(Utils.serieSeleccionada.Id, "Serie");

            Utils.ShowControl(controlVisualizacionSerie, PanelMain);
        }

        public void AbrirPestanaPelicula(int id)
        {
            Utils.serieSeleccionada = null;
            Utils.peliculaSeleccionada = UtilsBD.peliculasCargadas[id - 1];

            controlVisualizacionPeliculas.CargarPelicula(Utils.peliculaSeleccionada);
            UtilsBD.RegistrarVisualizacion(Utils.peliculaSeleccionada.Id, "Pelicula");

            Utils.ShowControl(controlVisualizacionPeliculas, PanelMain);
        }

        public Panel MainPanel
        {
            get { return PanelMain; }
        }

        private void ToolStpMenuCuenta_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlCuentaUsuario, PanelMain);
        }

        private void ToolStpMenuHome_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(panelContenedor, PanelMain);
        }

        public void CrearUI()
        {
            panelContenedor = new PanelGradiente
            {
                Dock = DockStyle.Fill,
            };

            PanelMain.BackColor = Color.Transparent;
            PanelBack.BackColor = Color.Transparent;
            PanelMain.Controls.Add(panelContenedor);

            controlAdmin = new ControlAdmin();

            controlCuentaUsuario = new ControlCuentaUsuario();
            controlCuentaUsuario.AbrirPelicula = AbrirPestanaPelicula;
            controlCuentaUsuario.AbrirSerie = AbrirPestanaSerie;

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

            lblSeries = new Label
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
    }
}
/*private void CargarUsuariosJSON()
{
    string ruta = Path.Combine(Application.StartupPath, "personas.json");
    string json = File.ReadAllText(ruta);
    UtilsBD.usuariosRegistrados = JsonSerializer.Deserialize<List<Usuario>>(json);
}
*/