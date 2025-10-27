using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reelnode
{
    public class AudiovisualMiniatura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ImagenURL { get; set; }
        public int CantidadVistas { get; set; }

        public decimal CalificacionPromedio { get; set; }
        public int CantidadCalificaciones { get; set; }

        public AudiovisualMiniatura() { }

        public AudiovisualMiniatura(int id, string nombre, string imagenURL)
        {
            Id = id;
            Nombre = nombre;
            ImagenURL = imagenURL;
        }

        public AudiovisualMiniatura(int id, string nombre, string imagenURL, decimal calif)
        {
            Id = id;
            Nombre = nombre;
            ImagenURL = imagenURL;
            CalificacionPromedio = calif;
        }

        /*public MediaMiniatura(int id, string nombre, string imagenURL, int vistas)
        {
            Id = id;
            Nombre = nombre;
            ImagenURL = imagenURL;
            CantidadVistas = vistas;
        }*/
    }
}
