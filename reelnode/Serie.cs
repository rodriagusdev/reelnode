using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reelnode
{
    public class Serie: Media
    {
        public override int Id { get; set; }
        public override string Nombre { get; set; }
        public override DateTime FechaEstreno { get; set; }
      
        public override string Descripcion { get; set; }
        public override string Director { get; set; }
        public override string ImagenURL { get; set; }

        public override string Tipo { get; set; }
        public override string TrailerURL { get; set; }

        public override int Network { get; set; }
        public int Temporadas { get; set; }
        public DateTime FechaFin {  get; set; }

        public Serie() { }

        public Serie(int id, string nombre, DateTime fecha, DateTime fechaFin, string descripcion, 
            string director, string img, byte temporadas, int network, string trailerURL)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.FechaEstreno = fecha;
            this.FechaFin = fechaFin;
            this.Descripcion = descripcion;
            this.Director = director;
            this.Temporadas = temporadas;
            this.Network = network;
            this.ImagenURL = img;
            this.TrailerURL = trailerURL;
            this.Tipo = "Serie";
        }
    }
}
