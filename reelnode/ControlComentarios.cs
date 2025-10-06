using Reelnode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public partial class ControlComentarios : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        public ControlComentarios()
        {
            InitializeComponent();
        }
        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            Panel.Invalidate();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(Panel.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, Panel.ClientRectangle);
            }
        }

        private void BtnEnviarComentario_Click(object sender, EventArgs e)
        {
            UtilsBD.Comentar(Utils.ObtenerIdMedia(), TxtComentario.Text, Utils.peliculaSeleccionada != null ? "Pelicula" : "Serie");
        }
    }
}
