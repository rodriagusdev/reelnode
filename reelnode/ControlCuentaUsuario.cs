using iTextSharp.xmp.impl;
using Reelnode;
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
    public partial class ControlCuentaUsuario : UserControl, ITemaPersonalizable
    {
        private PanelGradiente gradientPanelMain;
        private List<Pelicula> peliculasCalificadas = new List<Pelicula>();
        private List<Serie> seriesCalificadas = new List<Serie>();
        private FlowLayoutPanel flowPanelPeliculas;
        private Label lblPeliculas;
        public ControlCuentaUsuario()
        {
            InitializeComponent();

            int margenIzquierdo = 250;
            int margenSuperior = 15;
            int espacioEntrePaneles = 10;
            int altoPanel = 280;

            lblPeliculas = new Label
            {
                Text = "🎬 Calificaciones",
                Font = new Font("Courier New", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(margenIzquierdo, margenSuperior),
                BackColor = Color.Transparent,
                Tag = "Titulo"
            };

            flowPanelPeliculas = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true,
                AutoSize = false,
                BackColor = Color.Transparent,
                Padding = new Padding(10),
                Location = new Point(margenIzquierdo, lblPeliculas.Bottom + 10),
                Size = new Size(this.ClientSize.Width - 2 * margenIzquierdo, altoPanel),
                VerticalScroll = { Visible = false },
                Tag = "Default"
            };

            gradientPanelMain = new PanelGradiente();
            gradientPanelMain.Dock = DockStyle.Fill;
            this.Controls.Add(gradientPanelMain);
            gradientPanelMain.Controls.Add(flowPanelPeliculas);
            gradientPanelMain.Controls.Add(lblPeliculas);
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            gradientPanelMain.Color1 = color1;
            gradientPanelMain.Color2 = color2;
            gradientPanelMain.GradientMode = modo;
            gradientPanelMain.Invalidate();
        }

        public PanelGradiente MainPanel
        {
            get { return gradientPanelMain; }
        }

        private void ControlCuentaUsuario_Load(object sender, EventArgs e)
        {
            PicAvatar.Image = Utils.DescargarImagenDesdeURL(UtilsBD.usuarioActual.Avatar);
            LblEmail.Text = UtilsBD.usuarioActual.Email;
            LblUsuario.Text = UtilsBD.usuarioActual.NombreUsuario;  
            UtilsBD.CargarCalificaciones(UtilsBD.usuarioActual.Id, peliculasCalificadas);
            Utils.RellenarFlowPanel(flowPanelPeliculas, peliculasCalificadas, AbrirPestanaPelicula);
        }

        private void AbrirPestanaPelicula(int id)
        {
            Utils.serieSeleccionada = null;
            Utils.peliculaSeleccionada = UtilsBD.peliculasCargadas[id - 1];
            /*FormMain.controlVisualizacionPeliculas.CargarPelicula(Utils.peliculaSeleccionada);
            Utils.ShowControl(FormMain.controlVisualizacionPeliculas, FormMain.PanelMain);*/
        }

        private void BtnAvatar_Click(object sender, EventArgs e)
        {
            BtnConfirmarAvatar.Visible = true;
            PanelURL.Visible = true;
        }

        private void BtnConfirmarAvatar_Click(object sender, EventArgs e)
        {
            BtnConfirmarAvatar.Visible = false;
            PanelURL.Visible = false;

            UtilsBD.CambiarAvatar(UtilsBD.usuarioActual.Id, TxtURLImagen.Text);
        }
    }
}
