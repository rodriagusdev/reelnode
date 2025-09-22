using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public static class UtilsBD
    {
        public static ConexionBD Conexion = new ConexionBD();

        public static Usuario usuarioActual = new Usuario();
        public static List<Usuario> usuariosRegistrados = new List<Usuario>();
        public static List<Pelicula> peliculasCargadas = new List<Pelicula>();

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
                            Descripcion = reader.GetString("descripcion")
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
    }
}
/*nombre VARCHAR(255) NOT NULL,
    fecha_estreno DATE NOT NULL,
    descripcion VARCHAR(255),
    director VARCHAR(255),
    imagen MEDIUMBLOB,
    duracion VARCHAR(50)*/