using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reelnode
{
    using System;
    using System.Collections.Generic;

    namespace ProjectoNuevo
    {
        public static class GeneradorPeliculas
        {
            private static Random rnd = new Random();

            private static string[] nombres = { "Inception", "The Matrix", "Interstellar", "The Godfather",
                                           "Pulp Fiction", "Avengers: Endgame", "Titanic", "Jurassic Park",
                                           "The Dark Knight", "Forrest Gump", "Gladiator", "Avatar",
                                           "The Shawshank Redemption", "The Lion King", "Star Wars",
                                           "The Avengers", "Iron Man", "Black Panther", "Wonder Woman", "Joker" };

            private static string[] directores = { "Christopher Nolan", "Quentin Tarantino", "James Cameron",
                                               "Steven Spielberg", "Francis Ford Coppola", "Anthony Russo",
                                               "Joe Russo", "Peter Jackson", "Patty Jenkins", "Todd Phillips" };

            private static string[] descripciones = { "Una historia épica de acción y aventura.",
                                                  "Un drama que cambiará tu vida.",
                                                  "Comedia ligera para toda la familia.",
                                                  "Thriller intenso con giros inesperados.",
                                                  "Un viaje de autodescubrimiento y emoción.",
                                                  "Película de ciencia ficción futurista.",
                                                  "Romance y tragedia entrelazados.",
                                                  "Historia basada en hechos reales.",
                                                  "Animación para todas las edades.",
                                                  "Un mundo de fantasía lleno de aventuras." };

            private static string[] duraciones = { "120 min", "130 min", "140 min", "150 min", "160 min",
                                               "170 min", "180 min", "190 min", "200 min", "210 min" };

            public static void Insertar20PeliculasAleatorias()
            {
                HashSet<int> usados = new HashSet<int>();

                for (int i = 0; i < 20; i++)
                {
                    int idx;
                    do
                    {
                        idx = rnd.Next(nombres.Length);
                    } while (usados.Contains(idx));
                    usados.Add(idx);

                    Pelicula nueva = new Pelicula()
                    {
                        Nombre = nombres[idx],
                        FechaEstreno = RandomFecha(),
                        Descripcion = descripciones[rnd.Next(descripciones.Length)],
                        Director = directores[rnd.Next(directores.Length)],
                        Duracion = int.Parse(duraciones[rnd.Next(duraciones.Length)]),
                        ImagenURL = null // Puedes asignar una imagen por defecto si quieres
                    };

                    // Llamamos a tu método original
                    UtilsBD.InsertarPeliculaBD(nueva);
                }
            }

            private static DateTime RandomFecha()
            {
                int year = rnd.Next(1980, 2024);
                int month = rnd.Next(1, 13);
                int day = rnd.Next(1, 28); // evita problemas con febrero
                return new DateTime(year, month, day);
            }
        }
    }
}
