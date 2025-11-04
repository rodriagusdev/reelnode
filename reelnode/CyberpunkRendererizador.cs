using DocumentFormat.OpenXml.Drawing;
using Reelnode;
using System.Drawing;
using System.Windows.Forms;


public class CyberpunkRenderer : ToolStripProfessionalRenderer
{
    // --- MÉTODOS DE LECTURA DINÁMICA DE COLORES ---
    // El Renderer lee los colores del tema actual de la clase estática AdministradorTEMA

    // Texto/Principal (debería ser el azul brillante o verde neón del tema)
    private Color GetTextoNormal() => AdministradorTema.VerdeClaroNeon;

    // Contraste/Hover (debería ser el rosa/cyan del tema)
    private Color GetTextoHover() => AdministradorTema.RosaNeon;

    // Fondo oscuro del submenú
    private Color GetSubmenuFondo() => AdministradorTema.AzulOscuroNeon;

    // Fondo de hover semi-transparente (usa el color de contraste con Alpha 60)
    private Color GetHoverFondo()
    {
        Color hoverColor = AdministradorTema.RosaNeon;
        // Alpha 60 para el efecto semi-transparente
        return Color.FromArgb(60, hoverColor.R, hoverColor.G, hoverColor.B);
    }

    // --- 1. FONDO DEL TOOLSTRIP ---
    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
        if (e.ToolStrip is ToolStripDropDown)
        {
            // Fondo de submenús con el color base oscuro de la aplicación
            using (SolidBrush b = new SolidBrush(GetSubmenuFondo()))
            {
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }
        }
        else
        {
            // MenuStrip principal: transparente para que se vea el fondo del Panel/Form
            using (SolidBrush b = new SolidBrush(Color.Transparent))
            {
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }
        }
    }

    // --- 2. ELIMINAR LÍNEA Y BORDES BLANCOS ---

    // Elimina el borde blanco/gris alrededor del submenú
    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        // Dibujar un borde delgado con el color de borde del tema

    }

    // Elimina el margen izquierdo blanco/gris (ImageMargin)
    protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
    {
        if (e.ToolStrip is ToolStripDropDown)
        {
            // Dibuja el margen de imagen con el color de fondo del submenú
            using (SolidBrush b = new SolidBrush(GetSubmenuFondo()))
            {
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }
        }
        else
        {
            // Dejar el margen de imagen del MenuStrip principal transparente
            using (SolidBrush b = new SolidBrush(Color.Transparent))
            {
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }
        }
    }

    // --- 3. FONDO DE LOS ITEMS (HOVER Y SELECCIONADO) ---

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        // Ítems del submenú o la pestaña principal activa
        if (e.Item.Selected || e.Item.Pressed)
        {
            // Fondo del ítem activo/hover (usa el color semi-transparente dinámico)
            using (SolidBrush b = new SolidBrush(GetHoverFondo()))
            {
                e.Graphics.FillRectangle(b, e.Item.ContentRectangle);
            }
        }
        else
        {
            // Fondo transparente
            using (SolidBrush b = new SolidBrush(Color.Transparent))
            {
                e.Graphics.FillRectangle(b, e.Item.ContentRectangle);
            }
        }
    }

    // --- 4. TEXTO Y SEPARADOR ---

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        // Usar color de hover si está seleccionado, sino color normal
        Color colorTexto = e.Item.Selected ? GetTextoHover() : GetTextoNormal();

        // El texto del MenuStrip principal (pestañas superiores)
        if (e.Item.Owner is MenuStrip && !e.Item.Selected && !e.Item.Pressed)
        {
            colorTexto = GetTextoNormal();
        }

        e.TextColor = colorTexto;
        base.OnRenderItemText(e);
    }

    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
        // Separador con color normal del tema, semi-transparente
        Color separatorColor = GetTextoNormal();
        using (Pen p = new Pen(Color.FromArgb(100, separatorColor)))
        {
            e.Graphics.DrawLine(p, e.Item.Bounds.Left, e.Item.Bounds.Height / 2,
                                     e.Item.Bounds.Right, e.Item.Bounds.Height / 2);
        }
    }
}