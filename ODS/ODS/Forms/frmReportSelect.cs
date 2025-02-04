using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ODS.Forms
{
    public partial class frmReportSelect : XtraForm
    {
        public List<string> ColumnasSeleccionadas { get; private set; } = new List<string>();
        private DataTable datos;

        public frmReportSelect(DataTable datos)
        {
            InitializeComponent();
            this.datos = datos;
            ConfigurarCheckedListBox();
            ConfigurarGridControl();
        }

        private void ConfigurarCheckedListBox()
        {
            checkedListBoxControl1.Items.Clear();
            foreach (DataColumn columna in datos.Columns)
            {
                checkedListBoxControl1.Items.Add(columna.ColumnName, true);
            }
        }

        private void ConfigurarGridControl()
        {
            gridControl1.DataSource = datos;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ColumnasSeleccionadas = checkedListBoxControl1.CheckedItems.Cast<string>().ToList();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XlsxExportOptionsEx opciones = new XlsxExportOptionsEx
                {
                    ExportType = ExportType.WYSIWYG
                };
                gridControl1.ExportToXlsx(saveFileDialog1.FileName, opciones);
                XtraMessageBox.Show("Reporte exportado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
