using iTextSharp.xmp.impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlAdmin : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;

        // Creacion de controles
        private ControlGestionPeliculasCargar controlCargarPelicula;
        private ControlGestionPeliculasListarPeliculas controlListarPeliculas;
        private ControlGestionPeliculasActualizar controlActualizarPeliculas;
        private ControlGestionUsuarios controlGestionUsuarios;
        private ControlGestionSeriesCargar controlSeriesCargar;
        private ControlGestionSeriesActualizar controlSeriesActualizar;
        private ControlGestionSeriesListarSeries controlGestionSeriesListarSeries;
        private ControlGestionDashboard controlGestionDashboard;

        public event EventHandler HomeClicked;
        public Action<int> AbrirPelicula { get; set; }
        public Action<int> AbrirSerie { get; set; }
        public ControlAdmin()
        {
            InitializeComponent();

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

            PanelAdmin.Paint += PanelAdmin_Paint;
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelAdmin.Invalidate();
        }

        private void PanelAdmin_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelAdmin.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelAdmin.ClientRectangle);
            }
        }

        private void ToolStpSubMenuCargarPeliculas_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlCargarPelicula, PanelAdmin);
        }

        private void ToolStpSubMenuListarPeliculas_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlListarPeliculas, PanelAdmin);
        }

        private void ToolStpMenuUsuarios_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlGestionUsuarios, PanelAdmin);
        }

        private void ToolStpMenuActualizarPelicula_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlActualizarPeliculas, PanelAdmin);
        }

        private void cargarSerieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlSeriesCargar, PanelAdmin);
        }

        private void actualizarSerieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlSeriesActualizar, PanelAdmin);
        }

        private void listarSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlGestionSeriesListarSeries, PanelAdmin);
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlGestionDashboard, PanelAdmin);
        }
    }
}
