using DevExpress.XtraEditors;
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
        public FormRegistrar()
        {
            InitializeComponent();
            // Configurar el formulario para adaptarse correctamente
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0); // Elimina márgenes adicionales

            ConexionDB conexionDB = new ConexionDB();
            SqlConnection conexion = conexionDB.ConectarSQL();

            // Verificar si la conexión está abierta
            if (conexion.State == ConnectionState.Open)
            {
                XtraMessageBox.Show("Conexión exitosa a la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conexion.Close();
            if (conexion != null && conexion.State == System.Data.ConnectionState.Closed)
            {
                // La conexión se cerró correctamente
                MessageBox.Show("La conexión se cerró correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // La conexión no se cerró correctamente
                MessageBox.Show("La conexión no se cerró correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //los radiobutton cambi de true a false
            rbHardware.CheckedChanged += (s, e) => ActualizarEstadoRadioButton(rbHardware.Checked);
            rbSoftware.CheckedChanged += (s, e) => ActualizarEstadoRadioButton(!rbSoftware.Checked);
        }

        //Com´parar estado de  los radiobutton 
        private void ActualizarEstadoRadioButton(bool isRadioButton1Checked)
        {
            // Si radioButton1 está seleccionado
            if (isRadioButton1Checked)
            {
                // Habilitar controles asociados a radioButton1
                controlHadware.Enabled = true;

                // Deshabilitar controles asociados a radioButton2
                rbSoftware.Checked = false;
                resourcesComboBoxControl2.Enabled = false;
            }
            else
            {
                // Habilitar controles asociados a radioButton2
                resourcesComboBoxControl2.Enabled = true;

                // Deshabilitar controles asociados a radioButton1
                rbHardware.Checked = false;
                controlHadware.Enabled = false;
            }
        }

        private void FormRegistrar_Load(object sender, EventArgs e)
        {
            //Instanciar la clase ConsultasDB
            ConsultasDB consultas = new ConsultasDB();

            // Obtener el nombre del usuario con el ID 1 (puedes cambiar este valor según sea necesario)
            int idUsuario = 1; // ID de usuario que deseas consultar
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

            CargarTiposFallaHardware();

        }

        private void CargarTiposFallaHardware()
        {
            try
            {
                // Instanciar la clase ConsultasDB
                ConsultasDB consultas = new ConsultasDB();

                // Obtener la lista de descripciones de los tipos de falla de hardware
                List<string> tiposFallaHardware = consultas.ObtenerTiposFallaHardware();

                // Cargar el combobox con la lista de descripciones
                comboBox1.DataSource = tiposFallaHardware;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                XtraMessageBox.Show($"Error al cargar los tipos de falla de hardware: {ex.Message}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

