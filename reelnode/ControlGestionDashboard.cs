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
        string URLUsuarioAvatarActual = null;

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
            if(UtilsBD.usuarioActual.Avatar != null) 
            {
                PicAvatar.Image = Utils.DescargarImagenDesdeURL(UtilsBD.usuarioActual.Avatar);
            }

            LblUsuario.Text = UtilsBD.usuarioActual.NombreUsuario;
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
            AdministradorReportesAvanzados.ObtenerReporteAvanzadoSeries(
                TxtPalabrasTitulo.Text,
                CboGeneros.SelectedItem?.ToString(),
                TxtDirector.Text,
                CboNetwork.SelectedItem?.ToString(),
                DtpDesde.Value,
                DtpHasta.Value,
                DataGridReportes
            );

            /*string query = "";

            // Determinar tabla segun tipo de reporte en combobox
            // WHERE 1=1 permite agregar condiciones con AND sin que tire error
            if (CboTipoReporte.SelectedItem?.ToString() == "Peliculas")
            {
                query = @"
                SELECT p.nombre, p.fecha_estreno, p.descripcion, p.director, p.duracion
                FROM peliculas p
                WHERE 1=1  
                ";
            }
            else if (CboTipoReporte.SelectedItem?.ToString() == "Series")
            {
                query = @"
                SELECT s.titulo, COUNT(v.id_visualizacion) AS vistas
                FROM serie s
                INNER JOIN series_vistas v ON s.id_serie = v.id_serie
                WHERE 1=1
                ";
            }
            else
            {
                MessageBox.Show("Seleccioná un tipo de reporte válido (Películas o Series).");
                return;
            }

            // Filtro de género (si se selecciona uno)
            if (CboGeneros.SelectedIndex > 0)
            {
                // query += $" AND p.genero = '{CboGeneros.SelectedItem}'";
            }

            // Filtro de fechas 
            if (DtpDesde.Value <= DtpHasta.Value)
            {
                query += $" AND p.fecha_estreno BETWEEN '{DtpDesde.Value:yyyy-MM-dd}' AND '{DtpHasta.Value:yyyy-MM-dd}'";
            }
            else
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.");
                return;
            }

            // Agrupación y orden
            query += " GROUP BY p.nombre, p.fecha_estreno, p.descripcion, p.director, p.duracion ORDER BY p.fecha_estreno DESC;";

            MySqlConnection conn = UtilsBD.Conexion.GetConnection();

            // 2️⃣ Ejecutar consulta y llenar DataTable
            // Usamos la conexión obtenida, que debe estar abierta.
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // 3️⃣ Asignar el DataTable al DataGridView
            DataGridReportes.DataSource = dt;

            // 4️⃣ Limpieza de recursos
            // *Es crucial:* Cierra el DataAdapter para liberar recursos,
            // pero NO cierres la conexión (conn.Close() o UtilsBD.Conexion.CerrarBD()),
            // ya que es la conexión compartida de toda la aplicación.
            da.Dispose();*/
        }

        private void ControlGestionDashboard_VisibleChanged(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }
    }
}
