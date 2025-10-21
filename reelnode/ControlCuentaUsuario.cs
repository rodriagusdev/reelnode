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

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            this.Controls.Add(PanelMain);

            PanelMain.Controls.Add(FlowPanelPeliculas);
            PanelMain.Controls.Add(FlowPanelSeries);

            ConfiguracionCuentaUsuario();
        }

        private void ConfiguracionCuentaUsuario()
        {
            AdministradorCalificaciones.OnCalificacionActualizada += MostrarCalificaciones;
            /* !--- CARGAR DATOS DE USUARIO ---! */

            PicAvatar.Image = Utils.DescargarImagenDesdeURL(UtilsBD.usuarioActual.Avatar);
            LblEmail.Text = UtilsBD.usuarioActual.Email;
            LblUsuario.Text = UtilsBD.usuarioActual.NombreUsuario;

            AdministradorCalificaciones.CargarCalificacionesUsuarioPeliculas
                (UtilsBD.usuarioActual.Id, AdministradorCalificaciones.peliculasCalificadasUsuario);
            AdministradorCalificaciones.CargarCalificacionesUsuarioSeries
                (UtilsBD.usuarioActual.Id, AdministradorCalificaciones.seriesCalificadasUsuario);

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
        private void BtnAvatar_Click(object sender, EventArgs e)
        {
            BtnConfirmarAvatar.Visible = true;
            PanelURL.Visible = true;
        }

        private void BtnConfirmarAvatar_Click(object sender, EventArgs e)
        {
            BtnConfirmarAvatar.Visible = false;
            PanelURL.Visible = false;

            UtilsBD.CambiarAvatar(UtilsBD.usuarioActual.Id, TxtURLImagen.Text, PicAvatar);
        }

        /* !--- FIN DE EVENTOS DE BOTONES ---! */
    }
}
