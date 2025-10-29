using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class FormRegistrar : Form, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;

        public FormRegistrar()
        {
            InitializeComponent();
            PanelMain.Invalidate();
            PanelMain.Paint += PanelMain_Paint;
            BtnIngresar.FlatAppearance.BorderColor = Color.FromArgb(0, 29, 35);
            BtnSalir.FlatAppearance.BorderColor = Color.FromArgb(0, 29, 35);
        }

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelMain.Invalidate();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool registracionValida = true;
            if (string.IsNullOrWhiteSpace(TxtUsuario.Text))
            {
                registracionValida = false;
                errorProvider.SetError(TxtUsuario, "El nombre no puede estar vacío.");
            }
            errorProvider.SetError(TxtEmail, "");
            string email = TxtEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                errorProvider.SetError(TxtEmail, "El email no es válido.");
                registracionValida = false;
            }
            else if (!email.Contains("@") || !email.Contains(".com"))
            {
                errorProvider.SetError(TxtEmail, "El email no es válido.");
                registracionValida = false;
            }
            else
            {
                errorProvider.SetError(TxtEmail, "");
            }

            if (registracionValida)
            {
                Usuario nuevo = new Usuario
                {
                    NombreUsuario = TxtUsuario.Text,
                    Email = TxtEmail.Text,
                    Password = TxtPassword.Text,
                    RolUsuario = "Usuario",
                };

                bool registracionExitosa = AdministradorUsuarios.RegistrarUsuarioBD(nuevo);

                if (registracionExitosa)
                {
                    this.Close();
                }
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

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            if (TxtEmail.Text != "")
            {
                PanelEmailLinea.Visible = false;
                LblPanelEmail.Visible = false;
            }
            else
            {
                PanelEmailLinea.Visible = true;
                LblPanelEmail.Visible = true;
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelMain_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(PanelMain.ClientRectangle, _c1, _c2, _modo))
            {
                e.Graphics.FillRectangle(brush, PanelMain.ClientRectangle);
            }
        }
    }
}
