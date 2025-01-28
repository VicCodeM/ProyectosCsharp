using DevExpress.XtraEditors;
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
        ConsultasDB consultas = new ConsultasDB();
        ProcedimientosAlmacenadosDB procedimientosDB = new ProcedimientosAlmacenadosDB();
        #endregion

        #region Principal del Form
        public FormRegistrar()
        {
            InitializeComponent();

            #region Abrir Conexiones
            SqlConnection conexion = conexionDB.ConectarSQL();
            #endregion

            #region Acciones de controles

            CargarOrdenesPorUsuario(1);
            rbHardware.CheckedChanged += (s, e) => ActualizarEstadoRadioButton(rbHardware.Checked);
            rbSoftware.CheckedChanged += (s, e) => ActualizarEstadoRadioButton(!rbSoftware.Checked);
            //evitar editar el datagrid
            ((GridView)gridControl1.MainView).OptionsBehavior.Editable = false;
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
            string nombreUsuario = consultas.ObtenerNombreUsuario(idUsuario);

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
                gridControl1.DataSource = tablaOrdenes;
            }
            else
            {
                XtraMessageBox.Show("No se encontraron órdenes para el usuario seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Cargar tipos de falla de hardware
        private void CargarTiposFallaHardware()
        {
            try
            {
                ConsultasDB consultas = new ConsultasDB();

                // Obtener la lista de descripciones de fallas de hardware
                List<string> tiposFallaHardware = consultas.ObtenerTiposFallaHardware();

                if (tiposFallaHardware != null && tiposFallaHardware.Count > 0)
                {
                    comboFallos.DataSource = tiposFallaHardware;
                }
                else
                {
                    comboFallos.DataSource = null;
                    XtraMessageBox.Show("No se encontraron tipos de falla de hardware.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar tipos de falla de hardware: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Cargar tipos de falla de software
        private void CargarTiposFallaSoftware()
        {
            try
            {


                // Obtener la lista de descripciones de fallas de software
                List<string> tiposFallaSoftware = consultas.ObtenerTiposFallaSoftware();

                if (tiposFallaSoftware != null && tiposFallaSoftware.Count > 0)
                {
                    comboFallos.DataSource = tiposFallaSoftware; // Actualiza comboHadware
                }
                else
                {
                    comboFallos.DataSource = null;
                    XtraMessageBox.Show("No se encontraron tipos de falla de software.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar tipos de falla de software: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        #endregion

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}

