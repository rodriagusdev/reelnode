using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Reelnode
{
    public static class AdministradorJSON
    {
        public static List<Pelicula> peliculasJSON = new List<Pelicula>();
        public static List<Serie> seriesJSON = new List<Serie>();
        public static void ExportarAudiovisualJSON<A>(List<A> jsonList, string rutaArchivo) where A : Audiovisual
        {
            string jsonstring = JsonSerializer.Serialize(jsonList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, jsonstring);
        }

        public static void ExportarSeriesJSON(List<Serie> json, string rutaArchivo)
        {
            string jsonstring = JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, jsonstring);
        }

        //IMPORTACION A JSON
        // IMPORTAR PELICULAS
        public static void ImportarPeliculasJSON(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException("No se encontró el archivo JSON especificado.");

            string jsonString = File.ReadAllText(rutaArchivo, System.Text.Encoding.UTF8);

            peliculasJSON = JsonSerializer.Deserialize<List<Pelicula>>(jsonString); 
        }

        //IMPORTAR SERIES
        public static void ImportarSeriesJSON(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException("No se encontró el archivo JSON especificado.");

            string jsonString = File.ReadAllText(rutaArchivo, System.Text.Encoding.UTF8);

            seriesJSON = JsonSerializer.Deserialize<List<Serie>>(jsonString);
        }

        // PARA EXPORTAR CUALQUIER DATO DE UN DATA GRID
        public static void ExportarDataGridViewJSON(DataGridView dgv, string rutaArchivo)
        {
            // Crear una lista dinámica donde cada fila será un diccionario
            // Diccionaro porque una celda tiene un nombre y un valor
            var listaFilas = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (!fila.IsNewRow) // Evita la fila vacía al final
                {
                    var filaDict = new Dictionary<string, object>();
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        string nombreColumna = dgv.Columns[celda.ColumnIndex].HeaderText;
                        filaDict[nombreColumna] = celda.Value ?? ""; // si no tiene nada es "";
                    }
                    listaFilas.Add(filaDict);
                }
            }

            // Serializar la lista al JSON
            string jsonString = JsonSerializer.Serialize(listaFilas, new JsonSerializerOptions
            { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            File.WriteAllText(rutaArchivo, jsonString, System.Text.Encoding.UTF8);
        }
    }
}
