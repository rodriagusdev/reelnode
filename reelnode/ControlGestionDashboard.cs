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
        private FlowLayoutPanel flowPanelPeliculas;
        private FlowLayoutPanel flowPanelSeries;
        private Label lblSeries;
        private Label lblPeliculas;

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

            int margenIzquierdo = 250;
            int margenSuperior = 15;
            int espacioEntrePaneles = 10;
            int altoPanel = 280;

            lblPeliculas = new Label
            {
                Text = "🎬 Películas mas vistas",
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
                Text = "📺 Series mas vistas",
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

            PanelMain.Controls.Add(flowPanelPeliculas);
            PanelMain.Controls.Add(lblPeliculas);
            PanelMain.Controls.Add(flowPanelSeries);
            PanelMain.Controls.Add(lblSeries);

            Utils.RellenarFlowPanelMiniatura(flowPanelPeliculas, UtilsBD.pelisMasVistas, false, true);
            // Utils.RellenarFlowPanel(flowPanelSeries, seriesCalificadas, AbrirSerie);
        }
    }
}
