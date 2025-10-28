using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
            // Login exitoso devuelve 0 si hay error, o un ID mayor a 0 si encontro al usuario
            int loginExitoso = AdministradorUsuarios.Login(TxtUsuario.Text, TxtPassword.Text);

            if (loginExitoso > 0)
            {
                AdministradorUsuarios.CargarUsuarios();
                int posicionIdLista = loginExitoso - 1;
                Usuario logeado = AdministradorUsuarios.usuariosRegistrados[posicionIdLista];

                AdministradorUsuarios.usuarioActual = logeado;
                this.Close();
            }
            else
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
