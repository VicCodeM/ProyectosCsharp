﻿using ODS.Modelo;
using System;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmInicio : DevExpress.XtraEditors.XtraForm
    {
        #region Variables globales.
        private Timer timer;

        // Obtener los datos del usuario logueado
        int idUsuario = UsuarioLogueado.IdUsuario;
        string nombre = UsuarioLogueado.NombreCompleto;
        string departamento = UsuarioLogueado.Departamento;

        #endregion

        #region Instancia de Objetos.
        FechaServicio fechaService = new FechaServicio();
        #endregion

        #region Inicio de Forma Componentes.
        public frmInicio()
        {
            InitializeComponent();
        } 
        #endregion

        #region Eventos de la Forma.
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualizar el texto del Label con la hora actual
            labelHora.Text = "Hora: " + fechaService.ObtenerHora();
            labelFecha.Text = "Fecha: " + fechaService.ObtenerFecha();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

            // Crear una instancia del Timer
            timer = new Timer();

            // Configurar el intervalo a 1000 ms (1 segundo)
            timer.Interval = 1000;

            // Asignar el evento Tick del Timer
            timer.Tick += Timer_Tick;

            // Iniciar el Timer
            timer.Start();


            // Obtener el nombre del usuario con el ID 1 (puedes cambiar este valor según sea necesario)
            int idUsuario1 = Convert.ToInt32(idUsuario); // ID de usuario que deseas consultar

            // Obtener el departamento del usuario
            string nombreDepartamento = departamento;

            // Mostrar el resultado en un label
            if (!string.IsNullOrEmpty(departamento))
            {
                // labelUsuario.Text = nombreDepartamento;
            }
            else
            {

            }
            //mostrar nombre aplliedo
            string nombreYApellido = nombre;

            // Mostrar el resultado en el label
            if (!string.IsNullOrEmpty(nombre))
            {
                labelUsuario.Text = $"{nombre}".ToUpper();
            }
            else
            {
                labelUsuario.Text = "No se encontró el nombre del usuario.";
            }
        }
        #endregion
    }
}