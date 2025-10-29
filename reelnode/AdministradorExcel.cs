using System;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Reelnode
{
    public static class AdministradorExcel
    {
        public static void ExportarDataGridViewAExcel(DataGridView tablaDatos, string rutaArchivo)
        {
            // Validar extensión
            if (!rutaArchivo.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                rutaArchivo += ".xlsx";
            }

            try
            {
                if (tablaDatos == null)
                    throw new ArgumentNullException(nameof(tablaDatos));

                if (tablaDatos.Rows.Count == 0 || (tablaDatos.Rows.Count == 1 && tablaDatos.Rows[0].IsNewRow))
                {
                    MessageBox.Show(
                        "No hay datos para exportar.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                using (var libroExcel = new XLWorkbook())
                {
                    var hoja = libroExcel.Worksheets.Add("Datos");

                    int filaActual = 1; // Fila 1 para encabezados

                    // === Escribir encabezados ===
                    for (int col = 0; col < tablaDatos.Columns.Count; col++)
                    {
                        var celda = hoja.Cell(filaActual, col + 1);
                        celda.Value = tablaDatos.Columns[col].HeaderText ?? $"Columna{col + 1}";
                        celda.Style.Font.Bold = true;
                        celda.Style.Fill.BackgroundColor = XLColor.LightGray;
                        celda.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }

                    filaActual = 2; // Datos empiezan en fila 2

                    // === Escribir filas de datos ===
                    foreach (DataGridViewRow fila in tablaDatos.Rows)
                    {
                        if (fila.IsNewRow) continue;

                        for (int col = 0; col < tablaDatos.Columns.Count; col++)
                        {
                            var celda = hoja.Cell(filaActual, col + 1);
                            var valor = fila.Cells[col].Value;

                            // Manejar tipos de datos comunes
                            if (valor == null || valor == DBNull.Value)
                            {
                                celda.Value = "";
                            }
                            else if (valor is DateTime date)
                            {
                                celda.Value = date;
                                celda.Style.DateFormat.Format = "dd/MM/yyyy HH:mm";
                            }
                            else if (valor is decimal || valor is double || valor is float || valor is int || valor is long)
                            {
                                celda.Value = Convert.ToDouble(valor);
                                celda.Style.NumberFormat.Format = "#,##0.00";
                            }
                            else
                            {
                                celda.Value = valor.ToString();
                            }
                        }
                        filaActual++;
                    }

                    // Ajustar ancho de columnas (solo hasta 50 caracteres máximo por rendimiento)
                    hoja.Columns().AdjustToContents(1, 50);

                    // Guardar archivo
                    libroExcel.SaveAs(rutaArchivo);
                }

                MessageBox.Show(
                    $"Exportación completada correctamente.\nArchivo guardado en:\n{rutaArchivo}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    "No se pudo guardar el archivo. Verifica que no esté abierto en Excel u otro programa.\n\n" +
                    "Detalles: " + ex.Message,
                    "Archivo en uso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "Acceso denegado. No tienes permisos para guardar en esta ubicación.",
                    "Permiso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error inesperado al exportar a Excel:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}