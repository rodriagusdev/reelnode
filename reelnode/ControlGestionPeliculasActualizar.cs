using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionPeliculasActualizar: UserControl
    {
        private PanelGradiente PanelMain;

        private string trailerFinalURL = null;

        private DataGridViewRow filaSeleccionada;
        public ControlGestionPeliculasActualizar()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(PanelActualizar);
            this.Controls.Add(PanelMain);
        }

        private void ControlGestionPeliculasActualizar_Load(object sender, EventArgs e)
        {
            CreadorUI.CargarNetwork(CboNetwork);
            CreadorUI.CargarGeneros(ChkListGeneros);
        }

        /* !--- EVENTOS BOTONES ---! */
        private void BtnBuscarPelicula_Click(object sender, EventArgs e)
        {
            string textoBuscador = TxtBuscarNombrePelicula.Text;

            List<Pelicula> peliculasEncontradas = AdministradorPeliculas.peliculasCargadas
                .Where(p => p.Nombre.ToLower().Contains(textoBuscador.ToLower()))
                .ToList();

            if (peliculasEncontradas.Count == 0)
            {
                MessageBox.Show("No se encontraron películas con ese nombre.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Utils.ActualizarListaGrid(DataGridPeliculas, AdministradorPeliculas.peliculasCargadas, "Id", "Tipo");
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
                    actualizarPelicula.Network = UtilsBD.ObtenerNetworkId(CboNetwork.Text);
                    actualizarPelicula.TrailerURL = TxtURLTrailer.Text;
                    actualizarPelicula.Generos = UtilsBD.ObtenerIdGeneros(ChkListGeneros);
                }

                bool operacionExitosa = AdministradorPeliculas.ActualizarPelicula(actualizarPelicula);

                if (operacionExitosa)
                {
                    filaSeleccionada = null;
                    trailerFinalURL = null;
                    DataGridPeliculas.DataSource = null;
                    Utils.LimpiarCampos(this);
                }
               
            }         
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila.");
            }
        }

        private void BtnPrevisualizar_Click(object sender, EventArgs e)
        {
            Utils.CargarImagenDesdeURL(PicPelicula, TxtURLImagen.Text);
        }

        private async void BtnPrevisualizarTrailer_Click(object sender, EventArgs e)
        {
            trailerFinalURL = null;
            trailerFinalURL = await Utils.VerificarTrailer(PanelTrailer, TxtURLTrailer.Text);
        }

        /* !--- FIN EVENTOS BOTONES ---! */

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

        /* !--- EVENTOS CONTEXT MENU ---! */

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

        private void CtxMenuSubEliminar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada != null) 
            {
                int id = int.Parse(filaSeleccionada.Cells["Id"].Value.ToString());

                AdministradorPeliculas.EliminarPelicula(id);

                filaSeleccionada = null;
                Utils.ActualizarListaGrid(DataGridPeliculas, AdministradorPeliculas.peliculasCargadas, "Id", "Tipo");
            } else MessageBox.Show("No se ha seleccionado ninguna fila.");
        }
    }
}
