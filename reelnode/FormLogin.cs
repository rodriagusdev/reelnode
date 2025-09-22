using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            panel1.Invalidate();
            panel1.Paint += panel1_Paint;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = panel1.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(53, 106, 124),
                Color.FromArgb(24, 76, 90),
                LinearGradientMode.Vertical))
            {
                Blend blend = new Blend();
                blend.Positions = new float[] { 0f, 0.4f, 0.6f, 1f };
                blend.Factors = new float[] { 0f, 0.5f, 0.7f, 1f };
                brush.Blend = blend;
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            BtnIngresar.FlatAppearance.BorderColor = Color.FromArgb(0, 29, 35);
            BtnSalir.FlatAppearance.BorderColor = Color.FromArgb(0, 29, 35);
        }


        private void BtnIngresar_Click_1(object sender, EventArgs e)
        {
            bool usuarioEncontrado = false;
            foreach(Usuario u in UtilsBD.usuariosRegistrados)
            {
                if (TxtUsuario.Text == u.NombreUsuario && TxtPassword.Text == u.Password)
                {
                    UtilsBD.usuarioActual.NombreUsuario = u.NombreUsuario;
                    UtilsBD.usuarioActual.Password = u.Password;
                    UtilsBD.usuarioActual.RolUsuario = u.RolUsuario;
                    UtilsBD.usuarioActual.Email = u.Email;
                    usuarioEncontrado = true;
                    this.Close();
                    break;
                }
            }

            if (!usuarioEncontrado)
            {
                errorProvider.SetError(PanelUsuario, "Usuario incorrecto");
                MessageBox.Show("Usuario o Contraseña Incorrecta", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (TxtUsuario.Text != "")
            {
                PanelUsuarioLinea.Visible = false;
                LblPanelUsuario.Visible = false;
            }
            else
            {
                PanelUsuarioLinea.Visible = true;
                LblPanelUsuario.Visible = true;
            }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (TxtPassword.Text != "")
            {
                PanelPasswordLinea.Visible = false;
                LblPanelPassword.Visible = false;
            }
            else
            {
                PanelPasswordLinea.Visible = true;
                LblPanelPassword.Visible = true;
            }
        }

        private void LblRegistrar_Click(object sender, EventArgs e)
        {
            FormRegistrar registro = new FormRegistrar();

            registro.Show();
        }
        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
