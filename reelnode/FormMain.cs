using MySql.Data.MySqlClient;
using Reelnode.ProjectoNuevo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class FormMain : Form
    {
        private ControlAdmin controlAdmin;

        public FormMain()
        {
            InitializeComponent();

            controlAdmin = new ControlAdmin();

            PanelMain.Controls.Add(controlAdmin);

            controlAdmin.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                PanelMain.ClientRectangle,
                Color.FromArgb(43, 88, 118),
                Color.FromArgb(78, 67, 118),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, PanelMain.ClientRectangle);
            }
        }

        private void ToolStpMenuAdmin_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlAdmin, PanelMain);
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in GetAllControls(this))
            {
                if (ctrl is ITemaPersonalizable controlTematico)
                {
                    controlTematico.EstablecerGradiente(
                        Color.FromArgb(43, 88, 118),
                        Color.FromArgb(78, 67, 118),
                        LinearGradientMode.Vertical);
                }
            }

            UtilsBD.Conexion.AbrirBD();
            UtilsBD.CargarUsuario();
            UtilsBD.CargarPeliculas();

            FormLogin login = new FormLogin();

            login.ShowDialog();

            ToolStpMenuAdmin.Visible = UtilsBD.usuarioActual.RolUsuario == "Admin" ? true : false;
        }

        /*private void CargarUsuariosJSON()
        {
            string ruta = Path.Combine(Application.StartupPath, "personas.json");
            string json = File.ReadAllText(ruta);
            UtilsBD.usuariosRegistrados = JsonSerializer.Deserialize<List<Usuario>>(json);
        }
        */
        private void noTocarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneradorPeliculas.Insertar20PeliculasAleatorias();
            UtilsBD.CargarPeliculas();
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }
    }
}
