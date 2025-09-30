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
    public partial class FormRegistrar: Form
    {
        public FormRegistrar()
        {
            InitializeComponent();

            BtnIngresar.FlatAppearance.BorderColor = Color.FromArgb(0, 29, 35);
            BtnSalir.FlatAppearance.BorderColor = Color.FromArgb(0, 29, 35);
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

                UtilsBD.RegistrarUsuarioBD(nuevo);

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
            Rectangle rect = PanelMain.ClientRectangle;
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
    }
}
