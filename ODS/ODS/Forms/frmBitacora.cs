using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using ODS.Servicios;
using System;
using System.Data;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmBitacora : XtraUserControl
    {


        public frmBitacora()
        {
            InitializeComponent();
            CargarDataGrid();

            // Configuración del GridControl y GridView
            GridView gridView = gridControl1.MainView as GridView;
            if (gridView != null)
            {
                gridView.OptionsBehavior.Editable = false;
                gridView.BestFitColumns();
                gridView.OptionsView.ShowDetailButtons = false;
            }
        }

        private void CargarDataGrid()
        {
            try
            {
                BitacoraService queries = new BitacoraService();
                ConexionDB queryExecutor = new ConexionDB();

                DataTable dataTable = queryExecutor.ExecuteQuery(queries.DatosBitacora());


                gridControl1.DataSource = dataTable;

                GridView gridBistacora = gridControl1.MainView as GridView;
                if (gridBistacora != null)
                {
                    gridBistacora.Columns["Id_Orden"].Caption = "ID Orden";
                    gridBistacora.Columns["Descripcion"].Caption = "Descripción";
                    gridBistacora.Columns["Observaciones"].Caption = "Observaciones";
                    gridBistacora.Columns["Nombre_Completo"].Caption = "Empleado que creó la orden";
                    gridBistacora.Columns["Usuario"].Caption = "Usuario Logueado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
