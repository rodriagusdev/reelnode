using System;

namespace Reelnode
{
    public class Comentario
    {
        public string Usuario { get; set; }

        public string UsuarioAvatar { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }

        public Comentario(string usuario, string usuarioAvatar, string texto, DateTime fecha)
        {
            Usuario = usuario;
            UsuarioAvatar = usuarioAvatar;
            Texto = texto;
            Fecha = fecha;
        }

        public Comentario()
        {
        }
    }
}
