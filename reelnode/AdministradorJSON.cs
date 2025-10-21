using Reelnode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
