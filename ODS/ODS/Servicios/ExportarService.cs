using ClosedXML.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ODS.Modelo
{
    public class ExportarService
    {
        // Constantes para configuración visual
        private const string TITULO_EMPRESA = "JMAS de Cuauhtémoc";
        private const int ALTURA_ENCABEZADO = 30; // Altura de las filas del encabezado
        private const int ALTURA_FILA_DATOS = 20; // Altura de las filas de datos

        /// <summary>
        /// Método para exportar datos visibles en un GridControl a un archivo Excel con diseño profesional.
        /// </summary>
        /// <param name="gridControl">El GridControl que contiene los datos.</param>
        /// <param name="nombreReporte">El nombre del reporte (opcional).</param>
        public void ExportarExcel(GridControl gridControl, string nombreReporte = "Órdenes de Servicio")
        {
            try
            {
                // Validar que el DataSource no sea nulo
                if (gridControl.DataSource == null)
                {
                    XtraMessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los datos visibles en el GridControl
                GridView gridView = gridControl.MainView as GridView;
                if (gridView == null)
                {
                    XtraMessageBox.Show("La vista principal del GridControl no es compatible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear un DataTable con los datos visibles
                DataTable dataTable = GetVisibleData(gridView);

                // Crear un cuadro de diálogo para guardar el archivo
                using (SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Archivos Excel (*.xlsx)|*.xlsx",
                    Title = "Guardar Reporte en Excel"
                })
                {
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaArchivo = saveDialog.FileName;

                        // Crear un libro de trabajo de Excel
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var hoja = workbook.Worksheets.Add(nombreReporte);

                            // Agregar encabezado del reporte
                            AgregarEncabezado(hoja, nombreReporte, dataTable.Columns.Count);

                            // Insertar los datos de la tabla
                            InsertarDatos(hoja, dataTable, dataTable.Columns.Count);

                            // Guardar el archivo
                            workbook.SaveAs(rutaArchivo);
                        }

                        // Abrir automáticamente el archivo Excel generado
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = rutaArchivo,
                            UseShellExecute = true
                        });

                        // Mostrar mensaje de éxito
                        XtraMessageBox.Show("Reporte exportado con éxito en Excel.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores específicos
                XtraMessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene los datos visibles en el GridView del GridControl.
        /// </summary>
        /// <param name="gridView">El GridView del GridControl.</param>
        /// <returns>Un DataTable con los datos visibles.</returns>
        private DataTable GetVisibleData(GridView gridView)
        {
            DataTable dataTable = new DataTable();

            // Agregar columnas al DataTable
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
            {
                if (column.Visible)
                {
                    dataTable.Columns.Add(column.FieldName);
                }
            }

            // Agregar filas al DataTable
            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
                {
                    if (column.Visible)
                    {
                        dataRow[column.FieldName] = gridView.GetRowCellValue(i, column);
                    }
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        /// <summary>
        /// Agrega el encabezado del reporte a la hoja de Excel.
        /// </summary>
        /// <param name="hoja">La hoja de Excel donde se agregará el encabezado.</param>
        /// <param name="nombreReporte">El nombre del reporte.</param>
        /// <param name="columnas">El número de columnas en la tabla.</param>
        private void AgregarEncabezado(IXLWorksheet hoja, string nombreReporte, int columnas)
        {
            // Título de la empresa
            hoja.Cell(1, 1).Value = TITULO_EMPRESA;
            AplicarEstiloEncabezado(hoja.Cell(1, 1), XLColor.FromHtml("#283593"), true);
            hoja.Range(1, 1, 1, columnas).Merge(); // Combinar celdas para el título

            // Título del reporte
            hoja.Cell(2, 1).Value = nombreReporte;
            AplicarEstiloEncabezado(hoja.Cell(2, 1), XLColor.FromHtml("#3F51B5"), true);
            hoja.Range(2, 1, 2, columnas).Merge(); // Combinar celdas para el título

            // Fecha actual
            hoja.Cell(3, 1).Value = $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
            AplicarEstiloEncabezado(hoja.Cell(3, 1), XLColor.WhiteSmoke, false);
            hoja.Cell(3,1).Style.Font.FontColor = XLColor.Black;
            hoja.Range(3, 1, 3, columnas).Merge(); // Combinar celdas para la fecha

            // Ajustar altura de las filas del encabezado
            hoja.Row(1).Height = ALTURA_ENCABEZADO;
            hoja.Row(2).Height = ALTURA_ENCABEZADO;
            hoja.Row(3).Height = ALTURA_ENCABEZADO;

            // Espaciado entre el encabezado y los datos
            hoja.Row(4).Height = 10; // Fila vacía para separar
        }

        /// <summary>
        /// Inserta los datos de la tabla en la hoja de Excel.
        /// </summary>
        /// <param name="hoja">La hoja de Excel donde se insertarán los datos.</param>
        /// <param name="dataTable">La tabla de datos a insertar.</param>
        /// <param name="columnas">El número de columnas en la tabla.</param>
        private void InsertarDatos(IXLWorksheet hoja, DataTable dataTable, int columnas)
        {
            // Insertar la tabla de datos a partir de la fila 5
            var rangoTabla = hoja.Cell(5, 1).InsertTable(dataTable.AsEnumerable());

            // Acceder a la primera fila del rango (encabezado)
            var encabezado = rangoTabla.FirstRow();

            // Estilo del encabezado de la tabla
            encabezado.Style.Font.Bold = true;
            encabezado.Style.Fill.BackgroundColor = XLColor.FromHtml("#1F3566");
            encabezado.Style.Font.FontColor = XLColor.White;
            encabezado.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            encabezado.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            encabezado.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            // Ajustar el ancho de las columnas
            hoja.Columns().AdjustToContents();

            // Asegurarse de que la hoja se ajuste al tamaño de la página al imprimir
            hoja.PageSetup.FitToPages(1, 0);

            // Ajustar altura de las filas de datos
            foreach (var row in hoja.RowsUsed().Skip(4)) // Saltar las primeras 4 filas (encabezado)
            {
                row.Height = ALTURA_FILA_DATOS;
            }
        }

        /// <summary>
        /// Aplica un estilo común a las celdas del encabezado.
        /// </summary>
        /// <param name="celda">La celda a la que se aplicará el estilo.</param>
        /// <param name="colorFondo">El color de fondo de la celda.</param>
        /// <param name="esNegrita">Indica si el texto debe ser negrita.</param>
        private void AplicarEstiloEncabezado(IXLCell celda, XLColor colorFondo, bool esNegrita)
        {
            celda.Style.Font.Bold = esNegrita;
            celda.Style.Font.FontSize = esNegrita ? 14 : 12; // Tamaño de fuente
            celda.Style.Font.FontColor = XLColor.White;
            celda.Style.Fill.BackgroundColor = colorFondo;
            celda.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            celda.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        }
    }
}