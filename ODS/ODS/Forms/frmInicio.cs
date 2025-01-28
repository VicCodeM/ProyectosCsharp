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
    }
}