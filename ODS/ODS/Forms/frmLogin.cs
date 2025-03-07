using DevExpress.XtraEditors;
using ODS.Datos;
using ODS.Modelo;
using System;
using System.Data;
using System.Data.SqlClient; // Importamos la clase de conexión
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region Inctancia de Objetos.
        UsuarioConsultas consultas = new UsuarioConsultas(); // Instancia de las consultas
        ConexionDB conexionDB = new ConexionDB();
        #endregion

        #region Acciones al incio del form.
        public frmLogin()
        {

            InitializeComponent();

            // Asignar el botón btnLogin como el botón de aceptación (Enter)
            this.AcceptButton = btnLogin;
            // Evento con DevExpress para mover el formulario desde la parte de arriba 
            panelControl2.MouseDown += panelBarraTitulo_MouseDown;

        } 
        #endregion

        #region Métodos manejo de la forma.
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
        //cerrar app
        private void panelCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //minimizar forma
        private void panelMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Métodos de la forma.
        //metod limpiar campos con cerrar sesión
        public void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtUsuario.Focus(); // Enfocar el campo usuario para que el usuario pueda escribir de inmediato
        }


        #endregion

        #region Eventos de la forma.
        //btn login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                string usuario = txtUsuario.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
                {
                    XtraMessageBox.Show("Por favor, ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar credenciales del usuario
                string tipoUsuario = consultas.ValidarUsuario(usuario, password);

                if (!string.IsNullOrEmpty(tipoUsuario))
                {
                    // Obtener datos del usuario
                    DataTable datosUsuario = consultas.ObtenerDatosUsuario(usuario);

                    if (datosUsuario.Rows.Count > 0)
                    {
                        // Almacenar datos del usuario logueado
                        UsuarioLogueado.IdUsuario = Convert.ToInt32(datosUsuario.Rows[0]["Id_Usuario"]);
                        UsuarioLogueado.Usuario = datosUsuario.Rows[0]["Usuario"].ToString();
                        UsuarioLogueado.NombreCompleto = datosUsuario.Rows[0]["NombreCompleto"].ToString();
                        UsuarioLogueado.Correo = datosUsuario.Rows[0]["Correo"].ToString();
                        UsuarioLogueado.Departamento = datosUsuario.Rows[0]["Departamento"].ToString();
                        UsuarioLogueado.TipoUsuario = datosUsuario.Rows[0]["Tipo_Usuario"].ToString();
                        UsuarioLogueado.NombreUsuario = datosUsuario.Rows[0]["Usuario"].ToString();
                     
                    }

                    // Mostrar mensaje de éxito
                    //Mensaje Opcional
                    // XtraMessageBox.Show($"Inicio de sesión exitoso. Bienvenido, {UsuarioLogueado.NombreCompleto}", "Bienvenido",
                    //MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ocultar el formulario de login
                    this.Hide();

                    // Mostrar el formulario de carga
                    frmLoader loader = new frmLoader(tipoUsuario);

                    // Configurar el evento FormClosed del formulario de carga
                    loader.FormClosed += (s, args) =>
                    {
                        // Mostrar el formulario principal después de cerrar el formulario de carga
                        FormPanel mainForm = new FormPanel(tipoUsuario);

                        mainForm.FormClosed += (s2, args2) =>
                        {
                            // Limpiar campos al volver al login
                            LimpiarCampos();
                            this.Show();
                        };

                        mainForm.ShowDialog();
                    };

                    // Abrir el formulario de carga como modal
                    loader.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                XtraMessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Limpiar el campo de contraseña
                txtPassword.Text = "";
            }
        }



        // Botón para limpiar campos manualmente
        private void btnClear_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
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




        private void frmLogin_Load(object sender, EventArgs e)
        {
            //limpiar datos al cargar fromulario de nuevo
            LimpiarCampos();
            txtPassword.Text = "";

        }
        //Borrar con un clic el campo de password
        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        } 
        #endregion
    }
}