using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reelnode
{
    public class PeliculaMiniatura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ImagenURL { get; set; }
        public int CantidadVistas { get; set; }

        public int Calificacion { get; set; }

        public PeliculaMiniatura() { }

        public PeliculaMiniatura(int id, string nombre, string imagenURL)
        {
            Id = id;
            Nombre = nombre;
            ImagenURL = imagenURL;
        }

        public PeliculaMiniatura(int id, string nombre, string imagenURL, int calif)
        {
            Id = id;
            Nombre = nombre;
            ImagenURL = imagenURL;
            Calificacion = calif;
        }

        /*public PeliculaMiniatura(int id, string nombre, string imagenURL, int vistas)
        {
            Id = id;
            Nombre = nombre;
            ImagenURL = imagenURL;
            CantidadVistas = vistas;
        }*/
    }
}
