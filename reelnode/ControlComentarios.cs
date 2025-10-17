using ProjectoNuevo;
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

namespace Reelnode
{
    public partial class ControlComentarios : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        private List<Comentario> listaComentarios = new List<Comentario>();
        public ControlComentarios()
        {
            InitializeComponent();

            flowPanelComentarios.FlowDirection = FlowDirection.TopDown;
            flowPanelComentarios.WrapContents = false;
            flowPanelComentarios.AutoScroll = true;
            flowPanelComentarios.VerticalScroll.Visible = true;
            flowPanelComentarios.HorizontalScroll.Enabled = false;
            flowPanelComentarios.Visible = false;
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

        public void CargarComentarios()
        {
            listaComentarios = UtilsBD.CargarComentariosPelicula(Utils.peliculaSeleccionada.Id);


            var paneles = CreadorPanel.CrearPanelesComentarios(listaComentarios);

            //comentarios = CreadorFlowPanel.CrearPanelesComentarios(UtilsBD.CargarComentariosPelicula(Utils.peliculaSeleccionada.Id));

            foreach (var pnl in paneles)
            {
                pnl.Width = flowPanelComentarios.ClientSize.Width - pnl.Margin.Horizontal;

                flowPanelComentarios.Controls.Add(pnl);
            }

            AdministradorTema.AplicarTema(flowPanelComentarios);
        }

        private void BtnVerComentarios_Click(object sender, EventArgs e)
        {
            flowPanelComentarios.Visible = !flowPanelComentarios.Visible;

            if (flowPanelComentarios.Visible)
            {
                BtnVerComentarios.Text = "Ocultar comentarios";
            }
            else
            {
                BtnVerComentarios.Text = "Ver comentarios";
            }
        }
    }
}
