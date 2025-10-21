using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Reelnode
{
    public static class AdministradorDashboard
    {
        public static void CargarVisualizacionesUltimoMes(System.Windows.Forms.Label lbl)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_visualizaciones_ultimo_mes", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lbl.Text = reader.GetInt32("total_visualizaciones").ToString();
                    }
                }
            }
        }

        public static void CargarUsuariosRegistradosUltimoMes(System.Windows.Forms.Label lbl)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_usuarios_registrados_ultimo_mes", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lbl.Text = reader.GetInt32("usuarios_registrados").ToString();
                    }
                }
            }
        }

        public static void CargarUsuariosRegistrados(System.Windows.Forms.Label lbl)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_cantidad_usuarios", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lbl.Text = reader.GetInt32("usuarios_registrados").ToString();
                    }
                }
            }
        }
        public static void CargarTopVistas(int limit, string tipo, List<MediaMiniatura> list)
        {
            string procedure = "";
            string idMediaColumna = "";

            if (tipo == "peliculas")
            {
                procedure = "sp_historial_peliculas";
                idMediaColumna = "id_pelicula";
            }
            else
            {
                procedure = "sp_historial_series";
                idMediaColumna = "id_serie";
            }

            using (MySqlCommand cmd = new MySqlCommand(procedure, UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_limite", limit);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MediaMiniatura p = new MediaMiniatura
                        {
                            Id = reader.GetInt32(idMediaColumna),
                            Nombre = reader.GetString("nombre"),
                            CantidadVistas = reader.GetInt32("veces_visto"),
                        };

                        if (tipo == "peliculas")
                        {
                            list.Add(p);
                        }
                        else
                        {
                            list.Add(p);
                        }
                    }
                }
            }
        }

        public static void CargarTopCalificaciones(int limit, string tipo, List<MediaMiniatura> list)
        {
            string procedure = "";
            string idMediaColumna = "";

            if (tipo == "peliculas")
            {
                procedure = "sp_top_calificaciones_peliculas";
                idMediaColumna = "id_pelicula";
            }
            else
            {
                procedure = "sp_top_calificaciones_series";
                idMediaColumna = "id_serie";
            }

            using (MySqlCommand cmd = new MySqlCommand(procedure, UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_limite", limit);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MediaMiniatura p = new MediaMiniatura
                        {
                            Id = reader.GetInt32(idMediaColumna),
                            Nombre = reader.GetString("nombre"),
                            CalificacionPromedio = reader.GetDecimal("promedio_calificacion"),
                        };

                        if (tipo == "peliculas")
                        {
                            list.Add(p);
                        }
                        else
                        {
                            list.Add(p);
                        }
                    }
                }
            }
        }

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
    }
}
