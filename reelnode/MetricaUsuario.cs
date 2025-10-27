using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reelnode
{
    public class MetricaUsuario
    {
        public string NombreUsuario { get; set; }
        public int Cantidad { get; set; }

        public string FechaRegistro { get; set; }

        public string Avatar { get; set; }

        public MetricaUsuario() { }
        public MetricaUsuario(string usuario)
        {
            NombreUsuario = usuario;
        }
        public MetricaUsuario(string usuario, int cantidad)
        {
            NombreUsuario = usuario;
            Cantidad = cantidad;
        }

        public MetricaUsuario(string usuario, string fechaRegistro, string avatar)
        {
            NombreUsuario = usuario;
            FechaRegistro = fechaRegistro;
            Avatar = avatar;
        }
    }
}
