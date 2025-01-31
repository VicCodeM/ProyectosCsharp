using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ODS.Datos;
using ODS.Forms;
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

        #region Intaciar objetos
        ConexionDB conexionDB = new ConexionDB();
        ConsultasDB consultas = new ConsultasDB();
        FechaServicio fechaService = new FechaServicio();
        #endregion


        #region Pricipal de Form
        public FormPanel()
        {
            InitializeComponent();
            // Abre el formulario
            frmInicio formularioSecundario = new frmInicio();
            MostrarFormularioEnPanel(groupControl1, formularioSecundario);
            //cerrar cualquier conexion abierta
            conexionDB.CerrarConexion();


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
            // Obtener el nombre del usuario con el ID 1 (puedes cambiar este valor según sea necesario)
            int idUsuario = 2; // ID de usuario que deseas consultar

            // Obtener el departamento del usuario
            string nombreDepartamento = consultas.ObtenerDepartamentoPorUsuario(idUsuario);

            // Mostrar el resultado en un elemnt
            if (!string.IsNullOrEmpty(nombreDepartamento))
            {
                departamentoElement.Text = "Departamento: " + nombreDepartamento;
            }
            else
            {   //departamento no encontrado
                departamentoElement.Text = "N/A";
            }


            //mostrar nombre aplliedo
            string nombreYApellido = consultas.ObtenerNombreCompletoUsuario(idUsuario);
            string nombreUsuario = consultas.ObtenerNombreUsuario(idUsuario);

            // Mostrar el nombre completo en el inicio
            if (!string.IsNullOrEmpty(nombreYApellido))
            {
                // labelUsuario.Text = $"Usuario: {nombreYApellido}";
                acordeonUsuario.Text = nombreYApellido.ToUpper();
            }
            else
            {
                //usuario no encontrado
                acordeonUsuario.Text = "N/A";
            }

            //mostrar solo nombre de uaurio registrado 
            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                // labelUsuario.Text = $"Usuario: {nombreYApellido}";
                usuarioElement.Text = "Usuario: " + nombreUsuario;
            }
            else
            {
                //usuario no encontrado
                usuarioElement.Text = "N/A";
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
    }
}
