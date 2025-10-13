using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionPeliculasActualizar: UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        private string trailerFinalURL = null;

        private DataGridViewRow filaSeleccionada;
        public ControlGestionPeliculasActualizar()
        {
            InitializeComponent();

            BtnPrevisualizar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
            BtnActualizar.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
            BtnBuscarPelicula.FlatAppearance.BorderColor = Color.FromArgb(74, 184, 192);
        }
        private void PanelMain_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelMain.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelMain.ClientRectangle);
            }
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelMain.Invalidate();
        }

        private void BtnBuscarPelicula_Click(object sender, EventArgs e)
        {
            string textoBuscador = TxtBuscarNombrePelicula.Text;

            List<Pelicula> peliculasEncontradas = UtilsBD.peliculasCargadas
                .Where(p => p.Nombre.ToLower().Contains(textoBuscador.ToLower()))
                .ToList();

            if (peliculasEncontradas.Count == 0)
            {
                MessageBox.Show("No se encontraron películas con ese nombre.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Utils.ActualizarListaGrid(DataGridPeliculas, UtilsBD.peliculasCargadas, "Id", "Tipo");
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada != null) 
            {
                if (PicPelicula.Image == null)
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

                int duracion;
                if (!int.TryParse(TxtDuracion.Text, out duracion))
                {
                    MessageBox.Show("La duracion no es un numero entero.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Pelicula actualizarPelicula = new Pelicula();
                {
                    actualizarPelicula.Id = int.Parse(filaSeleccionada.Cells["Id"].Value.ToString());
                    actualizarPelicula.Nombre = TxtNombre.Text;
                    actualizarPelicula.FechaEstreno = DtpFechaEstreno.Value;
                    actualizarPelicula.Director = TxtDirector.Text;
                    actualizarPelicula.Duracion = int.Parse(TxtDuracion.Text);
                    actualizarPelicula.Descripcion = TxtDescripcion.Text;
                    actualizarPelicula.ImagenURL = TxtURLImagen.Text;
                    actualizarPelicula.Network = Utils.ObtenerNetworkId(CboNetwork.Text);
                    actualizarPelicula.TrailerURL = TxtURLTrailer.Text;
                    actualizarPelicula.Generos = Utils.ObtenerIdGeneros(ChkListGeneros);
                }

                filaSeleccionada = null;
                UtilsBD.ActualizarPelicula(actualizarPelicula);
                DataGridPeliculas.DataSource = null;
                LimpiarCampos();
            }         
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila.");
            }
        }

        private void LimpiarCampos()
        {
            TxtNombre.Text = "";
            TxtDirector.Text = "";
            TxtDuracion.Text = "";
            TxtDescripcion.Text = "";
            DtpFechaEstreno.Value = DateTime.Now;
            TxtURLImagen.Text = "";
            PicPelicula.Image = null;
            TxtURLTrailer.Text = "";
            PanelTrailer.Controls.Clear();
            trailerFinalURL = null;
            foreach (int i in ChkListGeneros.CheckedIndices) ChkListGeneros.SetItemChecked(i, false);
            CboNetwork.SelectedIndex = -1;
        }

        private async void CtxMenuSubModificar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada != null)
            {
                TxtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                TxtDirector.Text = filaSeleccionada.Cells["Director"].Value.ToString();
                TxtDuracion.Text = filaSeleccionada.Cells["Duracion"].Value.ToString();
                TxtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value.ToString();
                DtpFechaEstreno.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaEstreno"].Value);
                TxtURLImagen.Text = filaSeleccionada.Cells["ImagenURL"].Value.ToString();
                Utils.CargarImagenDesdeURL(PicPelicula, TxtURLImagen.Text);
                TxtURLTrailer.Text = filaSeleccionada.Cells["TrailerURL"].Value.ToString();
                trailerFinalURL = null;
                trailerFinalURL = await Utils.VerificarTrailer(PanelTrailer, TxtURLTrailer.Text);
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila.");
            }
        }

        private void DataGridPeliculas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridPeliculas.ClearSelection();
                    DataGridPeliculas.Rows[e.RowIndex].Selected = true;
                    filaSeleccionada = DataGridPeliculas.Rows[e.RowIndex];
                }
            }
        }

        private void CtxMenuSubEliminar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada != null) 
            {
                int id = int.Parse(filaSeleccionada.Cells["Id"].Value.ToString());

                UtilsBD.EliminarPelicula(id);

            } else MessageBox.Show("No se ha seleccionado ninguna fila.");
        }

        private void BtnPrevisualizar_Click(object sender, EventArgs e)
        {
            Utils.CargarImagenDesdeURL(PicPelicula, TxtURLImagen.Text);
        }

        private void ControlGestionPeliculasActualizar_Load(object sender, EventArgs e)
        {
            Utils.CargarNetwork(CboNetwork);
            Utils.CargarGeneros(ChkListGeneros);
        }

        private async void BtnPrevisualizarTrailer_Click(object sender, EventArgs e)
        {
            trailerFinalURL = null;
            trailerFinalURL = await Utils.VerificarTrailer(PanelTrailer, TxtURLTrailer.Text);
        }
    }
}
