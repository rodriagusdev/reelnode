using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
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
            Utils.ActualizarListaGrid(
                DataGridSeries,
                AdministradorSeries.seriesCargadas,
                "Id",
                "Tipo"
            );
        }

        private void BtnExportarJSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivos JSON (*.json)| *.json";
            saveFileDialog.Title = "Exportar series JSON";
            saveFileDialog.FileName = "series.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                AdministradorJSON.ExportarAudiovisualJSON(
                    AdministradorSeries.seriesCargadas,
                    saveFileDialog.FileName
                );
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
            string jsonString = JsonSerializer.Serialize(
                listaFilas,
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                }
            );
            File.WriteAllText(rutaArchivo, jsonString, System.Text.Encoding.UTF8);
        }

        private void BtnImportarJSON_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos JSON (*.json)| *.json";
            openFileDialog.Title = "Importar series JSON";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var peliculasImportadas = AdministradorJSON.ImportarPeliculasJSON(
                        openFileDialog.FileName
                    );

                    AdministradorPeliculas.peliculasCargadas = peliculasImportadas;

                    MessageBox.Show(
                        "Series importadas correctamente.",
                        "Importación exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al importar películas: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}

