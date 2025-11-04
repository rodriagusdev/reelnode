using System;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlAdmin : UserControl
    {
        private PanelGradiente PanelMain;

        /* !--- CREACION DE USER CONTROLS ---! */

        private ControlGestionPeliculasCargar controlCargarPelicula;
        private ControlGestionPeliculasListarPeliculas controlListarPeliculas;
        private ControlGestionPeliculasActualizar controlActualizarPeliculas;
        private ControlGestionUsuarios controlGestionUsuarios;
        private ControlGestionSeriesCargar controlSeriesCargar;
        private ControlGestionSeriesActualizar controlSeriesActualizar;
        private ControlGestionSeriesListarSeries controlGestionSeriesListarSeries;
        private ControlGestionDashboard controlGestionDashboard;

        /* !--- FIN DE CREACION DE USER CONTROLS ---! */

        // Evento para volver al home REVEER
        public event EventHandler HomeClicked;

        /* REVEER SU USO
        public Action<int> AbrirPelicula { get; set; }
        public Action<int> AbrirSerie { get; set; }
        */
        public ControlAdmin()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(PanelAdmin);
            this.Controls.Add(PanelMain);

            PanelAdmin.Controls.Add(controlCargarPelicula = new ControlGestionPeliculasCargar());
            PanelAdmin.Controls.Add(controlListarPeliculas = new ControlGestionPeliculasListarPeliculas());
            PanelAdmin.Controls.Add(controlGestionUsuarios = new ControlGestionUsuarios());
            PanelAdmin.Controls.Add(controlActualizarPeliculas = new ControlGestionPeliculasActualizar());
            PanelAdmin.Controls.Add(controlSeriesCargar = new ControlGestionSeriesCargar());
            PanelAdmin.Controls.Add(controlSeriesActualizar = new ControlGestionSeriesActualizar());
            PanelAdmin.Controls.Add(controlGestionSeriesListarSeries = new ControlGestionSeriesListarSeries());
            PanelAdmin.Controls.Add(controlGestionDashboard = new ControlGestionDashboard());

            controlCargarPelicula.Visible = false;
            controlListarPeliculas.Visible = false;
            controlGestionUsuarios.Visible = false;
            controlActualizarPeliculas.Visible = false;
            controlSeriesCargar.Visible = false;
            controlSeriesActualizar.Visible = false;
            controlGestionSeriesListarSeries.Visible = false;
            controlGestionDashboard.Visible = true;
        }

        /* !--- Eventos de las opciones de menu ---! */
        private void ToolStpSubMenuCargarPeliculas_Click(object sender, EventArgs e)
        {
            if (!controlCargarPelicula.Visible)
                Utils.ShowControl(controlCargarPelicula, PanelAdmin);
        }

        private void ToolStpSubMenuListarPeliculas_Click(object sender, EventArgs e)
        {
            if (!controlListarPeliculas.Visible)
                Utils.ShowControl(controlListarPeliculas, PanelAdmin);
        }

        private void ToolStpMenuUsuarios_Click(object sender, EventArgs e)
        {
            if (!controlGestionUsuarios.Visible)
                Utils.ShowControl(controlGestionUsuarios, PanelAdmin);
        }

        private void ToolStpMenuActualizarPelicula_Click(object sender, EventArgs e)
        {
            if (!controlActualizarPeliculas.Visible)
                Utils.ShowControl(controlActualizarPeliculas, PanelAdmin);
        }

        private void ToolStpMenuCargarSerie_Click(object sender, EventArgs e)
        {
            if (!controlSeriesCargar.Visible)
                Utils.ShowControl(controlSeriesCargar, PanelAdmin);
        }

        private void ToolStpMenuListarSerie_Click(object sender, EventArgs e)
        {
            if (!controlGestionSeriesListarSeries.Visible)
                Utils.ShowControl(controlGestionSeriesListarSeries, PanelAdmin);
        }

        private void ToolStpMenuActualizarSerie_Click(object sender, EventArgs e)
        {
            if (!controlSeriesActualizar.Visible)
                Utils.ShowControl(controlSeriesActualizar, PanelAdmin);
        }

        private void ToolStpMenuDashboard_Click(object sender, EventArgs e)
        {
            if (!controlGestionDashboard.Visible)
                Utils.ShowControl(controlGestionDashboard, PanelAdmin);
        }


        /* !--- Fin de eventos de los ToolStripMenuItems ---! */
    }
}
