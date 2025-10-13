using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public class PanelGradiente : Panel
    {
        public Color Color1 { get; set; } = Color.LightBlue;
        public Color Color2 { get; set; } = Color.DarkBlue;
        public LinearGradientMode GradientMode { get; set; } = LinearGradientMode.Vertical;

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color1, Color2, GradientMode))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }
    }
}
