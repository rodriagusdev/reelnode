using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Reelnode.ComentarioHelper;

namespace Reelnode
{
    public static class CreadorPanel
    {
        public static List<Panel> CrearPanelesComentarios(List<Comentario> comentarios)
        {
            List<Panel> paneles = new List<Panel>();

            foreach (var c in comentarios)
            {
                Panel panel = ComentarioUIHelper.CrearPanelComentario(c);
                paneles.Add(panel);
            }

            return paneles;
        }
    }
    
}
