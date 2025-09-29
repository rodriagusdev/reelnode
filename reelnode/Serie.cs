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
        public override string Imagen { get; set; }

        public override string Tipo { get; set; }
        public byte Temporadas { get; set; }


        public List<string> Network { get; set; }

        public Serie() { }

        public Serie(int id, string nombre, DateTime fecha, string descripcion, string director, string img, byte temporadas, List<string> network)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.FechaEstreno = fecha;
            this.Descripcion = descripcion;
            this.Director = director;
            this.Temporadas = temporadas;
            this.Network = network;
            this.Imagen = img;
            this.Tipo = "Serie";
        }
    }
}
