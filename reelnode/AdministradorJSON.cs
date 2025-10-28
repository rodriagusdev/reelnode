using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace Reelnode
{
    public static class AdministradorJSON
    {
        //EXPORTACION A JSON
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

        //IMPORTACION A JSON
        // IMPORTAR PELICULAS
        public static List<Pelicula> ImportarPeliculasJSON(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException("No se encontró el archivo JSON especificado.");

            string jsonString = File.ReadAllText(rutaArchivo, System.Text.Encoding.UTF8);

            var listaPeliculas = JsonSerializer.Deserialize<List<Pelicula>>(jsonString);
            foreach (var item in listaPeliculas) 
            {
                MessageBox.Show(item.Nombre);
            }

            return listaPeliculas ?? new List<Pelicula>();
        }

        //IMPORTAR SERIES
        public static List<Serie> ImportarSeriesJSON(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException("No se encontró el archivo JSON especificado.");

            string jsonString = File.ReadAllText(rutaArchivo, System.Text.Encoding.UTF8);

            var listaSeries = JsonSerializer.Deserialize<List<Serie>>(jsonString);

            return listaSeries ?? new List<Serie>();
        }

        //MANEJO DE DATOS DINAMICOS
        public static void ExportarDataGridViewJSON(DataGridView dgv, string rutaArchivo)
        {
            // Crear una lista dinámica donde cada fila será un diccionario
            var listaFilas = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (!fila.IsNewRow) // Evita la fila vacía al final
                {
                    var filaDict = new Dictionary<string, object>();
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        string nombreColumna = dgv.Columns[celda.ColumnIndex].HeaderText;
                        filaDict[nombreColumna] = celda.Value ?? "";
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
