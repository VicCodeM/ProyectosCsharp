using DevExpress.XtraSplashScreen;
using ODS.Modelo;
using System;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmLoader : SplashScreen
    {
        #region Variables Globales.
        private Timer timer;
        #endregion

        #region Inico de Forma con Compontes.
        public frmLoader(string tipoUsuario)
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 1982-" + DateTime.Now.Year.ToString();

            // Configurar el Timer para cerrar el SplashScreen después de 3 segundos
            timer = new Timer();
            timer.Interval = 3000; // 3000 milisegundos = 3 segundos
            timer.Tick += Timer_Tick;
            timer.Start();
            labelNombreUsuario.Text = UsuarioLogueado.NombreCompleto;
        } 
        #endregion

        #region Eventos de la Forma.
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop(); // Detiene el Timer para que no vuelva a ejecutarse
            this.Close(); // Cierra el SplashScreen
        } 
        #endregion

    }
}
