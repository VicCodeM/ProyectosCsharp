using ODS.Forms;
using System;
using System.Windows.Forms;

namespace ODS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar siempre con el formulario de login
            Application.Run(new frmLogin());
        }
    }
}