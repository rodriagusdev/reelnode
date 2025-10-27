using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Reelnode
{
    public static class AdministradorTema
    {
        /* !--- DEFINICION DE COLORES DEL TEMA CYBERPUNK ---! */

        public static Color AzulOscuroNeon = Color.FromArgb(42, 47, 79);
        public static Color VerdeClaroNeon = Color.FromArgb(0, 230, 118);
        public static Color RosaNeon = Color.FromArgb(255, 0, 127);
        public static Color CyanNeon = Color.FromArgb(0, 255, 255);
        public static Color GradienteAzulOscuroPrimero = Color.FromArgb(27, 38, 59);
        public static Color GradienteAzulOscuroSegundo = Color.FromArgb(13, 17, 23);
        public static Color MoradoNeonBoton = Color.FromArgb(123, 44, 191);
        public static Color AzulNeonBorde = Color.FromArgb(0, 183, 235);

        /* !--- FIN DE DEFINICION DE COLORES DEL TEMA CYBERPUNK ---! */

        // Esta funcion me permite recuperar todos los controles hijos de un control padre.
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
                /* !--- TEMA GRADIENTE USANDO INTERFAZ ---! */

                // Si el control implementa la interfaz ITemaPersonalizable, aplico el gradiente definido
                if (ctrl is ITemaPersonalizable controlTematico)
                {
                    controlTematico.EstablecerGradiente(
                        GradienteAzulOscuroPrimero,
                        GradienteAzulOscuroSegundo,
                        LinearGradientMode.Vertical
                    );
                }
                /* !--- FIN TEMA GRADIENTE USANDO INTERFAZ ---! */

                else if (ctrl is System.Windows.Forms.Panel pnl)
                {
                    if (pnl.Tag == "Default")
                        pnl.BackColor = Color.Transparent;
                    if (pnl.Tag == null || pnl.Tag == "")
                        pnl.BackColor = AzulOscuroNeon;
                    if (pnl.Tag == "Barra")
                        pnl.BackColor = VerdeClaroNeon;
                }
                else if (ctrl is System.Windows.Forms.CheckedListBox chkList)
                {
                    chkList.BackColor = AzulOscuroNeon;
                    chkList.ForeColor = VerdeClaroNeon;
                }
                else if (ctrl is System.Windows.Forms.ListView listView)
                {
                    listView.BackColor = AzulOscuroNeon;
                    listView.ForeColor = VerdeClaroNeon;
                }
                else if (ctrl is System.Windows.Forms.TextBox txt)
                {
                    txt.BackColor = AzulOscuroNeon;
                    txt.ForeColor = CyanNeon;
                    txt.Font = new Font("Consolas", txt.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is Label lbl)
                {
                    if (lbl.Tag == "Titulo")
                    {
                        lbl.Font = new Font("Consolas", lbl.Font.Size, FontStyle.Bold);
                        lbl.ForeColor = VerdeClaroNeon;
                    }
                    if (lbl.Tag == "Default")
                        lbl.ForeColor = Color.White;
                    if (lbl.Tag == null)
                        lbl.ForeColor = RosaNeon;

                    lbl.Font = new Font("Courier New", lbl.Font.Size, FontStyle.Bold);
                    lbl.BackColor = Color.Transparent;
                }
                else if (ctrl is System.Windows.Forms.Button btn)
                {
                    btn.BackColor = MoradoNeonBoton;
                    btn.ForeColor = CyanNeon;
                    btn.FlatAppearance.BorderColor = AzulNeonBorde;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Font = new Font("Consolas", btn.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is PictureBox pic)
                {
                    pic.BackColor = AzulOscuroNeon;
                }
                else if (ctrl is DataGridView grid)
                {
                    grid.BackgroundColor = AzulOscuroNeon;
                    grid.ForeColor = CyanNeon;
                    grid.DefaultCellStyle.BackColor = AzulOscuroNeon;
                    grid.DefaultCellStyle.ForeColor = CyanNeon;
                    grid.DefaultCellStyle.SelectionBackColor = VerdeClaroNeon;
                    grid.DefaultCellStyle.SelectionForeColor = AzulOscuroNeon;
                    grid.ColumnHeadersDefaultCellStyle.BackColor = MoradoNeonBoton;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.RowHeadersDefaultCellStyle.BackColor = MoradoNeonBoton;
                    grid.RowHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.EnableHeadersVisualStyles = false;
                    grid.GridColor = AzulNeonBorde;
                    grid.BorderStyle = BorderStyle.FixedSingle;
                    grid.DefaultCellStyle.Font = new Font("Consolas", 9, FontStyle.Bold);
                }
                else if (ctrl is FlowLayoutPanel flow)
                {
                    flow.BackColor = Color.Transparent;
                }
                else if (ctrl is System.Windows.Forms.ComboBox cmb)
                {
                    cmb.BackColor = AzulOscuroNeon;
                    cmb.ForeColor = CyanNeon;
                    cmb.Font = new Font("Courier New", cmb.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is CheckBox chk)
                {
                    chk.ForeColor = RosaNeon;
                    chk.Font = new Font("Courier New", chk.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is RadioButton rbt)
                {
                    rbt.ForeColor = RosaNeon;
                    rbt.Font = new Font("Courier New", rbt.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is MenuStrip menu)
                {
                    menu.BackColor = GradienteAzulOscuroPrimero;
                    menu.ForeColor = Color.White;
                }
            }
        }
    }
}
