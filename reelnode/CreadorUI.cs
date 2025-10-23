using Reelnode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public static class CreadorUI
    {
        public static void ReporteCrearPanelesBarra(
        FlowLayoutPanel flowPnl,
        List<MediaMiniatura> listaMedia,
        string tipoDato)
        {
            if (listaMedia.Count < 1) return;

            double maxValor = 0;
            if (tipoDato == "cantidad_vistas")
            {
                maxValor = listaMedia.Max(p => p.CantidadVistas);
            }

            if (tipoDato == "calificaciones")
            {
                maxValor = 5;
            }

            // 🔸 Escalado 35%
            double escala = 1.30;
            int anchoMaximo = 344;
            int altoPanel = (int)(30 * escala);
            int altoBarra = (int)(12 * escala);
            int margenY = (int)(15 * escala);

            foreach (var media in listaMedia)
            {
                // Panel contenedor
                Panel panelItem = new Panel
                {
                    Width = (int)(anchoMaximo + 52 * escala),
                    Height = altoPanel,
                    BackColor = Color.Transparent,
                    Margin = new Padding(0, 0, 0, (int)(2 * escala)),
                };

                // Label nombre
                Label lblNombre = new Label
                {
                    Text = media.Nombre,
                    ForeColor = Color.White,
                    Font = new Font("Consolas", (float)(8 * escala), FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point((int)(5 * escala), 0)
                };
                panelItem.Controls.Add(lblNombre);

                // Fondo de barra
                Panel fondo = new Panel
                {
                    BackColor = Color.FromArgb(50, 50, 50),
                    Location = new Point((int)(5 * escala), margenY),
                    Size = new Size(anchoMaximo, altoBarra),
                    Tag = "Default"
                };
                panelItem.Controls.Add(fondo);

                // Cálculo proporcional
                decimal calculoProporcional = tipoDato == "cantidad_vistas"
                    ? media.CantidadVistas
                    : media.CalificacionPromedio;

                int anchoBarra = (int)((double)calculoProporcional / (double)maxValor * fondo.Width);
                anchoBarra = Math.Max((int)(5 * escala), anchoBarra);

                // Barra
                Panel barra = new Panel
                {
                    BackColor = Color.FromArgb(255, 100, 0),
                    Size = new Size(anchoBarra, fondo.Height),
                    Location = new Point(0, 0),
                    Tag = "Barra"
                };
                fondo.Controls.Add(barra);

                // ---- VISTAS ----
                if (tipoDato == "cantidad_vistas")
                {
                    Label lblValor = new Label
                    {
                        Text = $"{media.CantidadVistas:N0} 👁",
                        ForeColor = Color.White,
                        Font = new Font("Consolas", (float)(8 * escala), FontStyle.Regular),
                        AutoSize = true
                    };

                    panelItem.Controls.Add(lblValor);
                    lblValor.Location = new Point(fondo.Right + (int)(8 * escala), fondo.Top - (int)(2 * escala));
                }

                // ---- CALIFICACIONES ----
                if (tipoDato == "calificaciones")
                {
                    Label lblValor = new Label
                    {
                        Text = $"{media.CalificacionPromedio:N1} ★",
                        ForeColor = Color.White,
                        Font = new Font("Consolas", (float)(8.5 * escala), FontStyle.Regular),
                        AutoSize = true
                    };

                    panelItem.Controls.Add(lblValor);
                    lblValor.Location = new Point(fondo.Right + (int)(8 * escala), fondo.Top - (int)(2 * escala));
                }

                flowPnl.Controls.Add(panelItem);
            }
        }

        public static void PintarRankingUsuarios(FlowLayoutPanel flowPnl)
        {
            flowPnl.Controls.Clear();

            if (AdministradorDashboard.usuariosMasActivos.Count == 0)
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

            // Iterar sobre el diccionario y crear un control por cada elemento
            foreach (KeyValuePair<string, int> usuario in AdministradorDashboard.usuariosMasActivos)
            {
                Panel pnlItem = new Panel
                {
                    Width = anchoContenedor,
                    Height = 70, 
                    BackColor = Color.FromArgb(30, 30, 40), 
                    Margin = new Padding(5, 5, 5, 5)
                };

                // Label del Nombre 
                Label lblUsuario = new Label
                {
                    Text = usuario.Key,
                    Font = new Font("Consolas", 11, FontStyle.Bold),
                    ForeColor = Color.White,
                    Width = pnlItem.Width, 
                    AutoSize = false,     
                    TextAlign = ContentAlignment.MiddleCenter,
                    Height = 25,
                    Location = new Point(0, 5) 
                };
                pnlItem.Controls.Add(lblUsuario);


                // Label de la Cantidad de Visualizaciones
                Label lblCantidadVisualizaciones = new Label
                {
                    Text = $"👁 Total: {usuario.Value:N0}",
                    Font = new Font("Consolas", 11),
                    Tag = "Default",
                    ForeColor = Color.LightGray,
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
    }
}
