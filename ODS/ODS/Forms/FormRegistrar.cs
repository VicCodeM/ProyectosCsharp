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
        private readonly ProcedimientosAlmacenadosDB procedimientosDB = new ProcedimientosAlmacenadosDB();
        #endregion

        #region Constructor y Eventos

        public FormRegistrar()
        {
            InitializeComponent();
            InicializarEventos();
            InicializarRadioButton();
            InicializarConexiones();
            CargarOrdenesPorUsuario(2); // Cargar órdenes por usuario
        }

        private void FormRegistrar_Load(object sender, EventArgs e)
        {
            ObtenerUsuario();
        }

        #endregion

        #region Inicialización y Eventos

        private void InicializarEventos()
        {
            ((GridView)gridCRegistrar.MainView).FocusedRowChanged += gridCRegistrar_FocusedRowChanged;
    
        }

        private void InicializarRadioButton()
        {
            radioGroupFallos.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Software", "Software"));
            radioGroupFallos.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Hardware", "Hardware"));
            radioGroupFallos.EditValue = "Hardware";
            ActualizarEstadoRadioButton(true);
        }

        private void InicializarConexiones()
        {
            SqlConnection conexion = conexionDB.ConectarSQL();
            if (conexion?.State == ConnectionState.Open)
            {
                // Connection opened successfully, handle as needed
            }
        }

        #endregion

        #region Métodos de la Forma

        public void ObtenerUsuario()
        {
            conexionDB.CerrarConexion();
            int idUsuario = 2;
            string nombreUsuario = consultasDB.ObtenerNombreUsuario(idUsuario);
            labelUsuario.Text = string.IsNullOrEmpty(nombreUsuario) ? "No se encontró el nombre de usuario." : $"Nombre de usuario: {nombreUsuario}";
        }

        private void ActualizarEstadoRadioButton(bool isHardwareChecked)
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

        private void CargarOrdenesPorUsuario(int idUsuario)
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

        private void AgregarHoraAOrdenes(DataTable tablaOrdenes)
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

        private void AsignarDatosAlGrid(DataTable tablaOrdenes)
        {
            gridCRegistrar.DataSource = tablaOrdenes;
            GridView gridViewOrdenes = (GridView)gridCRegistrar.MainView;

            // Configuración de columnas de fechas y hora
            ConfigurarFormatoColumnas(gridViewOrdenes);
            gridViewOrdenes.BestFitColumns();
        }

        private void ConfigurarFormatoColumnas(GridView gridViewOrdenes)
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

        private void CargarTiposFallaHardware()
        {
            try
            {
                List<string> listaHardware = consultasDB.ObtenerTiposFallaHardware();
                CargarTiposDeFallaEnLookUpEdit(listaHardware, "Descripcion", "Seleccione un tipo de falla de hardware");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al cargar los tipos de falla de hardware: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show("Error al cargar los tipos de falla de software: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTiposDeFallaEnLookUpEdit(List<string> listaFalla, string columna, string textoNull)
        {
            DataTable tabla = ConvertirListaADataTable(listaFalla, columna);
            lookUpEdit1.Properties.DataSource = tabla;
            lookUpEdit1.Properties.DisplayMember = columna;
            lookUpEdit1.Properties.ValueMember = "Id";
            lookUpEdit1.Properties.NullText = textoNull;
        }

        private DataTable ConvertirListaADataTable(List<string> lista, string nombreColumna)
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

        private void btnRegistrar_Click(object sender, EventArgs e)
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

            try
            {
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
            memoEditDescripcion.Text = "";
            lookUpEdit1.EditValue = null;
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
                XtraMessageBox.Show("Error al seleccionar la fila: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarDatosDeFilaAFormulario(DataRow row)
        {
            memoEditDescripcion.Text = row["Descripcion"]?.ToString() ?? string.Empty;
            memoEditObsevacion.Text = row["Observaciones"]?.ToString() ?? string.Empty;
            labelEstado.Text = row["Estado"]?.ToString() ?? string.Empty;
            labelFecha.Text = row["Fecha_Registro"] != DBNull.Value ? Convert.ToDateTime(row["Fecha_Registro"]).ToString("dd/MM/yyyy") : "Fecha no disponible";
            labelUsuario.Text = "Usuario: " + (row["Usuario"]?.ToString() ?? "Desconocido");

            if (row["Hardware"] != DBNull.Value && !string.IsNullOrEmpty(row["Hardware"].ToString()))
            {
                radioGroupFallos.EditValue = "Hardware";
                CargarTiposFallaHardware();
                lookUpEdit1.EditValue = row["Id"];
            }
            else if (row["Software"] != DBNull.Value && !string.IsNullOrEmpty(row["Software"].ToString()))
            {
                radioGroupFallos.EditValue = "Software";
                CargarTiposFallaSoftware();
                lookUpEdit1.EditValue = row["Id"];
            }
        }

        private void radioGroupFallos_EditValueChanged_1(object sender, EventArgs e)
        {
            bool isHardwareChecked = radioGroupFallos.EditValue.ToString() == "Hardware";
            ActualizarEstadoRadioButton(isHardwareChecked);
        }

        #endregion


    }
}