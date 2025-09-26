using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reelnode
{
    public interface ITemaPersonalizable
    {
        void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo);
    }
}
