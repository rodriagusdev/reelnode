using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlComentarios : UserControl
    {
        private PanelGradiente PanelMain;
        private readonly Moderador _moderator;

        private List<Comentario> listaComentarios = new List<Comentario>();

        public ControlComentarios()
        {
            InitializeComponent();

            AdministradorComentarios.onComentarioEliminado += CargarComentarios;

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

            try
            {
                _moderator = new Moderador(Application.StartupPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEnviarComentario_Click(object sender, EventArgs e)
        {
            if (
                !AdministradorPermisos.permisosUsuarioActual.Contains(
                    EnumPermisos.comentar.ToString()
                )
            )
            {
                MessageBox.Show(
                    "No posees los permisos para comentar",
                    "Error de permisos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtComentario.Text))
            {
                MessageBox.Show(
                    "Ingresa un comentario válido",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (_moderator == null)
            {
                MessageBox.Show(
                    "El moderador no está inicializado",
                    "Error de moderación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            try
            {
                bool esToxico = _moderator.ComentarioEsToxico(TxtComentario.Text);

                if (!esToxico)
                {
                    AdministradorComentarios.Comentar(
                        AdministradorAudiovisual.ObtenerIdAudiovisual(),
                        TxtComentario.Text,
                        AdministradorPeliculas.peliculaSeleccionada != null ? "Pelicula" : "Serie"
                    );
                }
                else
                {
                    MessageBox.Show(
                        "😱😱😖 Mala persona! 👎👎\nComentario bloqueado! 😜",
                        "Moderación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al moderar el comentario: {ex.Message}\nPor favor, revisa la consola (Ctrl+Alt+O) para más detalles.",
                    "Error de moderación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarComentarios()
        {
            listaComentarios.Clear();
            flowPanelComentarios.Controls.Clear();

            // Traer comentarios actualizados desde BD
            listaComentarios = AdministradorComentarios.ObtenerComentarios(
                AdministradorComentarios.procedimiento,
                AdministradorComentarios.p_id,
                AdministradorComentarios.idAudiovisual
            );

            // Crear los paneles si hay comentarios
            if (listaComentarios != null && listaComentarios.Count > 0)
            {
                CreadorUI.CrearPanelesComentarios(flowPanelComentarios, listaComentarios);
            }
        }
        private void BtnVerComentarios_Click(object sender, EventArgs e)
        {
            flowPanelComentarios.Visible = !flowPanelComentarios.Visible;

            if (flowPanelComentarios.Visible)
            {
                BtnVerComentarios.Text = "Ocultar comentarios";
                CargarComentarios();
            }
            else
            {
                BtnVerComentarios.Text = "Ver comentarios";
            }
        }

    }
}
