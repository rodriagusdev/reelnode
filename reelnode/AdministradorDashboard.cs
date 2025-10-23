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
        public static Dictionary<string, int> usuariosMasActivos = new Dictionary<string, int>();

        public static void CargarUsuarioMasCalificador(Label lblMasCalificador, Label lblCant)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_usuario_mas_calificador", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lblMasCalificador.Text = reader.GetString("nombre_usuario");
                        lblCant.Text = "Total: " +  reader.GetInt32("total_calificaciones").ToString();
                    }
                }
            }
        }

        public static void CargarUsuarioMasComentador(Label lblMasComentador, Label lblCant)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_usuario_mas_comentador", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lblMasComentador.Text = reader.GetString("nombre_usuario");
                        lblCant.Text = reader.GetInt32("total_comentarios").ToString() + " comentarios";
                    }
                }
            }
        }
        public static void CargarUltimoUsuarioRegistrado(Label lblNombre, Label lblFecha, PictureBox picAvatar)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_ultimo_usuario_registrado", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lblNombre.Text = reader.GetString("nombre_usuario");
                        lblFecha.Text = reader.GetDateTime("fecha_registro").ToString("dd/MM/yyyy");
                        picAvatar.Image = Utils.DescargarImagenDesdeURL(reader.GetString("avatar"));
                    }
                }
            }
        }

        public static void CargarUsuariosMasActivos(int limit)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_ranking_usuarios", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_limit", limit);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuariosMasActivos[reader.GetString("nombre_usuario")] = reader.GetInt32("total_visualizaciones");
                    }
                }
            }
        }
        public static void CargarVisualizacionesUltimoMes(Label lbl)
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

        public static void CargarUltimaPelicula(Label lbl, PictureBox pic)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_ultima_pelicula_cargada", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {                      
                        lbl.Text = reader.GetString("nombre");
                        pic.Image = Utils.DescargarImagenDesdeURL(reader.GetString("imagenURL"));
                    }
                }
            }
        }

        public static void CargarUltimaSerie(Label lbl, PictureBox pic)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_ultima_serie_cargada", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lbl.Text = reader.GetString("nombre");
                        pic.Image = Utils.DescargarImagenDesdeURL(reader.GetString("imagenURL"));
                    }
                }
            }
        }

        public static void CargarUsuariosRegistradosUltimoMes(Label lbl)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_cantidad_usuarios_registrados_ultimo_mes", UtilsBD.Conexion.GetConnection()))
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

        public static void CargarUsuariosRegistrados(Label lbl)
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
    }
}
