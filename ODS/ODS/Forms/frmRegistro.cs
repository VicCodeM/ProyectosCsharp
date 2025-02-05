using DevExpress.DocumentServices.ServiceModel.DataContracts;
using DevExpress.Export.Xl;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using ODS.Datos;
using System;
using System.Data;
using System.Windows.Forms;

using ClosedXML.Excel;
using DevExpress.XtraWaitForm;
using ODS.Modelo;

namespace ODS.Forms
{
    public partial class frmRegistro : DevExpress.XtraEditors.XtraUserControl
    {
        #region Intaciar objetos Utilizados
        ConexionDB conexionDB = new ConexionDB();
        ConsultasDB consultasDB = new ConsultasDB();
        #endregion


     

        public frmRegistro()
        {
            InitializeComponent();

            #region Acciones al incio del form
            //Cargar ordenes jutno con el formulario
            CargarOrdenes();
            CargarListasDesplegables();

            //configuramos RadioButton para el tipo de estado de la orden
            radioGroupEstados.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Abierto", "Abierto"));
            radioGroupEstados.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Pendiente", "Pendiente"));
            radioGroupEstados.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Completado", "Completado"));
            radioGroupEstados.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Cancelado", "Cancelado"));
            //Configuracion para el eveneto seleccionar datagrid y rellenar datos
            ((GridView)gridControl1.MainView).FocusedRowChanged += gridControl1_FocusedRowChanged;
            //No se modifica desde el datagrid
            ((GridView)gridControl1.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridControl1.MainView).BestFitColumns();
            ((GridView)gridControl1.MainView).OptionsView.ShowDetailButtons = false;
            //cargar usuario dentro del label
            ObtenerUsuario();

            // Mostrar la fecha y hora actual en el Label
            labelFecha.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
            #endregion
        }

        #region Métodos de form




        //metodo caragar usuario
        //Obtener usuario
        public void ObtenerUsuario()
        {
            //cerrar cualquier conexion abierta
            conexionDB.CerrarConexion();
            // Obtener el nombre del usuario con el ID 1 (puedes cambiar este valor según sea necesario)
            int idUsuario = UsuarioLogueado.IdUsuario; // ID de usuario que deseas consultar
           //string nombreUsuario = consultasDB.ObtenerNombreUsuario(idUsuario);

            // Mostrar el nombre del usuario en el label
            if (!string.IsNullOrEmpty(UsuarioLogueado.NombreUsuario))
            {
                labelUsuario.Text = $"Usuario: {UsuarioLogueado.NombreUsuario}";
            }
            else
            {
                labelUsuario.Text = "No se encontró el nombre de usuario.";
            }
        }




