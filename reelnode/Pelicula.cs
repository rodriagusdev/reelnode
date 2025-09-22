using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoNuevo
{
    public class Pelicula: Media
    {
        public override int Id { get; set; }
        public override string Nombre { get; set; }
        public override DateTime FechaEstreno {  get; set; }
        public override string Descripcion { get; set; }
        public override string Director {  get; set; }
        public override Image Imagen { get; set; }
        public string Duracion { get; set; }

        public Pelicula() { }
        public Pelicula(string nombre, DateTime fechaEstreno, string descripcion, string director, Image img, string duracion ) 
        {
            this.Nombre = nombre;
            this.FechaEstreno = fechaEstreno;
            this.Descripcion = descripcion;
            this.Director = director;
            this.Imagen = img;
            this.Duracion = duracion;
        }
        
    }
}
