using ClosedXML.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using ODS.Modelo;
using ODS.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static ODS.Modelo.OrdenService;

namespace ODS.Forms
{
    public partial class frmAdminRegistros : DevExpress.XtraEditors.XtraUserControl
    {
        #region Intaciar objetos Utilizados
        ConexionDB conexionDB = new ConexionDB();
        ConsultasDB consultasDB = new ConsultasDB();
        BitacoraService bitacoraService = new BitacoraService();
        ExportarService generarreporte = new ExportarService();
        #endregion




        public frmAdminRegistros()
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
            ((GridView)gridAdminRegistros.MainView).FocusedRowChanged += gridControl1_FocusedRowChanged;
            //No se modifica desde el datagrid
            ((GridView)gridAdminRegistros.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridAdminRegistros.MainView).BestFitColumns();
            ((GridView)gridAdminRegistros.MainView).OptionsView.ShowDetailButtons = false;
            //cargar usuario dentro del label
            ObtenerUsuario();

            // Mostrar la fecha y hora actual en el Label
            labelFecha.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
          
            #endregion
        }

        #region Métodos de form


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
                gridAdminRegistros.DataSource = tablaOrdenes;

                // Configurar el GridView
                GridView gridViewOrdenes = (GridView)gridAdminRegistros.MainView;

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

                // Cambiar el nombre de las columnas
                gridViewOrdenes.Columns["Fecha_Registro"].Caption = "Fecha de Registro";
                gridViewOrdenes.Columns["Hora"].Caption = "Hora de Registro";
                gridViewOrdenes.Columns["Usuario"].Caption = "Usuario";
                gridViewOrdenes.Columns["Descripcion"].Caption = "Descripción";
                gridViewOrdenes.Columns["Fecha_Atencion"].Caption = "Fecha de Atención";
                gridViewOrdenes.Columns["Observaciones"].Caption = "Observaciones";
                gridViewOrdenes.Columns["Hardware"].Caption = "Hardware";
                gridViewOrdenes.Columns["Software"].Caption = "Software";
                gridViewOrdenes.Columns["Fecha_Cierre"].Caption = "Fecha de Cierre";
                gridViewOrdenes.Columns["Departamento"].Caption = "Departamento";
                gridViewOrdenes.Columns["Estado"].Caption = "Estado de la orden";

