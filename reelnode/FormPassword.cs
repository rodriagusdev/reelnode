using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Reelnode
{
    public partial class FormPassword : Form, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        public FormPassword()
        {
            InitializeComponent();

            BtnCambiar.FlatAppearance.BorderColor = Color.FromArgb(0, 29, 35);
            BtnSalir.FlatAppearance.BorderColor = Color.FromArgb(0, 29, 35);
        }

        private void BtnCambiar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear(); // Limpia todos los errores previos
            bool registracionValida = true;

            string usuario = TxtUsuario.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string nuevaPassword = TxtCambiarPassword.Text;
            string confirmarPassword = TxtConfirmarPassword.Text;

            // Patrón de email simplificado para validación
            const string emailPattern = @"^.+@.+\..+$";

            // --- 1. VALIDACIÓN DE CAMPOS NO VACÍOS Y FORMATO DE EMAIL ---

            // Validar Usuario
            if (string.IsNullOrWhiteSpace(usuario))
            {
                errorProvider.SetError(PanelUsuario, "El nombre de usuario es obligatorio.");
                registracionValida = false;
            }

            // Validar Email (Vacío/Formato)
            if (string.IsNullOrWhiteSpace(email))
            {
                errorProvider.SetError(PanelEmail, "El email es obligatorio.");
                registracionValida = false;
            }
            else if (!Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
            {
                errorProvider.SetError(PanelEmail, "El formato del email no es válido.");
                registracionValida = false;
            }

            // Validar Nueva Contraseña
            if (string.IsNullOrWhiteSpace(nuevaPassword))
            {
                errorProvider.SetError(PanelPassword, "La nueva contraseña es obligatoria.");
                registracionValida = false;
            }

            // Validar Confirmar Contraseña
            if (string.IsNullOrWhiteSpace(confirmarPassword))
            {
                errorProvider.SetError(PanelConfirmarPassword, "La confirmación de contraseña es obligatoria y debe coincidir.");
                registracionValida = false;
            }

            // --- 2. VALIDACIÓN DE COINCIDENCIA DE CONTRASEÑAS ---

            if (registracionValida && nuevaPassword != confirmarPassword)
            {
                errorProvider.SetError(PanelPassword, "Las contraseñas no coinciden.");
                errorProvider.SetError(PanelConfirmarPassword, "Las contraseñas no coinciden.");
                registracionValida = false;
            }

            // --- 3. PROCESO DE CAMBIO DE CONTRASEÑA ---

            if (registracionValida)
            {
                bool cambiado = AdministradorUsuarios.CambiarPasswordUsuario(usuario, email, nuevaPassword);

                if (cambiado)
                {
                    MessageBox.Show("Contraseña actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string asunto = "Cambio de contraseña confirmado";
                    string cuerpo = $@"
                        <h3>Hola {usuario},</h3>
                        <p>Tu contraseña ha sido cambiada correctamente.</p>
                        <p>Si no realizaste este cambio, contacta con soporte inmediatamente.</p>
                        <br>
                        <b>Equipo de Reelnode</b>
                    ";

                    CorreoHelper.EnviarCorreo(email, asunto, cuerpo);

                    this.Close();
                }
                else
                {
                    // Error en la lógica de negocio (ej. usuario y correo no coinciden en la base de datos)
                    MessageBox.Show("El usuario o el correo electrónico no coinciden con los registros.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void TxtCambiarPassword_TextChanged(object sender, EventArgs e)
        {
            if (TxtCambiarPassword.Text != "")
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

        private void TxtConfirmarPassword_TextChanged(object sender, EventArgs e)
        {
            if (TxtConfirmarPassword.Text != "")
            {
                PanelConfirmarLinea.Visible = false;
                LblConfirmarPassword.Visible = false;
            }
            else
            {
                PanelConfirmarLinea.Visible = true;
                LblConfirmarPassword.Visible = true;
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
        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            _c1 = color1;
            _c2 = color2;
            _modo = modo;
            PanelMain.Invalidate();
        }

    }

}
