using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            string query = @"
            INSERT INTO usuario (nombre_usuario, password_usuario, email_usuario, avatar, fecha_registro, id_rol) 
            VALUES (@nombre, @password, @email, @avatar, @fecha_registro, @rol);";

            using (MySqlCommand cmd = new MySqlCommand(query, Conexion.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@nombre", nuevoUsuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@password", nuevoUsuario.Password);
                cmd.Parameters.AddWithValue("@email", nuevoUsuario.Email);
                cmd.Parameters.AddWithValue("@avatar", null);
                cmd.Parameters.AddWithValue("@fecha_registro", nuevoUsuario.FechaRegistro);
                cmd.Parameters.AddWithValue("@rol", ObtenerRolUsuario(nuevoUsuario.RolUsuario));

                cmd.ExecuteNonQuery();

                usuariosRegistrados.Add(nuevoUsuario);
            }
        }

        public static void ModificarUsuarioBD(DataGridView data)
        {
            string nombreUsuario = data.CurrentRow.Cells["NombreUsuario"].Value.ToString();

            if(nombreUsuario == usuarioActual.NombreUsuario)
            {
                MessageBox.Show("No puedes modificar tu propio rol mientras estás logueado.", "Modificación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string query = @"
            UPDATE usuario
            SET id_rol = @idRol
            WHERE nombre_usuario = @usuario;";

            using (MySqlCommand cmd = new MySqlCommand(query, Conexion.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@idRol", data.Tag.ToString());

                cmd.ExecuteNonQuery();             
            }
        }

        public static void CargarUsuario()
        {
            usuariosRegistrados.Clear();

            string query =
                "SELECT " +
                "u.nombre_usuario, " +
                "u.password_usuario, " +
                "u.email_usuario," +
                "r.tipo_rol as nombre_rol\r\n" +
                "FROM usuario u\r\n" +
                "INNER JOIN rol r on r.id_rol = u.id_rol;";

            using (MySqlCommand cmd = new MySqlCommand(query, UtilsBD.Conexion.GetConnection()))
            {
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
                string query = @"
                INSERT INTO peliculas (nombre, fecha_estreno, descripcion, director, imagen, duracion) 
                VALUES (@nombre, @fecha_estreno, @descripcion, @director, @imagen, @duracion);";

                using (MySqlCommand cmd = new MySqlCommand(query, Conexion.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@nombre", nuevaPelicula.Nombre);
                    cmd.Parameters.AddWithValue("@fecha_estreno", nuevaPelicula.FechaEstreno);
                    cmd.Parameters.AddWithValue("@descripcion", nuevaPelicula.Descripcion);
                    cmd.Parameters.AddWithValue("@director", nuevaPelicula.Director);
                    cmd.Parameters.AddWithValue("@imagen", nuevaPelicula.Imagen);
                    cmd.Parameters.AddWithValue("@duracion", nuevaPelicula.Duracion);
                    cmd.ExecuteNonQuery();

                    peliculasCargadas.Add(nuevaPelicula);

                    MessageBox.Show("Pelicula cargada con éxito", "Carga Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.
                    Information);
                }
            } catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }
            
        }

        public static void CargarPeliculas()
        {

            string query =
                "SELECT " +
                "p.id_pelicula," +
                "p.nombre, " +
                "p.fecha_estreno, " +
                "p.director," +
                "p.descripcion," +
                "p.duracion\r\n" +
                "FROM peliculas p\r\n";

            using (MySqlCommand cmd = new MySqlCommand(query, UtilsBD.Conexion.GetConnection()))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pelicula nueva = new Pelicula();
                        {
                            nueva.Id = reader.GetInt32("id_pelicula");
                            nueva.Nombre = reader.GetString("nombre");
                            nueva.FechaEstreno = reader.GetDateTime("fecha_estreno");
                            nueva.Director = reader.GetString("director");
                            nueva.Duracion = reader.GetString("duracion");
                            nueva.Descripcion = reader.GetString("descripcion");
                        }

                        peliculasCargadas.Add(nueva);
                    }
                }
            }
        }

        public static void EliminarPelicula(int id) 
        {
            try
            {
                string query =
                    "DELETE " +
                    "FROM peliculas " +
                    "WHERE id_pelicula = @idPeli";

                using (MySqlCommand cmd = new MySqlCommand(query, Conexion.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@idPeli", id);
               
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
            catch (Exception e) { }
        }

        public static void ActualizarPelicula(Pelicula actualizarPelicula) 
        {
            MessageBox.Show(actualizarPelicula.Id.ToString());

            try
            {
                string query = "UPDATE peliculas SET " +
               "nombre = @nombre, " +
               "descripcion = @descripcion, " +
               "director = @director, " +
               "imagen = @imagen, " +
               "duracion = @duracion " +
               "WHERE id_pelicula = @idPelicula";

                using (MySqlCommand cmd = new MySqlCommand(query, Conexion.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@nombre", actualizarPelicula.Nombre);
                    cmd.Parameters.AddWithValue("@fecha_estreno", actualizarPelicula.FechaEstreno);
                    cmd.Parameters.AddWithValue("@descripcion", actualizarPelicula.Descripcion);
                    cmd.Parameters.AddWithValue("@director", actualizarPelicula.Director);
                    cmd.Parameters.AddWithValue("@imagen", actualizarPelicula.Imagen);
                    cmd.Parameters.AddWithValue("@duracion", actualizarPelicula.Duracion);
                    cmd.Parameters.AddWithValue("@idPelicula", actualizarPelicula.Id);

                    cmd.ExecuteNonQuery();

                    peliculasCargadas.Clear();
                    UtilsBD.CargarPeliculas();

                    MessageBox.Show("Pelicula cargada con éxito", "Carga Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.
                    Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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