using Microsoft.Web.WebView2.WinForms;
using Reelnode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class ControlVisualizacionSerie : UserControl
    {
        public ControlVisualizacionSerie()
        {
            InitializeComponent();
        }

        public void CargarSerie(Serie serie)
        {
            if (serie == null)
                return;

            PanelTrailerSerie.Controls.Clear();

            PicSerie.Image = Utils.DescargarImagenDesdeURL(serie.ImagenURL);
            LblDescripcionPeli.Text = serie.Descripcion;
            LblDirector.Text = serie.Director;
            LblTemporadas.Text = serie.Temporadas + " temporadas";
            LblTitulo.Text = serie.Nombre;
            LblGeneros.Text = Utils.ObtenerNombresGeneros(serie.Generos);

            if (!string.IsNullOrEmpty(serie.TrailerURL))
            {
                string trailerURL = serie.TrailerURL;
                if (trailerURL.Contains("watch?v="))
                    trailerURL = trailerURL.Replace("watch?v=", "embed/");

                string URLDefault = $"{trailerURL}?rel=0&controls=1&autoplay=1";

                WebView2 trailer = new WebView2 { Dock = DockStyle.Fill };
                PanelTrailerSerie.Controls.Add(trailer);
                trailer.Source = new Uri(URLDefault);
            }
            else
            {
                PanelTrailerSerie.Visible = false;
            }
        }
    }
}
