using System;

namespace Reelnode
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Usuario { get; set; }

        public string UsuarioAvatar { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }

        public Comentario(int id, string usuario, string usuarioAvatar, string texto, DateTime fecha)
        {
            Id = id; 
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
