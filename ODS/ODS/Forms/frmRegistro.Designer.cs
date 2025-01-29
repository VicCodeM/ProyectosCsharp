namespace ODS.Forms
{
    partial class frmRegistro
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistro));
            this.labelEstado = new System.Windows.Forms.Label();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdOrden = new DevExpress.XtraEditors.TextEdit();
            this.dateEditFechaCreacion = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFechaAtendida = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFechaCerrada = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEditListaUsuarios = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditHadware = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditSofware = new DevExpress.XtraEditors.LookUpEdit();
            this.memoEditDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.memoEditObsevacion = new DevExpress.XtraEditors.MemoEdit();
            this.radioGroupEstados = new DevExpress.XtraEditors.RadioGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdOrden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaCreacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaCreacion.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaAtendida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaAtendida.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaCerrada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaCerrada.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditListaUsuarios.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditHadware.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSofware.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditObsevacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupEstados.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEstado
            // 
            this.labelEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.Location = new System.Drawing.Point(63, 115);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(110, 16);
            this.labelEstado.TabIndex = 27;
            this.labelEstado.Text = "Estado: Pendiente";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Appearance.Options.UseFont = true;
            this.btnActualizar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRegistrar.ImageOptions.SvgImage")));
            this.btnActualizar.Location = new System.Drawing.Point(163, 571);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(106, 37);
            this.btnActualizar.TabIndex = 26;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // labelUsuario
            // 
            this.labelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(63, 158);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(92, 16);
            this.labelUsuario.TabIndex = 25;
            this.labelUsuario.Text = "Usuario: Victor";
            // 
            // labelFecha
            // 
            this.labelFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(63, 184);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(172, 16);
            this.labelFecha.TabIndex = 24;
            this.labelFecha.Text = "Fecha: 26/01/2025 4:08 p.m";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 32);
            this.label1.TabIndex = 21;
            this.label1.Text = "Registro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(384, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Agregar ordenes";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIdOrden
            // 
            this.txtIdOrden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdOrden.Location = new System.Drawing.Point(735, 77);
            this.txtIdOrden.Name = "txtIdOrden";
            this.txtIdOrden.Size = new System.Drawing.Size(53, 20);
            this.txtIdOrden.TabIndex = 30;
            // 
            // dateEditFechaCreacion
            // 
            this.dateEditFechaCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEditFechaCreacion.EditValue = null;
            this.dateEditFechaCreacion.Location = new System.Drawing.Point(735, 111);
            this.dateEditFechaCreacion.Name = "dateEditFechaCreacion";
            this.dateEditFechaCreacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaCreacion.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaCreacion.Size = new System.Drawing.Size(100, 20);
            this.dateEditFechaCreacion.TabIndex = 31;
            // 
            // dateEditFechaAtendida
            // 
            this.dateEditFechaAtendida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEditFechaAtendida.EditValue = null;
            this.dateEditFechaAtendida.Location = new System.Drawing.Point(735, 154);
            this.dateEditFechaAtendida.Name = "dateEditFechaAtendida";
            this.dateEditFechaAtendida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaAtendida.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaAtendida.Size = new System.Drawing.Size(100, 20);
            this.dateEditFechaAtendida.TabIndex = 32;
            // 
            // dateEditFechaCerrada
            // 
            this.dateEditFechaCerrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEditFechaCerrada.EditValue = null;
            this.dateEditFechaCerrada.Location = new System.Drawing.Point(735, 193);
            this.dateEditFechaCerrada.Name = "dateEditFechaCerrada";
            this.dateEditFechaCerrada.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaCerrada.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaCerrada.Size = new System.Drawing.Size(100, 20);
            this.dateEditFechaCerrada.TabIndex = 33;
            // 
            // lookUpEditListaUsuarios
            // 
            this.lookUpEditListaUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditListaUsuarios.Location = new System.Drawing.Point(735, 233);
            this.lookUpEditListaUsuarios.Name = "lookUpEditListaUsuarios";
            this.lookUpEditListaUsuarios.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditListaUsuarios.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditListaUsuarios.TabIndex = 34;
            // 
            // lookUpEditHadware
            // 
            this.lookUpEditHadware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditHadware.Location = new System.Drawing.Point(735, 271);
            this.lookUpEditHadware.Name = "lookUpEditHadware";
            this.lookUpEditHadware.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditHadware.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditHadware.TabIndex = 35;
            // 
            // lookUpEditSofware
            // 
            this.lookUpEditSofware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditSofware.Location = new System.Drawing.Point(735, 309);
            this.lookUpEditSofware.Name = "lookUpEditSofware";
            this.lookUpEditSofware.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSofware.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditSofware.TabIndex = 36;
            // 
            // memoEditDescripcion
            // 
            this.memoEditDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditDescripcion.Location = new System.Drawing.Point(25, 235);
            this.memoEditDescripcion.Name = "memoEditDescripcion";
            this.memoEditDescripcion.Size = new System.Drawing.Size(490, 56);
            this.memoEditDescripcion.TabIndex = 37;
            // 
            // memoEditObsevacion
            // 
            this.memoEditObsevacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditObsevacion.Location = new System.Drawing.Point(25, 298);
            this.memoEditObsevacion.Name = "memoEditObsevacion";
            this.memoEditObsevacion.Size = new System.Drawing.Size(490, 56);
            this.memoEditObsevacion.TabIndex = 38;
            // 
            // radioGroupEstados
            // 
            this.radioGroupEstados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroupEstados.Location = new System.Drawing.Point(547, 236);
            this.radioGroupEstados.Name = "radioGroupEstados";
            this.radioGroupEstados.Size = new System.Drawing.Size(138, 107);
            this.radioGroupEstados.TabIndex = 39;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(25, 365);
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(870, 200);
            this.gridControl1.TabIndex = 40;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // frmRegistro
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.radioGroupEstados);
            this.Controls.Add(this.memoEditObsevacion);
            this.Controls.Add(this.memoEditDescripcion);
            this.Controls.Add(this.lookUpEditSofware);
            this.Controls.Add(this.lookUpEditHadware);
            this.Controls.Add(this.lookUpEditListaUsuarios);
            this.Controls.Add(this.dateEditFechaCerrada);
            this.Controls.Add(this.dateEditFechaAtendida);
            this.Controls.Add(this.dateEditFechaCreacion);
            this.Controls.Add(this.txtIdOrden);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "frmRegistro";
            this.Size = new System.Drawing.Size(898, 620);
            ((System.ComponentModel.ISupportInitialize)(this.txtIdOrden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaCreacion.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaCreacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaAtendida.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaAtendida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaCerrada.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFechaCerrada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditListaUsuarios.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditHadware.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSofware.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditObsevacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupEstados.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelEstado;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtIdOrden;
        private DevExpress.XtraEditors.DateEdit dateEditFechaCreacion;
        private DevExpress.XtraEditors.DateEdit dateEditFechaAtendida;
        private DevExpress.XtraEditors.DateEdit dateEditFechaCerrada;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditListaUsuarios;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditHadware;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSofware;
        private DevExpress.XtraEditors.MemoEdit memoEditDescripcion;
        private DevExpress.XtraEditors.MemoEdit memoEditObsevacion;
        private DevExpress.XtraEditors.RadioGroup radioGroupEstados;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}
