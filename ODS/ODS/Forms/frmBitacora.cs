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
            ((GridView)gridControl1.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridControl1.MainView).BestFitColumns();
            ((GridView)gridControl1.MainView).OptionsView.ShowDetailButtons = false;

            LoadDataToGrid(); // Cargar datos al abrir el formulario
        }
        private void LoadDataToGrid()
        {
            try
            {
                BitacoraService bitacoraService = new BitacoraService();
                DataTable dataTable = bitacoraService.ObtenerDatosBitacora();

                if (dataTable != null)
                {
                    gridControl1.DataSource = dataTable;

                    GridView gridView = gridControl1.MainView as GridView;
                    if (gridView != null)
                    {
                        gridView.Columns["Id"].Caption = "Id";
                        gridView.Columns["Id_Orden"].Caption = "Id Orden";
                        gridView.Columns["Administrador"].Caption = "Administrador";
                        gridView.Columns["Accion"].Caption = "Acción";
                        gridView.Columns["Fecha"].Caption = "Fecha";
                        gridView.Columns["Hora"].Caption = "Hora";
                        gridView.Columns["Descripcion"].Caption = "Descripción";

                        // Ajustar las columnas automáticamente
                        gridView.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos en el GridControl: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
