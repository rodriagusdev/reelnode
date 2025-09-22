using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public partial class ControlGestionPeliculasActualizar: UserControl
    {
        private DataGridViewRow filaSeleccionada;
        public ControlGestionPeliculasActualizar()
        {
            InitializeComponent();
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

            DataGridPeliculas.DataSource = null;
            DataGridPeliculas.DataSource = peliculasEncontradas;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Pelicula actualizarPelicula = new Pelicula();
            {
                actualizarPelicula.Id = int.Parse(filaSeleccionada.Cells["Id"].Value.ToString());
                actualizarPelicula.Nombre = TxtNombre.Text;
                actualizarPelicula.FechaEstreno = DtpFechaEstreno.Value;
                actualizarPelicula.Director = TxtDirector.Text;
                actualizarPelicula.Duracion = TxtDuracion.Text;
                actualizarPelicula.Descripcion = TxtDescripcion.Text;
                actualizarPelicula.Imagen = PicPelicula.Image;
            }

            UtilsBD.ActualizarPelicula(actualizarPelicula);
            DataGridPeliculas.DataSource = null;
        }

        private void CtxMenuSubModificar_Click(object sender, EventArgs e)
        {
            TxtNombre.Text = "";
            TxtDirector.Text = "";
            TxtDuracion.Text = "";
            TxtDescripcion.Text = "";

            if (filaSeleccionada != null)
            {
                TxtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                TxtDirector.Text = filaSeleccionada.Cells["Director"].Value.ToString();
                TxtDuracion.Text = filaSeleccionada.Cells["Duracion"].Value.ToString();
                //TxtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value.ToString();
                DtpFechaEstreno.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaEstreno"].Value);
                PicPelicula.Image = null;
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
    }
}
