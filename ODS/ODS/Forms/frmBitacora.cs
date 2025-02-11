using ClosedXML.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using ODS.Modelo;
using ODS.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmBitacora : XtraUserControl
    {


        public frmBitacora()
        {
            InitializeComponent();
            ((GridView)gridControl1.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridControl1.MainView).BestFitColumns();
            ((GridView)gridControl1.MainView).OptionsView.ShowDetailButtons = false;

            LoadDataToGrid(); // Cargar datos al abrir el formulario
            label2.Text = UsuarioLogueado.NombreCompleto;
        }
        private void LoadDataToGrid()
        {
            try
            {
                BitacoraService bitacoraService = new BitacoraService();
                DataTable dataTable = bitacoraService.ObtenerDatosBitacora();

                if (dataTable != null)
                {
                    gridControl1.DataSource = dataTable;

                    GridView gridView = gridControl1.MainView as GridView;
                    if (gridView != null)
                    {
                        gridView.Columns["Id"].Caption = "Id";
                        gridView.Columns["Id_Orden"].Caption = "Id Orden";
                        gridView.Columns["Administrador"].Caption = "Administrador";
                        gridView.Columns["Accion"].Caption = "Acción";
                        gridView.Columns["Fecha"].Caption = "Fecha";
                        gridView.Columns["Hora"].Caption = "Hora";
                        gridView.Columns["Descripcion"].Caption = "Descripción";

                        // Ajustar las columnas automáticamente
                        gridView.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos en el GridControl: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarExcel()
        {
            try
            {
                // Crear un cuadro de diálogo para que el usuario elija dónde guardar el archivo
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Archivos Excel (*.xlsx)|*.xlsx",
                    Title = "Guardar Reporte en Excel"
                };

                // Verificar si el usuario seleccionó una ubicación para guardar
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveDialog.FileName;

                    // Crear un libro de trabajo de Excel
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        // Obtener la fuente de datos del GridControl
                        DataTable dt = (DataTable)gridControl1.DataSource;

                        // Crear una hoja de trabajo y agregar los datos de la tabla
                        var hoja = workbook.Worksheets.Add("Órdenes de Servicio");

                        // Agregar el título y centrarlo
                        hoja.Cell(1, 1).Value = "JMAS de Cuauhtémoc";
                        hoja.Cell(1, 1).Style.Font.Bold = true;
                        hoja.Cell(1, 1).Style.Font.FontColor = XLColor.White;
                        hoja.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.DarkBlue;
                        hoja.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        hoja.Cell(2, 1).Value = "Órdenes de Servicio";
                        hoja.Cell(2, 1).Style.Font.Bold = true;
                        hoja.Cell(2, 1).Style.Font.FontColor = XLColor.White;
                        hoja.Cell(2, 1).Style.Fill.BackgroundColor = XLColor.DarkGreen;
                        hoja.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        hoja.Cell(3, 1).Value = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
                        hoja.Cell(3, 1).Style.Font.Italic = true;
                        hoja.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        hoja.Row(1).Height = 25;
                        hoja.Row(2).Height = 25;
                        hoja.Row(3).Height = 25;
                        hoja.Row(4).Height = 25;

                        // Espaciado entre el encabezado y los datos
                        hoja.Row(4).Height = 10;

                        // Insertar la tabla de datos a partir de la fila 5
                        var encabezado = hoja.Cell(5, 1).InsertTable(dt)
                            .Range(5, 1, 5, dt.Columns.Count).FirstRow();

                        // Estilo del encabezado de la tabla
                        encabezado.Style.Font.Bold = true;
                        encabezado.Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
                        encabezado.Style.Font.FontColor = XLColor.White;
                        encabezado.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // Ajustar el encabezado para que ocupe todo el ancho de la tabla
                        hoja.Range(1, 1, 1, dt.Columns.Count).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        hoja.Range(2, 1, 2, dt.Columns.Count).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        hoja.Range(3, 1, 3, dt.Columns.Count).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // Aplicar bordes y formato a la tabla de datos
                        hoja.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                        hoja.RangeUsed().Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        // Ajustar el ancho de las columnas
                        hoja.Columns().AdjustToContents();

                        // Ajustar el ancho de la columna de la fecha específicamente
                        hoja.Column("C").Width = 20;  // Ajusta el ancho de la columna de la fecha

                        // Asegurarse de que la hoja se ajuste al tamaño de la página al imprimir
                        hoja.PageSetup.FitToPages(1, 0);  // Ajusta el contenido para que quepa en una página

                        // Guardar el archivo en la ubicación seleccionada
                        workbook.SaveAs(rutaArchivo);
                    }

                    // Mostrar un mensaje de éxito
                    XtraMessageBox.Show("Reporte exportado con éxito en Excel.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la exportación
                XtraMessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        private void btnExportar_Click(object sender, EventArgs e)
        {
            //Exportar los datos del GridControl a un archivo de Excel
            ExportarExcel();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
