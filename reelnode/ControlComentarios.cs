using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlComentarios : UserControl
    {
        private PanelGradiente PanelMain;

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

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(Panel);
            this.Controls.Add(PanelMain);
        }

        private void BtnEnviarComentario_Click(object sender, EventArgs e)
        {
            UtilsBD.Comentar(Utils.ObtenerIdMedia(), TxtComentario.Text, Utils.peliculaSeleccionada != null ? "Pelicula" : "Serie");
        }

        public void CargarComentarios()
        {
            // listaComentarios = UtilsBD.CargarComentariosPelicula(Utils.peliculaSeleccionada.Id);


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
