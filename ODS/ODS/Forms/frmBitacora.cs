using ClosedXML.Excel;
using DevExpress.Utils;
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
        #region Instancia de Objetos.
        private readonly ExportarService exportarexcel = new ExportarService();
        #endregion

        #region Acciones al incio del form.
        public frmBitacora()
        {
            InitializeComponent();
            ((GridView)gridBitacora.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridBitacora.MainView).BestFitColumns();
            ((GridView)gridBitacora.MainView).OptionsView.ShowDetailButtons = false;

            LoadDataToGrid(); // Cargar datos al abrir el formulario
            label2.Text = UsuarioLogueado.NombreCompleto;
        }

        #endregion

        #region Métodos de la Forma.
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
                        // Configurar columnas con nombres reales de la consulta
                        gridViewBitacora.Columns["Id_Bitacora"].Caption = "ID Bitácora";
                        gridViewBitacora.Columns["Id_Orden"].Caption = "ID Orden";
                        gridViewBitacora.Columns["FechaCreacionOrden"].Caption = "Fecha Creación Orden";
                        gridViewBitacora.Columns["FechaAccionAdmin"].Caption = "Fecha Acción";
                        gridViewBitacora.Columns["HoraAccionAdmin"].Caption = "Hora Acción";
                        gridViewBitacora.Columns["Accion"].Caption = "Acción";
                        gridViewBitacora.Columns["Descripcion"].Caption = "Descripción";
                        gridViewBitacora.Columns["NombreCreador"].Caption = "Creador";
                        gridViewBitacora.Columns["NombreAdmin"].Caption = "Administrador";

                        // Formato de fechas
                        gridViewBitacora.Columns["FechaCreacionOrden"].DisplayFormat.FormatType = FormatType.DateTime;
                        gridViewBitacora.Columns["FechaCreacionOrden"].DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";

                        gridViewBitacora.Columns["FechaAccionAdmin"].DisplayFormat.FormatType = FormatType.DateTime;
                        gridViewBitacora.Columns["FechaAccionAdmin"].DisplayFormat.FormatString = "dd-MM-yyyy";

                        gridViewBitacora.Columns["HoraAccionAdmin"].DisplayFormat.FormatType = FormatType.DateTime;
                        gridViewBitacora.Columns["HoraAccionAdmin"].DisplayFormat.FormatString = "HH:mm";

                        // Orden de columnas
                        gridViewBitacora.Columns["Id_Bitacora"].VisibleIndex = 0;
                        gridViewBitacora.Columns["Id_Orden"].VisibleIndex = 1;
                        gridViewBitacora.Columns["FechaCreacionOrden"].VisibleIndex = 2;
                        gridViewBitacora.Columns["NombreCreador"].VisibleIndex = 3;
                        gridViewBitacora.Columns["Accion"].VisibleIndex = 4;
                        gridViewBitacora.Columns["FechaAccionAdmin"].VisibleIndex = 5;
                        gridViewBitacora.Columns["HoraAccionAdmin"].VisibleIndex = 6;
                        gridViewBitacora.Columns["Descripcion"].VisibleIndex = 7;
                        gridViewBitacora.Columns["NombreAdmin"].VisibleIndex = 8;

                        // Ocultar columnas innecesarias
                       // gridViewBitacora.Columns["Fecha_Accion"].Visible = false; // Ya está separada en Fecha/Hora

                        // Ajustar columnas automáticamente
                        gridViewBitacora.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos de la Forma.

        //exportar grid a excel
        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportarexcel.ExportarExcel(gridBitacora, "Bitacora");
        }
        #endregion
    }
}
