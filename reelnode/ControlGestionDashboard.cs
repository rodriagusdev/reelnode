using MySql.Data.MySqlClient;
using ProjectoNuevo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionDashboard: UserControl
    {
        private PanelGradiente PanelMain;
        bool usarCalificacionMinima = false;
        bool usarDuracionMinima = false;

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
            /* !--- CARGA DE DATOS ---! */

            AdministradorDashboard.CargarTopVistas(5, "peliculas", UtilsBD.pelisMasVistas);
            AdministradorDashboard.CargarTopVistas(5, "series", UtilsBD.seriesMasVistas);
            AdministradorDashboard.CargarTopCalificaciones(5, "peliculas", AdministradorCalificaciones.peliculasCalificadasUsuario);
            AdministradorDashboard.CargarTopCalificaciones(5, "series", AdministradorCalificaciones.seriesCalificadasUsuario);
            AdministradorDashboard.CargarUltimoUsuarioRegistrado(LblUsuarioNombreUltimo, LblFechaRegistroUltimo, PicUltimo);
            AdministradorDashboard.CargarUsuariosMasActivos(3);

            /* !--- FIN CARGA DE DATOS ---! */


            /* !--- MOSTRAR DATOS EN UI ---! */

            // De los datos de visualizaciones y calificaciones creo los paneles de barra correspondientes
         
            CreadorUI.ReporteCrearPanelesBarra(flowPanelPelisMasVistas, UtilsBD.pelisMasVistas, "cantidad_vistas");
            CreadorUI.ReporteCrearPanelesBarra(flowPanelSeriesMasVistas, UtilsBD.seriesMasVistas, "cantidad_vistas");
            CreadorUI.ReporteCrearPanelesBarra(flowPanelPeliculasMejorCalificadas, AdministradorCalificaciones.peliculasCalificadasUsuario, "calificaciones");
            CreadorUI.ReporteCrearPanelesBarra(flowPanelSeriesMejorCalificadas, AdministradorCalificaciones.seriesCalificadasUsuario, "calificaciones");
            CreadorUI.PintarRankingUsuarios(FlowPanelMasActivos);

            foreach (Genero gen in UtilsBD.generosCargados)
            {
                CboGeneros.Items.Add(gen.Nombre);
            }

            foreach (string network in UtilsBD.networksCargadas.ConvertAll(n => n.Nombre))
            {
                CboNetwork.Items.Add(network);
            }
            // Estos datos se cargan y se muestran directamente

            AdministradorDashboard.CargarVisualizacionesUltimoMes(LblVisualizacionesUltimoMes);
            AdministradorDashboard.CargarUsuariosRegistrados(LblUsuariosRegistrados);
            AdministradorDashboard.CargarUsuariosRegistradosUltimoMes(LblUsuariosRegistradosUltimoMes);
            AdministradorDashboard.CargarUsuarioMasCalificador(LblUsuarioMasCalificador, LblCantidadCalif);
            AdministradorDashboard.CargarUsuarioMasComentador(LblUsuarioMasComentador, LblCantidadComentario);
            AdministradorDashboard.CargarUltimaPelicula(LblUltimaPeli, PicUltimaPelicula);
            AdministradorDashboard.CargarUltimaSerie(LblUltimaSerie, PicUltimaSerie);
            /* !--- FIN DE MUESTRA DE DATOS ---! */
        }

        private void CargarDatosUsuario()
        {
            if(AdministradorUsuarios.usuarioActual.Avatar != null) 
            {
                PicAvatar.Image = Utils.DescargarImagenDesdeURL(AdministradorUsuarios.usuarioActual.Avatar);
            }

            LblUsuario.Text = AdministradorUsuarios.usuarioActual.NombreUsuario;
        }

        /* !--- VISIBILIDAD DE PANELES ---! */
        private void MostrarPanel(Panel panelMostrar)
        {
            List<Panel> allPanels = new List<Panel> { PanelDashboardMain, PanelDashboardMetricasUsuario, PanelReportesAvanzados };

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


        /* !--- FILTROS DE REPORTES AVANZADOS ---! */
        private void ChkFiltroCalif_CheckedChanged(object sender, EventArgs e)
        {
            NumUpCalificacionMinima.Enabled = ChkFiltroCalif.Checked;
            usarCalificacionMinima = ChkFiltroCalif.Checked;
        }


        private void ChkDuracion_CheckedChanged(object sender, EventArgs e)
        {
            NumUpDuracion.Enabled = ChkDuracion.Checked;
            usarDuracionMinima = ChkFiltroCalif.Checked;
        }

        private void BtnAplicarFiltrosConsultar_Click(object sender, EventArgs e)
        {
            switch (CboTipoReporte.Text)
            {
                case "Películas":
                    AdministradorReportesAvanzados.ObtenerReporteAvanzadoPeliculas(
                        TxtPalabrasTitulo.Text,
                        CboGeneros.SelectedItem?.ToString(),
                        TxtDirector.Text,
                        CboNetwork.SelectedItem?.ToString(),
                        DtpDesde.Value,
                        DtpHasta.Value,
                        DataGridReportes
                    );
                    break;
                case "Series":
                    AdministradorReportesAvanzados.ObtenerReporteAvanzadoSeries(
                        TxtPalabrasTitulo.Text,
                        CboGeneros.SelectedItem?.ToString(),
                        TxtDirector.Text,
                        CboNetwork.SelectedItem?.ToString(),
                        DtpDesde.Value,
                        DtpHasta.Value,
                        DataGridReportes
                    );
                    break;
                default:
                    MessageBox.Show("Seleccioná un tipo de reporte válido (Películas o Series).");
                    break;
            }
        }

        private void ControlGestionDashboard_VisibleChanged(object sender, EventArgs e)
        {
            CargarDatosUsuario();
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

        private void BtnExportarPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog documentoPDF = new SaveFileDialog();
            documentoPDF.Filter = "Archivos PDF (*.pdf |* .pdf)";
            documentoPDF.FileName = "Reportes Metricas.pdf";

            if (documentoPDF.ShowDialog() == DialogResult.OK) 
            { 
                AdministradorPDF.ExportadorDashboard(documentoPDF.FileName);
                MessageBox.Show("Reporte PDF generado correctamente", "Exito al generar el documento", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
}
