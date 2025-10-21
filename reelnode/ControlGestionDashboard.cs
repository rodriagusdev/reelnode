using System;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionDashboard: UserControl
    {
        private PanelGradiente PanelMain;

        public ControlGestionDashboard()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Tag = "Default";
            PanelMain.Dock = DockStyle.Fill; 
            PanelMain.Controls.Add(PanelMenu);
            PanelMain.Controls.Add(PanelDashboard);
            this.Controls.Add(PanelMain);
        }

        private void ControlGestionDashboard_Load(object sender, EventArgs e)
        {

            CargarDatosUsuario();
            CargarDatosDashboard();

            AdministradorTema.AplicarTema(this);
        }

        private void CargarDatosDashboard()
        {
            /* !--- CARGA DE DATOS ---! */

            AdministradorDashboard.CargarTopVistas(5, "peliculas", UtilsBD.pelisMasVistas);
            AdministradorDashboard.CargarTopVistas(5, "series", UtilsBD.seriesMasVistas);
            AdministradorDashboard.CargarTopCalificaciones(5, "peliculas", UtilsBD.peliculasCalificadas);
            AdministradorDashboard.CargarTopCalificaciones(5, "series", UtilsBD.seriesCalificadas);

            /* !--- FIN CARGA DE DATOS ---! */


            /* !--- MOSTRAR DATOS EN UI ---! */

            // De los datos de visualizaciones y calificaciones creo los paneles de barra correspondientes
            AdministradorDashboard.ReporteCrearPanelesBarra(flowPanelPelisMasVistas, UtilsBD.pelisMasVistas, "cantidad_vistas");
            AdministradorDashboard.ReporteCrearPanelesBarra(flowPanelSeriesMasVistas, UtilsBD.seriesMasVistas, "cantidad_vistas");
            AdministradorDashboard.ReporteCrearPanelesBarra(flowPanelPeliculasMejorCalificadas, UtilsBD.peliculasCalificadas, "calificaciones");
            AdministradorDashboard.ReporteCrearPanelesBarra(flowPanelSeriesMejorCalificadas, UtilsBD.seriesCalificadas, "calificaciones");

            // Estos datos se cargan y se muestran directamente
            AdministradorDashboard.CargarVisualizacionesUltimoMes(LblVisualizacionesUltimoMes);
            AdministradorDashboard.CargarUsuariosRegistrados(LblUsuariosRegistrados);
            AdministradorDashboard.CargarUsuariosRegistradosUltimoMes(LblUsuariosRegistradosUltimoMes);

            /* !--- FIN DE MUESTRA DE DATOS ---! */
        }

        private void CargarDatosUsuario()
        {
            if(UtilsBD.usuarioActual.Avatar != null) 
            {
                PicAvatar.Image = Utils.DescargarImagenDesdeURL(UtilsBD.usuarioActual.Avatar);
            }

            LblUsuario.Text = UtilsBD.usuarioActual.NombreUsuario;
        }
    }
}
