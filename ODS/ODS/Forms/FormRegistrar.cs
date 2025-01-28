using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ODS.Forms
{
    public partial class FormRegistrar : DevExpress.XtraEditors.XtraUserControl
    {
        #region Instanciar Objetos
        //instancias de las calses 
        ConexionDB conexionDB = new ConexionDB();
        ConsultasDB consultasDB = new ConsultasDB();
        ProcedimientosAlmacenadosDB procedimientosDB = new ProcedimientosAlmacenadosDB();
        #endregion

        #region Principal del Form
        public FormRegistrar()
        {
            InitializeComponent();

            // Suscripción al evento en el constructor o en el método Load
            ((GridView)gridCRegistrar.MainView).FocusedRowChanged += gridCRegistrar_FocusedRowChanged;

            #region Abrir Conexiones
            SqlConnection conexion = conexionDB.ConectarSQL();
            #endregion

            #region Acciones de controles

            CargarOrdenesPorUsuario(2);
            rbHardware.CheckedChanged += (s, e) => ActualizarEstadoRadioButton(rbHardware.Checked);
            rbSoftware.CheckedChanged += (s, e) => ActualizarEstadoRadioButton(!rbSoftware.Checked);
            //evitar editar el datagrid
            ((GridView)gridCRegistrar.MainView).OptionsBehavior.Editable = false;
            #endregion

            //// Verificar si la conexión está abierta
            //if (conexion.State == ConnectionState.Open)
            //{
            //    XtraMessageBox.Show("Conexión exitosa a la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //conexion.Close();
            //if (conexion != null && conexion.State == System.Data.ConnectionState.Closed)
            //{
            //    // La conexión se cerró correctamente
            //    MessageBox.Show("La conexión se cerró correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    // La conexión no se cerró correctamente
            //    MessageBox.Show("La conexión no se cerró correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //los radiobutton cambi de true a false

        }

        private void FormRegistrar_Load(object sender, EventArgs e)
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
        #endregion

        #region Métodos de la forma
        //Actualizar los radio button
        private void ActualizarEstadoRadioButton(bool isHardwareChecked)
        {
            if (isHardwareChecked)
            {
                // Si rbHardware está seleccionado
                rbHardware.Checked = true;
                CargarTiposFallaHardware(); // Cargar datos de hardware en comboHadware

                // Desactivar rbSoftware y limpiar comboHadware si no aplica
                rbSoftware.Checked = false;
            }
            else
            {
                // Si rbSoftware está seleccionado
                rbSoftware.Checked = true;
                CargarTiposFallaSoftware(); // Cargar datos de software en comboHadware

                // Desactivar rbHardware y limpiar comboHadware si no aplica
                rbHardware.Checked = false;
            }
        }



        //Cargar ordenes por usuario
        private void CargarOrdenesPorUsuario(int idUsuario)
        {
            ConsultasDB consulta = new ConsultasDB();
            DataTable tablaOrdenes = consulta.ObtenerOrdenesPorUsuario(idUsuario);

            if (tablaOrdenes.Rows.Count > 0)
            {
                // Carga los datos en un DataGridView o un control similar
                gridCRegistrar.DataSource = tablaOrdenes;
            }
            else
            {
                XtraMessageBox.Show("No se encontraron órdenes para el usuario seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gridCRegistrar.Refresh();
        }

        private void CargarTiposFallaHardware()
        {
            string query = "SELECT Id_TipoFallaHardware, Descripcion FROM TiposFallaHardware";

            try
            {
                using (SqlConnection conn = conexionDB.ConectarSQL())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboFallos.DataSource = dt;
                    comboFallos.DisplayMember = "Descripcion";
                    comboFallos.ValueMember = "Id_TipoFallaHardware";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar fallas de hardware: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTiposFallaSoftware()
        {
            string query = "SELECT Id_TipoFallaSoftware, Descripcion FROM TiposFallaSoftware";

            try
            {
                using (SqlConnection conn = conexionDB.ConectarSQL())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboFallos.DataSource = dt;
                    comboFallos.DisplayMember = "Descripcion";
                    comboFallos.ValueMember = "Id_TipoFallaSoftware";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar fallas de software: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (comboFallos.SelectedValue == null || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                XtraMessageBox.Show("Por favor, selecciona un tipo de falla y describe el problema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = 2; // Cambiar según el usuario logueado.
            int idFalloSeleccionado = Convert.ToInt32(comboFallos.SelectedValue);
            string descripcionProblema = txtDescripcion.Text.Trim();
            string estado = "Pendiente";

            try
            {
                if (!consultasDB.UsuarioExiste(idUsuario))
                {
                    XtraMessageBox.Show("El usuario no existe. Verifique el ID de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rbHardware.Checked)
                {
                    consultasDB.InsertarOrdenServicio(idUsuario, idFalloSeleccionado, null, descripcionProblema, estado);
                }
                else
                {
                    consultasDB.InsertarOrdenServicio(idUsuario, null, idFalloSeleccionado, descripcionProblema, estado);
                }

                XtraMessageBox.Show("Orden de servicio registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al registrar la orden de servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarOrdenesPorUsuario(idUsuario);

        }

        private void gridCRegistrar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //GridView view = sender as GridView;

            //if (view != null)
            //{
            //    // Obtén los valores de las columnas con una comprobación de nulos
            //    var idFallo = view.GetFocusedRowCellValue("IdFallo");
            //    var descripcion = view.GetFocusedRowCellValue("Descripcion");
            //    var estado = view.GetFocusedRowCellValue("Estado");
            //    var observaciones = view.GetFocusedRowCellValue("Observaciones");

            //    // Verificar si los valores son nulos antes de usarlos
            //    if (idFallo == DBNull.Value || descripcion == DBNull.Value || estado == DBNull.Value || observaciones == DBNull.Value)
            //    {
            //        XtraMessageBox.Show("Hay valores nulos en la fila seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    // Asigna los valores a los controles
            //    comboFallos.SelectedValue = idFallo;
            //    txtDescripcion.Text = descripcion?.ToString();
            //    labelEstado.Text = estado?.ToString();
            //    txtObservaciones.Text = observaciones?.ToString();
            //}
        }





    }
}

