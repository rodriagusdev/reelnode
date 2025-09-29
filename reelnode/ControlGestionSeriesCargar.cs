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
    public partial class ControlGestionSeriesCargar : UserControl, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        public ControlGestionSeriesCargar()
        {
            InitializeComponent();

            BtnCargar.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);
            BtnSalir.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);
            // BtnPrevisualizar.FlatAppearance.BorderColor = Color.FromArgb(25, 47, 71);
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

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            Serie nuevaSerie = new Serie
            {
                Nombre = TxtNombre.Text,
                Director = TxtDirector.Text,
                FechaEstreno = DtpFechaEstreno.Value,
                FechaFin = DtpFechaFin.Value,
                Descripcion = TxtDescripcion.Text,
                Imagen = TxtURLImagen.Text
            };

            UtilsBD.InsertarSerieBD(nuevaSerie);
        }

        private void BtnPrevisualizar_Click(object sender, EventArgs e)
        {
            Utils.CargarImagenDesdeURL(PicSerie, TxtURLImagen.Text);
        }
    }
}
