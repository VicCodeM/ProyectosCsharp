using DevExpress.XtraEditors;
using ODS.Datos;
using ODS.Forms;
using ODS.Modelo;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ODS
{
    public partial class FormPanel : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        #region Variables globales.
        private Timer timer;
        private string tipoUsuario;
        private bool cerrarPorSesion = false;


        //Foma de cierre del sistema por inactividad.
        private Timer inactivityTimer;
        private const int InactivityTimeout = 10800000; // 7 Horas de inactividad en milisegundos.
        private bool mensajeMostrado = false;
        private bool cerrarPorInactividad = false; // Variable para determinar si el cierre fue por inactividad

        #endregion

        #region Intaciar objetos
        ConexionDB conexionDB = new ConexionDB();
        FechaServicio fechaService = new FechaServicio();
        #endregion





        #region Pricipal de Form
        public FormPanel(string tipoUsuario)
        {
            InitializeComponent();
            InicializarTemporizadorInactividad();

            this.tipoUsuario = UsuarioLogueado.TipoUsuario;
            if (string.IsNullOrEmpty(tipoUsuario))
            {
                XtraMessageBox.Show("No se pudo obtener el tipo de usuario. Cerrando la aplicación.");
                Application.Exit();
                return;
            }


            // Configurar la apariencia del formulario
            this.Appearance.BackColor = Color.Transparent;
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

            // Mostrar formulario de inicio
            frmInicio formularioSecundario = new frmInicio();
            MostrarFormularioEnPanel(groupControl1, formularioSecundario);

            // Configurar el fondo transparente
            this.Appearance.BackColor = Color.Transparent; // Fondo transparente
            //this.LookAndFeel.UseDefaultLookAndFeel = false; // Desactivar el estilo predeterminado
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat; // Estilo plano
            // Abre el formulario
            frmInicio formularioSecundario2 = new frmInicio();
            MostrarFormularioEnPanel(groupControl1, formularioSecundario2);
            //cerrar cualquier conexion abierta
            conexionDB.CerrarConexion();

            this.FormClosed += FormPanel_FormClosed; // Vincula el evento de cerrado
            this.FormClosing += FormPanel_FormClosing; // Agregar esta línea

            #region Acciones inciales con  la forma
            // Crear una instancia del Timer
            timer = new Timer();

            // Configurar el intervalo a 1000 ms (1 segundo)
            timer.Interval = 1000;

            // Asignar el evento Tick del Timer
            timer.Tick += Timer_Tick;

            // Iniciar el Timer
            timer.Start();
            VerificarTipoUsuario();
            #endregion
        }



        private void FormInicial_Load(object sender, EventArgs e)
        {

            // Mostrar el departamento
            departamentoElement.Text = "Departamento: " + (string.IsNullOrEmpty(UsuarioLogueado.Departamento) ? "N/A" : UsuarioLogueado.Departamento);

            // Mostrar nombre completo
            acordeonUsuario.Text = string.IsNullOrEmpty(UsuarioLogueado.NombreCompleto) ? "N/A" : UsuarioLogueado.NombreCompleto.ToUpper();

            // Mostrar solo el nombre de usuario
            usuarioElement.Text = "Usuario: " + (string.IsNullOrEmpty(UsuarioLogueado.NombreUsuario) ? "N/A" : UsuarioLogueado.NombreUsuario);
            //Verificamos si el usuario es admin
            VerificarTipoUsuario();

        }
        #endregion

        #region Eventos del form


        private void panelControl1_SizeChanged(object sender, EventArgs e)
        {
            if (panelControl1.Controls.Count > 0)
            {
                var controlEmbebido = panelControl1.Controls[0];
                controlEmbebido.Dock = DockStyle.Fill;
                controlEmbebido.Refresh();
            }
        }
        //eventos del menu
        private void ControlINICIO_Click(object sender, EventArgs e)
        {
            frmInicio formularioSecundario = new frmInicio();

            // Llamar al método para mostrar el formulario dentro del PanelControl
            MostrarFormularioEnPanel(groupControl1, formularioSecundario);
        }




        private void ControlUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios formausuarios = new frmUsuarios();
            MostrarFormularioEnPanel(groupControl1, formausuarios);
        }



        private void FormPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cerrarPorInactividad)
            {
                // Si el cierre fue por inactividad, solo cerramos el formulario
                cerrarPorInactividad = false; // Reiniciar la variable
            }
            else
            {
                // Si el cierre fue manual, cerramos toda la aplicación
                // this.Close();
                //  Application.Exit();

            }

        }

        private void elementCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = XtraMessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Cerrar Sesión",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                cerrarPorSesion = true; // Indicar que el cierre es por sesión
                CerrarSesion();
                mensajeMostrado = true;
            }


        }
        #endregion

        #region Majeo de tipos de usuarios
        //Manejo de tipo usuario para mostrar funciones
        private void VerificarTipoUsuario()
        {
            if (UsuarioLogueado.TipoUsuario == "Admin")
            {
                // Mostrar el tipo de usuario

                elemntAdminstracion.Visible = true;
            }
            else
            {
                // Ocultar el tipo de usuario
                elemntAdminstracion.Visible = false;
            }

        }
        #endregion

        #region Métodos del form
        // Método que se ejecuta cada segundo (evento Tick)
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualizar el texto del Label con la hora actual
            labelHora.Text = "Hora: " + fechaService.ObtenerHora();
            labelFecha.Text = "Fecha: " + fechaService.ObtenerFecha();
        }

        private void MostrarFormularioEnPanel(Control panel, Control controlEmbebido)
        {
            // Limpiar cualquier control existente en el panel
            panel.Controls.Clear();

            // Configurar el control embebido según su tipo
            if (controlEmbebido is Form formulario)
            {
                // Si es un formulario, configurarlo para ser embebido
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panel.Controls.Add(formulario);
                formulario.Show();
            }
            else
            {
                // Si no es un formulario, asumir que es un control estándar
                controlEmbebido.Dock = DockStyle.Fill;
                panel.Controls.Add(controlEmbebido);
            }

            // Asegurar que el control es visible y actualizado
            controlEmbebido.BringToFront();
            controlEmbebido.Refresh();
        }

        #endregion

        #region Métodos de Inactividad

        private void InicializarTemporizadorInactividad()
        {
            inactivityTimer = new Timer();
            inactivityTimer.Interval = InactivityTimeout;
            inactivityTimer.Tick += TemporizadorInactividad_Tick;
            inactivityTimer.Start();

            // Suscribirse a eventos de actividad
            this.MouseMove += OnActividadUsuario;
            this.KeyPress += OnActividadUsuario;
            this.Click += OnActividadUsuario;
        }

        private void OnActividadUsuario(object sender, EventArgs e)
        {
            // Reiniciar el temporizador cada vez que hay actividad
            ReiniciarTemporizador();
        }

        private void TemporizadorInactividad_Tick(object sender, EventArgs e)
        {
            // Detener el temporizador
            inactivityTimer.Stop();

            // Ejecutar el método después de la inactividad
            EjecutarMetodoDespuesDeInactividad();
        }

        private void EjecutarMetodoDespuesDeInactividad()
        {
            // Verificar si el mensaje ya se ha mostrado
            if (!mensajeMostrado)
            {
                // Aquí puedes poner el código que quieres ejecutar después de la inactividad
                CerrarSesion();
                XtraMessageBox.Show("Sesión cerrada por inactividad.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Marcar que el mensaje ya se ha mostrado
                mensajeMostrado = true;
            }

            // Cerrar solo el formulario
            this.Hide();

            // Marcar que el cierre fue por inactividad
            cerrarPorInactividad = true;


        }
        private void CerrarSesion()
        {
            try
            {
                // Limpiar la sesión (centralizado en UsuarioLogueado)
                UsuarioLogueado.LimpiarDatos();

                // Ocultar y cerrar el formulario principal
                this.Hide(); // Cierra completamente el formulario principal

                // Buscar si frmLogin sigue abierto
                Form loginForm = Application.OpenForms["frmLogin"];
                if (loginForm != null)
                {
                    // Si ya está en memoria, lo mostramos
                    loginForm.Show();
                }
                else
                {
                    // Si no existe, creamos una nueva instancia y la mostramos
                    loginForm = new frmLogin();
                    loginForm.Show();
                }
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                XtraMessageBox.Show($"Ocurrió un error al cerrar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReiniciarTemporizador()
        {
            // Reiniciar el temporizador
            inactivityTimer.Stop();
            inactivityTimer.Start();

            // Reiniciar la bandera
            mensajeMostrado = false;
        }

        #endregion

        private void elementBitacora_Click(object sender, EventArgs e)
        {
            // Cierra la conexión antes de abrir el formulario
            if (conexionDB.ConectarSQL() != null && conexionDB.ConectarSQL().State == System.Data.ConnectionState.Open)
            {
                conexionDB.ConectarSQL().Close();
            }
            frmBitacora formabitacora = new frmBitacora();
            MostrarFormularioEnPanel(groupControl1, formabitacora);
        }

        private void elemntOrdenesServicio_Click(object sender, EventArgs e)
        {
            // Cierra la conexión antes de abrir el formulario
            if (conexionDB.ConectarSQL() != null && conexionDB.ConectarSQL().State == System.Data.ConnectionState.Open)
            {
                conexionDB.ConectarSQL().Close();
            }
            FormRegistrar formaregistrar = new FormRegistrar();
            MostrarFormularioEnPanel(groupControl1, formaregistrar);
        }

        private void elemntActualizarServicio_Click(object sender, EventArgs e)
        {
            // Cierra la conexión antes de abrir el formulario
            if (conexionDB.ConectarSQL() != null && conexionDB.ConectarSQL().State == System.Data.ConnectionState.Open)
            {
                conexionDB.ConectarSQL().Close();
            }
            frmAdminRegistros formaregistro = new frmAdminRegistros();
            MostrarFormularioEnPanel(groupControl1, formaregistro);
        }


        //elemento dos para cerrar sesión 
        private void elemtCerrarSesion1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = XtraMessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Cerrar Sesión",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                cerrarPorSesion = true; // Indicar que el cierre es por sesión
                CerrarSesion();
                mensajeMostrado = true;
            }


        }
        //Mensaje de cierre de app
        private bool isClosing = false;

        private void FormPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarPorSesion)
            {
                cerrarPorSesion = false;
                return;
            }

            if (!isClosing)
            {
                DialogResult resultado = XtraMessageBox.Show(
                    "¿Está seguro de que desea cerrar la aplicación?",
                    "Confirmar cierre",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    isClosing = true;
                    Application.Exit();
                }
            }
        }

    }
}
