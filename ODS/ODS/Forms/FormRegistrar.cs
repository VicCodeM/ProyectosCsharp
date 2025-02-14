using DevExpress.Data.ExpressionEditor;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DocumentFormat.OpenXml.Presentation;
using ODS.Datos;
using ODS.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class FormRegistrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instanciar Objetos
        private readonly ConexionDB conexionDB = new ConexionDB();
        private readonly ConsultasDB consultasDB = new ConsultasDB();
        private readonly ExportarService exportarexcel = new ExportarService();
        #endregion

        #region Constructor y Eventos

        public FormRegistrar()
        {
            InitializeComponent();
            InicializarEventos();
            InicializarRadioButton();
            InicializarConexiones();
            // Asignar el botón btnLogin como el botón de aceptación (Enter)
            this.AcceptButton = btnRegistrar;
            CargarOrdenesPorUsuario(UsuarioLogueado.IdUsuario); // Cargar órdenes por usuario
            //No se modifica desde el datagrid
            ((GridView)gridCRegistrar.MainView).OptionsBehavior.Editable = false;//modo editable desactivado
            ((GridView)gridCRegistrar.MainView).BestFitColumns();//ajustar columnas
            ((GridView)gridCRegistrar.MainView).ClearSelection();//eviatar seleccion automatica
            ((GridView)gridCRegistrar.MainView).OptionsView.ShowDetailButtons = false;//desactivar funciones del grid
            // Establecer un texto de marcador de posición
            memoEditDescripcion.Properties.NullText = "Escriba aquí su descripción...";
            // Simular el cambio de valor del RadioGroup al iniciar la forma
            radioGroupFallos_EditValueChanged(radioGroupFallos, EventArgs.Empty);
            // Actualizar el color del estado
            ActualizarColorEstado();
            // Desactivar la tecla "Enter" para el MemoEdit
            memoEditDescripcion.Properties.AcceptsReturn = false;

        }

        private void FormRegistrar_Load(object sender, EventArgs e)
        {
            try
            {
                if (radioGroupFallos.EditValue == null)
                {
                    XtraMessageBox.Show("Debes seleccionar un tipo de falla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                memoEditDescripcion.Text = "";
                memoEditObsevacion.Text = "";
                lookUpFallos.Text = "No hay falla Seleccionada";

                // Observaciones solo lectura
                memoEditObsevacion.Properties.ReadOnly = true;
                memoEditObsevacion.Enabled = false;

                memoEditDescripcion.Enabled = false;
                radioGroupFallos.Enabled = false;
                lookUpFallos.Enabled = false;

                // Mostrar la fecha y hora actual en el Label
                labelFecha.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");

                ObtenerUsuario();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Borramos descripción
        private void memoEditDescripcion_Click(object sender, EventArgs e)
        {
            memoEditDescripcion.Text = "";
            labelEstado.Text = "Estado:";
            memoEditObsevacion.Text = "";
            lookUpFallos.EditValue = null;
            
        }

        #endregion

        #region Inicialización y Eventos

        private void InicializarEventos()
        {
            try
            {
                ((GridView)gridCRegistrar.MainView).FocusedRowChanged += gridCRegistrar_FocusedRowChanged;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al inicializar eventos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarRadioButton()
        {
            try
            {
                radioGroupFallos.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Software", "Error Aplicaciones"));
                radioGroupFallos.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Hardware", "Error Físico"));
                radioGroupFallos.EditValue = "Hardware";

                ActualizarEstadoRadioButton(true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al inicializar los RadioButtons: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarConexiones()
        {
            try
            {
                SqlConnection conexion = conexionDB.ConectarSQL();
                if (conexion?.State != ConnectionState.Open)
                {
                    XtraMessageBox.Show($"Error al abrir  conexión. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al inicializar la conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos de la Forma
        //Metodo para cambair color del label 
        private void ActualizarColorEstado()
        {
            if (labelEstado.Text == "Estado: Pendiente")
            {
                labelEstado.ForeColor = Color.FromArgb(156, 113, 4); // Amarillo para Pendiente
            }
            else if (labelEstado.Text == "Estado: Cancelado")
            {
                labelEstado.ForeColor = Color.Red; // Rojo para Cancelado
            }
            else if (labelEstado.Text == "Estado: Abierto")
            {
                labelEstado.ForeColor = Color.Green; // Verde para Abierto
            }
            else if (labelEstado.Text == "Estado: Completado")
            {
                labelEstado.ForeColor = Color.Blue; // Azul para Completado
            }
            else
            {
                labelEstado.ForeColor = Color.Black; // Negro como valor predeterminado
            }
        }

        //Método para mostrar usuario logueado een el label
        public void ObtenerUsuario()
        {
            try
            {
                conexionDB.CerrarConexion();
                int idUsuario = UsuarioLogueado.IdUsuario;

                string nUsuario = UsuarioLogueado.NombreUsuario;
                labelUsuario.Text = string.IsNullOrEmpty(UsuarioLogueado.NombreUsuario) ? "No se encontró el nombre de usuario." : $"Usuario: {UsuarioLogueado.NombreUsuario}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al obtener el nombre de usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Método para seleccionar tipo de falla
        private void ActualizarEstadoRadioButton(bool isHardwareChecked)
        {
            try
            {
                if (isHardwareChecked)
                {
                    radioGroupFallos.EditValue = "Hardware";
                    CargarTiposFallaHardware();
                    lookUpFallos.Properties.NullText = "Seleccione un tipo de falla de física";
                }
                else
                {
                    radioGroupFallos.EditValue = "Software";
                    CargarTiposFallaSoftware();
                    lookUpFallos.Properties.NullText = "Seleccione un tipo de falla de Aplicaciones";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al actualizar el estado del RadioButton: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Método para cargar ordenes de usuario 
        private void CargarOrdenesPorUsuario(int idUsuario)
        {
            try
            {
                DataTable tablaOrdenes = consultasDB.ObtenerOrdenesPorUsuario(UsuarioLogueado.IdUsuario);
                if (tablaOrdenes.Rows.Count > 0)
                {
                    AgregarHoraAOrdenes(tablaOrdenes);
                    AsignarDatosAlGrid(tablaOrdenes);
                }
                else
                {
                    XtraMessageBox.Show("No se encontraron órdenes para el usuario seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar las órdenes del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //agregar hora la las ordenes
        private void AgregarHoraAOrdenes(DataTable tablaOrdenes)
        {
            try
            {
                if (!tablaOrdenes.Columns.Contains("Hora"))
                {
                    tablaOrdenes.Columns.Add("Hora", typeof(string));
                }

                foreach (DataRow row in tablaOrdenes.Rows)
                {
                    if (row["Fecha_Registro"] != DBNull.Value)
                    {
                        DateTime fecha = Convert.ToDateTime(row["Fecha_Registro"]);
                        row["Hora"] = fecha.ToString("hh:mm tt");
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al agregar la hora a las órdenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Carag del grid con los datos del usuario
        private void AsignarDatosAlGrid(DataTable tablaOrdenes)
        {
            try
            {
                gridCRegistrar.DataSource = tablaOrdenes;
                GridView gridViewOrdenes = (GridView)gridCRegistrar.MainView;

                // Configuración de columnas de fechas y hora
                ConfigurarFormatoColumnas(gridViewOrdenes);
                gridViewOrdenes.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al asignar los datos al Grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //configuracion de columnas
        private void ConfigurarFormatoColumnas(GridView gridViewOrdenes)
        {
            try
            {
                gridViewOrdenes.Columns["Fecha_Atencion"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Fecha_Atencion"].DisplayFormat.FormatString = "dd-MM-yyyy hh:mm tt";
                gridViewOrdenes.Columns["Fecha_Cierre"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Fecha_Cierre"].DisplayFormat.FormatString = "dd-MM-yyyy hh:mm tt";
                gridViewOrdenes.Columns["Fecha_Registro"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Fecha_Registro"].DisplayFormat.FormatString = "dd-MM-yyyy";
                gridViewOrdenes.Columns["Hora"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Hora"].DisplayFormat.FormatString = "hh:mm tt";

                // configuración de columnas
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al configurar el formato de las columnas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //cargar lista de tipos de falla de Hadware
        private void CargarTiposFallaHardware()
        {
            try
            {
                List<string> listaHardware = consultasDB.ObtenerTiposFallaHardware();
                CargarTiposDeFallaEnLookUpEdit(listaHardware, "Descripcion", "Seleccione un tipo de falla de hardware");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar los tipos de falla de hardware: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //cargar lista de tipos de falla de Software
        private void CargarTiposFallaSoftware()
        {
            try
            {
                List<string> listaSoftware = consultasDB.ObtenerTiposFallaSoftware();
                CargarTiposDeFallaEnLookUpEdit(listaSoftware, "Descripcion", "Seleccione un tipo de falla de software");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar los tipos de falla de software: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Método para obtenmer la falla segun su tipo
        private void CargarTiposDeFallaEnLookUpEdit(List<string> listaFalla, string columna, string textoNull)
        {
            try
            {
                DataTable tabla = ConvertirListaADataTable(listaFalla, columna);
                lookUpFallos.Properties.DataSource = tabla;
                lookUpFallos.Properties.DisplayMember = columna;
                lookUpFallos.Properties.ValueMember = "Id";
                lookUpFallos.Properties.NullText = textoNull;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar tipos de falla en LookUpEdit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Convertir datos para el grid
        private DataTable ConvertirListaADataTable(List<string> lista, string nombreColumna)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add(nombreColumna, typeof(string));

                for (int i = 0; i < lista.Count; i++)
                {
                    dataTable.Rows.Add(i + 1, lista[i]);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al convertir la lista a DataTable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //evento para mostrar texto ele lugar de null
        private void radioGroupFallos_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool isHardwareChecked = radioGroupFallos.EditValue.ToString() == "Hardware";
                ActualizarEstadoRadioButton(isHardwareChecked); // Actualizar estado
                lookUpFallos.EditValue = null; // Limpiar el valor del LookUpEdit antes de cargar nuevos datos

                if (isHardwareChecked)
                {
                    CargarTiposFallaHardware(); // Cargar hardware si es seleccionado
                    lookUpFallos.Properties.NullText = "Seleccione un tipo de falla de hardware";
                }
                else
                {
                    CargarTiposFallaSoftware(); // Cargar software si es seleccionado
                    lookUpFallos.Properties.NullText = "Seleccione un tipo de falla de software";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cambiar el valor del RadioButton: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //btn registrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(memoEditDescripcion.Text))
                {
                    XtraMessageBox.Show("Por favor, describe el problema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idUsuario = UsuarioLogueado.IdUsuario;
                string descripcionProblema = memoEditDescripcion.Text.Trim();
                string estado = "Abierto"; //Estado por defecto al registrar orden

                // Obtener el tipo de falla seleccionado
                string tipoFalla = radioGroupFallos.EditValue?.ToString();

                // Validar si seleccionó un tipo de falla
                if (string.IsNullOrEmpty(tipoFalla))
                {
                    XtraMessageBox.Show("Seleccione un tipo de falla: Hardware o Software.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar si seleccionó un valor en lookUpEdit1
                if (lookUpFallos.EditValue == null)
                {
                    XtraMessageBox.Show($"Seleccione un tipo de falla de {tipoFalla}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? idFalloHardware = tipoFalla == "Hardware" ? (int?)lookUpFallos.EditValue : null;
                int? idFalloSoftware = tipoFalla == "Software" ? (int?)lookUpFallos.EditValue : null;

                if (!consultasDB.UsuarioExiste(idUsuario))
                {
                    XtraMessageBox.Show("El usuario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                consultasDB.InsertarOrdenServicio(idUsuario, idFalloHardware, idFalloSoftware, descripcionProblema, estado);
                XtraMessageBox.Show("Orden registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfigurarControles(false);
                CargarOrdenesPorUsuario(idUsuario);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Debe seleccionar un tipo de falla para registrar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }


        private void LimpiarCampos()
        {
            try
            {
                memoEditDescripcion.Text = "";
                memoEditObsevacion.Text = "";
                lookUpFallos.EditValue = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al limpiar los campos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Manejo de Fila Seleccionada en el Grid

        private void gridCRegistrar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                var gridView = (GridView)gridCRegistrar.MainView;
                var row = gridView.GetFocusedDataRow();

                if (row == null) return;

                AsignarDatosDeFilaAFormulario(row);
                ActualizarColorEstado();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al seleccionar la fila: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarDatosDeFilaAFormulario(DataRow row)
        {
            try
            {
                memoEditDescripcion.Text = row["Descripcion"]?.ToString() ?? string.Empty;
                memoEditObsevacion.Text = row["Observaciones"]?.ToString() ?? string.Empty;
                labelEstado.Text = "Estado: " + (row["Estado"]?.ToString() ?? string.Empty);
                labelUsuario.Text = "Usuario: " + (row["Usuario"]?.ToString() ?? "Desconocido");

                // Asignar correctamente el valor a EditValue
                lookUpFallos.EditValue = row["Id"] ?? string.Empty;

                if (row["Hardware"] != DBNull.Value && !string.IsNullOrEmpty(row["Hardware"].ToString()))
                {
                    radioGroupFallos.EditValue = "Hardware"; // Establecer Hardware como el seleccionado
                    CargarTiposFallaHardware();              // Cargar tipos de falla de hardware
                    lookUpFallos.EditValue = row["Hardware"]; // Asignar el valor correspondiente
                }
                else if (row["Software"] != DBNull.Value && !string.IsNullOrEmpty(row["Software"].ToString()))
                {
                    radioGroupFallos.EditValue = "Software"; // Establecer Software como el seleccionado
                    CargarTiposFallaSoftware();              // Cargar tipos de falla de software
                    lookUpFallos.EditValue = row["Software"]; // Asignar el valor correspondiente
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al asignar los datos de la fila: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioGroupFallos_EditValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                bool isHardwareChecked = radioGroupFallos.EditValue.ToString() == "Hardware";
                ActualizarEstadoRadioButton(isHardwareChecked);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cambiar el valor del RadioButton: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void memoEditDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter"
            if (e.KeyCode == Keys.Enter)
            {
                // Cancelar el evento para evitar el salto de línea
                e.SuppressKeyPress = true;
                e.Handled = true;          // Marca el evento como manejado

                // Simular un clic en el botón
                btnRegistrar.PerformClick(); // Suponiendo que el botón para el enter

            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            
            exportarexcel.ExportarExcel(gridCRegistrar, "Reporte de Órdenes de Servicio");
        }
        //Botón para nueva orden 
        private void btnNuevaOrden_Click(object sender, EventArgs e)
        {
            // Observaciones solo lectura
            ConfigurarControles(true);
        }

        //Metodo para configurar controles 
        private void ConfigurarControles(bool habilitar)
        {
            memoEditObsevacion.Properties.ReadOnly = !habilitar;
            memoEditObsevacion.Enabled = habilitar;
            memoEditDescripcion.Enabled = habilitar;
            radioGroupFallos.Enabled = habilitar;
            lookUpFallos.Enabled = habilitar;

            if (!habilitar)
            {
                // Limpiar los campos cuando se deshabiliten los controles
                memoEditDescripcion.Text = "";
                memoEditObsevacion.Text = "";
                lookUpFallos.Text = "No hay falla Seleccionada";
                memoEditDescripcion.BackColor = Color.FromArgb(230, 231, 233);
            }

            // Enfocar el campo de descripción si se habilitan los controles
            if (habilitar)
            {
                memoEditDescripcion.BackColor = Color.White;
                memoEditDescripcion.Focus();
            }
        }

        private void memoEditDescripcion_EditValueChanged(object sender, EventArgs e)
        {
        
        }
    }
}
