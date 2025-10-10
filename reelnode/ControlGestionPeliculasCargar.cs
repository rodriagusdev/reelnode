using Microsoft.Web.WebView2.WinForms;
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
    public partial class ControlGestionPeliculasCargar : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        private string trailerFinalURL = null;
        public ControlGestionPeliculasCargar()
        {
            InitializeComponent();

            BtnCargar.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);
            BtnPrevisualizar.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);          
        }
        private void PanelPeliculaCreacion_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelPeliculaCreacion.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelPeliculaCreacion.ClientRectangle);
            }
        }
        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelPeliculaCreacion.Invalidate();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
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

            Pelicula nuevaPelicula = new Pelicula
            {
                Nombre = TxtNombre.Text,
                Director = TxtDirector.Text,
                Duracion = duracion,
                FechaEstreno = DtpFechaEstreno.Value,
                Descripcion = TxtDescripcion.Text,
                ImagenURL = TxtURLImagen.Text,
                TrailerURL = TxtURLTrailer.Text,
                Network = Utils.ObtenerNetworkId(CboNetwork.Text),
                Generos = Utils.ObtenerIdGeneros(ChkListGeneros) 
            };

            UtilsBD.InsertarPeliculaBD(nuevaPelicula);
            LimpiarCampos();
        }
      
        // Uso una funcion asincrona (async) porque la URL del trailer necesita hacer una peticion a la internet que toma un tiempo
        // y no quiero que la interfaz de usuario se congele mientras espera la respuesta. Ademas, no quiero que la funcion avance
        // hasta que la peticion se complete, por eso uso 'await'.
        private async void BtnPrevisualizarTrailer_Click(object sender, EventArgs e)
        {
            trailerFinalURL = null;
            trailerFinalURL = await Utils.VerificarTrailer(PanelTrailerSerie, TxtURLTrailer.Text);
        }

        private void BtnPrevisualizar_Click(object sender, EventArgs e)
        {
            Utils.CargarImagenDesdeURL(PicPelicula, TxtURLImagen.Text);
        }

        private void LimpiarCampos()
        {
            PicPelicula.Image = null;
            TxtURLImagen.Text = "";
            TxtNombre.Text = "";
            TxtDirector.Text = "";
            TxtDuracion.Text = "";
            DtpFechaEstreno.Value = DateTime.Now;
            TxtDescripcion.Text = "";
            TxtURLTrailer.Text = "";
            PanelTrailerSerie.Controls.Clear();
            CboNetwork.SelectedIndex = -1;
            for (int i = 0; i < ChkListGeneros.Items.Count; i++)
            {
                ChkListGeneros.SetItemChecked(i, false);
            }
            trailerFinalURL = null;
        }
        private void ControlGestionPeliculasCargar_Load(object sender, EventArgs e)
        {
           Utils.CargarNetwork(CboNetwork);

           Utils.CargarGeneros(ChkListGeneros);
        }
    }
}
