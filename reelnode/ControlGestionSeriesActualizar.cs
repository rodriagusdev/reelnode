using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionSeriesActualizar : UserControl, ITemaPersonalizable
    {        
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        private DataGridViewRow filaSeleccionada;
        private string trailerFinalURL = null;
        public ControlGestionSeriesActualizar()
        {
            InitializeComponent();

            BtnActualizar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
            BtnBuscar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
            BtnPrevisualizar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);

            Utils.TemaControles(PanelMain1, PicSerie);
        }
        private void ControlGestionSeriesActualizar_Load(object sender, EventArgs e)
        {
            Utils.CargarNetwork(CboNetwork);
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelMain1.Invalidate();
        }


        private void PanelMain1_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelMain1.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelMain1.ClientRectangle);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string textoBuscador = TxtBuscarSerie.Text;

            List<Serie> seriesEncontradas = UtilsBD.seriesCargadas
                .Where(s => s.Nombre.ToLower().Contains(textoBuscador.ToLower()))
                .ToList();

            if (seriesEncontradas.Count == 0)
            {
                MessageBox.Show("No se encontraron series con ese nombre.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Utils.ActualizarListaGrid(DataGridActualizarSerie, seriesEncontradas, "Id", "Tipo");
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada != null)
            {
                if (PicSerie.Image == null)
                {
                    MessageBox.Show("Imagen invalida.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (trailerFinalURL == null)
                {
                    MessageBox.Show("Trailer invalido.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (TxtNombre.Text == "" || TxtNombre.Text == null)
                {
                    MessageBox.Show("La pelicula no tiene titulo.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int cantTemporadas;
                if (!int.TryParse(TxtCantTemporadas.Text, out cantTemporadas))
                {
                    MessageBox.Show("La duracion no es un numero entero.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Serie actualizarSerie = new Serie();
                {
                    actualizarSerie.Id = int.Parse(filaSeleccionada.Cells["Id"].Value.ToString());
                    actualizarSerie.Nombre = TxtNombre.Text;
                    actualizarSerie.FechaEstreno = DtpFechaEstreno.Value;
                    actualizarSerie.Director = TxtDirector.Text;
                    actualizarSerie.Temporadas = int.Parse(TxtCantTemporadas.Text);
                    actualizarSerie.Descripcion = TxtDescripcion.Text;
                    actualizarSerie.ImagenURL = TxtURLImagen.Text;
                    actualizarSerie.Network = Utils.ObtenerNetworkId(CboNetwork.Text);
                    actualizarSerie.TrailerURL = TxtURLTrailer.Text;
                }

                UtilsBD.ActualizarSerie(actualizarSerie);
                DataGridActualizarSerie.DataSource = null;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila.");
            }
        }

        private async void ToolStpSubMenuModificar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada != null)
            {
                TxtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                TxtDirector.Text = filaSeleccionada.Cells["Director"].Value.ToString();
                TxtCantTemporadas.Text = filaSeleccionada.Cells["Temporadas"].Value.ToString();
                TxtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value.ToString();
                DtpFechaEstreno.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaEstreno"].Value);
                DtpFechaFin.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaFin"].Value);
                TxtURLImagen.Text = filaSeleccionada.Cells["ImagenURL"].Value.ToString();
                Utils.CargarImagenDesdeURL(PicSerie, TxtURLImagen.Text);
                TxtURLTrailer.Text = filaSeleccionada.Cells["trailerURL"].Value.ToString();
                trailerFinalURL = null;
                trailerFinalURL = await Utils.VerificarTrailer(PanelTrailer, TxtURLTrailer.Text);
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila.");
            }
        }

        private void ToolStpSubMenuEliminar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada != null)
            {
                int id = int.Parse(filaSeleccionada.Cells["Id"].Value.ToString());

                UtilsBD.EliminarSerie(id);

            }
            else MessageBox.Show("No se ha seleccionado ninguna fila.");
        }

        private void DataGridActualizarSerie_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridActualizarSerie.ClearSelection();
                    DataGridActualizarSerie.Rows[e.RowIndex].Selected = true;
                    filaSeleccionada = DataGridActualizarSerie.Rows[e.RowIndex];
                }
            }
        }
    }
}
