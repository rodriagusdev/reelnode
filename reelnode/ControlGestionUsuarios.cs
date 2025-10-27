using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            ChkListPermisos.Items.Clear();

            AdministradorPermisos.MostrarPermisosEnLista(ChkListPermisos);
            Utils.ActualizarListaGrid(
                DataGridUsuarios,
                AdministradorUsuarios.usuariosRegistrados,
                "Password"
            );
        }

        /* !--- MODIFICACION DE ROL DE USUARIO ---! */

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas cambiar el rol del usuario seleccionado?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                bool modificacionExitosa = AdministradorUsuarios.ModificarRolUsuario(
                    DataGridUsuarios
                );

                if (modificacionExitosa)
                {
                    AdministradorUsuarios.CargarUsuarios();
                    Utils.ActualizarListaGrid(
                        DataGridUsuarios,
                        AdministradorUsuarios.usuariosRegistrados,
                        "Password"
                    );

                    PanelCambiarRol.Enabled = false;
                }
            }
        }

        /* !--- FIN MODIFICACION DE ROL DE USUARIO ---! */

        /* !--- ASIGNACION PERMISOS ---! */
        private void BtnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkListPermisos.Items.Count; i++)
            {
                ChkListPermisos.SetItemChecked(i, true);
            }
        }

        private void BtnConfirmarPermisos_Click(object sender, EventArgs e)
        {
            AdministradorPermisos.AsignarPermisos(idUsuario, ChkListPermisos);

            for (int i = 0; i < ChkListPermisos.Items.Count; i++)
            {
                ChkListPermisos.SetItemChecked(i, false);
            }

            PanelPermisos.Enabled = false;
            LblAdvertencia.Visible = false;
        }

        /* !--- FIN DE ASIGNACION PERMISOS ---! */

        /* !--- MANEJO DE CLICK EN DATA GRID ---! */
        private void DataGridUsuarios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridUsuarios.CurrentCell = DataGridUsuarios[e.ColumnIndex, e.RowIndex];

                // Dispara el mismo evento que el click izquierdo.
                DataGridUsuarios_CellClick(
                    sender,
                    new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex)
                );
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

        private void DataGridUsuarios_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e
        )
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
            if (
                DataGridUsuarios.Columns[e.ColumnIndex].Name == "RolUsuario"
                && e.Value != null
                && e.Value.ToString().ToLower() == "admin"
            )
            {
                e.CellStyle.ForeColor = AdministradorTema.MoradoNeonBoton;
            }
            else if (
                DataGridUsuarios.Columns[e.ColumnIndex].Name == "RolUsuario"
                && e.Value != null
                && e.Value.ToString().ToLower() == "superadmin"
            )
            {
                e.CellStyle.ForeColor = AdministradorTema.VerdeClaroNeon;
            }
            else if (
                DataGridUsuarios.Columns[e.ColumnIndex].Name == "RolUsuario"
                && e.Value != null
                && e.Value.ToString().ToLower() == "usuario"
            )
            {
                e.CellStyle.ForeColor = AdministradorTema.RosaNeon;
            }
        }

        /* !--- FIN FORMATEO DE FILAS ---! */

        /* !--- EVENTOS MENU CONTEXTUAL Y RBTBUTTONS ---! */

        private void RbtAdmin_CheckedChanged(object sender, EventArgs e) =>
            DataGridUsuarios.Tag = "2";

        private void RbtUsuario_CheckedChanged(object sender, EventArgs e) =>
            DataGridUsuarios.Tag = "3";

        private void CtxMenuModificarRol_Click(object sender, EventArgs e)
        {
            PanelCambiarRol.Enabled = true;
        }

        private void CtxMenuAsignarPermisos_Click(object sender, EventArgs e)
        {
            List<string> listPermisosUsuarioSeleccionado =
                AdministradorPermisos.ObtenerPermisosUsuario(idUsuario);

            for (int i = 0; i < ChkListPermisos.Items.Count; i++)
            {
                if (listPermisosUsuarioSeleccionado.Contains(ChkListPermisos.Items[i]))
                {
                    ChkListPermisos.SetItemChecked(i, true);
                }
            }

            LblAdvertencia.Visible = true;
            PanelPermisos.Enabled = true;
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

        private void CtxMenuEliminarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar al usuario seleccionado?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                bool eliminacionExitosa = AdministradorUsuarios.EliminarUsuario(idUsuario);

                if (eliminacionExitosa)
                {
                    AdministradorUsuarios.CargarUsuarios();
                    Utils.ActualizarListaGrid(
                        DataGridUsuarios,
                        AdministradorUsuarios.usuariosRegistrados,
                        "Password"
                    );
                }
            }
        }

        /* !--- FIN HABILITACION CONTEXT MENUS ---! */
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
