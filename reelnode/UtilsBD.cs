using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public static class UtilsBD
    {
        public static ConexionBD Conexion = new ConexionBD();

        public static Usuario usuarioActual = new Usuario();
        public static List<Usuario> usuariosRegistrados = new List<Usuario>();
        public static List<Pelicula> peliculasCargadas = new List<Pelicula>();
        public static List<Serie> seriesCargadas = new List<Serie>();
        public static List<Network> networksCargadas = new List<Network>();
        public static List<Genero> generosCargados = new List<Genero>();

        // USUARIOS: Registro, login, modificación.
        public static void RegistrarUsuarioBD(Usuario nuevoUsuario)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_insertar_usuario", Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_nombre", nuevoUsuario.NombreUsuario);
                cmd.Parameters.AddWithValue("p_password", nuevoUsuario.Password);
                cmd.Parameters.AddWithValue("p_email", nuevoUsuario.Email);
                cmd.Parameters.AddWithValue("p_avatar", null);
                cmd.Parameters.AddWithValue("p_fecha_registro", nuevoUsuario.FechaRegistro);
                cmd.Parameters.AddWithValue("p_id_rol", ObtenerRolUsuario(nuevoUsuario.RolUsuario));

                cmd.ExecuteNonQuery();

                usuariosRegistrados.Add(nuevoUsuario);
            }
        }

        public static void ModificarUsuarioBD(DataGridView data)
        {
            string nombreUsuario = data.CurrentRow.Cells["NombreUsuario"].Value.ToString();

            if (nombreUsuario == usuarioActual.NombreUsuario)
            {
                MessageBox.Show("No puedes modificar tu propio rol mientras estás logueado.", "Modificación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (MySqlCommand cmd = new MySqlCommand("sp_modificar_rol_usuario", Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre_usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("p_id_rol", data.Tag.ToString());

                cmd.ExecuteNonQuery();
            }
        }
        private static string ObtenerRolUsuario(string rol)
        {
            switch (rol)
            {
                case "Admin":
                    return "1";
                case "Usuario":
                    return "2";
                default:
                    return "2";
            }
        }

        // CARGA DE DATOS
        public static void CargarUsuario()
        {
            usuariosRegistrados.Clear();

            using (MySqlCommand cmd = new MySqlCommand("sp_listar_usuarios", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario u = new Usuario()
                        {
                            Id = reader.GetInt32("id_usuario"),
                            NombreUsuario = reader.GetString("nombre_usuario"),
                            Password = reader.GetString("password_usuario"),
                            Email = reader.GetString("email_usuario"),
                            RolUsuario = reader.GetString("nombre_rol"),
                            FechaRegistro = reader.GetDateTime("fecha_registro"),
                            Avatar = reader.IsDBNull(reader.GetOrdinal("avatar")) ? null : reader.GetString("avatar"),
                        };

                        usuariosRegistrados.Add(u);
                    }
                }
            }
        }

        public static void CargarNetwork()
        {
            string procedure = "sp_listar_network";

            using (MySqlCommand cmd = new MySqlCommand(procedure, Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Network net = new Network(reader.GetInt32("id_network"), reader.GetString("nombre"));
                        networksCargadas.Add(net);
                    }
                }
            }
        }

        public static void CargarGeneros()
        {
            string procedure = "sp_listar_generos";

            using (MySqlCommand cmd = new MySqlCommand(procedure, Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Genero gen = new Genero(reader.GetInt32("id_genero"), reader.GetString("nombre"));
                        generosCargados.Add(gen);
                    }
                }
            }
        }
        public static void CargarPeliculas()
        {
            peliculasCargadas.Clear();

            using (MySqlCommand cmd = new MySqlCommand("sp_listar_peliculas", UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pelicula = new Pelicula
                        {
                            Id = reader.GetInt32("id_pelicula"),
                            Nombre = reader.GetString("nombre"),
                            FechaEstreno = reader.GetDateTime("fecha_estreno"),
                            Director = reader.GetString("director"),
                            Descripcion = reader.GetString("descripcion"),
                            ImagenURL = reader.GetString("imagenURL"),
                            Duracion = reader.GetInt32("duracion"),
                            TrailerURL = reader.GetString("trailerURL"),
                            Network = reader.GetInt32("id_network"),
                            Generos = reader.IsDBNull(reader.GetOrdinal("generos"))
                            ? new List<int>() // si no tiene géneros. La coma es el separador por defecto de la columna "generos" del SP
                            : reader.GetString("generos").Split(',')
                                .Select(s => int.Parse(s))
                                .ToList()
                        };

                        peliculasCargadas.Add(pelicula);
                    }
                }
            }
        }
        public static void CargarSeries()
        {
            seriesCargadas.Clear();

            using (MySqlCommand cmd = new MySqlCommand("sp_listar_series", Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Serie nueva = new Serie
                        {
                            Id = reader.GetInt32("id_serie"),
                            Nombre = reader.GetString("nombre"),
                            FechaEstreno = reader.GetDateTime("fecha_estreno"),
                            FechaFin = reader.GetDateTime("fecha_fin"),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString("descripcion"),
                            Director = reader.IsDBNull(reader.GetOrdinal("director")) ? null : reader.GetString("director"),
                            ImagenURL = reader.IsDBNull(reader.GetOrdinal("imagenURL")) ? null : reader.GetString("imagenURL"),
                            Temporadas = reader.GetInt32("cant_temporadas"),
                            Network = reader.GetInt32("id_network"),
                            TrailerURL = reader.IsDBNull(reader.GetOrdinal("trailerURL")) ? null : reader.GetString("trailerURL"),
                            Generos = reader.IsDBNull(reader.GetOrdinal("generos"))
                            ? new List<int>() // si no tiene géneros. La coma es el separador por defecto de la columna "generos" del SP
                            : reader.GetString("generos").Split(',')
                                .Select(s => int.Parse(s))
                                .ToList()
                        };

                        seriesCargadas.Add(nueva);
                    }
                }
            }
        }

        // INSERTS
        public static void InsertarSerieBD(Serie nuevaSerie)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertar_serie", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_nombre", nuevaSerie.Nombre);
                    cmd.Parameters.AddWithValue("p_fecha_estreno", nuevaSerie.FechaEstreno);
                    cmd.Parameters.AddWithValue("p_fecha_fin", nuevaSerie.FechaFin);
                    cmd.Parameters.AddWithValue("p_descripcion", string.IsNullOrEmpty(nuevaSerie.Descripcion) ? (object)DBNull.Value : nuevaSerie.Descripcion);
                    cmd.Parameters.AddWithValue("p_director", string.IsNullOrEmpty(nuevaSerie.Director) ? (object)DBNull.Value : nuevaSerie.Director);
                    cmd.Parameters.AddWithValue("p_imagenURL", string.IsNullOrEmpty(nuevaSerie.ImagenURL) ? (object)DBNull.Value : nuevaSerie.ImagenURL);
                    cmd.Parameters.AddWithValue("p_trailerURL", string.IsNullOrEmpty(nuevaSerie.TrailerURL) ? (object)DBNull.Value : nuevaSerie.TrailerURL);
                    cmd.Parameters.AddWithValue("p_cant_temporadas", nuevaSerie.Temporadas);
                    cmd.Parameters.AddWithValue("p_id_network", nuevaSerie.Network);

                    // Parámetro OUT de sp_insertar_serie para obtener el ID utilizando LastInsertId()
                    // NECESARIO PARA PODER INSERTAR LOS GENEROS EN LA TABLA PIVOTE

                    var obtenerUltimoIdSerie = new MySqlParameter("p_id_serie", MySqlDbType.Int32);
                    obtenerUltimoIdSerie.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(obtenerUltimoIdSerie);

                    cmd.ExecuteNonQuery();

                    int idPelicula = Convert.ToInt32(obtenerUltimoIdSerie.Value);

                    foreach (int idGenero in nuevaSerie.Generos)
                    {
                        using (MySqlCommand cmdGenero = new MySqlCommand("sp_insertar_genero_por_serie", Conexion.GetConnection()))
                        {
                            cmdGenero.CommandType = CommandType.StoredProcedure;

                            cmdGenero.Parameters.AddWithValue("p_id_serie", idPelicula);
                            cmdGenero.Parameters.AddWithValue("p_id_genero", idGenero);
                            cmdGenero.ExecuteNonQuery();
                        }
                    }

                    
                    MessageBox.Show("Serie cargada con éxito", "Carga Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar serie: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static void InsertarPeliculaBD(Pelicula nuevaPelicula)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertar_pelicula", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_usuario", usuarioActual.Id);
                    cmd.Parameters.AddWithValue("p_nombre", nuevaPelicula.Nombre);
                    cmd.Parameters.AddWithValue("p_fecha", nuevaPelicula.FechaEstreno);
                    cmd.Parameters.AddWithValue("p_descripcion", nuevaPelicula.Descripcion);
                    cmd.Parameters.AddWithValue("p_director", nuevaPelicula.Director);
                    cmd.Parameters.AddWithValue("p_imagenURL", nuevaPelicula.ImagenURL);
                    cmd.Parameters.AddWithValue("p_duracion", nuevaPelicula.Duracion);
                    cmd.Parameters.AddWithValue("p_trailerURL", nuevaPelicula.TrailerURL);
                    cmd.Parameters.AddWithValue("p_id_network", nuevaPelicula.Network);

                    // Parámetro OUT de sp_insertar_pelicula para obtener el ID utilizando LastInsertId()

                    var obtenerUltimoIdPelicula = new MySqlParameter("p_id_pelicula", MySqlDbType.Int32);
                    obtenerUltimoIdPelicula.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(obtenerUltimoIdPelicula);

                    cmd.ExecuteNonQuery();

                    int idPelicula = Convert.ToInt32(obtenerUltimoIdPelicula.Value);

                    foreach (int idGenero in nuevaPelicula.Generos)
                    {
                        using (MySqlCommand cmdGenero = new MySqlCommand("sp_insertar_genero_por_peli", Conexion.GetConnection()))
                        {
                            cmdGenero.CommandType = CommandType.StoredProcedure;

                            cmdGenero.Parameters.AddWithValue("p_id_pelicula", idPelicula);
                            cmdGenero.Parameters.AddWithValue("p_id_genero", idGenero);
                            cmdGenero.ExecuteNonQuery();
                        }
                    }

                    peliculasCargadas.Add(nuevaPelicula);

                    MessageBox.Show("Película cargada con éxito", "Carga Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // UPDATES

        public static void ActualizarPelicula(Pelicula actualizarPelicula)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_actualizar_pelicula", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id", actualizarPelicula.Id);
                    cmd.Parameters.AddWithValue("p_nombre", actualizarPelicula.Nombre);
                    cmd.Parameters.AddWithValue("p_fecha_estreno", actualizarPelicula.FechaEstreno);
                    cmd.Parameters.AddWithValue("p_descripcion", actualizarPelicula.Descripcion);
                    cmd.Parameters.AddWithValue("p_director", actualizarPelicula.Director);
                    cmd.Parameters.AddWithValue("p_imagenURL", actualizarPelicula.ImagenURL);
                    cmd.Parameters.AddWithValue("p_duracion", actualizarPelicula.Duracion);
                    cmd.Parameters.AddWithValue("p_id_network", actualizarPelicula.Network);
                    cmd.Parameters.AddWithValue("p_trailerURL", actualizarPelicula.TrailerURL);

                    cmd.ExecuteNonQuery();

                    foreach (int idGenero in actualizarPelicula.Generos)
                    {
                        using (MySqlCommand cmdGenero = new MySqlCommand("sp_insertar_genero_por_peli", Conexion.GetConnection()))
                        {
                            cmdGenero.CommandType = CommandType.StoredProcedure;

                            cmdGenero.Parameters.AddWithValue("p_id_pelicula", actualizarPelicula.Id);
                            cmdGenero.Parameters.AddWithValue("p_id_genero", idGenero);
                            cmdGenero.ExecuteNonQuery();
                        }
                    }

                    peliculasCargadas.Clear();
                    CargarPeliculas();

                    MessageBox.Show("Película actualizada con éxito", "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la película: " + ex.Message);
            }
        }

        public static bool CambiarPassword(string nombreUsuario, string email, string nuevaPassword)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_actualizar_password", Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre_usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("p_email", email);
                cmd.Parameters.AddWithValue("p_nueva_password", nuevaPassword);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public static void ActualizarSerie(Serie actualizarSerie)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_actualizar_serie", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_serie", actualizarSerie.Id);
                    cmd.Parameters.AddWithValue("p_nombre", actualizarSerie.Nombre);
                    cmd.Parameters.AddWithValue("p_fecha_estreno", actualizarSerie.FechaEstreno);
                    cmd.Parameters.AddWithValue("P_fecha_fin", actualizarSerie.FechaFin);
                    cmd.Parameters.AddWithValue("p_descripcion", string.IsNullOrEmpty(actualizarSerie.Descripcion) ? (object)DBNull.Value : actualizarSerie.Descripcion);
                    cmd.Parameters.AddWithValue("p_director", string.IsNullOrEmpty(actualizarSerie.Director) ? (object)DBNull.Value : actualizarSerie.Director);
                    cmd.Parameters.AddWithValue("p_imagenURL", string.IsNullOrEmpty(actualizarSerie.ImagenURL) ? (object)DBNull.Value : actualizarSerie.ImagenURL);
                    cmd.Parameters.AddWithValue("p_cant_temporadas", actualizarSerie.Temporadas);
                    cmd.Parameters.AddWithValue("p_id_network", actualizarSerie.Network);
                    cmd.Parameters.AddWithValue("p_trailerURL", string.IsNullOrEmpty(actualizarSerie.TrailerURL) ? (object)DBNull.Value : actualizarSerie.TrailerURL);
               
                    cmd.ExecuteNonQuery();

                    foreach (int idGenero in actualizarSerie.Generos)
                    {
                        using (MySqlCommand cmdGenero = new MySqlCommand("sp_insertar_genero_por_serie", Conexion.GetConnection()))
                        {
                            cmdGenero.CommandType = CommandType.StoredProcedure;

                            cmdGenero.Parameters.AddWithValue("p_id_serie", actualizarSerie.Id);
                            cmdGenero.Parameters.AddWithValue("p_id_genero", idGenero);
                            cmdGenero.ExecuteNonQuery();
                        }
                    }

                    seriesCargadas.Clear();
                    CargarSeries();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar serie: " + ex.Message);
            }          
        }

        // DELETES
        public static void EliminarPelicula(int id)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_eliminar_pelicula_sin_trasaccion", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Película eliminada con éxito", "Eliminación Exitosa",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        peliculasCargadas.Clear();
                        CargarPeliculas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar!", "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Excepción",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        public static void EliminarSerie(int id)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_eliminar_serie_con_temporadas", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Serie y sus temporadas eliminadas con éxito", "Eliminación Exitosa",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        seriesCargadas.Clear();
                        CargarSeries();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la serie!", "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Excepción",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // LISTADOS DE COMENTARIOS, CALIFICACIONES Y VISUALIZACIONES

        public static void CargarComentariosPelicula(int idUsuario)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_listar_comentarios_pelicula", Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_pelicula", idUsuario);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pelicula = new Pelicula
                        {
                            Id = reader.GetInt32("id_pelicula"),
                            Nombre = reader.GetString("nombre"),
                            FechaEstreno = reader.GetDateTime("fecha_estreno"),
                            Director = reader.GetString("director"),
                            Descripcion = reader.GetString("descripcion"),
                            ImagenURL = reader.GetString("imagenURL"),
                            Duracion = reader.GetInt32("duracion"),
                            TrailerURL = reader.GetString("trailerURL"),
                            Network = reader.GetInt32("id_network"),
                            Generos = reader.IsDBNull(reader.GetOrdinal("generos"))
                            ? new List<int>() // si no tiene géneros. La coma es el separador por defecto de la columna "generos" del SP
                            : reader.GetString("generos").Split(',')
                                .Select(s => int.Parse(s))
                                .ToList()
                        };

                        peliculasCargadas.Add(pelicula);
                    }
                }
            }
        }

        public static void CargarCalificaciones(int idUsuario, List<Pelicula> peliculasCalificadas)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_calificaciones_x_usuario", Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pelicula = new Pelicula
                        {
                            Id = reader.GetInt32("id_pelicula"),
                            Nombre = reader.GetString("nombre"),
                            ImagenURL = reader.GetString("imagenURL"),
                        };

                        peliculasCalificadas.Add(pelicula);
                    }
                }
            }
        }

        public static void CargarCalificacionesSerie(int idUsuario, List<Serie> seriesCalificadas)
        {
            using (MySqlCommand cmd = new MySqlCommand("sp_obtener_calificaciones_x_usuario_serie", Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pelicula = new Serie
                        {
                            Id = reader.GetInt32("id_serie"),
                            Nombre = reader.GetString("nombre"),
                            ImagenURL = reader.GetString("imagenURL"),
                        };

                        seriesCalificadas.Add(pelicula);
                    }
                }
            }
        }

        // ACCIONES

        public static void CambiarAvatar(int idUsuario, string URL)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_actualizar_avatar_usuario", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_usuario", idUsuario);
                    cmd.Parameters.AddWithValue("p_url", URL);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Película actualizada con éxito", "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la película: " + ex.Message);
            }
        }

        public static void Calificar(int idMedia, int puntuacion, string tipo)
        {
            string procedure = tipo == "Pelicula" ? "sp_calificar_pelicula" : "sp_calificar_serie";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(procedure, Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_pelicula", idMedia);
                    cmd.Parameters.AddWithValue("p_calificacion", puntuacion);
                    cmd.Parameters.AddWithValue("p_id_usuario", usuarioActual.Id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Calificacion enviada", "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calificar la " + tipo == "Pelicula" ? "pelicula": "serie" + ex.Message);
            }
        }

        public static void Comentar(int idMedia, string comentario, string tipo)
        {
            string procedure = tipo == "Pelicula" ? "sp_comentar_pelicula" : "sp_comentar_serie";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(procedure, Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_usuario", usuarioActual.Id);
                    cmd.Parameters.AddWithValue("p_id_pelicula", idMedia);
                    cmd.Parameters.AddWithValue("p_texto", comentario);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Comentario enviado", "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calificar la " + tipo == "Pelicula" ? "pelicula" : "serie" + ex.Message);
            }
        }
    } 
}