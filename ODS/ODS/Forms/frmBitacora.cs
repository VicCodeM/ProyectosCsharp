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
            CargarDataGrid();
            ((GridView)gridControl1.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridControl1.MainView).BestFitColumns();
            ((GridView)gridControl1.MainView).OptionsView.ShowDetailButtons = false;
        }

        private void CargarDataGrid()
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

                // Verificar si la columna "Hora" existe en el DataTable; si no, agregarla
                if (!dataTable.Columns.Contains("Hora"))
                {
                    dataTable.Columns.Add("Hora", typeof(string)); // Agregar la columna "Hora"
                }

                // Llenar la columna "Hora" con la hora extraída de la columna "Fecha_Accion"
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["Fecha_Accion"] != DBNull.Value)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(row["Fecha_Accion"]);
                        row["Hora"] = fechaRegistro.ToString("hh:mm tt"); // Extraer solo la hora en formato de 12 horas
                    }
                    else
                    {
                        row["Hora"] = string.Empty; // Si "Fecha_Accion" es nulo, dejar la columna vacía
                    }
                }

                // Vincular los datos al GridControl
                gridControl1.DataSource = dataTable;

                // Personalizar las columnas visibles
                GridView gridBistacora = gridControl1.MainView as GridView;
                if (gridBistacora != null)
                {
                    // Mostrar el nombre del usuario
                    gridBistacora.Columns["NombreUsuario"].Visible = true;
                    gridBistacora.Columns["NombreUsuario"].Caption = "Nombre de Usuario";

                    // Configurar los títulos de las columnas existentes
                    gridBistacora.Columns["Id_Bitacora"].Caption = "Id";
                    gridBistacora.Columns["Fecha_Accion"].Caption = "Fecha de Acción";
                    gridBistacora.Columns["Id_Orden"].Caption = "Id de la Orden";
                    gridBistacora.Columns["Estado_Anterior"].Caption = "Estado Anterior";
                    gridBistacora.Columns["Estado_Nuevo"].Caption = "Estado Nuevo";
                    gridBistacora.Columns["Fecha_Atendida"].Caption = "Fecha de Atención";
                    gridBistacora.Columns["Fecha_Cerrada"].Caption = "Fecha de Cierre";
                    gridBistacora.Columns["Descripcion"].Caption = "Descripción";
                    gridBistacora.Columns["Observaciones"].Caption = "Observaciones";
                    gridBistacora.Columns["Accion"].Caption = "Acción";

                    // Formato para la columna "Fecha_Registro"
                    gridBistacora.Columns["Fecha_Accion"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    gridBistacora.Columns["Fecha_Accion"].DisplayFormat.FormatString = "dd-MM-yyyy";

                    // Formato para la nueva columna "Hora"
                    gridBistacora.Columns["Hora"].Visible = true; // Asegurarse de que la columna "Hora" esté visible
                    gridBistacora.Columns["Hora"].Caption = "Hora";
                    gridBistacora.Columns["Hora"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    gridBistacora.Columns["Hora"].DisplayFormat.FormatString = "hh:mm tt"; // Formato de 12 horas con AM/PM

                    gridBistacora.Columns["Fecha_Accion"].VisibleIndex = 1;
                    gridBistacora.Columns["Hora"].VisibleIndex = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
