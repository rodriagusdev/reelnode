using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                            NombreUsuario = reader.GetString("nombre_usuario"),
                            Password = reader.GetString("password_usuario"),
                            Email = reader.GetString("email_usuario"),
                            RolUsuario = reader.GetString("nombre_rol")
                        };

                        usuariosRegistrados.Add(u);
                    }
                }
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

        public static void InsertarPeliculaBD(Pelicula nuevaPelicula)
        {
            MessageBox.Show("2");
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertar_pelicula", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_nombre", nuevaPelicula.Nombre);
                    cmd.Parameters.AddWithValue("p_fecha", nuevaPelicula.FechaEstreno);
                    cmd.Parameters.AddWithValue("p_descripcion", nuevaPelicula.Descripcion);
                    cmd.Parameters.AddWithValue("p_director", nuevaPelicula.Director);
                    cmd.Parameters.AddWithValue("p_imagen", nuevaPelicula.Imagen);
                    cmd.Parameters.AddWithValue("p_duracion", nuevaPelicula.Duracion);

                    cmd.ExecuteNonQuery();

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
                        Pelicula nueva = new Pelicula
                        {
                            Id = reader.GetInt32("id_pelicula"),
                            Nombre = reader.GetString("nombre"),
                            FechaEstreno = reader.GetDateTime("fecha_estreno"),
                            Director = reader.GetString("director"),
                            Duracion = reader.GetString("duracion"),
                            Descripcion = reader.GetString("descripcion"),
                            Imagen = reader.GetString("imagen")
                        };

                        peliculasCargadas.Add(nueva);
                    }
                }
            }
        }

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

        public static void ActualizarPelicula(Pelicula actualizarPelicula)
        {
            MessageBox.Show(actualizarPelicula.Id.ToString());
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
                    cmd.Parameters.AddWithValue("p_imagen", actualizarPelicula.Imagen);
                    cmd.Parameters.AddWithValue("p_duracion", actualizarPelicula.Duracion);

                    cmd.ExecuteNonQuery();

                    peliculasCargadas.Clear();
                    UtilsBD.CargarPeliculas();

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

        public static bool ActualizarSerie(
       int idSerie,
       string nombre,
       DateTime fechaEstreno,
       string descripcion,
       string director,
       string imagen,
       int cantTemporadas,
       int? idNetwork)
        {
            using (MySqlConnection conn = Conexion.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand("sp_actualizar_serie", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_serie", idSerie);
                cmd.Parameters.AddWithValue("p_nombre", nombre);
                cmd.Parameters.AddWithValue("p_fecha_estreno", fechaEstreno);
                cmd.Parameters.AddWithValue("p_descripcion", string.IsNullOrEmpty(descripcion) ? (object)DBNull.Value : descripcion);
                cmd.Parameters.AddWithValue("p_director", string.IsNullOrEmpty(director) ? (object)DBNull.Value : director);
                cmd.Parameters.AddWithValue("p_imagen", string.IsNullOrEmpty(imagen) ? (object)DBNull.Value : imagen);
                cmd.Parameters.AddWithValue("p_cant_temporadas", cantTemporadas);
                cmd.Parameters.AddWithValue("p_id_network", idNetwork.HasValue ? (object)idNetwork.Value : DBNull.Value);
                try
                {
                    conn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar serie: " + ex.Message);
                    return false;
                }
            }
        }

        public static bool InsertarSerieBD(
                        string nombre,
                        DateTime fechaEstreno,
                        DateTime? fechaFin,
                        string descripcion,
                        string director,
                        string imagen,
                        int cantTemporadas,
                        int? idNetwork)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertar_serie", Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_nombre", nombre);
                    cmd.Parameters.AddWithValue("p_fecha_estreno", fechaEstreno);
                    cmd.Parameters.AddWithValue("p_fecha_fin", fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("p_descripcion", string.IsNullOrEmpty(descripcion) ? (object)DBNull.Value : descripcion);
                    cmd.Parameters.AddWithValue("p_director", string.IsNullOrEmpty(director) ? (object)DBNull.Value : director);
                    cmd.Parameters.AddWithValue("p_imagen", string.IsNullOrEmpty(imagen) ? (object)DBNull.Value : imagen);
                    cmd.Parameters.AddWithValue("p_cant_temporadas", cantTemporadas);
                    cmd.Parameters.AddWithValue("p_id_network", idNetwork.HasValue ? (object)idNetwork.Value : DBNull.Value);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar serie: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /*
         * public static void CargarSeries()
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
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString("descripcion"),
                                Director = reader.IsDBNull(reader.GetOrdinal("director")) ? null : reader.GetString("director"),
                                Imagen = reader.IsDBNull(reader.GetOrdinal("imagen")) ? null : reader.GetString("imagen"),
                                CantTemporadas = reader.GetInt32("cant_temporadas"),
                                IdNetwork = reader.IsDBNull(reader.GetOrdinal("id_network")) ? (int?)null : reader.GetInt32("id_network")
                            };

                            seriesCargadas.Add(nueva);
                        }
                    }
                }
            }
        }*/
    }
}