namespace ODS.Forms
{
    partial class FormRegistrar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrar));
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCRegistrar = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.radioGroupFallos = new DevExpress.XtraEditors.RadioGroup();
            this.memoEditObsevacion = new DevExpress.XtraEditors.MemoEdit();
            this.memoEditDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.btnRegistrar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCRegistrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupFallos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditObsevacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = null;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ordenes de Servicio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(358, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Registrar Ordenes ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton1.AutoSize = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(119, 806);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(109, 36);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridCRegistrar;
            this.gridView1.Name = "gridView1";
            // 
            // gridCRegistrar
            // 
            this.gridCRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCRegistrar.Location = new System.Drawing.Point(0, 272);
            this.gridCRegistrar.MainView = this.gridView1;
            this.gridCRegistrar.Name = "gridCRegistrar";
            this.gridCRegistrar.Size = new System.Drawing.Size(832, 247);
            this.gridCRegistrar.TabIndex = 11;
            this.gridCRegistrar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridCRegistrar;
            this.gridView3.Name = "gridView3";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.groupControl2.Appearance.BorderColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.groupBox1);
            this.groupControl2.Controls.Add(this.materialLabel3);
            this.groupControl2.Controls.Add(this.materialLabel2);
            this.groupControl2.Controls.Add(this.materialLabel1);
            this.groupControl2.Controls.Add(this.radioGroupFallos);
            this.groupControl2.Controls.Add(this.memoEditObsevacion);
            this.groupControl2.Controls.Add(this.memoEditDescripcion);
            this.groupControl2.Controls.Add(this.lookUpEdit1);
            this.groupControl2.Controls.Add(this.btnRegistrar);
            this.groupControl2.Controls.Add(this.gridCRegistrar);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.simpleButton1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(838, 565);
            this.groupControl2.TabIndex = 12;
            this.groupControl2.Text = "groupControl2";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.labelUsuario);
            this.groupBox1.Controls.Add(this.labelFecha);
            this.groupBox1.Controls.Add(this.labelEstado);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 84);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(6, 23);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(92, 16);
            this.labelUsuario.TabIndex = 13;
            this.labelUsuario.Text = "Usuario: Victor";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(6, 39);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(167, 14);
            this.labelFecha.TabIndex = 12;
            this.labelFecha.Text = "Fecha: 26/01/2025 4:08 p.m";
            // 
            // labelEstado
            // 
            this.labelEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.Location = new System.Drawing.Point(6, 53);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(108, 14);
            this.labelEstado.TabIndex = 15;
            this.labelEstado.Text = "Estado: Pendiente";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(16, 200);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(105, 19);
            this.materialLabel3.TabIndex = 44;
            this.materialLabel3.Text = "Observaciones";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(15, 119);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(84, 19);
            this.materialLabel2.TabIndex = 43;
            this.materialLabel2.Text = "Descripción";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(657, 117);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(93, 19);
            this.materialLabel1.TabIndex = 42;
            this.materialLabel1.Text = "Tipo de Falla";
            // 
            // radioGroupFallos
            // 
            this.radioGroupFallos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroupFallos.Location = new System.Drawing.Point(622, 166);
            this.radioGroupFallos.Name = "radioGroupFallos";
            this.radioGroupFallos.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupFallos.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupFallos.Size = new System.Drawing.Size(189, 92);
            this.radioGroupFallos.TabIndex = 41;
            this.radioGroupFallos.EditValueChanged += new System.EventHandler(this.radioGroupFallos_EditValueChanged_1);
            // 
            // memoEditObsevacion
            // 
            this.memoEditObsevacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditObsevacion.Location = new System.Drawing.Point(19, 222);
            this.memoEditObsevacion.Name = "memoEditObsevacion";
            this.memoEditObsevacion.Size = new System.Drawing.Size(582, 36);
            this.memoEditObsevacion.TabIndex = 40;
            // 
            // memoEditDescripcion
            // 
            this.memoEditDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditDescripcion.Location = new System.Drawing.Point(19, 141);
            this.memoEditDescripcion.Name = "memoEditDescripcion";
            this.memoEditDescripcion.Size = new System.Drawing.Size(582, 56);
            this.memoEditDescripcion.TabIndex = 39;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEdit1.Location = new System.Drawing.Point(622, 139);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(189, 20);
            this.lookUpEdit1.TabIndex = 18;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegistrar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Appearance.Options.UseFont = true;
            this.btnRegistrar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrar.ImageOptions.Image")));
            this.btnRegistrar.Location = new System.Drawing.Point(19, 525);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(80, 27);
            this.btnRegistrar.TabIndex = 14;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // FormRegistrar
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupControl2);
            this.Name = "FormRegistrar";
            this.Size = new System.Drawing.Size(838, 565);
            this.Load += new System.EventHandler(this.FormRegistrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCRegistrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupFallos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditObsevacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridCRegistrar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelUsuario;
        private DevExpress.XtraEditors.SimpleButton btnRegistrar;
        private System.Windows.Forms.Label labelEstado;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.MemoEdit memoEditObsevacion;
        private DevExpress.XtraEditors.MemoEdit memoEditDescripcion;
        private DevExpress.XtraEditors.RadioGroup radioGroupFallos;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
