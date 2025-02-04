using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace ODS.Forms
{
    partial class frmReportSelect
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnExportarExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportarExcel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();

            // checkedListBoxControl1
            this.checkedListBoxControl1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxControl1.Size = new System.Drawing.Size(260, 150);
            this.checkedListBoxControl1.CheckOnClick = true;

            // btnAceptar
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Location = new System.Drawing.Point(45, 180);
            this.btnAceptar.Size = new System.Drawing.Size(80, 30);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            // btnCancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(150, 180);
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // btnExportarExcel
            this.btnExportarExcel.Text = "Exportar a Excel";
            this.btnExportarExcel.Location = new System.Drawing.Point(90, 220);
            this.btnExportarExcel.Size = new System.Drawing.Size(120, 30);
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);

            // gridControl1
            this.gridControl1.Location = new System.Drawing.Point(12, 260);
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.MainView = this.gridView1;

            // gridView1
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.BestFitColumns();

            // Formulario
            this.ClientSize = new System.Drawing.Size(430, 480);
            this.Controls.Add(this.checkedListBoxControl1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.gridControl1);
            this.Text = "Seleccionar Columnas";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}


