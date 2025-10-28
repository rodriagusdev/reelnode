using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

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
