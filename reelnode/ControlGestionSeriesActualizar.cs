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

namespace Reelnode
{
    public partial class ControlGestionSeriesActualizar : UserControl, ITemaPersonalizable
    {        
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        public ControlGestionSeriesActualizar()
        {
            InitializeComponent();

            BtnActualizar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
            BtnBuscar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
            BtnPrevisualizar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
        }



        private DataGridViewRow filaSeleccionada;

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelMain1.Invalidate();
        }


        private void ControlGestionSeriesActualizar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PanelMain1_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelMain1.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelMain1.ClientRectangle);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
