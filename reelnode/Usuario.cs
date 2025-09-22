using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoNuevo
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }

        public string RolUsuario { get; set; }
        public string Email { get; set; }

        public byte[] Avatar { get; set; }
        public DateTime FechaRegistro { get; set; }


        public Usuario() { }
        public Usuario(string nombreUsuario, string password, string email, byte[] avatar, string rolUsuario)
        {
            NombreUsuario = nombreUsuario;
            Password = password;
            RolUsuario = rolUsuario;
            Email = email;
            Avatar = avatar;
            FechaRegistro = DateTime.Now;
        }

        public Usuario(string v1, string v2, string v3, string v4)
        {
        }

        public override string ToString()
        {
            return $"NombreUsuario: {NombreUsuario}, Password: {Password}, RolUsuario: {RolUsuario}, Email: {Email}";
        }
    }
}
