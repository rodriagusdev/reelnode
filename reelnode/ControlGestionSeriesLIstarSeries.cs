using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionSeriesListarSeries : UserControl
    {
        private PanelGradiente PanelMain;
        public ControlGestionSeriesListarSeries()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(PanelListar);
            this.Controls.Add(PanelMain);
        }

        private void ControlGestionSeriesListarSeries_Load(object sender, EventArgs e)
        {
            Utils.ActualizarListaGrid(DataGridSeries, AdministradorSeries.seriesCargadas, "Id", "Tipo");
        }

        private void BtnExportarJSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivos JSON (*.json)| *.json";
            saveFileDialog.Title = "Exportar series JSON";
            saveFileDialog.FileName = "series.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                AdministradorJSON.ExportarAudiovisualJSON(AdministradorSeries.seriesCargadas, saveFileDialog.FileName);
            }
        
        }

        public static void ExportarDataGridViewJSON(DataGridView dgv, string rutaArchivo)
        {
            // Diccionario porque cada celda tiene un nombre y un valor
            var listaFilas = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (!fila.IsNewRow) // Evita la fila vacía al final
                {
                    var filaDict = new Dictionary<string, object>();
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        string nombreColumna = dgv.Columns[celda.ColumnIndex].HeaderText;
                        filaDict[nombreColumna] = celda.Value ?? ""; // Si no tiene valor es ""
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
