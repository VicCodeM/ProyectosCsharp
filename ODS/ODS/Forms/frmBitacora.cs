using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ODS.Datos;
using ODS.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmBitacora : DevExpress.XtraEditors.XtraUserControl
    {
        public frmBitacora()
        {
            InitializeComponent();
            LoadDataToGrid();
            ((GridView)gridControl1.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridControl1.MainView).BestFitColumns();
            ((GridView)gridControl1.MainView).OptionsView.ShowDetailButtons = false;
        }

        private void LoadDataToGrid()
        {
            try
            {
                // Crear instancias de las clases
                BitacoraService queries = new BitacoraService();
                ConexionDB queryExecutor = new ConexionDB();

                // Obtener la consulta SQL
                string query = queries.DatosBitacora();

                // Ejecutar la consulta y obtener los datos
                DataTable dataTable = queryExecutor.ExecuteQuery(query);


                // Vincular los datos al GridControl
                gridControl1.DataSource = dataTable;

                // Personalizar las columnas visibles
                GridView gridView = gridControl1.MainView as GridView;
                if (gridView != null)
                {
                    gridView.Columns["NombreUsuario"].Visible = true; // Mostrar el nombre del usuario
                    gridView.Columns["NombreUsuario"].Caption = "Nombre de Usuario";
                    gridView.Columns["Id_Bitacora"].Caption = "Id";
                    gridView.Columns["Fecha_Accion"].Caption = "Fecha de Acción";
                    gridView.Columns["Id_Orden"].Caption = "Id de la Orden";
                    gridView.Columns["Estado_Anterior"].Caption = "Estado Anterior";
                    gridView.Columns["Estado_Nuevo"].Caption = "Estado Nuevo";
                    gridView.Columns["Fecha_Atendida"].Caption = "Fecha de Atención";
                    gridView.Columns["Fecha_Cerrada"].Caption = "Fecha de Cierre";
                    gridView.Columns["Descripcion"].Caption = "Descripción";
                    gridView.Columns["Observaciones"].Caption = "Observaciones";
                    gridView.Columns["Accion"].Caption = "Acción";

                    // gridView.Columns["Id_Usuario"].Visible = false; // Ocultar Id_Usuario si existe
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
