using MySql.Data.MySqlClient;
using Reelnode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string usuario = TxtUsuario.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string nuevaPassword = TxtCambiarPassword.Text;
            string confirmarPassword = TxtConfirmarPassword.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(nuevaPassword) || string.IsNullOrEmpty(confirmarPassword))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (nuevaPassword != confirmarPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            bool cambiado = AdministradorUsuarios.CambiarPasswordUsuario(usuario, email, nuevaPassword);

            if (cambiado)
            {
                MessageBox.Show("Contraseña actualizada con éxito.");

                string asunto = "Cambio de contraseña confirmado";
                string cuerpo = $@"
                    <h3>Hola {usuario},</h3>
                    <p>Tu contraseña ha sido cambiada correctamente.</p>
                    <p>Si no realizaste este cambio, contacta con soporte inmediatamente.</p>
                    <br>
                    <b>Equipo ProyectoNuevo</b>
                ";

                CorreoHelper.EnviarCorreo(email, asunto, cuerpo);

                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario y el correo no coinciden.");
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
