using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using System;
using System.Data;
using System.Windows.Forms;

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

            //cargar usuario dentro del label
            ObtenerUsuario();
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
            int idUsuario = 2; // ID de usuario que deseas consultar
            string nombreUsuario = consultasDB.ObtenerNombreUsuario(idUsuario);

            // Mostrar el nombre del usuario en el label
            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                labelUsuario.Text = $"Nombre de usuario: {nombreUsuario}";
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

            // Asignar los datos a los LookUpEdit
            lookUpEditListaUsuarios.Properties.DataSource = tablaUsuarios;
            lookUpEditListaUsuarios.Properties.DisplayMember = "Usuario";
            lookUpEditListaUsuarios.Properties.ValueMember = "Id_Usuario";

            lookUpEditHadware.Properties.DataSource = tablaHardware;
            lookUpEditHadware.Properties.DisplayMember = "Descripcion";
            lookUpEditHadware.Properties.ValueMember = "Id_TipoFallaHardware";

            lookUpEditSofware.Properties.DataSource = tablaSoftware;
            lookUpEditSofware.Properties.DisplayMember = "Descripcion";
            lookUpEditSofware.Properties.ValueMember = "Id_TipoFallaSoftware";
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
            // Obtener los valores de los controles
            int idOrden = Convert.ToInt32(txtIdOrden.EditValue);
            DateTime? fechaAtendida = dateEditFechaAtendida.EditValue as DateTime?;
            DateTime? fechaCerrada = dateEditFechaCerrada.EditValue as DateTime?;
            int idUsuario = Convert.ToInt32(lookUpEditListaUsuarios.EditValue);
            int? idFallaHardware = lookUpEditHadware.EditValue as int?;
            int? idFallaSoftware = lookUpEditSofware.EditValue as int?;
            string descripcion = memoEditDescripcion.Text;
            string observaciones = memoEditObsevacion.Text;
            string estado = radioGroupEstados.EditValue.ToString();

            // Asignar la hora actual a las fechas si están presentes
            if (fechaAtendida.HasValue)
            {
                fechaAtendida = fechaAtendida.Value.Date.Add(DateTime.Now.TimeOfDay); // Asigna la fecha seleccionada y la hora actual
            }

            if (fechaCerrada.HasValue)
            {
                fechaCerrada = fechaCerrada.Value.Date.Add(DateTime.Now.TimeOfDay); // Asigna la fecha seleccionada y la hora actual
            }

            // Llamar al método ActualizarOrden
            consultasDB.ActualizarOrden(idOrden, fechaAtendida, fechaCerrada, idUsuario, idFallaHardware, idFallaSoftware, descripcion, observaciones, estado);

            // Opcional: Mostrar un mensaje de éxito
            XtraMessageBox.Show("Orden de servicio actualizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refrescar el GridControl
            gridControl1.RefreshDataSource();
            CargarOrdenes();
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

    }
}
