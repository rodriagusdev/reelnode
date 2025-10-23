using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Reelnode
{
    public partial class ControlGestionUsuarios : UserControl
    {
        private PanelGradiente PanelMain;

        private string nombreUsuario = "";
        private int idUsuario = -1;
        public ControlGestionUsuarios()
        {
            InitializeComponent();

            PanelMain = new PanelGradiente();
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(PanelGestionUsuarios);
            this.Controls.Add(PanelMain);
        }

        private void ControlGestionUsuarios_Load(object sender, EventArgs e)
        {
            DataGridUsuarios.DataSource = null;
            DataGridUsuarios.DataSource = UtilsBD.usuariosRegistrados;
            // DataGridUsuarios.Columns["Avatar"].Visible = false;
        }

        /* !--- MODIFICACION DE ROL DE USUARIO ---! */
        private void RbtAdmin_CheckedChanged(object sender, EventArgs e) => DataGridUsuarios.Tag = "1";
        private void RbtUsuario_CheckedChanged(object sender, EventArgs e) => DataGridUsuarios.Tag = "2";

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cambiar el rol del usuario seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                UtilsBD.ModificarUsuarioBD(DataGridUsuarios);
                UtilsBD.CargarUsuario();
                DataGridUsuarios.DataSource = null;
                DataGridUsuarios.DataSource = UtilsBD.usuariosRegistrados;

                PanelCambiarRol.Enabled = false;
            }
        }

        /* !--- FIN MODIFICACION DE ROL DE USUARIO ---! */

        /* !--- HABILITACION CONTEXT MENUS AL CLICKEAR ---! */
        private void CtxMenuModificarRol_Click(object sender, EventArgs e)
        {
            PanelCambiarRol.Enabled = Enabled;
            RbtAdmin.Checked = true;
        }

        private void CtxMenuAsignarPermisos_Click(object sender, EventArgs e)
        {
            LblAdvertencia.Visible = true;
            PanelPermisos.Enabled = true;
        }

        /* !--- FIN HABILITACION CONTEXT MENUS ---! */

        /* !--- PERMISOS ---! */
        private void BtnConfirmarPermisos_Click(object sender, EventArgs e)
        {
            AdministradorPermisos.AsignarPermisos(idUsuario, ChkListPermisos);

            PanelPermisos.Enabled = false;
            LblAdvertencia.Visible = false;
        }

        private void BtnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkListPermisos.Items.Count; i++)
            {
                ChkListPermisos.SetItemChecked(i, true);
            }
        }

        private void CtxMenuVerPermisos_Click(object sender, EventArgs e)
        {
            List<string> obtenerPermisos = AdministradorPermisos.ObtenerPermisosUsuario(idUsuario);

            if (obtenerPermisos != null)
            {
                string textoPermisos = string.Join(" | ", obtenerPermisos);
                LblPermisosUsuario.Text = textoPermisos;
                LblPermisosNombre.Text = $"Permisos de {nombreUsuario}:";
            }
        }

        /* !--- FIN DE PERMISOS ---! */

        /* !--- MANEJO DE CLICK EN DATA GRID ---! */
        private void DataGridUsuarios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridUsuarios.CurrentCell = DataGridUsuarios[e.ColumnIndex, e.RowIndex];

                // Dispara el mismo evento que el click izquierdo.
                DataGridUsuarios_CellClick(sender, new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex));
            }
        }

        private void DataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Asigno las variables globales para que tomen el valor de las celdas de la fila actual.
                nombreUsuario = DataGridUsuarios.CurrentRow.Cells["NombreUsuario"].Value.ToString();
                idUsuario = Convert.ToInt32(DataGridUsuarios.CurrentRow.Cells["Id"].Value);
            }
        }

        /* !--- FIN MANEJO DE CLICK EN DATA GRID ---! */

        /* !--- FORMATEO DE FILAS ---! */

        private void DataGridUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Para que las fechas se muestren como, por ejemplo, "2023/11/05" en lugar del formato por defecto.
            if (DataGridUsuarios.Columns[e.ColumnIndex].Name == "FechaRegistro" && e.Value != null)
            {
                if (e.Value is DateTime fecha)
                {
                    e.Value = fecha.ToString("yyyy/MM/dd");
                    e.FormattingApplied = true;
                }
            }

            // Coloreo los roles de usuario.
            if (DataGridUsuarios.Columns[e.ColumnIndex].Name == "RolUsuario" &&
            e.Value != null && e.Value.ToString() == "Admin")
            {
                e.CellStyle.ForeColor = Color.Green;
            }
            else if (DataGridUsuarios.Columns[e.ColumnIndex].Name == "RolUsuario" &&
            e.Value != null && e.Value.ToString() == "Moderador")
            {
                e.CellStyle.ForeColor = Color.Purple;
            }
        }

        /* !--- FIN FORMATEO DE FILAS ---! */
    }
}
/*        private void BtnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF (*.pdf)|*.pdf";
            saveFile.FileName = "Personas.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    Paragraph titulo = new Paragraph("Listado de Personas");
                    titulo.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(titulo);
                    pdfDoc.Add(new Paragraph(" "));

                    PdfPTable tabla = new PdfPTable(4); 
                    tabla.WidthPercentage = 100;
                    tabla.AddCell("Nombre");
                    tabla.AddCell("Email");
                    tabla.AddCell("Fecha Registro");
                    tabla.AddCell("Rol");

                    foreach (var p in UtilsBD.usuariosRegistrados)
                    {
                        tabla.AddCell(p.NombreUsuario);
                        tabla.AddCell(p.Email);
                        tabla.AddCell(p.FechaRegistro.ToString());
                        tabla.AddCell(p.RolUsuario);
                    }

                    pdfDoc.Add(tabla);
                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("PDF exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/