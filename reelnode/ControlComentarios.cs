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

        public string procedimiento;
        public string p_id;
        public int idAudiovisual;

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
            AdministradorComentarios.Comentar(
                AdministradorAudiovisual.ObtenerIdAudiovisual(),
                TxtComentario.Text,
                AdministradorPeliculas.peliculaSeleccionada != null ? "Pelicula" : "Serie"
            );

            CargarComentarios();
            CreadorUI.CrearPanelesComentarios(flowPanelComentarios, listaComentarios);
        }

        private void BtnVerComentarios_Click(object sender, EventArgs e)
        {
            flowPanelComentarios.Visible = !flowPanelComentarios.Visible;

            if (flowPanelComentarios.Visible)
            {
                CargarComentarios();

                if (listaComentarios.Count > 0)
                {
                    BtnVerComentarios.Text = "Ocultar comentarios";

                    CreadorUI.CrearPanelesComentarios(flowPanelComentarios, listaComentarios);
                }
            }
            else
            {
                flowPanelComentarios.Visible = false;
                BtnVerComentarios.Text = "Ver comentarios";
            }
        }

        private void CargarComentarios()
        {
            listaComentarios.Clear();
            flowPanelComentarios.Controls.Clear();

            listaComentarios = AdministradorComentarios.ObtenerComentarios(
                procedimiento,
                p_id,
                idAudiovisual
            );
        }
    }
}
