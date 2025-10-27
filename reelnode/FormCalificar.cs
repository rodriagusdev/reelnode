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
    public partial class FormCalificar : Form, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;

        private int puntuacion = 0;

        public FormCalificar()
        {
            InitializeComponent();

            // Con esto se maneja a traves del Tag la puntuacion que representa
            // cada RadioButton unido al evento RadioButton_CheckedChanged
            RbtPunt.Tag = 1;
            RbtPunt2.Tag = 2;
            RbtPunt3.Tag = 3;
            RbtPunt4.Tag = 4;
            RbtPunt5.Tag = 5;

            RbtPunt.CheckedChanged += RadioButton_CheckedChanged;
            RbtPunt2.CheckedChanged += RadioButton_CheckedChanged;
            RbtPunt3.CheckedChanged += RadioButton_CheckedChanged;
            RbtPunt4.CheckedChanged += RadioButton_CheckedChanged;
            RbtPunt5.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (
                !AdministradorPermisos.permisosUsuarioActual.Contains(
                    EnumPermisos.calificar.ToString()
                )
            )
            {
                MessageBox.Show(
                    "No posees los permisos para calificar",
                    "Error de permisos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (puntuacion != 0)
            {
                int idMedia =
                    AdministradorPeliculas.peliculaSeleccionada != null
                        ? AdministradorPeliculas.peliculaSeleccionada.Id
                        : AdministradorSeries.serieSeleccionada.Id;

                // Si peliculaSeleccionada es null, entonces se clickeó una serie
                AdministradorCalificaciones.Calificar(
                    idMedia,
                    puntuacion,
                    AdministradorPeliculas.peliculaSeleccionada != null
                        ? EnumTipoId.p_id_pelicula
                        : EnumTipoId.p_id_serie
                );
                this.Close();
            }
            else
                MessageBox.Show(
                    "Debe elegir una puntuacion",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelMain.Invalidate();
        }

        private void PanelMain_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelMain.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelMain.ClientRectangle);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
                puntuacion = (int)rb.Tag;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
