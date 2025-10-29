using System;
using System.Windows.Forms;

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

        private void BtnExportarJSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivos JSON (*.json)| *.json";
            saveFileDialog.Title = "Exportar peliculas JSON";
            saveFileDialog.FileName = "peliculas.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                AdministradorJSON.ExportarAudiovisualJSON(AdministradorPeliculas.peliculasCargadas, saveFileDialog.FileName);
            }
        }

        private void BtnImportarJSON_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos JSON (*.json)| *.json";
            openFileDialog.Title = "Importar peliculas JSON";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    AdministradorJSON.ImportarPeliculasJSON(openFileDialog.FileName);


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
