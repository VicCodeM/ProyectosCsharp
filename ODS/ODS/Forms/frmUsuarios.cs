using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using ODS.Modelo;
using System;
using System.Data;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmUsuarios : DevExpress.XtraEditors.XtraForm
    {
        private ConexionDB conexionDB = new ConexionDB();

        #region Inicio de la Forma compoenentes
        public frmUsuarios()
        {
            InitializeComponent();

            // Cargar datos al iniciar
            CargarUsuarios();
            CargarEmpleados();
            CargarDepartamentos();
            CargarTiposDeUsuario();

            //label usuario
            labelControl7.Text = UsuarioLogueado.NombreCompleto;

            // Manejar selección de empleados
            lookUpEmpleado.EditValueChanged += LookUpEmpleado_EditValueChanged;
            gridView1.FocusedRowChanged += gridUsuarios_FocusedRowChanged;

            // Inicializa el control GridControl
            ((GridView)gridUsuarios.MainView).Columns["Id_Departamento"].Visible = false;
            ((GridView)gridUsuarios.MainView).Columns["Id_Usuario"].Caption = "Id";
            ((GridView)gridUsuarios.MainView).Columns["Id_Empleado"].Visible = false;
            ((GridView)gridUsuarios.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridUsuarios.MainView).BestFitColumns();
            ((GridView)gridUsuarios.MainView).OptionsView.ShowDetailButtons = false;

            //activar boton enter al actualizar
            this.AcceptButton = btnActualizar;
        }
        #endregion

        #region Eventos de la forma
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un empleado
            if (lookUpEmpleado.EditValue == null)
            {
                XtraMessageBox.Show("Debe seleccionar un empleado antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener los valores de los controles
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string tipoUsuario = comboTipoUsuario.Text;

            // Obtener el ID del empleado seleccionado
            int idEmpleado = Convert.ToInt32(lookUpEmpleado.EditValue);

            // 🔴 1️⃣ Verificar si el empleado ya tiene un usuario registrado en la base de datos
            string queryVerificarEmpleado = $"SELECT COUNT(*) FROM Login WHERE Id_Empleado = {idEmpleado}";
            DataTable dtEmpleadoExistente = conexionDB.EjecutarConsulta(queryVerificarEmpleado);

            // Si el empleado ya tiene un usuario, no permitir registrar otro
            if (dtEmpleadoExistente.Rows.Count > 0 && Convert.ToInt32(dtEmpleadoExistente.Rows[0][0]) > 0)
            {
                XtraMessageBox.Show("Este empleado ya tiene un usuario asignado. No puede registrar otro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔴 2️⃣ Verificar si el usuario ya existe con otro empleado
            string queryVerificarUsuario = $"SELECT Id_Empleado FROM Login WHERE Usuario = '{usuario}'";
            DataTable dtUsuarioExistente = conexionDB.EjecutarConsulta(queryVerificarUsuario);

            if (dtUsuarioExistente.Rows.Count > 0)
            {
                int empleadoExistente = Convert.ToInt32(dtUsuarioExistente.Rows[0]["Id_Empleado"]);

                // Si el usuario ya existe pero con un empleado diferente, mostrar advertencia
                if (empleadoExistente != idEmpleado)
                {
                    XtraMessageBox.Show("El nombre de usuario ya está registrado con otro empleado. Use otro nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 🔵 3️⃣ Insertar el nuevo usuario en la tabla Login si pasa las validaciones
            string queryLogin = $"INSERT INTO Login (Usuario, Password, Tipo_Usuario, Id_Empleado) " +
                                $"VALUES ('{usuario}', '{password}', '{tipoUsuario}', {idEmpleado})";

            try
            {
                // Ejecutar la consulta
                conexionDB.EjecutarComando(queryLogin);

                // Mostrar mensaje de éxito
                XtraMessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar los datos en los controles
                CargarUsuarios();
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                XtraMessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (gridUsuarios.MainView is GridView gridView && gridView.FocusedRowHandle >= 0)
            {
                // 🔴 Validar que se haya seleccionado un empleado
                if (lookUpEmpleado.EditValue == null)
                {
                    XtraMessageBox.Show("Debe seleccionar un empleado antes de actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idUsuario = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id_Usuario"));
                int idEmpleado = Convert.ToInt32(lookUpEmpleado.EditValue);
                string usuario = txtUsuario.Text;
                string password = txtPassword.Text;
                string tipoUsuario = comboTipoUsuario.SelectedItem.ToString();
                int idDepartamento = Convert.ToInt32(lookUpDepartamento.EditValue);

                // Verificar si hay cambios antes de actualizar
                string queryVerificarCambios = $"SELECT Usuario, Password, Tipo_Usuario FROM Login WHERE Id_Usuario = {idUsuario}";
                DataTable dtUsuarioActual = conexionDB.EjecutarConsulta(queryVerificarCambios);

                if (dtUsuarioActual.Rows.Count > 0)
                {
                    DataRow row = dtUsuarioActual.Rows[0];
                    if (row["Usuario"].ToString() == usuario && row["Password"].ToString() == password && row["Tipo_Usuario"].ToString() == tipoUsuario)
                    {
                        XtraMessageBox.Show("Para actualizar, debe haber algún cambio en los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Actualizar los datos del usuario
                string queryActualizar = $"UPDATE Login SET Usuario = '{usuario}', Password = '{password}', Tipo_Usuario = '{tipoUsuario}' WHERE Id_Usuario = {idUsuario}; " +
                                         $"UPDATE Empleados SET Id_Departamento = {idDepartamento} WHERE Id_Empleado = {idEmpleado};";
                conexionDB.EjecutarComando(queryActualizar);

                XtraMessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
            }
            else
            {
                XtraMessageBox.Show("Seleccione un usuario para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void btnEiminar_Click(object sender, EventArgs e)
        {
            GridView gridView = gridUsuarios.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                object idUsuario = gridView.GetFocusedRowCellValue("Id_Usuario");

                if (idUsuario != null && int.TryParse(idUsuario.ToString(), out int id) && id > 0)
                {
                    DialogResult result = XtraMessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string query = $"DELETE FROM OrdenServicio WHERE Id_Usuario = {id}; " +
                                       $"DELETE FROM Login WHERE Id_Usuario = {id}";

                        conexionDB.EjecutarComando(query);
                        XtraMessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarUsuarios();
                    }
                }
                else
                {
                    XtraMessageBox.Show("No se pudo eliminar el usuario. El ID del usuario es inválido o no está seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Seleccione un usuario antes de intentar eliminarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LookUpEmpleado_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEmpleado.EditValue == null)
            {
                XtraMessageBox.Show("No hay empleado seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(lookUpEmpleado.EditValue.ToString(), out int idEmpleado))
            {
                XtraMessageBox.Show("Error al obtener el ID del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = $"SELECT e.*, l.Usuario, l.Password, l.Tipo_Usuario " +
                           $"FROM Empleados e " +
                           $"LEFT JOIN Login l ON e.Id_Empleado = l.Id_Empleado " +
                           $"WHERE e.Id_Empleado = {idEmpleado}";

            DataTable dt = conexionDB.EjecutarConsulta(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Rellenar datos del empleado
                // txtNombreEmpleado.Text = row["Nombre_Empleado"].ToString();
                txtCorreoElectronico.Text = row["Correo_Electronico"].ToString();
                lookUpDepartamento.EditValue = row["Id_Departamento"];

                // Rellenar datos del usuario si existen
                txtUsuario.Text = row["Usuario"] != DBNull.Value ? row["Usuario"].ToString() : "";
                txtPassword.Text = row["Password"] != DBNull.Value ? row["Password"].ToString() : "";

                // Asegurar que `Tipo_Usuario` se seleccione correctamente
                string tipoUsuario = row["Tipo_Usuario"] != DBNull.Value ? row["Tipo_Usuario"].ToString() : "General";

                if (comboTipoUsuario.Properties.Items.Contains(tipoUsuario))
                {
                    comboTipoUsuario.SelectedItem = tipoUsuario;
                }
                else
                {
                    comboTipoUsuario.SelectedIndex = 0; // Si no se encuentra, seleccionar "Admin"
                }

                // Seleccionar la fila correspondiente en el grid
                int idUsuarioSeleccionado = Convert.ToInt32(lookUpEmpleado.EditValue);
                int rowHandle = gridView1.LocateByValue("Id_Usuario", idUsuarioSeleccionado);
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    gridView1.FocusedRowHandle = rowHandle;
                }
            }
            else
            {
                XtraMessageBox.Show("No se encontraron datos del empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridUsuarios_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                GridView gridView = sender as GridView;
                DataRow row = gridView.GetDataRow(e.FocusedRowHandle);
                if (row != null)
                {
                    // Rellenar datos del empleado
                    //  txtNombreEmpleado.Text = row["Nombre_Completo"].ToString();
                    txtCorreoElectronico.Text = row["Correo_Electronico"].ToString();

                    // Asignar el ID del empleado al LookUpEdit
                    int idEmpleado = Convert.ToInt32(row["Id_Empleado"]);
                    lookUpEmpleado.EditValue = idEmpleado;

                    // Rellenar datos del usuario
                    txtUsuario.Text = row["Usuario"].ToString();
                    txtPassword.Text = row["Password"].ToString();
                    comboTipoUsuario.SelectedItem = row["Tipo_Usuario"].ToString();

                    // Asignar el ID del departamento
                    lookUpDepartamento.EditValue = Convert.ToInt32(row["Id_Departamento"]);

                    // Mostrar nombre del departamento en el grid
                    gridView.Columns["Nombre_Departamento"].Visible = true;
                    gridView.Columns["Id_Departamento"].Visible = false;
                    gridView.Columns["Id_Empleado"].Visible = false;
                }
            }
        }
        #endregion

        #region Métodos de la forma
        private void CargarTiposDeUsuario()
        {
            // Asegurarte de que el ComboBox tiene los valores disponibles
            comboTipoUsuario.Properties.Items.Clear();
            //cambiar esta parte por los roles correspodientes a la bse de datos si no da error
            comboTipoUsuario.Properties.Items.AddRange(new string[] { "Admin", "RH", "RM", "General", "N5", "N6" });
            comboTipoUsuario.SelectedIndex = 2; // 🔥 Seleccionar "Admin" por defecto
        }



        private void CargarUsuarios()
        {
            string query = $"SELECT l.Id_Usuario, l.Usuario, l.Password, l.Tipo_Usuario, " +
                           $"e.Id_Empleado, e.Nombre_Empleado + ' ' + e.Apellido_Paterno + ' ' + e.Apellido_Materno AS Nombre_Completo, " +
                           $"e.Correo_Electronico, d.Nombre_Departamento, d.Id_Departamento " +
                           $"FROM Login l " +
                           $"INNER JOIN Empleados e ON l.Id_Empleado = e.Id_Empleado " +
                           $"INNER JOIN Departamentos d ON e.Id_Departamento = d.Id_Departamento";
            DataTable dt = conexionDB.EjecutarConsulta(query);
            gridUsuarios.DataSource = dt;
        }


        private void CargarEmpleados()
        {
            string query = "SELECT Id_Empleado, (Nombre_Empleado + ' ' + Apellido_Paterno + ' ' + Apellido_Materno) AS Nombre_Empleado FROM Empleados";
            DataTable dt = conexionDB.EjecutarConsulta(query);
            if (dt.Rows.Count > 0)
            {
                lookUpEmpleado.Properties.DataSource = dt;
                lookUpEmpleado.Properties.DisplayMember = "Nombre_Empleado"; // Campo visible
                lookUpEmpleado.Properties.ValueMember = "Id_Empleado";      // Valor interno
                lookUpEmpleado.EditValue = null; // Limpiar selección inicial
            }
            else
            {
                lookUpEmpleado.Properties.DataSource = null;
                XtraMessageBox.Show("No hay empleados en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarDepartamentos()
        {
            lookUpDepartamento.Properties.DataSource = null; // Limpia el DataSource
            string query = "SELECT Id_Departamento, Nombre_Departamento FROM Departamentos";
            lookUpDepartamento.Properties.DataSource = conexionDB.EjecutarConsulta(query);
            lookUpDepartamento.Properties.DisplayMember = "Nombre_Departamento";
            lookUpDepartamento.Properties.ValueMember = "Id_Departamento";
            lookUpDepartamento.Refresh(); // Actualiza el LookUpEdit
        }




        #endregion

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}

