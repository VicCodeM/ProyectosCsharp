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

            //caragar radio button
            radioGroupFallos.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Software", "Software"));
            radioGroupFallos.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Hardware", "Hardware"));
            radioGroupFallos.EditValue = "Hardware"; // O "Software", según lo que prefieras

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
            ObtenerUsuario();
       

        }
        #endregion

        #region Métodos de la forma

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

        private void ActualizarEstadoRadioButton(bool isHardwareChecked)
        {
            if (isHardwareChecked)
            {
                // Si isHardwareChecked es verdadero, seleccionamos la opción "Hardware"
                radioGroupFallos.EditValue = "Hardware"; // Esto seleccionará "Hardware" en el RadioGroup
                CargarTiposFallaHardware(); // Cargar datos de hardware en el lookUpEdit1

                // Si es necesario, puedes limpiar o actualizar otros controles relacionados con "Hardware"
                lookUpEdit1.Properties.NullText = "Seleccione un tipo de falla de hardware"; // Cambiar texto a algo relacionado
            }
            else
            {
                // Si isHardwareChecked es falso, seleccionamos la opción "Software"
                radioGroupFallos.EditValue = "Software"; // Esto seleccionará "Software" en el RadioGroup
                CargarTiposFallaSoftware(); // Cargar datos de software en el lookUpEdit1

                // Si es necesario, puedes limpiar o actualizar otros controles relacionados con "Software"
                lookUpEdit1.Properties.NullText = "Seleccione un tipo de falla de software"; // Cambiar texto a algo relacionado
            }
        }





        //Cargar ordenes por usuario
        private void CargarOrdenesPorUsuario(int idUsuario)
        {
            ConsultasDB consulta = new ConsultasDB();
            DataTable tablaOrdenes = consulta.ObtenerOrdenesPorUsuario(idUsuario);

            if (tablaOrdenes.Rows.Count > 0)
            {
                // Agregar una columna para la hora
                if (!tablaOrdenes.Columns.Contains("Hora"))
                {
                    tablaOrdenes.Columns.Add("Hora", typeof(string));
                }

                // Llenar la columna "Hora" con la hora extraída
                foreach (DataRow row in tablaOrdenes.Rows)
                {
                    if (row["Fecha_Registro"] != DBNull.Value)
                    {
                        DateTime fecha = Convert.ToDateTime(row["Fecha_Registro"]);
                        row["Hora"] = fecha.ToString("hh:mm tt"); // Solo la hora en formato de 12 horas
                    }
                }

                // Asignar el DataTable al grid
                gridCRegistrar.DataSource = tablaOrdenes;

                // Configurar el GridView
                GridView gridViewOrdenes = (GridView)gridCRegistrar.MainView;

                gridViewOrdenes.Columns["Fecha_Atencion"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Fecha_Atencion"].DisplayFormat.FormatString = "dd-MM-yyyy hh:mm tt";

                gridViewOrdenes.Columns["Fecha_Cierre"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Fecha_Cierre"].DisplayFormat.FormatString = "dd-MM-yyyy hh:mm tt";


                // Formato para las columnas existentes
                gridViewOrdenes.Columns["Fecha_Registro"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Fecha_Registro"].DisplayFormat.FormatString = "dd-MM-yyyy";

                // Formato para la nueva columna "Hora"
                gridViewOrdenes.Columns["Hora"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewOrdenes.Columns["Hora"].DisplayFormat.FormatString = "hh:mm tt";

                // Ajustar el orden: colocar la columna "Hora" después de "FechaC"
                gridViewOrdenes.Columns["Fecha_Registro"].VisibleIndex = 1; // Primera columna (si es necesario, ajusta este índice)
                gridViewOrdenes.Columns["Hora"].VisibleIndex = 2;   // Segunda columna, justo después de "FechaC"

                // Opcional: Ajustar ancho de columnas
                gridViewOrdenes.BestFitColumns();
            }
            else
            {
                XtraMessageBox.Show("No se encontraron órdenes para el usuario seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gridCRegistrar.Refresh();

        }

        private DataTable ConvertirListaADatatable(List<string> lista, string nombreColumna)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(nombreColumna, typeof(string));

            foreach (var item in lista)
            {
                dt.Rows.Add(item);
            }

            return dt;
        }

        private void CargarTiposFallaHardware()
        {
            try
            {
                // Verificar si lookUpEdit1 está correctamente instanciado
                if (lookUpEdit1 == null)
                {
                    MessageBox.Show("lookUpEdit1 no está disponible.");
                    return;
                }

                ConsultasDB consulta = new ConsultasDB();
                List<string> listaHardware = consulta.ObtenerTiposFallaHardware(); // Obtener las fallas de hardware de la base de datos

                if (listaHardware != null && listaHardware.Count > 0)
                {
                    // Crear un DataTable para llenar el lookUpEdit1
                    DataTable tablaHardware = new DataTable();
                    tablaHardware.Columns.Add("ID", typeof(int)); // Columna ID
                    tablaHardware.Columns.Add("Descripcion", typeof(string)); // Columna Descripcion

                    // Llenamos el DataTable con los datos de las fallas de hardware
                    for (int i = 0; i < listaHardware.Count; i++)
                    {
                        tablaHardware.Rows.Add(i + 1, listaHardware[i]);
                    }

                    // Asignamos el DataTable al lookUpEdit1
                    lookUpEdit1.Properties.DataSource = tablaHardware;
                    lookUpEdit1.Properties.DisplayMember = "Descripcion"; // Mostrar la descripción
                    lookUpEdit1.Properties.ValueMember = "ID"; // Usar el ID como valor
                    lookUpEdit1.Properties.NullText = "Seleccione un tipo de falla de hardware";
                }
                else
                {
                    MessageBox.Show("No se encontraron fallas de hardware.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de falla de hardware: " + ex.Message);
            }
        }

        private void CargarTiposFallaSoftware()
        {
            try
            {
                // Verificar si lookUpEdit1 está correctamente instanciado
                if (lookUpEdit1 == null)
                {
                    MessageBox.Show("lookUpEdit1 no está disponible.");
                    return;
                }

                ConsultasDB consulta = new ConsultasDB();
                List<string> listaSoftware = consulta.ObtenerTiposFallaSoftware(); // Obtener las fallas de software de la base de datos

                if (listaSoftware != null && listaSoftware.Count > 0)
                {
                    // Crear un DataTable para llenar el lookUpEdit1
                    DataTable tablaSoftware = new DataTable();
                    tablaSoftware.Columns.Add("ID", typeof(int)); // Columna ID
                    tablaSoftware.Columns.Add("Descripcion", typeof(string)); // Columna Descripcion

                    // Llenamos el DataTable con los datos de las fallas de software
                    for (int i = 0; i < listaSoftware.Count; i++)
                    {
                        tablaSoftware.Rows.Add(i + 1, listaSoftware[i]);
                    }

                    // Asignamos el DataTable al lookUpEdit1
                    lookUpEdit1.Properties.DataSource = tablaSoftware;
                    lookUpEdit1.Properties.DisplayMember = "Descripcion"; // Mostrar la descripción
                    lookUpEdit1.Properties.ValueMember = "ID"; // Usar el ID como valor
                    lookUpEdit1.Properties.NullText = "Seleccione un tipo de falla de software";
                }
                else
                {
                    MessageBox.Show("No se encontraron fallas de software.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de falla de software: " + ex.Message);
            }
        }




        #endregion
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Verificar que se haya escrito la descripción
            if (string.IsNullOrWhiteSpace(memoEditDescripcion.Text))
            {
                XtraMessageBox.Show("Por favor, describe el problema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = 2; // Cambiar según el usuario logueado
            string descripcionProblema = memoEditDescripcion.Text.Trim();
            string estado = "Abierto";

            // Intenta obtener el valor de lookUpEdit1 (ahora un ID numérico)
            int idFalloSeleccionado = 0; // Inicializa con 0 como valor predeterminado
            if (lookUpEdit1.EditValue != null)
            {
                // Intenta convertir el valor de EditValue a int
                bool esValido = int.TryParse(lookUpEdit1.EditValue.ToString(), out idFalloSeleccionado);
                if (!esValido || idFalloSeleccionado == 0)
                {
                    XtraMessageBox.Show("El tipo de falla seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                if (!consultasDB.UsuarioExiste(idUsuario))
                {
                    XtraMessageBox.Show("El usuario no existe. Verifique el ID de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Registrar la orden según el tipo de falla (Hardware o Software)
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

            // Actualiza las órdenes por el usuario
            CargarOrdenesPorUsuario(idUsuario);
        }






        private void gridCRegistrar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                var tipoFalla = view.GetFocusedRowCellValue("TipoFalla"); // Asumiendo que esta columna indica Hardware o Software

                // Actualizamos el RadioGroup en función del tipo de falla
                if (tipoFalla != DBNull.Value)
                {
                    string tipoFallaString = tipoFalla.ToString().Trim();
                    radioGroupFallos.EditValue = tipoFallaString.Equals("Hardware", StringComparison.OrdinalIgnoreCase) ? "Hardware" : "Software";
                }
            }
        }

        private void radioGroupFallos_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Verificamos si hay un valor seleccionado
                if (radioGroupFallos.EditValue == null)
                {
                    MessageBox.Show("Debe seleccionar una opción.");
                    return; // Salir de la función si no hay opción seleccionada
                }

                string valorSeleccionado = radioGroupFallos.EditValue.ToString();

                // Limpiamos el lookUpEdit1 antes de cargar nuevos datos
                lookUpEdit1.Properties.DataSource = null;

                if (valorSeleccionado == "Hardware")
                {
                    CargarTiposFallaHardware();
                }
                else if (valorSeleccionado == "Software")
                {
                    CargarTiposFallaSoftware();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el tipo de falla: " + ex.Message);
            }
        }



    }

}








