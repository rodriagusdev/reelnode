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
using System.IO;
using System.Text.Json;

namespace Reelnode
{
    public partial class ControlGestionPeliculasListarPeliculas : UserControl
    {
        private PanelGradiente PanelMain;
        public ControlGestionPeliculasListarPeliculas()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(PanelListar);
            this.Controls.Add(PanelMain);
        }

        private void ControlGestionPeliculasListarPeliculas_Load(object sender, EventArgs e)
        {
            Utils.ActualizarListaGrid(DataGridPeliculas, AdministradorPeliculas.peliculasCargadas, "Id", "Tipo");
        }
        //EXPORTAR PELIS JSON
        private void BtnExportarJSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivos JSON (*.json)| *.json";
            saveFileDialog.Title = "Exportar peliculas JSON";
            saveFileDialog.FileName = "peliculas.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                AdministradorJSON.ExportarPeliculasJSON(AdministradorPeliculas.peliculasCargadas, saveFileDialog.FileName);
            }
        }

        //IMPORTAR PELIS A JSON
        private void BtnImportarPeliculasJSON_Click_1(object sender, EventArgs e)
        {
            //IMPORTAR PELIS
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos JSON (*.json)|*.json";
            openFileDialog.Title = "Importar películas desde JSON";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var peliculasImportadas = AdministradorJSON.ImportarPeliculasJSON(openFileDialog.FileName);

                    // Guardar en la lista principal
                    AdministradorPeliculas.peliculasCargadas = peliculasImportadas;

                    MessageBox.Show("Películas importadas correctamente.", "Importación exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al importar películas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
