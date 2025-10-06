using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reelnode
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Genero(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
