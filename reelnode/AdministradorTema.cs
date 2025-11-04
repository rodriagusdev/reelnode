using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Reelnode
{
    public static class AdministradorTema
    {
        /* !--- DEFINICION DE COLORES DEL TEMA CYBERPUNK ---! */
        public static int IndiceTemaActual = 1;
        // Propiedades de color:
        public static Color AzulOscuroNeon = Color.FromArgb(30, 35, 55); // Original (42, 47, 79) -> Ligeramente más oscuro

        // 2. Verde Claro Neon - Mantiene su tono verde, pero ajustado para "sentirse" más frío/eléctrico
        public static Color VerdeClaroNeon = Color.FromArgb(0, 200, 100); // Original (0, 230, 118) -> Más azulado, pero aún verde neón

        // 3. Rosa Neon - Mantiene su brillo, es un color clave del synthwave
        public static Color RosaNeon = Color.FromArgb(255, 0, 127); // Original (255, 0, 127) -> Sin cambios

        // 4. Cyan Neon - Un cyan vibrante, complemento perfecto para el rosa
        public static Color CyanNeon = Color.FromArgb(0, 255, 255); // Original (0, 255, 255) -> Sin cambios

        // 5. Morado Neon Boton - Más oscuro para un mejor contraste y menos "pop"
        public static Color MoradoNeonBoton = Color.FromArgb(90, 30, 140); // Original (123, 44, 191) -> Más oscuro y profundo

        // 6. Azul Neon Borde - Mantiene su brillo para bordes de realce
        public static Color AzulNeonBorde = Color.FromArgb(0, 183, 235); // Original (0, 183, 235) -> Sin cambios

        // 7. Gradientes (Se mantienen sin cambios, son los fondos más oscuros)
        public static Color GradienteAzulOscuroPrimero = Color.FromArgb(27, 38, 59); // Sin cambios
        public static Color GradienteAzulOscuroSegundo = Color.FromArgb(13, 17, 23); // Sin cambios

        public static void CambiarTemaCyberpunk(Control parent)
        {
            // 1. Aumentar el índice y resetear
            IndiceTemaActual++;
            if (IndiceTemaActual > 5)
            {
                IndiceTemaActual = 1;
            }

            // 2. Definir los colores para el nuevo tema (Solo las VARIABLES ESTÁTICAS)
            switch (IndiceTemaActual)
            {
                case 1: // TEMA 1: Synthwave Default (Tu paleta actual, ajustada por consistencia)
                    AzulOscuroNeon = Color.FromArgb(30, 35, 55);
                    VerdeClaroNeon = Color.FromArgb(0, 200, 100);
                    RosaNeon = Color.FromArgb(255, 0, 127);
                    CyanNeon = Color.FromArgb(0, 255, 255);
                    MoradoNeonBoton = Color.FromArgb(90, 30, 140);
                    AzulNeonBorde = Color.FromArgb(0, 183, 235);
                    GradienteAzulOscuroPrimero = Color.FromArgb(27, 38, 59);
                    GradienteAzulOscuroSegundo = Color.FromArgb(13, 17, 23);
                    break;

                case 2: // TEMA 2: Naranja Eléctrico / Verde Lima ("Fuego Digital")
                    AzulOscuroNeon = Color.FromArgb(35, 30, 25); // Fondo más cálido
                    VerdeClaroNeon = Color.FromArgb(255, 136, 0); // Naranja Eléctrico (Principal)
                    RosaNeon = Color.FromArgb(128, 255, 0);       // Verde Lima (Contraste)
                    CyanNeon = Color.FromArgb(128, 255, 0);       // Verde Lima (Data/Hover)
                    MoradoNeonBoton = Color.FromArgb(60, 40, 20); // Marrón Oscuro Botón
                    AzulNeonBorde = Color.FromArgb(255, 136, 0);  // Naranja Eléctrico (Borde)
                    GradienteAzulOscuroPrimero = Color.FromArgb(35, 25, 10);
                    GradienteAzulOscuroSegundo = Color.FromArgb(15, 10, 5);
                    break;

                case 3: // TEMA 3: Rojo Neón / Azul Profundo ("Glitch/Alarma")
                    AzulOscuroNeon = Color.FromArgb(30, 30, 40); // Fondo más frío
                    VerdeClaroNeon = Color.FromArgb(255, 51, 51); // Rojo Neón (Principal)
                    RosaNeon = Color.FromArgb(0, 153, 255);       // Azul Profundo (Contraste)
                    CyanNeon = Color.FromArgb(0, 153, 255);       // Azul Profundo (Data/Hover)
                    MoradoNeonBoton = Color.FromArgb(40, 20, 20); // Rojo Oscuro Botón
                    AzulNeonBorde = Color.FromArgb(255, 51, 51);  // Rojo Neón (Borde)
                    GradienteAzulOscuroPrimero = Color.FromArgb(30, 30, 40);
                    GradienteAzulOscuroSegundo = Color.FromArgb(15, 15, 20);
                    break;

                case 4: // TEMA 4: Blanco/Cian ("Holograma Limpio")
                    AzulOscuroNeon = Color.FromArgb(40, 40, 50); // Fondo Gris Azulado
                    VerdeClaroNeon = Color.White;                // Blanco (Principal)
                    RosaNeon = Color.FromArgb(0, 255, 255);      // Cian Brillante (Contraste)
                    CyanNeon = Color.FromArgb(0, 255, 255);      // Cian Brillante (Data/Hover)
                    MoradoNeonBoton = Color.FromArgb(60, 60, 60); // Gris Oscuro Botón
                    AzulNeonBorde = Color.FromArgb(0, 255, 255);  // Cian Brillante (Borde)
                    GradienteAzulOscuroPrimero = Color.FromArgb(40, 45, 50);
                    GradienteAzulOscuroSegundo = Color.FromArgb(20, 20, 25);
                    break;
                case 5: // TEMA 5: Cyberpunk Hacker (Verde Terminal / Rojo Glitch)
                    AzulOscuroNeon = Color.FromArgb(15, 20, 15); // Fondo Negro verdoso profundo (Terminal)
                    VerdeClaroNeon = Color.FromArgb(0, 255, 0);  // Verde Neón puro (Texto Terminal)
                    RosaNeon = Color.FromArgb(255, 0, 0);        // Rojo Glitch (Advertencia/Contraste)
                    CyanNeon = Color.FromArgb(255, 0, 0);        // Rojo Glitch (Data/Hover)
                    MoradoNeonBoton = Color.FromArgb(30, 40, 30); // Verde oscuro (Botón)
                    AzulNeonBorde = Color.FromArgb(0, 255, 0);   // Borde Verde Neón
                    GradienteAzulOscuroPrimero = Color.FromArgb(10, 15, 10); // Gradiente de fondo más oscuro
                    GradienteAzulOscuroSegundo = Color.FromArgb(5, 8, 5);
                    break;
            }

            // 3. Reaplicar el tema a todos los controles
            AplicarTema(parent);
        }

        /* !--- FIN DE DEFINICION DE COLORES DEL TEMA CYBERPUNK ---! */

        // Esta funcion me permite recuperar todos los controles hijos de un control padre.
        public static IEnumerable<Control> ObtenerTodosLosControles(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in ObtenerTodosLosControles(c))
                    yield return child;
            }
        }


        public static void AplicarTema(Control parent)
        {
            

            foreach (Control ctrl in ObtenerTodosLosControles(parent))
            {
                /* !--- TEMA GRADIENTE USANDO INTERFAZ ---! */
                if (ctrl is ITemaPersonalizable controlTematico)
                {
                    controlTematico.EstablecerGradiente(
                        GradienteAzulOscuroPrimero, // Asumiendo que sigue siendo un azul oscuro
                        GradienteAzulOscuroSegundo, // Asumiendo que sigue siendo un azul oscuro
                        LinearGradientMode.Vertical
                    );
                }
                /* !--- FIN TEMA GRADIENTE USANDO INTERFAZ ---! */

                else if (ctrl is System.Windows.Forms.Panel pnl)
                {
                    if (pnl.Tag == "Default")
                        pnl.BackColor = Color.Transparent;
                    if (pnl.Tag == null || pnl.Tag == "")
                        pnl.BackColor = AzulOscuroNeon; // Fondo oscuro
                    if (pnl.Tag == "Barra")
                        pnl.BackColor = VerdeClaroNeon; // Fondo de barra (Ahora Azul Brillante)
                }
                else if (ctrl is System.Windows.Forms.CheckedListBox chkList)
                {
                    chkList.BackColor = AzulOscuroNeon;
                    chkList.ForeColor = VerdeClaroNeon; // Azul Brillante
                }
                else if (ctrl is System.Windows.Forms.ListView listView)
                {
                    listView.BackColor = AzulOscuroNeon;
                    listView.ForeColor = VerdeClaroNeon; // Azul Brillante
                }
                else if (ctrl is System.Windows.Forms.TextBox txt)
                {
                    txt.BackColor = AzulOscuroNeon;
                    txt.ForeColor = CyanNeon; // Rosa Neón
                    txt.Font = new Font("Consolas", txt.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is Label lbl)
                {
                    if (lbl.Tag == "Titulo")
                    {
                        lbl.Font = new Font("Consolas", lbl.Font.Size, FontStyle.Bold);
                        lbl.ForeColor = VerdeClaroNeon; // Azul Brillante
                    }
                    if (lbl.Tag == "Default")
                        lbl.ForeColor = Color.White; // Se mantiene Blanco para neutralidad
                    if (lbl.Tag == null)
                        lbl.ForeColor = RosaNeon; // Rosa Neón (Contraste)

                    lbl.Font = new Font("Courier New", lbl.Font.Size, FontStyle.Bold);
                    lbl.BackColor = Color.Transparent;
                }
                else if (ctrl is Button btn)
                {
                    btn.BackColor = MoradoNeonBoton; // Fondo oscuro del botón
                    btn.ForeColor = CyanNeon; // Rosa Neón (Texto del botón)
                    btn.FlatAppearance.BorderColor = AzulNeonBorde; // Borde Azul Brillante
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
                    grid.ForeColor = CyanNeon; // Rosa Neón (Texto)
                    grid.DefaultCellStyle.BackColor = AzulOscuroNeon;
                    grid.DefaultCellStyle.ForeColor = CyanNeon; // Rosa Neón
                    grid.DefaultCellStyle.SelectionBackColor = VerdeClaroNeon; // Selección Azul Brillante
                    grid.DefaultCellStyle.SelectionForeColor = AzulOscuroNeon; // Texto de selección oscuro
                    grid.ColumnHeadersDefaultCellStyle.BackColor = MoradoNeonBoton; // Fondo oscuro
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.RowHeadersDefaultCellStyle.BackColor = MoradoNeonBoton; // Fondo oscuro
                    grid.RowHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.EnableHeadersVisualStyles = false;
                    grid.GridColor = AzulNeonBorde; // Borde de cuadrícula Azul Brillante
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
                    cmb.ForeColor = CyanNeon; // Rosa Neón
                    cmb.Font = new Font("Courier New", cmb.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is CheckBox chk)
                {
                    chk.ForeColor = RosaNeon; // Rosa Neón
                    chk.Font = new Font("Courier New", chk.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is RadioButton rbt)
                {
                    rbt.ForeColor = RosaNeon; // Rosa Neón
                    rbt.Font = new Font("Courier New", rbt.Font.Size, FontStyle.Bold);
                }
                else if (ctrl is MenuStrip menu)
                {
                    // --- CÓDIGO DEL MENUSTRIP CON LA PALETA AZUL/ROSA ---
                    Color textoNormal = Color.FromArgb(0, 191, 255);        // Azul Brillante
                    Color azulOscuro = Color.FromArgb(20, 25, 40);          // Fondo
                    Color moradoNeon = Color.FromArgb(255, 0, 191);         // Rosa Neón (Auxiliar)
                    Color textoHover = Color.FromArgb(255, 0, 191);         // Texto hover: Rosa Neón

                    // Re-definición del Renderer para usar el hover en Rosa Neón
                    // **IMPORTANTE**: Asegúrate de que CyberpunkRenderer use las variables de color Rosa/Azul
                    // o define las variables privadas dentro de CyberpunkRenderer con estos valores:
                    /*
                    private Color textoNormal = Color.FromArgb(0, 191, 255); // Azul Brillante
                    private Color textoHover = Color.FromArgb(255, 0, 191);  // Rosa Neón
                    private Color submenuFondo = Color.FromArgb(255, 20, 25, 40); 
                    private Color hoverFondo = Color.FromArgb(60, 255, 0, 191); // Semi-transparente Rosa
                    */

                    menu.ForeColor = textoNormal;
                    menu.BackColor = Color.Transparent;
                    menu.RenderMode = ToolStripRenderMode.Professional;
                    menu.Renderer = new CyberpunkRenderer();
                    menu.ForeColor = textoNormal; // texto normal

                    foreach (ToolStripMenuItem item in menu.Items)
                    {
                        item.ForeColor = textoNormal;

                        item.MouseEnter += (s, e) =>
                        {
                            item.ForeColor = textoHover; // Rosa Neón
                        };

                        item.MouseLeave += (s, e) =>
                        {
                            item.ForeColor = textoNormal; // Azul Brillante
                        };
                    }
                }
            }
        }
    }
}
