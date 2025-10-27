using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Reelnode
{
    public static class AdministradorAudiovisual
    {
        /* !--- CARGA DE DATOS AUDIOVISUALES (PELICULAS Y SERIES) ---! */
        public static List<AudiovisualMiniatura> CargarMiniaturaAudiovisual(string procedimiento, EnumTipoId idTipo)
        {
            List<AudiovisualMiniatura> listAudiovisual = new List<AudiovisualMiniatura>();

            using (MySqlCommand cmd = new MySqlCommand(procedimiento, UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AudiovisualMiniatura preview = new AudiovisualMiniatura
                        (
                            reader.GetInt32(idTipo.ToString()),
                            reader.GetString("nombre"),
                            reader.GetString("imagenURL")
                        );

                        listAudiovisual.Add(preview);
                    }
                }
            }

            return listAudiovisual;
        }

        public static List<Audiovisual> CargarAudiovisualCompleto(string procedimiento, EnumTipoId idTipo)
        {
            List<Audiovisual> listAudiovisual = new List<Audiovisual>();

            using (MySqlCommand cmd = new MySqlCommand(procedimiento, UtilsBD.Conexion.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Audiovisual contenido;

                        /* DATOS PROPIOS (Depende del tipo segun el enumerado) */
                        if (idTipo == EnumTipoId.id_pelicula)
                        {
                            contenido = new Pelicula
                            {
                                Duracion = reader.GetInt32("duracion")
                            };
                        }
                        else
                        {
                            contenido = new Serie
                            {
                                Temporadas = reader.GetInt32("cant_temporadas"),
                                FechaFin = reader.GetDateTime("fecha_fin"),
                            };
                        }

                        /* FIN DATOS PROPIOS */


                        /* DATOS COMPARTIDOS */

                        contenido.Id = reader.GetInt32(idTipo.ToString());
                        contenido.Nombre = reader.GetString("nombre");
                        contenido.FechaEstreno = reader.GetDateTime("fecha_estreno");
                        contenido.Director = reader.GetString("director");
                        contenido.Descripcion = reader.GetString("descripcion");
                        contenido.ImagenURL = reader.GetString("imagenURL");
                        contenido.TrailerURL = reader.GetString("trailerURL");
                        contenido.Network = reader.GetInt32("id_network");
                        contenido.Generos = reader.IsDBNull(reader.GetOrdinal("generos"))
                            ? new List<int>()
                            : reader.GetString("generos").Split(',')
                                .Select(s => int.Parse(s))
                                .ToList();

                        /* FIN DATOS COMPARTIDOS */

                        listAudiovisual.Add(contenido);
                    }
                }
            }

            return listAudiovisual;
        }

        /* !--- FIN CARGA DE DATOS AUDIOVISUALES (PELICULAS Y SERIES) ---! */


        /* !--- INSERTS Y UPDATES DE DATOS AUDIOVISUALES (PELICULAS Y SERIES) ---! */


        public static void EnviarDatosAudiovisual(MySqlCommand cmd, Audiovisual audiovisual, EnumTipoId tipoId)
        {
            if (audiovisual is Pelicula pelicula)
            {
                cmd.Parameters.AddWithValue("p_duracion", pelicula.Duracion);
            }

            if (audiovisual is Serie serie)
            {
                cmd.Parameters.AddWithValue("p_cant_temporadas", serie.Temporadas);
                cmd.Parameters.AddWithValue("p_fecha_fin", serie.FechaFin);
            }

            cmd.Parameters.AddWithValue("p_id_usuario", AdministradorUsuarios.usuarioActual.Id);
            cmd.Parameters.AddWithValue("p_nombre", audiovisual.Nombre);
            cmd.Parameters.AddWithValue("p_fecha_estreno", audiovisual.FechaEstreno);
            cmd.Parameters.AddWithValue("p_descripcion", string.IsNullOrEmpty(audiovisual.Descripcion) ? (object)DBNull.Value : audiovisual.Descripcion);
            cmd.Parameters.AddWithValue("p_director", string.IsNullOrEmpty(audiovisual.Director) ? (object)DBNull.Value : audiovisual.Director);
            cmd.Parameters.AddWithValue("p_imagenURL", string.IsNullOrEmpty(audiovisual.ImagenURL) ? (object)DBNull.Value : audiovisual.ImagenURL);
            cmd.Parameters.AddWithValue("p_id_network", audiovisual.Network);
            cmd.Parameters.AddWithValue("p_trailerURL", string.IsNullOrEmpty(audiovisual.TrailerURL) ? (object)DBNull.Value : audiovisual.TrailerURL);
        }

        public static void EnviarGenerosAudiovisual(Audiovisual audiovisual, EnumTipoId tipoId, int id)
        {
            string procedimientoGeneros = "";
            string mensajeExito = "";

            if (tipoId == EnumTipoId.p_id_pelicula)
            {
                procedimientoGeneros = "sp_insertar_genero_por_peli";
                mensajeExito = "Operación de pelicula exitosa!";
            }

            if (tipoId == EnumTipoId.p_id_serie)
            {
                procedimientoGeneros = "sp_insertar_genero_por_serie";
                mensajeExito = "Operación de serie exitosa!";
            }

            foreach (int idGenero in audiovisual.Generos)
            {
                try
                {
                    using (MySqlCommand cmdGenero = new MySqlCommand(procedimientoGeneros, UtilsBD.Conexion.GetConnection()))
                    {
                        cmdGenero.CommandType = CommandType.StoredProcedure;

                        cmdGenero.Parameters.AddWithValue(tipoId.ToString(), id == 0 ? audiovisual.Id : id);
                        cmdGenero.Parameters.AddWithValue("p_id_genero", idGenero);
                        cmdGenero.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show(mensajeExito, "Operación Exitosa",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }
        public static bool InsertarAudiovisual(Audiovisual audiovisual, string procedimiento, EnumTipoId tipoId)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(procedimiento, UtilsBD.Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    EnviarDatosAudiovisual(cmd, audiovisual, tipoId);

                    /* OBTENCION PARAMETRO OUT */

                    // Parámetro OUT que devuelve sp_insertar_pelicula
                    // para obtener el ID utilizando LastInsertId() 

                    var obtenerUltimoId = new MySqlParameter(tipoId.ToString(), MySqlDbType.Int32);
                    obtenerUltimoId.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(obtenerUltimoId);

                    cmd.ExecuteNonQuery();

                    int idAudiovisual = Convert.ToInt32(obtenerUltimoId.Value);

                    /* FIN OBTENCION PARAMETRO OUT */

                    EnviarGenerosAudiovisual(audiovisual, tipoId, idAudiovisual);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar contenido audiovisual! " + ex.Message);
                return false;
            }
        }
        public static bool ActualizarAudiovisual(Audiovisual audiovisual, string procedimiento, EnumTipoId tipoId)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(procedimiento, UtilsBD.Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    EnviarDatosAudiovisual(cmd, audiovisual, tipoId);
                    // tipoId Envia p_id_pelicula, o p_id_serie, y el id audiovisual es necesario
                    // para hacer le update en el procedimiento
                    cmd.Parameters.AddWithValue(tipoId.ToString(), audiovisual.Id);

                    cmd.ExecuteNonQuery();

                    EnviarGenerosAudiovisual(audiovisual, tipoId, 0);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar! " + ex.Message);
            }

            return false;
        }

        /* !--- ELIMINACION DE CONTENIDO AUDIOVISUAL */
        public static bool EliminarAudiovisual(string procedimiento, int id, string mensaje)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(procedimiento, UtilsBD.Conexion.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_id_usuario", AdministradorUsuarios.usuarioActual.Id);
                    cmd.Parameters.AddWithValue("p_id", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(mensaje, "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Excepción",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }

        /* !--- OTRAS FUNCIONES ---! */
        public static int ObtenerIdAudiovisual()
        {
            if (AdministradorPeliculas.peliculaSeleccionada != null) return AdministradorPeliculas.peliculaSeleccionada.Id;

            // Si es null se selecciono una serie, entonces devuelvo un Id de serie
            return AdministradorSeries.serieSeleccionada.Id;
        }

    }
}
