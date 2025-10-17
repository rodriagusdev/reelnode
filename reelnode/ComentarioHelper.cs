using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reelnode
{
    public static class ComentarioHelper
    {
        // Clase estática auxiliar para crear componentes de UI relacionados con comentarios
        public static class ComentarioUIHelper
        {
            // Método estático que crea un panel visual para un comentario
            // Proveido por Gemini
            public static Panel CrearPanelComentario(Comentario c)
            {
                Panel panel = new Panel
                {
                    Width = 100, 
                    MinimumSize = new Size(0, 100),
                    MaximumSize = new Size(820, 100),
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                // Avatar
                PictureBox pbAvatar = new PictureBox
                {
                    Size = new Size(40, 40),
                    Location = new Point(5, 5),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = null
                };

                // Nombre de usuario
                Label lblUsuario = new Label
                {
                    Text = c.Usuario,
                    Tag = "Titulo",
                    Location = new Point(50, 5),
                    AutoSize = true
                };

                // Fecha de comentario
                Label lblFecha = new Label
                {
                    Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    Font = new Font("Segoe UI", 8, FontStyle.Italic),
                    Location = new Point(50, 25), 
                    ForeColor = Color.Gray,
                    AutoSize = true
                };

                // Comentario
                Label lblTexto = new Label
                {
                    Text = c.Texto,
                    Tag = "Default",
                    Location = new Point(50, 45), 
                    Size = new Size(700, 100),
                    Padding = new Padding(5)
                };

                lblTexto.Width = 1000;

                int textoHeight = lblTexto.PreferredHeight;
                panel.Height = Math.Max(100, 50 + textoHeight);

                panel.Controls.Add(pbAvatar);
                panel.Controls.Add(lblUsuario);
                panel.Controls.Add(lblFecha);
                panel.Controls.Add(lblTexto);

                return panel;
            }
        }
    }
}
