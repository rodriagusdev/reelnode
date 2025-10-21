using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlCuentaUsuario : UserControl
    {
        private PanelGradiente PanelMain;

        private List<Pelicula> peliculasCalificadas = new List<Pelicula>();
        private List<Serie> seriesCalificadas = new List<Serie>();

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
            /* !--- CARGAR DATOS DE USUARIO ---! */

            PicAvatar.Image = Utils.DescargarImagenDesdeURL(UtilsBD.usuarioActual.Avatar);
            LblEmail.Text = UtilsBD.usuarioActual.Email;
            LblUsuario.Text = UtilsBD.usuarioActual.NombreUsuario;
            UtilsBD.CargarCalificacionesUsuario(UtilsBD.usuarioActual.Id, peliculasCalificadas);
            UtilsBD.CargarCalificacionesUsuarioSerie(UtilsBD.usuarioActual.Id, seriesCalificadas);

            /* !--- FIN DE CARGADO ---! */

            /* !--- RELLENAR FLOW PANELS CON DATOS ---! */

            Utils.RellenarFlowPanel(FlowPanelPeliculas, peliculasCalificadas, AbrirPelicula);
            Utils.RellenarFlowPanel(FlowPanelSeries, seriesCalificadas, AbrirSerie);

            /* !--- FIN DE RELLENO ---! */
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
