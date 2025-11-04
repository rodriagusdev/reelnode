using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
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

            // Validar Usuario
            if (string.IsNullOrWhiteSpace(TxtUsuario.Text))
            {
                registracionValida = false;
                errorProvider.SetError(PanelUsuario, "El nombre no puede estar vacío.");
            }
            else
            {
                errorProvider.SetError(PanelUsuario, string.Empty);
            }

            // --- INICIO: VALIDACIÓN DE CONTRASEÑA AÑADIDA ---
            if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                registracionValida = false;
                errorProvider.SetError(PanelPassword, "La contraseña no puede estar vacía."); // Asumo que usas TxtPassword como control
            }
            else
            {
                errorProvider.SetError(PanelPassword, string.Empty);
            }
            // --- FIN: VALIDACIÓN DE CONTRASEÑA AÑADIDA ---

            // --- VALIDACIÓN DE EMAIL (Mantenida con Regex) ---
            string email = TxtEmail.Text;
            const string pattern = @"^.+@.+\..+$";

            // 1. Verificación de campo vacío/espacios
            if (string.IsNullOrWhiteSpace(email))
            {
                errorProvider.SetError(PanelEmail, "El email es obligatorio.");
                registracionValida = false;
            }
            // 2. Verificación de formato usando Regex
            else if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                errorProvider.SetError(
                    PanelEmail,
                    "El formato del email no es válido (ej. usuario@dominio.com)."
                );
                registracionValida = false;
            }
            // Si pasa ambas validaciones
            else
            {
                errorProvider.SetError(PanelEmail, string.Empty);
            }
            // --- FIN: VALIDACIÓN DE EMAIL ---

            if (registracionValida)
            {
                Usuario nuevo = new Usuario
                {
                    NombreUsuario = TxtUsuario.Text,
                    Email = TxtEmail.Text,
                    Password = TxtPassword.Text,
                    RolUsuario = "Usuario",
                    Avatar = "",
                };

                bool registracionExitosa = AdministradorUsuarios.RegistrarUsuarioBD(nuevo);

                if (registracionExitosa)
                {
                    this.Close();
                }
                else
                {
                    // Opcional: Mostrar un mensaje de error si la DB falla (ej. usuario ya existe)
                    MessageBox.Show("Error al registrar usuario. El nombre de usuario o email ya existen.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
