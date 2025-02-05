using DevExpress.XtraEditors;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ODS.Datos;
using ODS.Modelo;
using System.Data; // Importamos la clase de conexión

namespace ODS.Forms
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        UsuarioConsultas consultas = new UsuarioConsultas(); // Instancia de las consultas

        public frmLogin()
        {

            InitializeComponent();

            // Asignar el botón btnLogin como el botón de aceptación (Enter)
            this.AcceptButton = btnLogin;
            // Evento con DevExpress para mover el formulario desde la parte de arriba 
            panelControl2.MouseDown += panelBarraTitulo_MouseDown;
        }

        // Crear función para arrastrar formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Evento para mover formulario
        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                XtraMessageBox.Show("Por favor, ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipoUsuario = consultas.ValidarUsuario(usuario, password);

            if (!string.IsNullOrEmpty(tipoUsuario))
            {
                // Obtener datos del usuario logueado
                DataTable datosUsuario = consultas.ObtenerDatosUsuario(usuario);
                if (datosUsuario.Rows.Count > 0)
                {
                    UsuarioLogueado.IdUsuario = Convert.ToInt32(datosUsuario.Rows[0]["Id_Usuario"]); // Convertir a INT
                    UsuarioLogueado.NombreCompleto = datosUsuario.Rows[0]["NombreCompleto"].ToString();
                    UsuarioLogueado.Correo = datosUsuario.Rows[0]["Correo"].ToString();
                    UsuarioLogueado.Departamento = datosUsuario.Rows[0]["Departamento"].ToString();
                    UsuarioLogueado.TipoUsuario = datosUsuario.Rows[0]["Tipo_Usuario"].ToString();
                    UsuarioLogueado.NombreUsuario = datosUsuario.Rows[0]["Usuario"].ToString();
                }

                XtraMessageBox.Show($"Inicio de sesión exitoso. Bienvenido, {UsuarioLogueado.NombreCompleto}", "Bienvenido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                FormPanel mainForm = new FormPanel(UsuarioLogueado.TipoUsuario);
                mainForm.Show();
            }
            else
            {
                XtraMessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }

        private void checkboxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si el CheckBox está marcado
            if (checkboxShowPass.Checked)
            {
                // Mostrar la contraseña: Desactivar el PasswordChar
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                // Ocultar la contraseña: Activar el PasswordChar
                txtPassword.PasswordChar = '*'; // Puedes usar '*' o '●'
            }
    }
}
}