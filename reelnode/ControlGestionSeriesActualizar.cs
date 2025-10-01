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
        private DataGridViewRow filaSeleccionada;
        public ControlGestionSeriesActualizar()
        {
            InitializeComponent();

            BtnActualizar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
            BtnBuscar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
            BtnPrevisualizar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);

            Utils.TemaControles(PanelMain1, PicSerie);
        }
        private void ControlGestionSeriesActualizar_Load(object sender, EventArgs e)
        {
            CboNetwork.DataSource = UtilsBD.networksCargadas;
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelMain1.Invalidate();
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
            string textoBuscador = TxtBuscarSerie.Text;

            List<Serie> seriesEncontradas = UtilsBD.seriesCargadas
                .Where(s => s.Nombre.ToLower().Contains(textoBuscador.ToLower()))
                .ToList();

            if (seriesEncontradas.Count == 0)
            {
                MessageBox.Show("No se encontraron series con ese nombre.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Utils.ActualizarListaGrid(DataGridActualizarSerie, seriesEncontradas, "Id", "Tipo");
        }
    }
}
