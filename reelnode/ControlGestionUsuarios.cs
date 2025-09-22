using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectoNuevo
{
    public partial class ControlGestionUsuarios : UserControl
    {
        public ControlGestionUsuarios()
        {
            InitializeComponent();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
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
        }

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
            }
        }

        private void RbtAdmin_CheckedChanged(object sender, EventArgs e) => DataGridUsuarios.Tag = "1";

        private void RbtUsuario_CheckedChanged(object sender, EventArgs e) => DataGridUsuarios.Tag = "2";

        private void DataGridUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataGridUsuarios.Columns[e.ColumnIndex].Name == "FechaRegistro" && e.Value != null)
            {
                if (e.Value is DateTime fecha)
                {
                    e.Value = fecha.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }

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
            else e.CellStyle.ForeColor = Color.Black;
        }

        private void CtxMenuModificarRol_Click(object sender, EventArgs e)
        {
            PanelCambiarRol.Visible = true;
            RbtAdmin.Checked = true;
        }

        private void ControlGestionUsuarios_Load(object sender, EventArgs e)
        {
            DataGridUsuarios.DataSource = null;
            DataGridUsuarios.DataSource = UtilsBD.usuariosRegistrados;
        }

        private void DataGridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
