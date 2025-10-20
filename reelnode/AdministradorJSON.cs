using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Reelnode;

namespace ProjectoNuevo
{
    public static class AdministradorJSON
    {
        public static void ExportarPeliculasJSON(List<Pelicula> pelisJson)
        {
            //creo el nombre de ruta para el archivo

            string archivoPeli = "peliculas.json";

            //serializo la lista de pelis
            string jsonstring = JsonSerializer.Serialize(pelisJson, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(archivoPeli, jsonstring);
        }

        //Para exportar las series a JSON

        public static void ExportarSeriesJSON(List<Serie> serieJson)
        {
            //creo el nombre de ruta para el archivo
            string archivoSerie = "series.json";

            //serializo la lista de series
            string jsonstring = JsonSerializer.Serialize(serieJson, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(archivoSerie, jsonstring);
        }
    }
}
