using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class FormRegistrar : DevExpress.XtraEditors.XtraUserControl
    {
        #region Instanciar Objetos
        private readonly ConexionDB conexionDB = new ConexionDB();
        private readonly ConsultasDB consultasDB = new ConsultasDB();
        #endregion

        #region Constructor y Eventos

        public FormRegistrar()
        {
            InitializeComponent();
            InicializarEventos();
            InicializarRadioButton();
            InicializarConexiones();
            CargarOrdenesPorUsuario(2); // Cargar órdenes por usuario
            //No se modifica desde el datagrid
            ((GridView)gridCRegistrar.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridCRegistrar.MainView).BestFitColumns();
            ((GridView)gridCRegistrar.MainView).OptionsView.ShowDetailButtons = false;
        }

        private void FormRegistrar_Load(object sender, EventArgs e)
        {
            try
            {
                // Observaciones solo lectura
                memoEditObsevacion.Properties.ReadOnly = true;
                memoEditObsevacion.Enabled = false;

                // Mostrar la fecha y hora actual en el Label
                labelFecha.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");

                ObtenerUsuario();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                radioGroupFallos.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Software", "Software"));
                radioGroupFallos.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Hardware", "Hardware"));
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
                if (conexion?.State == ConnectionState.Open)
                {
                    // Connection opened successfully, handle as needed
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos de la Forma

        public void ObtenerUsuario()
        {
            try
            {
                conexionDB.CerrarConexion();
                int idUsuario = 2;
                string nombreUsuario = consultasDB.ObtenerNombreUsuario(idUsuario);
                labelUsuario.Text = string.IsNullOrEmpty(nombreUsuario) ? "No se encontró el nombre de usuario." : $"Nombre de usuario: {nombreUsuario}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al obtener el nombre de usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadoRadioButton(bool isHardwareChecked)
        {
            try
            {
                if (isHardwareChecked)
                {
                    radioGroupFallos.EditValue = "Hardware";
                    CargarTiposFallaHardware();
                    lookUpEdit1.Properties.NullText = "Seleccione un tipo de falla de hardware";
                }
                else
                {
                    radioGroupFallos.EditValue = "Software";
                    CargarTiposFallaSoftware();
                    lookUpEdit1.Properties.NullText = "Seleccione un tipo de falla de software";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al actualizar el estado del RadioButton: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarOrdenesPorUsuario(int idUsuario)
        {
            try
            {
                DataTable tablaOrdenes = consultasDB.ObtenerOrdenesPorUsuario(idUsuario);
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al configurar el formato de las columnas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void CargarTiposDeFallaEnLookUpEdit(List<string> listaFalla, string columna, string textoNull)
        {
            try
            {
                DataTable tabla = ConvertirListaADataTable(listaFalla, columna);
                lookUpEdit1.Properties.DataSource = tabla;
                lookUpEdit1.Properties.DisplayMember = columna;
                lookUpEdit1.Properties.ValueMember = "Id";
                lookUpEdit1.Properties.NullText = textoNull;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar tipos de falla en LookUpEdit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void radioGroupFallos_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool isHardwareChecked = radioGroupFallos.EditValue.ToString() == "Hardware";
                ActualizarEstadoRadioButton(isHardwareChecked); // Actualizar estado
                lookUpEdit1.EditValue = null; // Limpiar el valor del LookUpEdit antes de cargar nuevos datos

                if (isHardwareChecked)
                {
                    CargarTiposFallaHardware(); // Cargar hardware si es seleccionado
                    lookUpEdit1.Properties.NullText = "Seleccione un tipo de falla de hardware";
                }
                else
                {
                    CargarTiposFallaSoftware(); // Cargar software si es seleccionado
                    lookUpEdit1.Properties.NullText = "Seleccione un tipo de falla de software";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cambiar el valor del RadioButton: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(memoEditDescripcion.Text))
                {
                    XtraMessageBox.Show("Por favor, describe el problema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idUsuario = 2;
                string descripcionProblema = memoEditDescripcion.Text.Trim();
                string estado = "Abierto";
                int? idFalloHardware = radioGroupFallos.EditValue.ToString() == "Hardware" ? (int?)lookUpEdit1.EditValue : null;
                int? idFalloSoftware = radioGroupFallos.EditValue.ToString() == "Software" ? (int?)lookUpEdit1.EditValue : null;

                if (!consultasDB.UsuarioExiste(idUsuario))
                {
                    XtraMessageBox.Show("El usuario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                consultasDB.InsertarOrdenServicio(idUsuario, idFalloHardware, idFalloSoftware, descripcionProblema, estado);
                XtraMessageBox.Show("Orden registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarOrdenesPorUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al registrar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            try
            {
                memoEditDescripcion.Text = "";
                lookUpEdit1.EditValue = null;
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
                lookUpEdit1.EditValue = row["Id"] ?? string.Empty;

                if (row["Hardware"] != DBNull.Value && !string.IsNullOrEmpty(row["Hardware"].ToString()))
                {
                    radioGroupFallos.EditValue = "Hardware"; // Establecer Hardware como el seleccionado
                    CargarTiposFallaHardware();              // Cargar tipos de falla de hardware
                    lookUpEdit1.EditValue = row["Hardware"]; // Asignar el valor correspondiente
                }
                else if (row["Software"] != DBNull.Value && !string.IsNullOrEmpty(row["Software"].ToString()))
                {
                    radioGroupFallos.EditValue = "Software"; // Establecer Software como el seleccionado
                    CargarTiposFallaSoftware();              // Cargar tipos de falla de software
                    lookUpEdit1.EditValue = row["Software"]; // Asignar el valor correspondiente
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
    }
}
