using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reelnode
{
    public class Pelicula: Media
    {
        public override int Id { get; set; }
        public override string Nombre { get; set; }
        public override DateTime FechaEstreno {  get; set; }
        public override string Descripcion { get; set; }
        public override string Director {  get; set; }
        public override string ImagenURL { get; set; }

        public override int Network { get; set; }
        public override string Tipo { get; set; }
        public override string TrailerURL { get; set; }
        public int Duracion { get; set; }

        public Pelicula() { }
        public Pelicula(string nombre, DateTime fechaEstreno, string descripcion, string director, string img, int duracion, string trailerURL, int network)
        {
            this.Nombre = nombre;
            this.FechaEstreno = fechaEstreno;
            this.Descripcion = descripcion;
            this.Director = director;
            this.ImagenURL = img;
            this.Duracion = duracion;
            this.TrailerURL = trailerURL;
            this.Tipo = "Pelicula";
            this.Network = network;
        }

    }
}
