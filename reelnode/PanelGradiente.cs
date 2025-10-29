using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Reelnode
{
    public class PanelGradiente : Panel, ITemaPersonalizable
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

        public void EstablecerGradiente(Color color1, Color color2, LinearGradientMode modo)
        {
            this.Color1 = color1;
            this.Color2 = color2;
            this.GradientMode = modo;
            this.Invalidate();
        }
    }
}
