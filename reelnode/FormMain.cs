using System;
using System.Drawing;
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
            PanelMain = new PanelGradiente { Dock = DockStyle.Fill };

            PanelMain.Controls.Add(LblSeries);
            PanelMain.Controls.Add(LblPeliculas);
            PanelMain.Controls.Add(FlowPanelPeliculas);
            PanelMain.Controls.Add(FlowPanelSeries);
            Panel.Controls.Add(PanelMain);
        }

        public void ConfiguracionAPP()
        {
            AdministradorPeliculas.onPeliculaCargada += CargarPeliculasSiHayInsercion;
            AdministradorSeries.onSerieCargada += CargarSeriesSiHayInsercion;

            /* !--- ESTABLECIMIENTO Y CONFIGURACION DE USER CONTROLS ---! */

            controlAdmin = new ControlAdmin();
            controlAdmin.Visible = false;

            controlCuentaUsuario = new ControlCuentaUsuario();
            controlCuentaUsuario.Visible = false;

            controlVisualizacionSerie = new ControlVisualizacionSerie();
            controlVisualizacionSerie.Visible = false;

            controlVisualizacionPeliculas = new ControlVisualizacionPeliculas();
            controlVisualizacionPeliculas.Visible = false;

            /* !--- CONFIGURACION DE USER CONTROLS FINALIZADA ---! */

            /* INICIO ASIGNACION DE FUNCIONES */

            // Asigno las mismas funciones del main para abrir peliculas y series
            // a las acciones del control de cuenta de usuario
            // Permite al usuario abrir una serie desde su cuenta y no solo desde el Home

            controlCuentaUsuario.AbrirPelicula = AbrirPestanaPelicula;
            controlCuentaUsuario.AbrirSerie = AbrirPestanaSerie;

            /* FIN ASIGNACION DE FUNCIONES */

            /* !--- CONFIGURACION DE UI PRINCIPAL ---! */

            // Agrego los controles creados al panel principal
            Panel.Controls.Add(controlAdmin);
            Panel.Controls.Add(controlCuentaUsuario);
            Panel.Controls.Add(controlVisualizacionSerie);
            Panel.Controls.Add(controlVisualizacionPeliculas);
            Panel.BackColor = Color.Transparent;

            // Relleno los flow panels de la UI principal con las peliculas y series cargadas en la base de datos
            CargarPeliculasSiHayInsercion();

            CargarSeriesSiHayInsercion();
            
            /* !--- CARGA DE PERMISOS ---! */

            // Aca solo elijo si mostrar o no el menu de Administracion, disponible
            // solo para Superadmin y admins.
            AdministradorPermisos.CargarPermisosActuales(AdministradorUsuarios.usuarioActual.Id);

            ToolStpMenuAdmin.Visible = AdministradorPermisos.permisosUsuarioActual.Contains(
                EnumPermisos.administrar_media.ToString()
            )
                ? true
                : false;

            /* !--- FIN CARGA DE PERMISOS ---! */

            /* !--- FIN CONFIGURACION DE UI PRINCIPAL ---! */
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            /* !--- LOGIN ---! */

            UtilsBD.Conexion.AbrirBD();

            FormLogin login = new FormLogin();

            login.ShowDialog();

            /* !--- FIN LOGIN ---! */

            /* !--- CARGA DE DATOS ---! */

            // Cargo devuelta los usuarios si se registro uno nuevo.
            AdministradorUsuarios.CargarUsuarios();
            AdministradorPeliculas.CargarPeliculas();
            AdministradorSeries.CargarSeries();
            UtilsBD.CargarNetworks();
            UtilsBD.CargarGeneros();

            /* !--- FIN CARGADO DE DATOS ---! */

            ConfiguracionAPP();

            // APLICACION DE TEMA -> F12 para abrir la configuracion de tema
            AdministradorTema.AplicarTema(this);
        }

        /* !--- EVENTOS DE CLICK SOBRE CONTENIDO AUDIOVISUAL ---! */

        public string EnviarCalificacionAFormateo(int idAudiovisual, EnumTipoId tipo)
        {
            double califPromedio = 0;
            string procedimiento = "";

            if (tipo == EnumTipoId.p_id_serie)
                procedimiento = "sp_obtener_serie_calificacion_promedio";
            if (tipo == EnumTipoId.p_id_pelicula)
                procedimiento = "sp_obtener_pelicula_calificacion_promedio";

            califPromedio = AdministradorCalificaciones.ObtenerCalificacionPromedio(
                procedimiento,
                idAudiovisual,
                tipo
            );

            return Utils.FormatearPuntoPromedio(califPromedio);
        }

        public void AbrirPestanaSerie(int idAudiovisualClick)
        {
            AdministradorPeliculas.peliculaSeleccionada = null;

            AdministradorSeries.serieSeleccionada = AdministradorSeries.seriesCargadas[
                idAudiovisualClick - 1
            ];

            controlVisualizacionSerie.LblCalificacion.Text =
                $"{EnviarCalificacionAFormateo(idAudiovisualClick, EnumTipoId.p_id_serie):F1}";

            controlVisualizacionSerie.CargarSerie(AdministradorSeries.serieSeleccionada);

            AdministradorVisualizaciones.RegistrarVisualizacion(
                AdministradorSeries.serieSeleccionada.Id,
                "Serie"
            );

            Utils.ShowControl(controlVisualizacionSerie, Panel);
        }

        public void AbrirPestanaPelicula(int idAudiovisualClick)
        {
            AdministradorSeries.serieSeleccionada = null;

            AdministradorPeliculas.peliculaSeleccionada = AdministradorPeliculas.peliculasCargadas[
                idAudiovisualClick - 1
            ];

            controlVisualizacionPeliculas.LblCalificacion.Text =
                $"{EnviarCalificacionAFormateo(idAudiovisualClick, EnumTipoId.p_id_pelicula):F1}";

            controlVisualizacionPeliculas.CargarPelicula(
                AdministradorPeliculas.peliculaSeleccionada
            );

            AdministradorVisualizaciones.RegistrarVisualizacion(
                AdministradorPeliculas.peliculaSeleccionada.Id,
                "Pelicula"
            );

            Utils.ShowControl(controlVisualizacionPeliculas, Panel);
        }

        public void CargarPeliculasSiHayInsercion()
        {
            CreadorUI.MostrarGaleriaAudiovisual(
                FlowPanelPeliculas,
                AdministradorPeliculas.CargarPeliculasPreview(),
                AbrirPestanaPelicula,
                190,
                220
            );
        }

        public void CargarSeriesSiHayInsercion()
        {
            CreadorUI.MostrarGaleriaAudiovisual(
                FlowPanelSeries,
                AdministradorSeries.CargarSeriesPreview(),
                AbrirPestanaSerie,
                190,
                220
            );
        }

        /* !--- FIN DE EVENTOS DE CLICK SOBRE CONTENIDO AUDIOVISUAL ---! */

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
