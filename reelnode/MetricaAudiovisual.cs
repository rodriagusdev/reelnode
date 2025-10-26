using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reelnode
{
    public class MetricaAudiovisual
    {
        public string NombreMedia { get; set; }
        public string ImagenURL { get; set; }

        public MetricaAudiovisual(string nombreMedia, string imagenURL)
        {
            NombreMedia = nombreMedia;
            ImagenURL = imagenURL;
        }
    }
}
