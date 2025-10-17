using Reelnode;
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
    public static class AdministradorTema
    {
        public static IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }
        public static void AplicarTema(Control parent)
        {
            foreach (Control ctrl in GetAllControls(parent))
            {
                if (ctrl is ITemaPersonalizable controlTematico)
                {
                    controlTematico.EstablecerGradiente(
                        Color.FromArgb(27, 38, 59),
                        Color.FromArgb(13, 17, 23),
                        LinearGradientMode.Vertical);
                }

                else if (ctrl is System.Windows.Forms.Panel pnl)
                {
                    if (pnl.Tag != "Default") pnl.BackColor = Color.FromArgb(42, 47, 79);
                    // DEFAULT = TRANSPARENTE
                    // != DEFAULT = COLOR OSCURO
                }
                else if (ctrl is System.Windows.Forms.CheckedListBox chkList)
                {
                    chkList.BackColor = Color.FromArgb(42, 47, 79);
                    chkList.ForeColor = Color.FromArgb(0, 230, 118);
                    chkList.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is System.Windows.Forms.TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(42, 47, 79);
                    txt.ForeColor = Color.FromArgb(0, 255, 255);
                    txt.Font = new Font("Consolas", txt.Font.Size, FontStyle.Bold);
                }

                else if (ctrl is System.Windows.Forms.Label lbl)
                {
                    if (lbl.Tag == "Titulo") lbl.ForeColor = Color.FromArgb(0, 230, 118);
                    if (lbl.Tag == "Default") lbl.ForeColor = Color.FromArgb(255, 255, 255);
                    if (lbl.Tag == null) lbl.ForeColor = Color.FromArgb(255, 0, 127);
                    // TITULO = VERDE NEON
                    // DEFAULT = BLANCO
                    // NULL = ROSA NEON

                    lbl.Font = new Font("Courier New", lbl.Font.Size, FontStyle.Bold);
                    lbl.BackColor = Color.Transparent;
                }

                else if (ctrl is System.Windows.Forms.Button btn)
                {
                    btn.BackColor = Color.FromArgb(123, 44, 191);
                    btn.ForeColor = Color.FromArgb(0, 255, 255);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(0, 183, 235);
                    btn.Font = new Font("Consolas", btn.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is PictureBox pic)
                {
                    pic.BackColor = Color.FromArgb(42, 47, 79);
                }
                else if (ctrl is DataGridView grid)
                {
                    // ... (Lógica de DataGridView)
                }
                else if (ctrl is FlowLayoutPanel flow)
                {
                    flow.BackColor = Color.Transparent;
                }
                else if (ctrl is System.Windows.Forms.ComboBox cmb)
                {
                    cmb.BackColor = Color.FromArgb(42, 47, 79);
                    cmb.ForeColor = Color.FromArgb(0, 255, 255);
                    cmb.Font = new Font("Courier New", cmb.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is CheckBox chk)
                {
                    chk.ForeColor = Color.FromArgb(255, 0, 127);
                    chk.Font = new Font("Courier New", chk.Font.Size, FontStyle.Bold);

                }
                else if (ctrl is RadioButton rbt)
                {
                    rbt.ForeColor = Color.FromArgb(255, 0, 127);
                    rbt.Font = new Font("Courier New", rbt.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is MenuStrip menu)
                {
                    menu.BackColor = Color.FromArgb(27, 38, 59);
                    menu.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }
        }
    }
}
