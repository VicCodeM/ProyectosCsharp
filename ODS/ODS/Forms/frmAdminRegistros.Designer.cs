namespace ODS.Forms
{
    partial class frmAdminRegistros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminRegistros));
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
            this.gridAdminRegistros = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridAdminRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnActualizar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnActualizar.Appearance.BorderColor = System.Drawing.Color.Lime;
            this.btnActualizar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Appearance.Options.UseBackColor = true;
            this.btnActualizar.Appearance.Options.UseBorderColor = true;
            this.btnActualizar.Appearance.Options.UseFont = true;
            this.btnActualizar.Appearance.Options.UseTextOptions = true;
            this.btnActualizar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnActualizar.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.btnActualizar.AppearanceHovered.BackColor = System.Drawing.Color.Cyan;
            this.btnActualizar.AppearanceHovered.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnActualizar.AppearanceHovered.ForeColor = System.Drawing.Color.Transparent;
            this.btnActualizar.AppearanceHovered.Options.UseBackColor = true;
            this.btnActualizar.AppearanceHovered.Options.UseBorderColor = true;
            this.btnActualizar.AppearanceHovered.Options.UseForeColor = true;
            this.btnActualizar.AppearanceHovered.Options.UseTextOptions = true;
            this.btnActualizar.AppearanceHovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnActualizar.BackgroundImage = global::ODS.Properties.Resources.textura3;
            this.btnActualizar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnActualizar1.ImageOptions.SvgImage")));
            this.btnActualizar.Location = new System.Drawing.Point(73, 7);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(158, 36);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // labelUsuario
            // 
            this.labelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(6, 22);
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
            this.labelFecha.Location = new System.Drawing.Point(6, 39);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(172, 16);
            this.labelFecha.TabIndex = 24;
            this.labelFecha.Text = "Fecha: 26/01/2025 4:08 p.m";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 32);
            this.label1.TabIndex = 21;
            this.label1.Text = "Administrar Ordenes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(416, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Editar Ordenes";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIdOrden
            // 
            this.txtIdOrden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIdOrden.Location = new System.Drawing.Point(25, 139);
            this.txtIdOrden.Name = "txtIdOrden";
            this.txtIdOrden.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtIdOrden.Properties.Appearance.Options.UseBackColor = true;
            this.txtIdOrden.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtIdOrden.Size = new System.Drawing.Size(53, 20);
            this.txtIdOrden.TabIndex = 1;
            // 
            // dateEditFechaCreacion
            // 
            this.dateEditFechaCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateEditFechaCreacion.EditValue = null;
            this.dateEditFechaCreacion.Location = new System.Drawing.Point(94, 139);
            this.dateEditFechaCreacion.Name = "dateEditFechaCreacion";
            this.dateEditFechaCreacion.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.dateEditFechaCreacion.Properties.Appearance.Options.UseBackColor = true;
            this.dateEditFechaCreacion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dateEditFechaCreacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaCreacion.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaCreacion.Size = new System.Drawing.Size(121, 20);
            this.dateEditFechaCreacion.TabIndex = 2;
            // 
            // dateEditFechaAtendida
            // 
            this.dateEditFechaAtendida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateEditFechaAtendida.EditValue = null;
            this.dateEditFechaAtendida.Location = new System.Drawing.Point(221, 139);
            this.dateEditFechaAtendida.Name = "dateEditFechaAtendida";
            this.dateEditFechaAtendida.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.dateEditFechaAtendida.Properties.Appearance.Options.UseBackColor = true;
            this.dateEditFechaAtendida.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dateEditFechaAtendida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaAtendida.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaAtendida.Size = new System.Drawing.Size(121, 20);
            this.dateEditFechaAtendida.TabIndex = 3;
            // 
            // dateEditFechaCerrada
            // 
            this.dateEditFechaCerrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateEditFechaCerrada.EditValue = null;
            this.dateEditFechaCerrada.Location = new System.Drawing.Point(348, 139);
            this.dateEditFechaCerrada.Name = "dateEditFechaCerrada";
            this.dateEditFechaCerrada.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.dateEditFechaCerrada.Properties.Appearance.Options.UseBackColor = true;
            this.dateEditFechaCerrada.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dateEditFechaCerrada.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaCerrada.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFechaCerrada.Size = new System.Drawing.Size(121, 20);
            this.dateEditFechaCerrada.TabIndex = 4;
            // 
            // lookUpEditListaUsuarios
            // 
            this.lookUpEditListaUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lookUpEditListaUsuarios.Location = new System.Drawing.Point(475, 139);
            this.lookUpEditListaUsuarios.Name = "lookUpEditListaUsuarios";
            this.lookUpEditListaUsuarios.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.lookUpEditListaUsuarios.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEditListaUsuarios.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lookUpEditListaUsuarios.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditListaUsuarios.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditListaUsuarios.TabIndex = 5;
            // 
            // lookUpEditHadware
            // 
            this.lookUpEditHadware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lookUpEditHadware.Location = new System.Drawing.Point(602, 139);
            this.lookUpEditHadware.Name = "lookUpEditHadware";
            this.lookUpEditHadware.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.lookUpEditHadware.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEditHadware.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lookUpEditHadware.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditHadware.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditHadware.TabIndex = 6;
            // 
            // lookUpEditSofware
            // 
            this.lookUpEditSofware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lookUpEditSofware.Location = new System.Drawing.Point(729, 139);
            this.lookUpEditSofware.Name = "lookUpEditSofware";
            this.lookUpEditSofware.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.lookUpEditSofware.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEditSofware.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lookUpEditSofware.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSofware.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditSofware.TabIndex = 7;
            // 
            // memoEditDescripcion
            // 
            this.memoEditDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditDescripcion.Location = new System.Drawing.Point(25, 198);
            this.memoEditDescripcion.Name = "memoEditDescripcion";
            this.memoEditDescripcion.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.memoEditDescripcion.Properties.Appearance.Options.UseBackColor = true;
            this.memoEditDescripcion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.memoEditDescripcion.Size = new System.Drawing.Size(706, 56);
            this.memoEditDescripcion.TabIndex = 8;
            // 
            // memoEditObsevacion
            // 
            this.memoEditObsevacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditObsevacion.Location = new System.Drawing.Point(25, 283);
            this.memoEditObsevacion.Name = "memoEditObsevacion";
            this.memoEditObsevacion.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.memoEditObsevacion.Properties.Appearance.Options.UseBackColor = true;
            this.memoEditObsevacion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.memoEditObsevacion.Size = new System.Drawing.Size(706, 56);
            this.memoEditObsevacion.TabIndex = 9;
            // 
            // radioGroupEstados
            // 
            this.radioGroupEstados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroupEstados.Location = new System.Drawing.Point(746, 199);
            this.radioGroupEstados.Name = "radioGroupEstados";
            this.radioGroupEstados.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.radioGroupEstados.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.radioGroupEstados.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupEstados.Properties.Appearance.Options.UseBorderColor = true;
            this.radioGroupEstados.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.radioGroupEstados.Size = new System.Drawing.Size(192, 140);
            this.radioGroupEstados.TabIndex = 39;
            // 
            // gridAdminRegistros
            // 
            this.gridAdminRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAdminRegistros.BackgroundImage = global::ODS.Properties.Resources.textura3;
            this.gridAdminRegistros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gridAdminRegistros.Location = new System.Drawing.Point(25, 354);
            this.gridAdminRegistros.MainView = this.gridView2;
            this.gridAdminRegistros.Name = "gridAdminRegistros";
            this.gridAdminRegistros.Size = new System.Drawing.Size(913, 159);
            this.gridAdminRegistros.TabIndex = 40;
            this.gridAdminRegistros.TabStop = false;
            this.gridAdminRegistros.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.gridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseTextOptions = true;
            this.gridView2.Appearance.ColumnFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.GridControl = this.gridAdminRegistros;
            this.gridView2.Name = "gridView2";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEliminar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnEliminar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Appearance.Options.UseBackColor = true;
            this.btnEliminar.Appearance.Options.UseFont = true;
            this.btnEliminar.Appearance.Options.UseTextOptions = true;
            this.btnEliminar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnEliminar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEliminar.ImageOptions.SvgImage")));
            this.btnEliminar.Location = new System.Drawing.Point(400, 7);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(149, 37);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "ID Orden";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Fecha Inicio";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(218, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "Fecha Atendida";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(345, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "Fecha Cierre";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(472, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 46;
            this.label7.Text = "Usuario";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(599, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 47;
            this.label8.Text = "Fallla Hadware";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(726, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 16);
            this.label9.TabIndex = 48;
            this.label9.Text = "Fallla Software";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 49;
            this.label10.Text = "Descripción";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 16);
            this.label11.TabIndex = 50;
            this.label11.Text = "Observaciones";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.groupBox1.Controls.Add(this.labelUsuario);
            this.groupBox1.Controls.Add(this.labelFecha);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 66);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExportar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnExportar.Appearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnExportar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnExportar.Appearance.Options.UseBackColor = true;
            this.btnExportar.Appearance.Options.UseBorderColor = true;
            this.btnExportar.Appearance.Options.UseFont = true;
            this.btnExportar.Appearance.Options.UseForeColor = true;
            this.btnExportar.Appearance.Options.UseTextOptions = true;
            this.btnExportar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnExportar.AppearanceDisabled.BorderColor = System.Drawing.Color.Red;
            this.btnExportar.AppearanceDisabled.Options.UseBorderColor = true;
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnExportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.Image")));
            this.btnExportar.Location = new System.Drawing.Point(705, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Padding = new System.Windows.Forms.Padding(10);
            this.btnExportar.Size = new System.Drawing.Size(170, 41);
            this.btnExportar.TabIndex = 12;
            this.btnExportar.Text = "Generar Reporte";
            this.btnExportar.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.btnExportar);
            this.groupControl1.Controls.Add(this.btnActualizar);
            this.groupControl1.Controls.Add(this.btnEliminar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 480);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(956, 50);
            this.groupControl1.TabIndex = 52;
            this.groupControl1.Text = "groupControl1";
            // 
            // frmAdminRegistros
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::ODS.Properties.Resources.textura3;
            this.ClientSize = new System.Drawing.Size(956, 530);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridAdminRegistros);
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "frmAdminRegistros";
            this.Load += new System.EventHandler(this.frmAdminRegistros_Load);
            this.Click += new System.EventHandler(this.frmAdminRegistros_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAdminRegistros_KeyDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridAdminRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private DevExpress.XtraGrid.GridControl gridAdminRegistros;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton btnEliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
    }
}
