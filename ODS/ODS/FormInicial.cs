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
    public partial class FormInicial : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
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
        public FormInicial()
        {
            InitializeComponent();
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
            int idUsuario = 1; // ID de usuario que deseas consultar

            // Obtener el departamento del usuario
            string nombreDepartamento = consultas.ObtenerDepartamentoPorUsuario(idUsuario);

            // Mostrar el resultado en un label
            if (!string.IsNullOrEmpty(nombreDepartamento))
            {
                departamentoElement.Text = nombreDepartamento;
            }
            else
            {
                departamentoElement.Text = "No se encontró el departamento para este usuario.";
            }
            //mostrar nombre aplliedo
            string nombreYApellido = consultas.ObtenerNombreCompletoUsuario(idUsuario);

            // Mostrar el resultado en el label
            if (!string.IsNullOrEmpty(nombreYApellido))
            {
                labelUsuario.Text = $"Usuario: {nombreYApellido}";
                usuarioElement.Text = nombreYApellido;
            }
            else
            {
                labelUsuario.Text = "No se encontró el nombre del usuario.";
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
            FormInicial formularioSecundario = new FormInicial();

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

    }
}
