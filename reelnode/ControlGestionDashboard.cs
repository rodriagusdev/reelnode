using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionDashboard : UserControl
    {
        private PanelGradiente PanelMain;
        bool usarCalificacionMinima = false;
        bool usarDuracionMinima = false;
        bool usarCantTemporadas = false;
        bool usarNetwork = false;
        bool usarGeneros = false;

        public ControlGestionDashboard()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Tag = "Default";
            PanelMain.Dock = DockStyle.Fill;

            PanelMain.Controls.Add(PanelMenu);
            PanelMain.Controls.Add(PanelDashboardMain);
            PanelMain.Controls.Add(PanelReportesAvanzados);
            PanelMain.Controls.Add(PanelDashboardMetricasUsuario);

            this.Controls.Add(PanelMain);

            FlowPanelMasActivos.HorizontalScroll.Visible = false;
        }

        private void ControlGestionDashboard_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            CargarDatosDashboard();

            AdministradorTema.AplicarTema(this);
        }

        private void CargarDatosDashboard()
        {
            /* !--- MOSTRAR DATOS EN UI ---! */

            /* !--- MOSTRAR METRICAS GENERALES EN UI ---! */
            CreadorUI.MostrarTotalVisualizacionesUltimoMes(LblVisualizacionesUltimoMes);

            CreadorUI.MostrarUltimaSerieRegistrada(LblUltimaSerie, PicUltimaSerie);
            CreadorUI.MostrarUltimaPeliculaRegistrada(LblUltimaPeli, PicUltimaPelicula);

            CreadorUI.MostrarAudiovisualMasVistos(
                flowPanelSeriesMasVistas,
                AdministradorSeries.CargarSeriesMasVistas(5)
            );
            CreadorUI.MostrarAudiovisualMasVistos(
                flowPanelPelisMasVistas,
                AdministradorPeliculas.CargarPeliculasMasVistas(5)
            );

            CreadorUI.MostrarAudiovisualMejorCalificados(
                flowPanelSeriesMejorCalificadas,
                AdministradorSeries.CargarSeriesMejorCalificadas(5)
            );
            CreadorUI.MostrarAudiovisualMejorCalificados(
                flowPanelPeliculasMejorCalificadas,
                AdministradorPeliculas.CargarPeliculasMejorCalificadas(5)
            );
            /* !--- FIN DE METRICAS GENERALES ---! */

            /* !--- MOSTRAR METRICAS DE USUARIO EN UI ---! */

            CreadorUI.MostrarRankingUsuarios(FlowPanelMasActivos, 5);
            CreadorUI.MostrarUsuariosRegistrados(LblUsuariosRegistrados);
            CreadorUI.MostrarUsuariosRegistradosUltimoMes(LblUsuariosRegistradosUltimoMes);
            CreadorUI.MostrarUsuarioMasCalificador(LblUsuarioMasCalificador, LblCantidadCalif);
            CreadorUI.MostrarUsuarioMasComentador(LblUsuarioMasComentador, LblCantidadComentario);
            CreadorUI.MostrarUltimoUsuarioRegistrado(
                LblUsuarioNombreUltimo,
                LblFechaRegistroUltimo,
                PicUltimo
            );

            /* !--- FIN DE METRICAS DE USUARIO ---! */

            foreach (Genero gen in UtilsBD.CargarGeneros())
            {
                CboGeneros.Items.Add(gen.Nombre);
            }

            foreach (Network network in UtilsBD.CargarNetworks())
            {
                CboNetwork.Items.Add(network.Nombre);
            }

            CboTipoReporte.SelectedIndex = 0;
        }

        /* !--- FILTROS DE REPORTES AVANZADOS Y VISIBILIDAD DE COMPONENTES ---! */
        private void ChkFiltroCalif_CheckedChanged(object sender, EventArgs e)
        {
            NumUpCalificacionMinima.Enabled = ChkFiltroCalif.Checked;
            usarCalificacionMinima = ChkFiltroCalif.Checked;
        }

        private void ChkDuracion_CheckedChanged(object sender, EventArgs e)
        {
            NumUpDuracion.Enabled = ChkDuracion.Checked;
            usarDuracionMinima = ChkDuracion.Checked;
        }

        private void ChkFiltroCantTemporadas_CheckedChanged(object sender, EventArgs e)
        {
            usarCantTemporadas = ChkFiltroCantTemporadas.Checked;
            NumUpCantTemporadas.Enabled = ChkFiltroCantTemporadas.Checked;
        }

        private void ChkFiltroGenero_CheckedChanged(object sender, EventArgs e)
        {
            CboGeneros.Enabled = ChkFiltroGenero.Checked;
            usarGeneros = ChkFiltroGenero.Checked;
        }

        private void ChkFiltroNetwork_CheckedChanged(object sender, EventArgs e)
        {
            CboNetwork.Enabled = ChkFiltroNetwork.Checked;
            usarNetwork = ChkFiltroNetwork.Checked;
        }

        private void CboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboTipoReporte.Text == "Peliculas")
            {

                ChkFiltroCantTemporadas.Visible = false;
                ChkFiltroCantTemporadas.Enabled = false;

                NumUpCantTemporadas.Visible = false;
                NumUpCantTemporadas.Enabled = false;

                ChkDuracion.Visible = true;
                ChkDuracion.Enabled = true;

                NumUpDuracion.Visible = true;
                NumUpDuracion.Enabled = true;
            }
            else
            {
                ChkDuracion.Visible = false;
                ChkDuracion.Enabled = false;
                NumUpDuracion.Visible = false;
                NumUpDuracion.Enabled = false;

                ChkFiltroCantTemporadas.Visible = true;
                ChkFiltroCantTemporadas.Enabled = true;

                NumUpCantTemporadas.Visible = true;
                NumUpCantTemporadas.Enabled = true;
            }
        }

        private void BtnAplicarFiltrosConsultar_Click(object sender, EventArgs e)
        {
            switch (CboTipoReporte.Text)
            {
                case "Peliculas":
                    AdministradorReportesAvanzados.ObtenerReporteAvanzadoPeliculas(
                        TxtPalabrasTitulo.Text,
                        usarGeneros == true ? CboGeneros.SelectedItem?.ToString() : "",
                        TxtDirector.Text,
                        usarNetwork == true ? CboNetwork.SelectedItem?.ToString() : "",
                        DtpDesde.Value,
                        DtpHasta.Value,
                        usarDuracionMinima == true ? Convert.ToInt32(NumUpDuracion.Value) : 0,
                        usarCalificacionMinima == true
                            ? Convert.ToInt32(NumUpCalificacionMinima.Value)
                            : 0,
                        DataGridReportes
                    );
                    break;
                case "Series":
                    AdministradorReportesAvanzados.ObtenerReporteAvanzadoSeries(
                        TxtPalabrasTitulo.Text,
                        usarGeneros == true ? CboGeneros.SelectedItem?.ToString() : "",
                        TxtDirector.Text,
                        usarNetwork == true ? CboNetwork.SelectedItem?.ToString() : "",
                        DtpDesde.Value,
                        DtpHasta.Value,
                        usarCantTemporadas == true ?  Convert.ToInt32(NumUpCantTemporadas.Value)
                            : 0,
                        usarCalificacionMinima == true
                            ? Convert.ToInt32(NumUpCalificacionMinima.Value)
                            : 0,
                        DataGridReportes
                    );
                    break;
                default:
                    MessageBox.Show("Seleccioná un tipo de reporte válido (Películas o Series).");
                    break;
            }
        }

        private void BtnBorrarFiltros_Click(object sender, EventArgs e)
        {
            TxtDirector.Text = "";
            TxtPalabrasTitulo.Text = "";
            CboGeneros.SelectedIndex = -1;
            CboNetwork.SelectedIndex = -1;
            DtpDesde.Value = DateTime.Now;
            DtpHasta.Value = DateTime.Now;
            NumUpCalificacionMinima.Value = 1;
            NumUpDuracion.Value = 1;
            ChkDuracion.Checked = false;
            ChkFiltroCalif.Checked = false;
        }

        /* !--- FIN DE FILTROS DE REPORTES AVANZADOS ---! */

        /* !--- VISIBILIDAD DE PANELES ---! */
        private void MostrarPanel(Panel panelMostrar)
        {
            List<Panel> allPanels = new List<Panel>
            {
                PanelDashboardMain,
                PanelDashboardMetricasUsuario,
                PanelReportesAvanzados,
            };

            foreach (Panel panel in allPanels)
            {
                panel.Visible = false;
            }

            panelMostrar.Visible = true;
            panelMostrar.Dock = DockStyle.Right;
            panelMostrar.Size = new Size(1028, 720);
        }

        private void BtnVerMetricasUsuarios_Click(object sender, EventArgs e)
        {
            MostrarPanel(PanelDashboardMetricasUsuario);
        }

        private void BtnVerMetricasGenerales_Click(object sender, EventArgs e)
        {
            MostrarPanel(PanelDashboardMain);
        }

        private void BtnReportesAvanzados_Click(object sender, EventArgs e)
        {
            MostrarPanel(PanelReportesAvanzados);
        }

        /* !--- FIN DE VISIBILIDAD DE PANELES ---! */

        private void CargarDatosUsuario()
        {
            if (AdministradorUsuarios.usuarioActual.Avatar != null)
            {
                PicAvatar.Image = Utils.DescargarImagenDesdeURL(
                    AdministradorUsuarios.usuarioActual.Avatar
                );
            }

            LblUsuario.Text = AdministradorUsuarios.usuarioActual.NombreUsuario;
        }

        private void ControlGestionDashboard_VisibleChanged(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        /* !--- EXPORTACION PDF ---! */
        private void BtnExportarTodoPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF (*.pdf)|*.pdf";
            saveFile.FileName = "ReporteGeneral.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                AdministradorPDF.ExportadorDashboard(saveFile.FileName);
            }
        }

        private void BtnExportarGrilla_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF (*.pdf)|*.pdf";
            saveFile.FileName = $"ReporteGrilla{CboTipoReporte.Text.ToUpper()}.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                AdministradorPDF.ExportarDataGridToPDF(DataGridReportes, saveFile.FileName);
            }
        }



        /* !--- FIN EXPORTACION PDF ---! */
    }
}