        //caragra ordenes en grid
        private void CargarOrdenes()
        {

            // Obtener todas las órdenes (puedes adaptar este método según cómo se obtienen en tu base de datos)
            DataTable tablaOrdenes = consultasDB.ObtenerTodasLasOrdenes();

            if (tablaOrdenes.Rows.Count > 0)
            {
                // Agregar una columna para la hora, si no existe
                if (!tablaOrdenes.Columns.Contains("Hora"))
                {
                    tablaOrdenes.Columns.Add("Hora", typeof(string));
                }

                // Llenar la columna "Hora" con la hora extraída de la columna "Fecha_Registro"
                foreach (DataRow row in tablaOrdenes.Rows)
                {
                    if (row["Fecha_Registro"] != DBNull.Value)
                    {
                        DateTime fecha = Convert.ToDateTime(row["Fecha_Registro"]);
                        row["Hora"] = fecha.ToString("hh:mm tt"); // Solo la hora en formato de 12 horas
                    }
                }

                // Asignar el DataTable al grid
                gridControl1.DataSource = tablaOrdenes;

                // Configurar el GridView
                GridView gridViewOrdenes = (GridView)gridControl1.MainView;

                // Formato de las fechas en las columnas existentes
                gridViewOrdenes.Columns["Fecha_Atencion"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Fecha_Atencion"].DisplayFormat.FormatString = "dd-MM-yyyy hh:mm tt";

                gridViewOrdenes.Columns["Fecha_Cierre"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Fecha_Cierre"].DisplayFormat.FormatString = "dd-MM-yyyy hh:mm tt";

                gridViewOrdenes.Columns["Fecha_Registro"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Fecha_Registro"].DisplayFormat.FormatString = "dd-MM-yyyy";

                // Formato para la nueva columna "Hora"
                gridViewOrdenes.Columns["Hora"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Hora"].DisplayFormat.FormatString = "hh:mm tt";

                // Ajustar el orden: colocar la columna "Hora" después de "Fecha_Registro"
                gridViewOrdenes.Columns["Fecha_Registro"].VisibleIndex = 1; // Primera columna
                gridViewOrdenes.Columns["Hora"].VisibleIndex = 2;   // Segunda columna
                gridViewOrdenes.Columns["Usuario"].VisibleIndex = 3;
                gridViewOrdenes.Columns["Descripcion"].VisibleIndex = 4;
                gridViewOrdenes.Columns["Fecha_Atencion"].VisibleIndex = 5;
                gridViewOrdenes.Columns["Observaciones"].VisibleIndex = 6;
                gridViewOrdenes.Columns["Hardware"].VisibleIndex = 7;
                gridViewOrdenes.Columns["Software"].VisibleIndex = 8;
                gridViewOrdenes.Columns["Fecha_Cierre"].VisibleIndex = 9;
                gridViewOrdenes.Columns["Departamento"].VisibleIndex = 10;
                gridViewOrdenes.Columns["Estado"].VisibleIndex = 11;
                // Opcional: Ajustar el ancho de las columnas automáticamente
                gridViewOrdenes.BestFitColumns();
            }
            else
            {
                XtraMessageBox.Show("No se encontraron órdenes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gridControl1.Refresh();
        }


        private void CargarDatosOrdenSeleccionada(int idOrden)
        {
            // Llamar al método de la clase ConsultasDB para obtener los datos
            DataRow row = consultasDB.CargarDatosOrdenSeleccionada(idOrden);

            if (row != null)
            {
                // Llenar los controles con los datos obtenidos
                txtIdOrden.EditValue = row["Id_Orden"];
                dateEditFechaCreacion.EditValue = row["Fecha_Creacion"];
                dateEditFechaAtendida.EditValue = row["Fecha_Atendida"] == DBNull.Value ? null : row["Fecha_Atendida"];
                dateEditFechaCerrada.EditValue = row["Fecha_Cerrada"] == DBNull.Value ? null : row["Fecha_Cerrada"];
                lookUpEditListaUsuarios.EditValue = row["Id_Usuario"];
                lookUpEditHadware.EditValue = row["Id_TipoFallaHardware"] == DBNull.Value ? null : row["Id_TipoFallaHardware"];
                lookUpEditSofware.EditValue = row["Id_TipoFallaSoftware"] == DBNull.Value ? null : row["Id_TipoFallaSoftware"];
                memoEditDescripcion.Text = row["Descripcion_Problema"].ToString();
                memoEditObsevacion.Text = row["Observaciones"].ToString();

                // Configurar el estado en el RadioGroup
                string estado = row["Estado"].ToString();
                radioGroupEstados.EditValue = estado;
            }
            else
            {
                // Si no se encuentra la orden, puedes mostrar un mensaje o manejar el error
                DevExpress.XtraEditors.XtraMessageBox.Show("No se encontraron datos para la orden seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarListasDesplegables()
        {

            // Llamar al método para obtener las tablas de los datos
            DataTable tablaUsuarios, tablaHardware, tablaSoftware;
            consultasDB.CargarListasDesplegables(out tablaUsuarios, out tablaHardware, out tablaSoftware);

            // Crear fila "Ninguno" para Hardware
            DataRow drHardware = tablaHardware.NewRow();
            drHardware["Id_TipoFallaHardware"] = DBNull.Value;  // Este valor indica que no se ha seleccionado una falla de hardware
            drHardware["Descripcion"] = "Ninguno";  // Texto que aparecerá en la lista
            tablaHardware.Rows.InsertAt(drHardware, 0);  // Insertar al principio

            // Crear fila "Ninguno" para Software
            DataRow drSoftware = tablaSoftware.NewRow();
            drSoftware["Id_TipoFallaSoftware"] = DBNull.Value;  // Este valor indica que no se ha seleccionado una falla de software
            drSoftware["Descripcion"] = "Ninguno";  // Texto que aparecerá en la lista
            tablaSoftware.Rows.InsertAt(drSoftware, 0);  // Insertar al principio

            // Asignar los datos a los LookUpEdit
            lookUpEditListaUsuarios.Properties.DataSource = tablaUsuarios;
            lookUpEditListaUsuarios.Properties.DisplayMember = "Usuario";
            lookUpEditListaUsuarios.Properties.ValueMember = "Id_Usuario";

            lookUpEditHadware.Properties.DataSource = tablaHardware;
            lookUpEditHadware.Properties.DisplayMember = "Descripcion";
            lookUpEditHadware.Properties.ValueMember = "Id_TipoFallaHardware";
            lookUpEditHadware.Properties.NullText = "Seleccione una falla de hardware";  // Texto cuando no hay valor seleccionado

            lookUpEditSofware.Properties.DataSource = tablaSoftware;
            lookUpEditSofware.Properties.DisplayMember = "Descripcion";
            lookUpEditSofware.Properties.ValueMember = "Id_TipoFallaSoftware";
            lookUpEditSofware.Properties.NullText = "Seleccione una falla de software";  // Texto cuando no hay valor seleccionado
        }

        #endregion


        #region Eventos del Form
        private void gridControl1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView gridView = (GridView)sender;

            // Obtiene el Id de la orden seleccionada
            int idOrdenSeleccionada = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id"));
            Console.WriteLine("ID Orden seleccionada: " + idOrdenSeleccionada); // Para depurar

            // Llama al método para cargar los datos al formulario
            CargarDatosOrdenSeleccionada(idOrdenSeleccionada);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los controles
                int idOrden;
                DateTime? fechaAtendida = dateEditFechaAtendida.EditValue as DateTime?;
                DateTime? fechaCerrada = dateEditFechaCerrada.EditValue as DateTime?;
                int idUsuario;
                int? idFallaHardware = lookUpEditHadware.EditValue as int?;
                int? idFallaSoftware = lookUpEditSofware.EditValue as int?;
                string descripcion = memoEditDescripcion.Text;
                string observaciones = memoEditObsevacion.Text;
                string estado;

                // Validar y convertir los valores necesarios
                try
                {
                    idOrden = Convert.ToInt32(txtIdOrden.EditValue);
                    idUsuario = Convert.ToInt32(lookUpEditListaUsuarios.EditValue);
                    estado = radioGroupEstados.EditValue?.ToString();

                    if (estado == null)
                    {
                        throw new InvalidOperationException("El estado no puede ser nulo.");
                    }
                }
                catch (FormatException ex)
                {
                    XtraMessageBox.Show($"Error al convertir un valor: {ex.Message}", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidCastException ex)
                {
                    XtraMessageBox.Show($"Error al obtener un valor de los controles: {ex.Message}", "Error de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validación: Solo se debe seleccionar una falla (Hardware o Software)
                if (idFallaHardware.HasValue && idFallaSoftware.HasValue)
                {
                    XtraMessageBox.Show("Solo puede seleccionar una de las fallas (Hardware o Software), no ambas.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Asignar la hora actual a las fechas si están presentes
                if (fechaAtendida.HasValue)
                {
                    fechaAtendida = fechaAtendida.Value.Date.Add(DateTime.Now.TimeOfDay); // Asigna la fecha seleccionada y la hora actual
                }
                if (fechaCerrada.HasValue)
                {
                    fechaCerrada = fechaCerrada.Value.Date.Add(DateTime.Now.TimeOfDay); // Asigna la fecha seleccionada y la hora actual
                }

                // Llamar al método ActualizarOrden dentro de un bloque try-catch para manejar errores de base de datos
                try
                {
                    consultasDB.ActualizarOrden(idOrden, fechaAtendida, fechaCerrada, idUsuario, idFallaHardware, idFallaSoftware, descripcion, observaciones, estado);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error al actualizar la orden en la base de datos: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mostrar un mensaje de éxito
                XtraMessageBox.Show("Orden de servicio actualizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar el GridControl
                try
                {
                    gridControl1.RefreshDataSource();
                    CargarOrdenes();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error al refrescar los datos: {ex.Message}", "Error de Refresco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Capturar cualquier otra excepción inesperada
                XtraMessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdOrden.EditValue == null || string.IsNullOrEmpty(txtIdOrden.Text))
            {
                XtraMessageBox.Show("Seleccione una orden para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idOrden = Convert.ToInt32(txtIdOrden.EditValue);

            // Confirmación antes de eliminar
            DialogResult resultado = XtraMessageBox.Show("¿Está seguro de que desea eliminar esta orden?", "Confirmar Eliminación",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {

                bool eliminado = consultasDB.EliminarOrden(idOrden);

                if (eliminado)
                {
                    XtraMessageBox.Show("Orden eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar el GridControl después de eliminar
                    CargarOrdenes();
                }
                else
                {
                    XtraMessageBox.Show("No se pudo eliminar la orden. Verifique si existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion


        // Método para exportar el GridControl a Excel
        private void Exportar()
        {
            // Obtener el GridView del GridControl
            GridView gridView = (GridView)gridControl1.MainView;

            // Crear un objeto de opciones de exportación para el formato Xlsx
            XlsxExportOptionsEx opcionesExportacion = new XlsxExportOptionsEx()
            {
                ExportMode = XlsxExportMode.SingleFile, // Exportar todo en un solo archivo
                TextExportMode = TextExportMode.Text, // Exportar texto como texto
                SheetName = "Reporte de Órdenes", // Nombre de la hoja de Excel
                ExportType = DevExpress.Export.ExportType.WYSIWYG, // Exportar según lo que se ve en el Grid
            };


            // Mostrar un cuadro de diálogo para guardar el archivo Excel
            SaveFileDialog guardarArchivo = new SaveFileDialog
            {
                Filter = "Archivos Excel (*.xlsx)|*.xlsx" // Filtro para guardar como .xlsx
            };

            if (guardarArchivo.ShowDialog() == DialogResult.OK)
            {
                // Exportar los datos de la vista del Grid a un archivo Excel
                gridView.ExportToXlsx(guardarArchivo.FileName, opcionesExportacion);

                // Mostrar mensaje de éxito
                XtraMessageBox.Show("El reporte se ha exportado con éxito.", "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        var hoja = workbook.Worksheets.Add("Órdenes");

                        // Agregar el título y centrarlo
                        hoja.Cell(1, 1).Value = "Nombre de la Empresa";
                        hoja.Cell(1, 1).Style.Font.Bold = true;
                        hoja.Cell(1, 1).Style.Font.FontColor = XLColor.White;
                        hoja.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.DarkBlue;
                        hoja.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        hoja.Cell(2, 1).Value = "Reporte de Órdenes";
                        hoja.Cell(2, 1).Style.Font.Bold = true;
                        hoja.Cell(2, 1).Style.Font.FontColor = XLColor.White;
                        hoja.Cell(2, 1).Style.Fill.BackgroundColor = XLColor.DarkGreen;
                        hoja.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        hoja.Cell(3, 1).Value = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
                        hoja.Cell(3, 1).Style.Font.Italic = true;
                        hoja.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        hoja.Row(1).Height = 25;
                        hoja.Row(2).Height = 25;
                        hoja.Row(3).Height = 20;

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




        private void simpleButton1_Click(object sender, EventArgs e)
        {
            

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            // Exportar();
            ExportarExcel();
        }
    }
}
