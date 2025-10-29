using System;
using System.Collections.Generic;

namespace Reelnode
{
    public abstract class Audiovisual
    {
        public abstract int Id { get; set; }
        public abstract string Nombre { get; set; }
        public abstract DateTime FechaEstreno { get; set; }
        public abstract string Descripcion { get; set; }
        public abstract string Director { get; set; }
        public abstract string ImagenURL { get; set; }
        public abstract string Tipo { get; set; }
        public abstract string TrailerURL { get; set; }
        public abstract int Network { get; set; }
        public abstract List<int> Generos { get; set; }
    }
}
