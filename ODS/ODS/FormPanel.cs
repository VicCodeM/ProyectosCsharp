using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ODS.Datos;
using ODS.Forms;
using ODS.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ODS
{
    public partial class FormPanel : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        #region Variables globales.
        private Timer timer;
        private SqlConnection conexion;
        private ConexionDB conexionBD;



        private Timer inactivityTimer;
        private const int InactivityTimeout = 900000; // 5 segundos
        #endregion



        private string tipoUsuario;


        #region Intaciar objetos
        ConexionDB conexionDB = new ConexionDB();
        ConsultasDB consultas = new ConsultasDB();
        FechaServicio fechaService = new FechaServicio();
        #endregion


        #region Pricipal de Form
        public FormPanel(string tipoUsuario)
        {
            InitializeComponent();
            InitializeInactivityTimer();

            this.tipoUsuario = tipoUsuario;
           

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



            #region Acciones inciales con  la forma
            // Crear una instancia del Timer
            timer = new Timer();

            // Configurar el intervalo a 1000 ms (1 segundo)
            timer.Interval = 1000;

            // Asignar el evento Tick del Timer
            timer.Tick += Timer_Tick;

            // Iniciar el Timer
            timer.Start();

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


            if (UsuarioLogueado.TipoUsuario != "Admin")
            {
                // Mostrar el tipo de usuario
                adminregistrosElement.Visible = false;
            }
            else
            {
                // Ocultar el tipo de usuario
                adminregistrosElement.Visible = true;
            }

        } 
        #endregion

        #region Eventos del form
        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            // Cierra la conexión antes de abrir el formulario
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }

            // Abre el formulario
            FormRegistrar formularioSecundario = new FormRegistrar();
            MostrarFormularioEnPanel(groupControl1, formularioSecundario);
        }

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

        private void registrosElement_Click(object sender, EventArgs e)
        {
            frmRegistro formularioSecundario = new frmRegistro();

            // Llamar al método para mostrar el formulario dentro del PanelControl
            MostrarFormularioEnPanel(groupControl1, formularioSecundario);
        }

        private void ControlUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios formausuarios = new frmUsuarios();
            MostrarFormularioEnPanel(groupControl1, formausuarios);
        }

        public void CerrarSesion()
        {
                // Limpiar la sesión
                UsuarioLogueado.IdUsuario = 0;
                UsuarioLogueado.NombreCompleto = string.Empty;
                UsuarioLogueado.Correo = string.Empty;
                UsuarioLogueado.Departamento = string.Empty;
                UsuarioLogueado.TipoUsuario = string.Empty;
                UsuarioLogueado.NombreUsuario = string.Empty;

                // Buscar si frmLogin sigue abierto
                Form loginForm = Application.OpenForms["frmLogin"];

                if (loginForm != null)
                {
                    loginForm.Show(); // Si ya está en memoria, solo lo mostramos
                }
                else
                {
                    loginForm = new frmLogin();
                    loginForm.Show(); // Si no existe, lo creamos
                }

                this.Hide(); // Cierra FormPanel
        }

        private void FormPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación

        }

        private void elementCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = XtraMessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Cerrar Sesión",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                CerrarSesion();
            }
                
        
        }


        #region Métodos de Inactividad
        private void InitializeInactivityTimer()
        {
            inactivityTimer = new Timer();
            inactivityTimer.Interval = InactivityTimeout;
            inactivityTimer.Tick += InactivityTimer_Tick;
            inactivityTimer.Start();

            // Suscribirse a eventos de actividad
            this.MouseMove += OnUserActivity;
            this.KeyPress += OnUserActivity;
            this.Click += OnUserActivity;
        }

        private void OnUserActivity(object sender, EventArgs e)
        {
            // Reiniciar el temporizador cada vez que hay actividad
            inactivityTimer.Stop();
            inactivityTimer.Start();
        }

        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            // Detener el temporizador
            inactivityTimer.Stop();

            // Ejecutar el método después de 5 segundos de inactividad
            ExecuteMethodAfterInactivity();
        }

        private void ExecuteMethodAfterInactivity()
        {
            // Aquí puedes poner el código que quieres ejecutar después de la inactividad
            DialogResult resultado = XtraMessageBox.Show("¿Desea seguir trabajando?", "Inactividad",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                CerrarSesion();
            }
            else
            {
                // Reiniciar el temporizador cada vez que hay actividad
                inactivityTimer.Stop();
                inactivityTimer.Start();
            }
        }

        #endregion
    }
}
