using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoNuevo
{
    public abstract class Media
    {
        public abstract int Id { get; set; }
        public abstract string Nombre { get; set; }
        public abstract DateTime FechaEstreno { get; set; }
        public abstract string Descripcion { get; set; }
        public abstract string Director { get; set; }
        public abstract Image Imagen { get; set; }
    }
}
