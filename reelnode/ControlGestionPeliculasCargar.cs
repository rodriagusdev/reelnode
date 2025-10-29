using System;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlGestionPeliculasCargar : UserControl
    {
        private PanelGradiente PanelMain;

        private string trailerFinalURL = null;
        public ControlGestionPeliculasCargar()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(PanelPeliculaCreacion);
            this.Controls.Add(PanelMain);
        }

        private void ControlGestionPeliculasCargar_Load(object sender, EventArgs e)
        {
            CreadorUI.CargarNetwork(CboNetwork);

            CreadorUI.CargarGeneros(ChkListGeneros);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            /* !--- INICIO VALIDACIONES --- ! */
            if (PicPelicula.Image == null)
            {
                MessageBox.Show("Imagen invalida.", "Error al cargar película", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (trailerFinalURL == null)
            {
                MessageBox.Show("Trailer invalido.", "Error al cargar película", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtNombre.Text == "" || TxtNombre.Text == null)
            {
                MessageBox.Show("La pelicula no tiene titulo.", "Error al cargar película", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxtDirector.Text == "" || TxtDirector.Text == null)
            {
                MessageBox.Show("No se especificó nombre del director.", "Error al cargar película", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int duracion;
            if (!int.TryParse(TxtDuracion.Text, out duracion))
            {
                MessageBox.Show("La duracion no es un numero entero.", "Error al cargar película", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /* !--- FIN VALIDACIONES --- ! */

            Pelicula nuevaPelicula = new Pelicula
            {
                Nombre = TxtNombre.Text,
                Director = TxtDirector.Text,
                Duracion = duracion,
                FechaEstreno = DtpFechaEstreno.Value,
                Descripcion = TxtDescripcion.Text,
                ImagenURL = TxtURLImagen.Text,
                TrailerURL = TxtURLTrailer.Text,
                Network = UtilsBD.ObtenerNetworkId(CboNetwork.Text),
                Generos = UtilsBD.ObtenerIdGeneros(ChkListGeneros)
            };

            bool operacionExitosa = AdministradorPeliculas.InsertarPeliculaBD(nuevaPelicula);

            if (operacionExitosa)
            {
                trailerFinalURL = null;
                Utils.LimpiarCampos(this);
            }

        }

        /* !--- PREVISUALIZACION DE POSTER Y TRAILER ---! */

        // SOBRE LA CARGA DE IMAGENES Y TRAILERS:
        // La eleccion es la carga a traves de URLs para no sobrecargar la base de datos.   

        /* 
         * Explicacion sobre funcion asincrona:
         
         * Uso una funcion asincrona (async) porque la URL del trailer necesita 
         * hacer una peticion a la internet que toma un tiempo
         * y no quiero que la interfaz de usuario se congele mientras espera la respuesta. 
         * Ademas, no quiero que la funcion avance hasta que la peticion se complete,
         * lo cual logro usando 'await'. Es esencial que sea una funcion asincrona.
         
        */
        private async void BtnPrevisualizarTrailer_Click(object sender, EventArgs e)
        {
            trailerFinalURL = null;
            trailerFinalURL = await Utils.VerificarTrailer(PanelTrailerSerie, TxtURLTrailer.Text);
        }

        private void BtnPrevisualizar_Click(object sender, EventArgs e)
        {
            Utils.CargarImagenDesdeURL(PicPelicula, TxtURLImagen.Text);
        }

        /* !--- FIN DE PREVISUALIZACION DE POSTER Y TRAILER --- ! */
    }
}
