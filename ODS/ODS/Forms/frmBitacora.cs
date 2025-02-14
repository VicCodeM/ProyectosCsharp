using ClosedXML.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Modelo;
using ODS.Servicios;
using System;
using System.Data;
using System.Windows.Forms;


namespace ODS.Forms
{
    public partial class frmBitacora : XtraUserControl
    {
        private readonly ExportarService exportarexcel = new ExportarService();

        public frmBitacora()
        {
            InitializeComponent();
            ((GridView)gridBitacora.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridBitacora.MainView).BestFitColumns();
            ((GridView)gridBitacora.MainView).OptionsView.ShowDetailButtons = false;

            LoadDataToGrid(); // Cargar datos al abrir el formulario
            label2.Text = UsuarioLogueado.NombreCompleto;
        }
        private void LoadDataToGrid()
        {
            try
            {
                BitacoraService bitacoraService = new BitacoraService();
                DataTable dataTable = bitacoraService.ObtenerDatosBitacora();

                if (dataTable != null)
                {
                    gridBitacora.DataSource = dataTable;

                    GridView gridViewBitacora = gridBitacora.MainView as GridView;
                    if (gridViewBitacora != null)
                    {
                        gridViewBitacora.Columns["Id"].Caption = "Id";
                        gridViewBitacora.Columns["Id_Orden"].Caption = "Id Órden";
                        gridViewBitacora.Columns["Administrador"].Caption = "Administrador";
                        gridViewBitacora.Columns["Accion"].Caption = "Acción";
                        gridViewBitacora.Columns["Fecha_Orden"].Caption = "Fecha Óraden";
                        gridViewBitacora.Columns["Fecha_Accion"].Caption = "Fecha Atención";
                        gridViewBitacora.Columns["Hora_Orden"].Caption = "Hora Órden";
                        gridViewBitacora.Columns["Hora_Accion"].Caption = "Hora Atención";
                        gridViewBitacora.Columns["Descripcion"].Caption = "Descripción";
                        gridViewBitacora.Columns["Nombre_Empleado"].Caption = "Administrador";

                        // Ajustar el orden: colocar la columna "Hora" después de "Fecha_Registro"
                        gridViewBitacora.Columns["Id_Orden"].VisibleIndex = 1; // Primera columna
                        gridViewBitacora.Columns["Hora_Orden"].VisibleIndex = 2;   // Segunda columna
                        gridViewBitacora.Columns["Fecha_Orden"].VisibleIndex = 3;
                        gridViewBitacora.Columns["Accion"].VisibleIndex = 4;
                        gridViewBitacora.Columns["Fecha_Accion"].VisibleIndex = 5;
                        gridViewBitacora.Columns["Descripcion"].VisibleIndex = 6;
                        gridViewBitacora.Columns["Hora_Accion"].VisibleIndex = 7;
                        gridViewBitacora.Columns["Administrador"].VisibleIndex = 8;

                        //ocultar columnas
                        gridViewBitacora.Columns["Administrador"].Visible = false;  



                        // Ajustar las columnas automáticamente
                        gridViewBitacora.BestFitColumns();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos en el GridControl: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //exportar grid a excel
        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportarexcel.ExportarExcel(gridBitacora, "Bitacora");
        }

    }
}
