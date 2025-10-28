using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        //IMPORTAR SERIES JSON
        private void BtnImportarSeriesJSON_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos JSON (*.json)|*.json";
            openFileDialog.Title = "Importar series desde JSON";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var seriesImportadas = AdministradorJSON.ImportarSeriesJSON(openFileDialog.FileName);

                    // Guardar en la lista principal
                    AdministradorSeries.seriesCargadas = seriesImportadas;

                    MessageBox.Show("Series importadas correctamente.", "Importación exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al importar series: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //EXPORTAR SERIES JSON
        private void BtnExportarJSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivos JSON (*.json)| *.json";
            saveFileDialog.Title = "Exportar series JSON";
            saveFileDialog.FileName = "series.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                AdministradorJSON.ExportarSeriesJSON(AdministradorSeries.seriesCargadas, saveFileDialog.FileName);
            }
        }
    }
}
