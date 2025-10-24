using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class FormMain : Form
    {
        private PanelGradiente PanelMain;

        // !--- CREACION DE USER CONTROLS ---!

        private ControlAdmin controlAdmin;
        private ControlCuentaUsuario controlCuentaUsuario;
        private ControlVisualizacionSerie controlVisualizacionSerie;
        private ControlVisualizacionPeliculas controlVisualizacionPeliculas;

        // !--- FIN CREACION DE USER CONTROLS ---!

        public FormMain()
        {
            InitializeComponent();

            // CREACION DEL PANEL PRINCIPAL CON GRADIENTE
            PanelMain = new PanelGradiente
            {
                Dock = DockStyle.Fill,
            };

            PanelMain.Controls.Add(FlowPanelPeliculas);
            PanelMain.Controls.Add(FlowPanelSeries);
            Panel.Controls.Add(PanelMain);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UtilsBD.Conexion.AbrirBD();
            AdministradorUsuarios.CargarUsuario();

            FormLogin login = new FormLogin();

            login.ShowDialog();

            ToolStpMenuAdmin.Visible = AdministradorUsuarios.usuarioActual.RolUsuario == "Admin" ? true : false;

            AdministradorUsuarios.CargarUsuario();

            /* !--- CARGA DE DATOS ---! */

            UtilsBD.CargarSeries();
            UtilsBD.CargarPeliculas();
            UtilsBD.CargarSeries();
            UtilsBD.CargarNetwork();
            UtilsBD.CargarGeneros();

            /* !--- FIN CARGADO DE DATOS ---! */

            ConfiguracionAPP();

            // APLICACION DE TEMA -> F12 para abrir la configuracion de tema
            AdministradorTema.AplicarTema(this);
        }

        public void ConfiguracionAPP()
        {
            /* !--- ESTABLECIMIENTO Y CONFIGURACION DE USER CONTROLS ---! */

            controlAdmin = new ControlAdmin();
            controlAdmin.Visible = false;

            controlCuentaUsuario = new ControlCuentaUsuario();
            controlCuentaUsuario.Visible = false;
            // Asigno las mismas funciones del main para abrir peliculas y series a las acciones del control de cuenta de usuario
            // Permite al usuario abrir una serie desde su cuenta y no solo desde el Home
            controlCuentaUsuario.AbrirPelicula = AbrirPestanaPelicula;
            controlCuentaUsuario.AbrirSerie = AbrirPestanaSerie;

            controlVisualizacionSerie = new ControlVisualizacionSerie();
            controlVisualizacionSerie.Visible = false;

            controlVisualizacionPeliculas = new ControlVisualizacionPeliculas();
            controlVisualizacionPeliculas.Visible = false;

            /* !--- CONFIGURACION DE USER CONTROLS FINALIZADA ---! */


            /* !--- CONFIGURACION DE UI PRINCIPAL ---! */

            // Agrego los controles creados al panel principal
            Panel.Controls.Add(controlAdmin);
            Panel.Controls.Add(controlCuentaUsuario);
            Panel.Controls.Add(controlVisualizacionSerie);
            Panel.Controls.Add(controlVisualizacionPeliculas);
            Panel.BackColor = Color.Transparent;

            // Relleno los flow panels de la UI principal con las peliculas y series cargadas en la base de datos
            Utils.RellenarFlowPanelTest(FlowPanelPeliculas, UtilsBD.peliculasCargadas, AbrirPestanaPelicula);
            Utils.RellenarFlowPanelTest(FlowPanelSeries, UtilsBD.seriesCargadas, AbrirPestanaSerie);

            /* !--- FIN CONFIGURACION DE UI PRINCIPAL ---! */
        }

        public void AbrirPestanaSerie(int id)
        {
            Utils.peliculaSeleccionada = null;
            Utils.serieSeleccionada = UtilsBD.seriesCargadas[id - 1];

            controlVisualizacionSerie.CargarSerie(Utils.serieSeleccionada);
            UtilsBD.RegistrarVisualizacion(Utils.serieSeleccionada.Id, "Serie");

            Utils.ShowControl(controlVisualizacionSerie, Panel);
        }

        public void AbrirPestanaPelicula(int id)
        {
            Utils.serieSeleccionada = null;
            Utils.peliculaSeleccionada = UtilsBD.peliculasCargadas[id - 1];

            controlVisualizacionPeliculas.CargarPelicula(Utils.peliculaSeleccionada);
            UtilsBD.RegistrarVisualizacion(Utils.peliculaSeleccionada.Id, "Pelicula");

            Utils.ShowControl(controlVisualizacionPeliculas, Panel);
        }


        /* !--- EVENTOS DE BOTONES DEL MENU ---! */
        private void ToolStpMenuAdmin_Click_1(object sender, EventArgs e)
        {
            Utils.ShowControl(controlAdmin, Panel);
        }
        private void ToolStpMenuCuenta_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlCuentaUsuario, Panel);
        }

        private void ToolStpMenuHome_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(PanelMain, Panel);

            if (controlVisualizacionPeliculas.trailer != null)
            {
                controlVisualizacionPeliculas.DetenerTrailer();
            }

            if (controlVisualizacionSerie.trailer != null)
            {
                controlVisualizacionSerie.DetenerTrailer();
            }
        }

        private void ToolStpMenuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /* !--- FIN EVENTOS DE BOTONES DEL MENU ---! */
    }
}