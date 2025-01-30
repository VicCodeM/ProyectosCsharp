using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmUsuarios : DevExpress.XtraEditors.XtraUserControl
    {
        private GridView gridView; // 🔥 Asegurar que esté declarado correctamente

        ConexionDB conexionDB = new ConexionDB();
        public frmUsuarios()
        {
            InitializeComponent();

            //cragamos datos correctos
            CargarUsuarios();
            CargarEmpleados();
            CargarDepartamentos();
            CargarTiposDeUsuario();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string tipoUsuario = comboTipoUsuario.Text;
            int idEmpleado = Convert.ToInt32(lookUpEmpleado.EditValue);

            string query = $"INSERT INTO Login (Usuario, Password, Tipo_Usuario, Id_Empleado) VALUES ('{usuario}', '{password}', '{tipoUsuario}', {idEmpleado})";
            conexionDB.EjecutarComando(query);

            XtraMessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarUsuarios();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id_Usuario"));
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string tipoUsuario = comboTipoUsuario.Text;
            int idEmpleado = Convert.ToInt32(lookUpEmpleado.EditValue);

            string query = $"UPDATE Login SET Usuario = '{usuario}', Password = '{password}', Tipo_Usuario = '{tipoUsuario}', Id_Empleado = {idEmpleado} WHERE Id_Usuario = {idUsuario}";
            conexionDB.EjecutarComando(query);

            XtraMessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarUsuarios();
        }

        private void btnEiminar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(gridView.GetFocusedRowCellValue("Id_Usuario"));
            string query = $"DELETE FROM Login WHERE Id_Usuario = {idUsuario}";
            conexionDB.EjecutarComando(query);

            XtraMessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarUsuarios();
        }


        //metodos del form
        private void CargarUsuarios()
        {
            string query = "SELECT Id_Usuario, Usuario, Password, Tipo_Usuario, " +
                           "(SELECT Nombre_Empleado FROM Empleados WHERE Empleados.Id_Empleado = Login.Id_Empleado) AS Empleado " +
                           "FROM Login";

            gridUsuarios.DataSource = conexionDB.EjecutarConsulta(query);
        }


        private void CargarEmpleados()
        {
            string query = "SELECT Id_Empleado, (Nombre_Empleado + ' ' + Apellido_Paterno) AS Nombre_Empleado FROM Empleados";
            lookUpEmpleado.Properties.DataSource = conexionDB.EjecutarConsulta(query);
            lookUpEmpleado.Properties.DisplayMember = "Nombre_Empleado";
            lookUpEmpleado.Properties.ValueMember = "Id_Empleado";
        }

        private void CargarDepartamentos()
        {
            string query = "SELECT Id_Departamento, Nombre_Departamento FROM Departamentos";
            lookUpDepartamento.Properties.DataSource = conexionDB.EjecutarConsulta(query);
            lookUpDepartamento.Properties.DisplayMember = "Nombre_Departamento";
            lookUpDepartamento.Properties.ValueMember = "Id_Departamento";
        }

        private void CargarTiposDeUsuario()
        {
            comboTipoUsuario.Properties.Items.Clear();
            comboTipoUsuario.Properties.Items.AddRange(new string[] { "Admin", "Nivel2", "Nivel3", "Nivel4" });
            comboTipoUsuario.SelectedIndex = 0; // Seleccionar el primero
        }



    }
}
