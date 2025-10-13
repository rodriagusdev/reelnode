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
    public partial class ControlGestionPeliculasListarPeliculas : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        public ControlGestionPeliculasListarPeliculas()
        {
            InitializeComponent();
        }

        private void PanelListar_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelListar.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelListar.ClientRectangle);
            }
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelListar.Invalidate();
        }

        private void ControlGestionPeliculasListarPeliculas_Load(object sender, EventArgs e)
        {
            Utils.ActualizarListaGrid(DataGridPeliculas, UtilsBD.peliculasCargadas, "Id", "Tipo");
        }
    }
}
