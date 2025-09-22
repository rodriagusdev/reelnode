using MySql.Data.MySqlClient;
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

namespace ProjectoNuevo
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
            /*using (LinearGradientBrush brush = new LinearGradientBrush(
                PanelMain.ClientRectangle,
                Color.DarkSlateGray,
                Color.FloralWhite,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, PanelMain.ClientRectangle);
            }*/
        }

        private void ToolStpMenuAdmin_Click(object sender, EventArgs e)
        {
            Utils.ShowControl(controlAdmin, PanelMain);
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            UtilsBD.Conexion.AbrirBD();
            UtilsBD.CargarUsuario();
            UtilsBD.CargarPeliculas();

            FormLogin login = new FormLogin();

            login.ShowDialog();

            ToolStpMenuAdmin.Visible = UtilsBD.usuarioActual.RolUsuario == "Admin" ? true : false;
        }

        private void CargarUsuarios()
        {
            string ruta = Path.Combine(Application.StartupPath, "personas.json");
            string json = File.ReadAllText(ruta);
            UtilsBD.usuariosRegistrados = JsonSerializer.Deserialize<List<Usuario>>(json);
        }

    }
}
