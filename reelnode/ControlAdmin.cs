using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public partial class ControlAdmin : UserControl
    {
        private ControlGestionPeliculasCargar controlCargarPelicula;
        private ControlGestionPeliculasListarPeliculas controlListarPeliculas;
        private ControlGestionPeliculasActualizar controlActualizarPeliculas;
        private ControlGestionUsuarios controlGestionUsuarios;

        public ControlAdmin()
        {
            InitializeComponent();

            PanelAdmin.Controls.Add(controlCargarPelicula = new ControlGestionPeliculasCargar());
            PanelAdmin.Controls.Add(controlListarPeliculas = new ControlGestionPeliculasListarPeliculas());
            PanelAdmin.Controls.Add(controlGestionUsuarios = new ControlGestionUsuarios());
            PanelAdmin.Controls.Add(controlActualizarPeliculas = new ControlGestionPeliculasActualizar());
            controlCargarPelicula.Visible = false;
            controlListarPeliculas.Visible = false;
            controlGestionUsuarios.Visible = false;
            controlActualizarPeliculas.Visible = false;
        }

        private void ToolStpSubMenuCargarPeliculas_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlCargarPelicula, PanelAdmin);
        }

        private void ToolStpSubMenuListarPeliculas_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlListarPeliculas, PanelAdmin);
        }

        private void ToolStpMenuUsuarios_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlGestionUsuarios, PanelAdmin);
        }

        private void ToolStpMenuActualizarPelicula_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlActualizarPeliculas, PanelAdmin);
        }
    }
}
