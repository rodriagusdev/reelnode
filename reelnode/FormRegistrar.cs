using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public partial class FormRegistrar: Form, ITemaPersonalizable
    {
        private Color _c1 = Color.FromArgb(20, 30, 48);
        private Color _c2 = Color.FromArgb(36, 59, 85);
        private LinearGradientMode _modo = LinearGradientMode.Vertical;
        public FormRegistrar()
        {
            InitializeComponent();

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
            bool valido = true;
            if (string.IsNullOrWhiteSpace(TxtUsuario.Text))
            {
                valido = false;
                errorProvider.SetError(TxtUsuario, "El nombre no puede estar vacío.");
            }
            errorProvider.SetError(TxtEmail, "");
            string email = TxtEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                errorProvider.SetError(TxtEmail, "El email no es válido.");
                valido = false;

            }
            else if (!email.Contains("@") || !email.Contains(".com"))
            {
                errorProvider.SetError(TxtEmail, "El email no es válido.");
                valido = false;
            }
            else
            {
                errorProvider.SetError(TxtEmail, "");
            }

            if (valido) 
            {
                Usuario nuevo = new Usuario
                {
                    NombreUsuario = TxtUsuario.Text,
                    Email = TxtEmail.Text,
                    Password = TxtPassword.Text,
                    RolUsuario = "Usuario"
                };

                /* Utils.usuariosRegistrados.Add(persona);
                 string toJSON = JsonSerializer.Serialize(Utils.usuariosRegistrados);
                 File.WriteAllText(Path.Combine(Application.StartupPath, "personas.json"), toJSON);
                */

                AdministradorUsuarios.RegistrarUsuarioBD(nuevo);

                MessageBox.Show("Usuario registrado con éxito", "Registro Exitoso", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.
                    Information);

                this.Close();
            }
        }

        private void FormRegistrar_Load(object sender, EventArgs e)
        {
            BtnIngresar.FlatAppearance.BorderColor = Color.FromArgb(0, 29, 35);
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
