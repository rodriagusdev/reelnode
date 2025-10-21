using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
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
    public partial class ControlGestionSeriesCargar : UserControl
    {
        private PanelGradiente PanelMain;
        private string trailerFinalURL = null;
        public ControlGestionSeriesCargar()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(PanelSerie);
            this.Controls.Add(PanelMain);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            /* !--- INICIO VALIDACIONES --- ! */

            if (PicSerie.Image == null)
            {
                MessageBox.Show("Imagen invalida.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(trailerFinalURL == null)
            {
                MessageBox.Show("Trailer invalido.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(TxtNombre.Text == "" || TxtNombre.Text == null)
            {
                MessageBox.Show("La serie no tiene titulo.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantTemporadas;
            if (!int.TryParse(TxtDuracion.Text, out cantTemporadas))
            {
                MessageBox.Show("Cantidad de temporadas no es un numero entero.", "Error al cargar serie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /* !--- FIN VALIDACIONES --- ! */

            Serie nuevaSerie = new Serie
            {
                Nombre = TxtNombre.Text,
                Director = TxtDirector.Text,
                FechaEstreno = DtpFechaEstreno.Value,
                FechaFin = DtpFechaFin.Value,
                Descripcion = TxtDescripcion.Text,
                ImagenURL = TxtURLImagen.Text,
                TrailerURL = TxtURLTrailer.Text,
                Temporadas = cantTemporadas,
                Network = Utils.ObtenerNetworkId(CboNetwork.Text),
                Generos = Utils.ObtenerIdGeneros(ChkListGeneros)
            };

            UtilsBD.InsertarSerieBD(nuevaSerie);
        }

        /* !--- PREVISUALIZACION DE POSTER Y TRAILER ---! */

        /* 
            SOBRE LA CARGA DE IMAGENES Y TRAILERS:
            Mi eleccion es la carga a traves de URLs para no sobrecargar la base de datos.     
        */

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
            Utils.CargarImagenDesdeURL(PicSerie, TxtURLImagen.Text);
        }

        /* !--- FIN DE PREVISUALIZACION DE POSTER Y TRAILER --- ! */

        private void ControlGestionSeriesCargar_Load(object sender, EventArgs e)
        {
            Utils.CargarNetwork(CboNetwork);
            Utils.CargarGeneros(ChkListGeneros);
        }
    }
}
