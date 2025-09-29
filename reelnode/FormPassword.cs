using MySql.Data.MySqlClient;
using ProjectoNuevo;
using Reelnode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public partial class FormPassword : Form
    {
        public FormPassword()
        {
            InitializeComponent();
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

            bool cambiado = UtilsBD.CambiarPassword(usuario, email, nuevaPassword);

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
    }
    
}
