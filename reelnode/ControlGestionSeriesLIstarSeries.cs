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
    public partial class ControlGestionSeriesListarSeries : UserControl
    {
        private PanelGradiente PanelMain;
        public ControlGestionSeriesListarSeries()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(PanelListar);
            this.Controls.Add(PanelMain);
        }

        private void ControlGestionSeriesListarSeries_Load(object sender, EventArgs e)
        {
            Utils.ActualizarListaGrid(DataGridSeries, UtilsBD.seriesCargadas, "Id", "Tipo");
        }
    }
}
