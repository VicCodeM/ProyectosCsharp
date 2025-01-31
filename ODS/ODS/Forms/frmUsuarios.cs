﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmUsuarios : XtraUserControl
    {
        private ConexionDB conexionDB = new ConexionDB();

        public frmUsuarios()
        {
            InitializeComponent();

            // Cargar datos al iniciar
            CargarUsuarios();
            CargarEmpleados();
            CargarDepartamentos();
            CargarTiposDeUsuario();

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
        }

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

            // Insertar el nuevo usuario en la tabla Login
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
                int idUsuario = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id_Usuario"));
                int idEmpleado = Convert.ToInt32(lookUpEmpleado.EditValue);
                string usuario = txtUsuario.Text;
                string password = txtPassword.Text;
                string tipoUsuario = comboTipoUsuario.SelectedItem.ToString();
                int idDepartamento = Convert.ToInt32(lookUpDepartamento.EditValue); // 🔥 Nuevo: Obtener el departamento seleccionado


                // Actualizar los datos del usuario
                string queryActualizar = $"UPDATE Login SET Usuario = '{usuario}', Password = '{password}', Tipo_Usuario = '{tipoUsuario}' WHERE Id_Usuario = {idUsuario}; " +
                                         $"UPDATE Empleados SET Id_Departamento = {lookUpDepartamento.EditValue} WHERE Id_Empleado = {idEmpleado};";
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
                    DialogResult result = XtraMessageBox.Show("¿Está seguro de eliminar este usuario?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string query = $"DELETE FROM OrdenServicio WHERE Id_Usuario = {id}; " +
                                       $"DELETE FROM Login WHERE Id_Usuario = {id}";

                        conexionDB.EjecutarComando(query);
                        XtraMessageBox.Show("Usuario eliminado correctamente.","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        CargarUsuarios();
                    }
                }
                else
                {
                    XtraMessageBox.Show("No se pudo eliminar el usuario. El ID del usuario es inválido o no está seleccionado.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Seleccione un usuario antes de intentar eliminarlo.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void CargarTiposDeUsuario()
        {
            // Asegurarte de que el ComboBox tiene los valores disponibles
            comboTipoUsuario.Properties.Items.Clear();
            comboTipoUsuario.Properties.Items.AddRange(new string[] { "Admin", "Nivel2", "Nivel3", "Nivel4", "Nivel5", "Nivel6" });
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
                string tipoUsuario = row["Tipo_Usuario"] != DBNull.Value ? row["Tipo_Usuario"].ToString() : "Nivel2";

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
    }
}

