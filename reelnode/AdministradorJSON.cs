using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Reelnode
{
    public static class AdministradorJSON
    {
        public static void ExportarPeliculasJSON(List<Pelicula> pelisJson, string rutaArchivo)
        {
            string jsonstring = JsonSerializer.Serialize(pelisJson, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, jsonstring);
        }

        public static void ExportarSeriesJSON(List<Serie> serieJson, string rutaArchivo)
        {
            string jsonstring = JsonSerializer.Serialize(serieJson, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, jsonstring);
        }
    }
}
