using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlCuentaUsuario : UserControl
    {
        private PanelGradiente PanelMain;

        /* !--- Acciones para abrir pelicula o serie ---! */

        // Al hacerlas publicas, puedo asignarlas desde el formulario principal
        // que tambien comparte la misma logica de abrir una pantalla de pelicula o serie
        public Action<int> AbrirPelicula { get; set; }
        public Action<int> AbrirSerie { get; set; }

        /* !--- Fin de Acciones ---! */
        public ControlCuentaUsuario()
        {
            InitializeComponent();

            /* Necesario para que funcione el panel con gradiente de fondo */
            PanelMain = new PanelGradiente
            {
                Dock = DockStyle.Fill
            };

            while (this.Controls.Count > 0)
            {
                Control ctrl = this.Controls[0];
                this.Controls.RemoveAt(0);
                PanelMain.Controls.Add(ctrl);
            }
            this.Controls.Add(PanelMain);
            /* ------------------------------------------------------------- */
        }

        private void ConfiguracionCuentaUsuario()
        {
            AdministradorCalificaciones.OnCalificacionActualizada += MostrarCalificaciones;
            /* !--- CARGAR DATOS DE USUARIO ---! */

            PicAvatar.Image = Utils.DescargarImagenDesdeURL(AdministradorUsuarios.usuarioActual.Avatar);
            LblEmail.Text = AdministradorUsuarios.usuarioActual.Email;
            LblUsuario.Text = AdministradorUsuarios.usuarioActual.NombreUsuario;

            AdministradorCalificaciones.CargarCalificacionesUsuarioPeliculas();

            AdministradorCalificaciones.CargarCalificacionesUsuarioSeries();
  

            /* !--- FIN DE CARGADO ---! */

            /* !--- RELLENAR FLOW PANELS CON DATOS ---! */

            MostrarCalificaciones();

            /* !--- FIN DE RELLENO ---! */
        }

        private void MostrarCalificaciones()
        {
            Utils.RellenarFlowPanel(FlowPanelPeliculas,
                AdministradorCalificaciones.peliculasCalificadasUsuario, AbrirPelicula);

            Utils.RellenarFlowPanel(FlowPanelSeries,
                AdministradorCalificaciones.seriesCalificadasUsuario, AbrirSerie);
        }

        /* !--- EVENTOS DE BOTONES ---! */

        private void BtnConfirmarAvatar_Click_1(object sender, EventArgs e)
        {
            BtnConfirmarAvatar.Visible = false;
            PanelURL.Visible = false;

            AdministradorUsuarios.CambiarAvatar(AdministradorUsuarios.usuarioActual.Id, TxtURLImagen.Text, PicAvatar);
        }

        private void BtnAvatar_Click_1(object sender, EventArgs e)
        {
            BtnConfirmarAvatar.Visible = true;
            PanelURL.Visible = true;
        }

        private void ControlCuentaUsuario_Load(object sender, EventArgs e)
        {
            ConfiguracionCuentaUsuario();
        }

        /* !--- FIN DE EVENTOS DE BOTONES ---! */
    }
}
