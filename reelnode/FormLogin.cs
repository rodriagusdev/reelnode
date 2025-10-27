using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectoNuevo;

namespace Reelnode
{
    public partial class FormLogin : Form, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;

        public FormLogin()
        {
            InitializeComponent();
            PanelMain.Invalidate();
            PanelMain.Paint += panel1_Paint;
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelMain.Invalidate();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelMain.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelMain.ClientRectangle);
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

            foreach (Usuario u in AdministradorUsuarios.usuariosRegistrados)
            {
                if (TxtUsuario.Text == u.NombreUsuario && TxtPassword.Text == u.Password)
                {
                    /* Cargo los permisos y chequeo si el usuario puede loguear */
                    List<string> permisos = AdministradorPermisos.ObtenerPermisosUsuario(u.Id);

                    if (permisos.Contains(EnumPermisos.loguear.ToString()))
                    {
                        AdministradorUsuarios.usuarioActual.Id = u.Id;
                        AdministradorUsuarios.usuarioActual.NombreUsuario = u.NombreUsuario;
                        AdministradorUsuarios.usuarioActual.Password = u.Password;
                        AdministradorUsuarios.usuarioActual.RolUsuario = u.RolUsuario;
                        AdministradorUsuarios.usuarioActual.Email = u.Email;
                        AdministradorUsuarios.usuarioActual.Avatar = u.Avatar;
                        AdministradorUsuarios.usuarioActual.IdRol = u.IdRol;

                        usuarioEncontrado = true;
                        this.Close();
                        break;
                    }

                    MessageBox.Show(
                        "No tienes permisos para ingresar en la aplicación",
                        "Error de permisos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }
            }

            if (!usuarioEncontrado)
            {
                errorProvider.SetError(PanelUsuario, "Usuario incorrecto");
                MessageBox.Show(
                    "Usuario o Contraseña Incorrecta",
                    "Error de Autenticación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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

            registro.ShowDialog();
        }

        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LblOlvidarPassword_Click(object sender, EventArgs e)
        {
            FormPassword password = new FormPassword();
            password.ShowDialog();
        }
    }
}
