using Reelnode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public static class CreadorUI
    {
        /* !--- CREACION DE COMPONENTES BASICOS ---! */

        public static Panel CrearPanel(int width, int height, int margenY)
        {
            Panel panel = new Panel();
            panel.Width = width;
            panel.Height = height;
            panel.Margin = new Padding(0, 0, 0, margenY);
            panel.BackColor = Color.Transparent;
            panel.Tag = "Default";

            return panel;
        }

        public static PictureBox CrearPictureBox(int width, int height, Point p, Image img)
        {
            PictureBox pictureBox = new PictureBox
            {
                Height = height,
                Width = width,
                Location = p,
                Image = img,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
            };

            return pictureBox;
        }

        public static Label CrearLabel(string texto, Point p, int sizeW, int sizeH, string tag)
        {
            Label label = new Label
            {
                Text = texto,
                Font = new Font("Courier New", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = p,
                ForeColor = Color.White,
                Size = new Size(sizeW, sizeH),
                BackColor = Color.Transparent,
                Tag = tag
            };

            return label;
        }

        public static Panel CrearComentario(Comentario c)
        {
            Panel panel = new Panel
            {
                Width = 100,
                MinimumSize = new Size(0, 100),
                MaximumSize = new Size(820, 100),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
            };

            // Avatar
            PictureBox pbAvatar = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(5, 5),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = null,
            };

            // Nombre de usuario
            Label lblUsuario = new Label
            {
                Text = c.Usuario,
                Tag = "Titulo",
                Location = new Point(50, 5),
                AutoSize = true,
            };

            // Fecha de comentario
            Label lblFecha = new Label
            {
                Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                Location = new Point(50, 25),
                ForeColor = Color.Gray,
                AutoSize = true,
            };

            // Comentario
            Label lblTexto = new Label
            {
                Text = c.Texto,
                Tag = "Default",
                Location = new Point(50, 45),
                Size = new Size(700, 100),
                Padding = new Padding(5),
            };

            lblTexto.Width = 1000;

            int textoHeight = lblTexto.PreferredHeight;
            panel.Height = Math.Max(100, 50 + textoHeight);

            panel.Controls.Add(pbAvatar);
            panel.Controls.Add(lblUsuario);
            panel.Controls.Add(lblFecha);
            panel.Controls.Add(lblTexto);

            return panel;
        }

        /* !--- MOSTRAR METRICAS USUARIOS ---! */
        public static void MostrarUltimoUsuarioRegistrado(Label lblNombre, Label lblFecha, PictureBox picAvatar)
        {
            MetricaUsuario ultimoUsuario = AdministradorUsuarios.CargarUltimoUsuarioRegistrado();

            if (ultimoUsuario == null) return;

            lblNombre.Text = ultimoUsuario.NombreUsuario;
            lblFecha.Text = ultimoUsuario.FechaRegistro;
            
            if (!string.IsNullOrEmpty(ultimoUsuario.Avatar))
            {
                picAvatar.Image = Utils.DescargarImagenDesdeURL(ultimoUsuario.Avatar);
            }
        }
        public static void MostrarUsuariosRegistrados(Label lbl)
        {
            lbl.Text = AdministradorUsuarios.CargarUsuariosRegistrados().ToString();
        }

        public static void MostrarUsuariosRegistradosUltimoMes(Label lbl)
        {
            lbl.Text = AdministradorUsuarios.CargarUsuariosRegistradosUltimoMes().ToString();
        }

        public static void MostrarUsuarioMasCalificador(Label lblNombre, Label lblCantidad)
        {
            MostrarMetricaUsuario(AdministradorUsuarios.CargarUsuarioMasCalificador(), lblNombre, lblCantidad);
        }

        public static void MostrarUsuarioMasComentador(Label lblNombre, Label lblCantidad)
        {
            MostrarMetricaUsuario(AdministradorUsuarios.CargarUsuarioMasComentador(), lblNombre, lblCantidad);
        }
        public static void MostrarMetricaUsuario(MetricaUsuario usuario, Label lblNombre, Label lblCantidad)
        {
            if (usuario == null) return;

            lblNombre.Text = usuario.NombreUsuario;
            lblCantidad.Text = usuario.Cantidad.ToString();
        }

        public static void MostrarRankingUsuarios(FlowLayoutPanel flowPnl, int limit)
        {
            flowPnl.Controls.Clear();

            Dictionary<string, int> usuariosMasActivos = AdministradorUsuarios.CargarUsuariosMasActivos(limit);

            if (usuariosMasActivos == null)
            {
                Label lblVacio = new Label
                {
                    Text = "No hay usuarios activos para mostrar.",
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(5)
                };
                flowPnl.Controls.Add(lblVacio);
                return;
            }

            int anchoContenedor = flowPnl.Width - 10;

            // Recorro el diccionario y creo un control por cada elemento
            foreach (KeyValuePair<string, int> usuario in usuariosMasActivos)
            {
                Panel pnlItem = new Panel
                {
                    Width = anchoContenedor,
                    Height = 70,
                    Margin = new Padding(5, 5, 5, 5)
                };

                Label lblUsuarioNombre = new Label
                {
                    Text = usuario.Key,
                    Font = new Font("Consolas", 11, FontStyle.Bold),
                    Width = pnlItem.Width,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 25,
                    Location = new Point(0, 5)
                };
                pnlItem.Controls.Add(lblUsuarioNombre);

                Label lblCantidadVisualizaciones = new Label
                {
                    Text = $"👁 Total: {usuario.Value}",
                    Font = new Font("Consolas", 11),
                    Tag = "Default",
                    Width = pnlItem.Width,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 25,
                    Location = new Point(0, 35)
                };
                pnlItem.Controls.Add(lblCantidadVisualizaciones);

                flowPnl.Controls.Add(pnlItem);
            }
        }

        /* !--- FIN DE METRICAS USUARIOS ---! */


        /* !--- METRICAS GENERALES ---! */

        public static void MostrarTotalVisualizacionesUltimoMes(Label lbl)
        {
            lbl.Text = AdministradorVisualizaciones.CargarVisualizacionesUltimoMes().ToString();
        }

        public static void MostrarUltimaPeliculaRegistrada(Label lbl, PictureBox pic)
        {
            MostrarMetricaAudiovisual(AdministradorPeliculas.CargarUltimaPeliculaRegistrada(), lbl, pic);
        }

        public static void MostrarUltimaSerieRegistrada(Label lbl, PictureBox pic)
        {
            MostrarMetricaAudiovisual(AdministradorSeries.CargarUltimaSerieRegistrada(), lbl, pic);
        }

        public static void MostrarMetricaAudiovisual(MetricaAudiovisual audiovisual, Label lblNombre, PictureBox pic)
        {
            if (audiovisual == null) return;
            
            lblNombre.Text = audiovisual.NombreMedia;

            if (!string.IsNullOrEmpty(audiovisual.ImagenURL))
            {
                pic.Image = Utils.DescargarImagenDesdeURL(audiovisual.ImagenURL);
            }
        }
        
        public static void MostrarGaleriaAudiovisual<T>(FlowLayoutPanel flowPnl, List<T> list, Action<int> abrirPestana, int ancho, int alto) where T : AudiovisualMiniatura
        {
            flowPnl.Controls.Clear();

            /* Configuracion de la tarjeta */
            int anchoTarjeta = ancho;
            int altoPanel = alto;
            int margenY = 0;

            /* Configuracion del poster */
            int anchoPoster = anchoTarjeta - 10;
            int altoPoster = altoPanel-40;
            Point location = new Point(5, 5);

            /* Configuracion del titulo */
            int posicionX = (anchoTarjeta - 200) / 2;
            int posicionY = anchoTarjeta;
            Point posicionTitulo = new Point(posicionX, posicionY);
            int anchoTitulo = anchoTarjeta - 0;
            int altoTitulo = 20;

            foreach (var audiovisual in list)
            {
                // Por cada contenido audiovisual creo una tarjeta (Panel) con su poster y titulo              
                Panel Tarjeta = CrearPanel(anchoTarjeta, altoPanel, margenY);

                PictureBox Poster = CrearPictureBox(anchoPoster, altoPoster, location, Utils.DescargarImagenDesdeURL(audiovisual.ImagenURL));
                // Creo un evento click para abrir la pestana de detalles al hacer click en el poster
                Poster.Click += (s, e) => abrirPestana(audiovisual.Id);

                Label TituloMedia = CrearLabel(audiovisual.Nombre, posicionTitulo, anchoTitulo, altoTitulo, "Titulo");

                // Los agrego al panel, el cual agrego al FlowLayoutPanel de la interfaz del formulario principal
                Tarjeta.Controls.Add(Poster);
                Tarjeta.Controls.Add(TituloMedia);

                flowPnl.Controls.Add(Tarjeta);
            }
        }


        /* !--- METRICAS DE BARRA ---! */
        public static void MostrarAudiovisualMejorCalificados(
            FlowLayoutPanel flowPnl,
            List<AudiovisualMiniatura> listaAudiovisual)
        {
            if (flowPnl == null || listaAudiovisual == null) return;
            if (listaAudiovisual.Count < 1)
            {
                MostrarSinRegistros(flowPnl, "No hay registros de calificaciones");
                return;
            }

            // El valor máximo es fijo para calificaciones
            double maxCalificacion = 5.0;

            ReporteCrearPanelesBarra(
                flowPnl,
                listaAudiovisual,
                audiovisual => (double)audiovisual.CalificacionPromedio,
                maxCalificacion,
                audiovisual => $"{audiovisual.CalificacionPromedio:N1} ★"
            );
        }


        public static void MostrarAudiovisualMasVistos(
            FlowLayoutPanel flowPnl,
            List<AudiovisualMiniatura> listaAudiovisual
            )
        {
            if (flowPnl == null || listaAudiovisual == null) return;

            if (listaAudiovisual.Count < 1) 
            {
                MostrarSinRegistros(flowPnl, "No hay registros de visualizaciones");
                return;
            }

            // El que tenga la mayor cantidad de vistas es el 100% de la barra
            double maxValor = listaAudiovisual.Max(p => p.CantidadVistas);

            ReporteCrearPanelesBarra(
                flowPnl,
                listaAudiovisual,
                audiovisual => audiovisual.CantidadVistas,
                maxValor,
                audiovisual => $"{audiovisual.CantidadVistas:N0} 👁"
            );
        }

        public static void MostrarSinRegistros(FlowLayoutPanel flowPnl, string mensaje)
        {
            Label lblNombre = CrearLabel(mensaje, new Point(2, 2), 200, 20, null);
            lblNombre.AutoSize = true;

            flowPnl.Controls.Add(lblNombre);
        }

        // Func son funciones delegadas, para poder manejar dinamicamente que datos utilizar.

        // La primer Func<AudiovisualMiniatura, decimal> definira ancho que tendra su barra
        // Dependera de:
        // a) la calificacion maxima
        // b) el contenido con la mayor cantidad de de visualizaciones.

        // La segunda Func<AudiovisualMiniatura, string> es para mostrar el texto que yo quiera cuando llame la funcion.

        // Ambas se leen de la siguiente forma:
        // Func<AudiovisualMiniatura, decimal>: La funcion recibe un item AudiovisualMiniatura y devuelve un decimal.
        // La otra lo mismo, pero con string.
        public static void ReporteCrearPanelesBarra(
            FlowLayoutPanel flowPnl,
            List<AudiovisualMiniatura> listaAudiovisual,
            Func<AudiovisualMiniatura, double> obtenerValorBarra,
            double maxValor,
            Func<AudiovisualMiniatura, string> obtenerTextoValor)
        {
            flowPnl.Controls.Clear();
            if (listaAudiovisual.Count < 1) return;

            /* Configuracion del Panel Contenedor */
            int anchoPanelContenedor = 400;
            int altoPanelContenedor = 39;
            int margenVerticalPanelContenedor = 3;

            /* Configuracion del Label Nombre */
            Point posicionNombre = new Point(6, 0);
            string tagLabelNombre = null;

            /* Configuracion del Fondo de la Barra */
            int anchoBarraFondo = 333;
            int altoBarra = 16;
            int margenSuperiorBarra = 20;
            Point posicionFondo = new Point(6, margenSuperiorBarra);
            Color colorFondo = Color.FromArgb(50, 50, 50);

            /* Configuracion del Label Valor */
            Point posicionValor = new Point(posicionFondo.X + anchoBarraFondo + 11, posicionFondo.Y - 3);

            string tagLabelValor = null;

            // !! Los tag de labels son null porque asi son RosaNeon como en el AdministradorTema.

            foreach (var audiovisual in listaAudiovisual)
            {
                // Panel contenedor (Tarjeta)
                Panel panelContenedor = CrearPanel(anchoPanelContenedor, altoPanelContenedor, margenVerticalPanelContenedor);

                Label lblNombre = CrearLabel(audiovisual.Nombre, posicionNombre, 200, 20, tagLabelNombre);
                lblNombre.AutoSize = true;
                panelContenedor.Controls.Add(lblNombre);

                // Fondo de barra
                Panel fondoBarra = CrearPanel(anchoBarraFondo, altoBarra, 0);
                fondoBarra.Location = posicionFondo;
                fondoBarra.BackColor = colorFondo;
                panelContenedor.Controls.Add(fondoBarra);

                // Luego del fondo de barra, calculo el ancho que tendra respecto a ese fondo
                // (USO DEL DELEGADO obtenerValorBarra): devolvera la calificacion maxima, o la mayor cantidad de vistas.
                double porcentajeDeBarra = (double)obtenerValorBarra(audiovisual);

                /* ** Cálculo proporcional: **
                 *  Ejemplo si el valor es calificacion promedio (CP) y el AnchoBarra es 100px:
                 *  El contenido tiene una CP de 3, y el maxValor es 5 (calificacion maxima siempre es 5)
                 * Entonces: ( 3 / 5 ) * AnchoBarra(100px) = 0.6 * 100 = 60px -> el 60% de la barra.
                */
                int anchoBarraCalculoProporcional = (int)((porcentajeDeBarra / maxValor) * anchoBarraFondo);

                // Especifico que el ancho minimo es de 7px.
                anchoBarraCalculoProporcional = Math.Max(7, anchoBarraCalculoProporcional);

                // El tag "Barra" define que sea de color verde
                Panel barra = CrearPanel(anchoBarraCalculoProporcional, fondoBarra.Height, 0);
                barra.Tag = "Barra";
                fondoBarra.Controls.Add(barra);

                // Valor (Total vistas, o calificacion promedio) (USO DEL DELEGADO obtenerTextoValor)
                Label lblValor = CrearLabel(obtenerTextoValor(audiovisual), posicionValor, 100, 20, tagLabelValor);
                lblValor.AutoSize = true;
                panelContenedor.Controls.Add(lblValor);

                flowPnl.Controls.Add(panelContenedor);
            }
        }

        /* !--- FIN METRICAS DE BARRA ---! */


        /* !--- CARGA DE DATOS A COMPONENTES ---! */
        public static void CargarNetwork(ComboBox cbo)
        {
            foreach (Network net in UtilsBD.CargarNetworks())
            {
                cbo.Items.Add(net.Nombre);
            }
            cbo.SelectedIndex = 0;
        }

        public static void CargarGeneros(CheckedListBox chk)
        {
            foreach (Genero gen in UtilsBD.CargarGeneros())
            {
                chk.Items.Add(gen.Nombre);
            }
        }
        public static void CrearPanelesComentarios(FlowLayoutPanel flowPanelComentarios, List<Comentario> comentarios)
        {
            foreach (var c in comentarios)
            {
                Panel panel = CrearComentario(c);
                panel.Width = flowPanelComentarios.ClientSize.Width - panel.Margin.Horizontal;

                flowPanelComentarios.Controls.Add(panel);
            }

            AdministradorTema.AplicarTema(flowPanelComentarios);
        }


        /* !--- FIN DE CARGA DE DATOS A COMPONENTES ---! */
    }
}
