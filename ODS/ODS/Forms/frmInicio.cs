using DevExpress.XtraEditors;
using ODS.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmInicio : DevExpress.XtraEditors.XtraForm
    {
        #region Variables globales.
        private Timer timer;
        private SqlConnection conexion;
        private ConexionDB conexionBD;
        #endregion

        FechaServicio fechaService = new FechaServicio();
        ConsultasDB consultas = new ConsultasDB();

        public frmInicio()
        {
            InitializeComponent();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualizar el texto del Label con la hora actual
            labelHora.Text = "Hora: " + fechaService.ObtenerHora();
            labelFecha.Text = "Fecha: " + fechaService.ObtenerFecha();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
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
            // Obtener el nombre del usuario con el ID 1 (puedes cambiar este valor según sea necesario)
            int idUsuario = 2; // ID de usuario que deseas consultar

            // Obtener el departamento del usuario
            string nombreDepartamento = consultas.ObtenerDepartamentoPorUsuario(idUsuario);

            // Mostrar el resultado en un label
            if (!string.IsNullOrEmpty(nombreDepartamento))
            {
               // labelUsuario.Text = nombreDepartamento;
            }
            else
            {
               
            }
            //mostrar nombre aplliedo
            string nombreYApellido = consultas.ObtenerNombreCompletoUsuario(idUsuario);

            // Mostrar el resultado en el label
            if (!string.IsNullOrEmpty(nombreYApellido))
            {
                labelUsuario.Text = $"Usuario: {nombreYApellido}";
              
            }
            else
            {
                labelUsuario.Text = "No se encontró el nombre del usuario.";
            }
        }
    }
}