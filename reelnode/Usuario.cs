using System;

namespace Reelnode
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }

        public int IdRol { get; set; }
        public string RolUsuario { get; set; }
        public string Email { get; set; }

        public string Avatar { get; set; }
        public DateTime FechaRegistro { get; set; }


        public Usuario() { }
        public Usuario(int id, string nombreUsuario, string password, string email, string avatar, string rolUsuario, int idRol)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            Password = password;
            RolUsuario = rolUsuario;
            Email = email;
            Avatar = avatar;
            FechaRegistro = DateTime.Now;
            IdRol = idRol;
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
