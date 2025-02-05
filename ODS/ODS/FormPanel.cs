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

            // Configurar el fondo transparente
            this.Appearance.BackColor = Color.Transparent; // Fondo transparente
            //this.LookAndFeel.UseDefaultLookAndFeel = false; // Desactivar el estilo predeterminado
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat; // Estilo plano
            // Abre el formulario
            frmInicio formularioSecundario = new frmInicio();
            MostrarFormularioEnPanel(groupControl1, formularioSecundario);
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

        private void FormPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación

        }
    }
}
