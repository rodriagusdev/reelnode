using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Reelnode
{
    public partial class ControlGestionDashboard: UserControl, ITemaPersonalizable
    {
        private PanelGradiente PanelMain;

        public ControlGestionDashboard()
        {
            InitializeComponent();            
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            PanelMain.Color1 = color1;
            PanelMain.Color2 = color2;
            PanelMain.GradientMode = modo;
            PanelMain.Invalidate();
        }

        public PanelGradiente MainPanel
        {
            get { return PanelMain; }
        }

        private void ControlGestionDashboard_Load(object sender, EventArgs e)
        {
            PanelMain = new PanelGradiente();
            PanelMain.Tag = "Default";
            PanelMain.Dock = DockStyle.Fill;
            this.Controls.Add(PanelMain);

            CargarDatos();
            AdministradorTema.AplicarTema(this);
        }

        private void CargarDatos()
        {
            // VISTAS
            Utils.ReporteCrearPanelesBarra(flowPanelPelisMasVistas, UtilsBD.pelisMasVistas, "cantidad_vistas");
            Utils.ReporteCrearPanelesBarra(flowPanelSeriesMasVistas, UtilsBD.seriesMasVistas, "cantidad_vistas");

            // CALIFICACIONES
            Utils.ReporteCrearPanelesBarra(flowPanelPeliculasMejorCalificadas, UtilsBD.peliculasCalificadas, "calificaciones");
            Utils.ReporteCrearPanelesBarra(flowPanelSeriesMejorCalificadas, UtilsBD.seriesCalificadas, "calificaciones");
        }
    }
}