                // Opcional: Ajustar el ancho de las columnas automáticamente
                gridViewOrdenes.BestFitColumns();
            }
            else
            {
                XtraMessageBox.Show("No se encontraron órdenes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gridAdminRegistros.Refresh();
        }
        //cargar fila con el grid
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
        //Listas deplegables de los fallos
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
        //Caragr controles con los datos del grid
        private void gridControl1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView gridView = (GridView)sender;

            // Obtiene el Id de la orden seleccionada
            int idOrdenSeleccionada = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id"));
            Console.WriteLine("ID Orden seleccionada: " + idOrdenSeleccionada); // Para depurar

            // Llama al método para cargar los datos al formulario
            CargarDatosOrdenSeleccionada(idOrdenSeleccionada);
        }
        //boton actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores originales de la orden desde la base de datos
                var ordenOriginal = consultasDB.ObtenerOrdenPorId(Convert.ToInt32(txtIdOrden.EditValue));

                // Obtener los valores de los controles
                int idOrden = Convert.ToInt32(txtIdOrden.EditValue);
                DateTime? fechaAtendida = dateEditFechaAtendida.EditValue as DateTime?;
                DateTime? fechaCerrada = dateEditFechaCerrada.EditValue as DateTime?;
                int idUsuario = UsuarioLogueado.IdUsuario;
                int? idFallaHardware = lookUpEditHadware.EditValue as int?;
                int? idFallaSoftware = lookUpEditSofware.EditValue as int?;
                string descripcion = memoEditDescripcion.Text;
                string observaciones = memoEditObsevacion.Text;
                string estado = radioGroupEstados.EditValue?.ToString();

                // Validaciones
                if (estado == null)
                {
                    throw new InvalidOperationException("El estado no puede ser nulo.");
                }
                if (idFallaHardware.HasValue && idFallaSoftware.HasValue)
                {
                    XtraMessageBox.Show("Solo puede seleccionar una de las fallas (Hardware o Software), no ambas.",
                                        "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ajustar fechas si están presentes
                if (fechaAtendida.HasValue)
                {
                    fechaAtendida = fechaAtendida.Value.Date.Add(DateTime.Now.TimeOfDay);
                }
                if (fechaCerrada.HasValue)
                {
                    fechaCerrada = fechaCerrada.Value.Date.Add(DateTime.Now.TimeOfDay);
                }

                // Obtener los cambios
                List<string> cambios = ObtenerCambios(ordenOriginal, fechaAtendida, fechaCerrada, idFallaHardware, idFallaSoftware, descripcion, observaciones, estado);

                // Actualizar la orden en la base de datos
                consultasDB.ActualizarOrden(idOrden, fechaAtendida, fechaCerrada, idUsuario, idFallaHardware, idFallaSoftware, descripcion, observaciones, estado);

                // Concatenar todos los cambios en un solo mensaje
                string mensajeConsolidado = string.Join("; ", cambios);

                // Registrar el mensaje consolidado en la bitácora
                bitacoraService.RegistrarAccionEnBitacora(idOrden, UsuarioLogueado.IdUsuario, "Actualización", mensajeConsolidado, UsuarioLogueado.IdUsuario);

                // Mostrar mensaje de éxito
                XtraMessageBox.Show("Orden de servicio actualizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridAdminRegistros.RefreshDataSource();
                CargarOrdenes();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private List<string> ObtenerCambios(Orden idOrden, DateTime? fechaAtendida, DateTime? fechaCerrada,
                                            int? idFallaHardware, int? idFallaSoftware, string descripcion,
                                            string observaciones, string estado)
        {
            List<string> cambios = new List<string>();

            // Detectar cambios individuales
            bool fechaAtendidaCambiada = !Equals(idOrden.FechaAtendida, fechaAtendida);
            bool fechaCerradaCambiada = !Equals(idOrden.FechaCerrada, fechaCerrada);
            bool estadoCambiado = !Equals(idOrden.Estado, estado);
            bool descripcionCambiada = !string.Equals(idOrden.Descripcion?.Trim(), descripcion?.Trim(), StringComparison.OrdinalIgnoreCase);
            bool observacionesCambiadas = !string.Equals(idOrden.Observaciones?.Trim(), observaciones?.Trim(), StringComparison.OrdinalIgnoreCase);

            // Combinar cambios específicos (los tres campos juntos)
            if (fechaAtendidaCambiada && estadoCambiado && descripcionCambiada)
            {
                // Mensaje consolidado para los tres campos
                cambios.Add($"Se atendió la orden el {fechaAtendida?.ToString("dd/MM/yyyy")}, la orden se puso en estado {estado}. Detalles de la orden: {descripcion}");
            }
            else if (fechaCerradaCambiada && estadoCambiado)
            {
                // Mensaje consolidado para fechaCerrada y estado
                cambios.Add($"La orden se resolvió el {fechaCerrada?.ToString("dd/MM/yyyy")}, la orden quedó en el estatus {estado}");
            }
            else
            {
                // Registrar cambios individuales
                if (fechaAtendidaCambiada)
                {
                    cambios.Add($"Se atendió la orden el {fechaAtendida?.ToString("dd/MM/yyyy")}");
                }
                if (fechaCerradaCambiada)
                {
                    cambios.Add($"La orden se completó el {fechaCerrada}");
                }
                if (estadoCambiado)
                {
                    cambios.Add($"Estado cambiado a {estado}");
                }
                if (!Equals(idOrden.IdFallaHardware, idFallaHardware))
                {
                    cambios.Add($"Falla Hardware cambiada de {idOrden.IdFallaHardware} a {idFallaHardware}");
                }
                if (!Equals(idOrden.IdFallaSoftware, idFallaSoftware))
                {
                    cambios.Add($"Falla Software cambiada de {idOrden.IdFallaSoftware} a {idFallaSoftware}");
                }
                if (descripcionCambiada)
                {
                    cambios.Add($"Descripción cambiada de {idOrden.Descripcion} a {descripcion}");
                }
                if (observacionesCambiadas && !string.IsNullOrWhiteSpace(observaciones))
                {
                    cambios.Add($"Observaciones cambiadas de {idOrden.Observaciones} a {observaciones}");
                }
            }

            return cambios;
        }




        //boton eleminar
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
                bitacoraService.RegistrarAccionEnBitacora(idOrden, UsuarioLogueado.IdUsuario, "Elimino",
"Se se elimino una orden con el id: " + idOrden + ". ", UsuarioLogueado.IdUsuario);
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




        //boton exportar
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            generarreporte.ExportarExcel(gridAdminRegistros, "Órdenes de Servicio");
        }
        #endregion
    }
}
