using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoNuevo
{
    public class Serie: Media
    {
        public override int Id { get; set; }
        public override string Nombre { get; set; }
        public override DateTime FechaEstreno { get; set; }
        public override string Descripcion { get; set; }
        public override string Director { get; set; }
        public override Image Imagen { get; set; }
        public string Temporadas { get; set; }

        public List<string> Network { get; set; }
    }
}
