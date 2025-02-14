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
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCRegistrar = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelInferior = new DevExpress.XtraEditors.GroupControl();
            this.btnNuevaOrden = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.radioGroupFallos = new DevExpress.XtraEditors.RadioGroup();
            this.memoEditObsevacion = new DevExpress.XtraEditors.MemoEdit();
            this.memoEditDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.lookUpFallos = new DevExpress.XtraEditors.LookUpEdit();
            this.btnRegistrar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCRegistrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInferior)).BeginInit();
            this.panelInferior.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupFallos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditObsevacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpFallos.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = null;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(404, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Registrar Órdenes ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton1.AutoSize = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(119, 813);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(109, 36);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.Blue;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
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
            this.gridCRegistrar.Size = new System.Drawing.Size(901, 217);
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
            // panelInferior
            // 
            this.panelInferior.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelInferior.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.panelInferior.Appearance.Options.UseBackColor = true;
            this.panelInferior.Appearance.Options.UseBorderColor = true;
            this.panelInferior.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("panelInferior.CaptionImageOptions.Image")));
            this.panelInferior.CaptionLocation = DevExpress.Utils.Locations.Bottom;
            this.panelInferior.ContentImage = global::ODS.Properties.Resources.textura3;
            this.panelInferior.Controls.Add(this.btnNuevaOrden);
            this.panelInferior.Controls.Add(this.btnExportar);
            this.panelInferior.Controls.Add(this.label11);
            this.panelInferior.Controls.Add(this.label10);
            this.panelInferior.Controls.Add(this.labelEstado);
            this.panelInferior.Controls.Add(this.label3);
            this.panelInferior.Controls.Add(this.groupBox1);
            this.panelInferior.Controls.Add(this.radioGroupFallos);
            this.panelInferior.Controls.Add(this.memoEditObsevacion);
            this.panelInferior.Controls.Add(this.memoEditDescripcion);
            this.panelInferior.Controls.Add(this.lookUpFallos);
            this.panelInferior.Controls.Add(this.btnRegistrar);
            this.panelInferior.Controls.Add(this.gridCRegistrar);
            this.panelInferior.Controls.Add(this.label2);
            this.panelInferior.Controls.Add(this.simpleButton1);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInferior.Location = new System.Drawing.Point(0, 0);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(907, 562);
            this.panelInferior.TabIndex = 12;
            // 
            // btnNuevaOrden
            // 
            this.btnNuevaOrden.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNuevaOrden.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnNuevaOrden.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaOrden.Appearance.Options.UseBackColor = true;
            this.btnNuevaOrden.Appearance.Options.UseFont = true;
            this.btnNuevaOrden.Appearance.Options.UseTextOptions = true;
            this.btnNuevaOrden.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnNuevaOrden.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaOrden.ImageOptions.Image")));
            this.btnNuevaOrden.Location = new System.Drawing.Point(28, 495);
            this.btnNuevaOrden.Name = "btnNuevaOrden";
            this.btnNuevaOrden.Size = new System.Drawing.Size(154, 40);
            this.btnNuevaOrden.TabIndex = 54;
            this.btnNuevaOrden.Text = "Agregar Órden";
            this.btnNuevaOrden.Click += new System.EventHandler(this.btnNuevaOrden_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExportar.Appearance.BackColor = System.Drawing.Color.Chocolate;
            this.btnExportar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Appearance.Options.UseBackColor = true;
            this.btnExportar.Appearance.Options.UseFont = true;
            this.btnExportar.Appearance.Options.UseTextOptions = true;
            this.btnExportar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnExportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.Image")));
            this.btnExportar.Location = new System.Drawing.Point(706, 495);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(150, 40);
            this.btnExportar.TabIndex = 53;
            this.btnExportar.Text = "Generar Reporte";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 16);
            this.label11.TabIndex = 52;
            this.label11.Text = "Observaciones";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 51;
            this.label10.Text = "Descripción";
            // 
            // labelEstado
            // 
            this.labelEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEstado.AutoSize = true;
            this.labelEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.labelEstado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.Location = new System.Drawing.Point(688, 118);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(125, 16);
            this.labelEstado.TabIndex = 15;
            this.labelEstado.Text = "Estado: Pendiente";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(306, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(348, 32);
            this.label3.TabIndex = 48;
            this.label3.Text = "Agregar Órden de Servicio ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.groupBox1.Controls.Add(this.labelUsuario);
            this.groupBox1.Controls.Add(this.labelFecha);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 64);
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
            // radioGroupFallos
            // 
            this.radioGroupFallos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroupFallos.Location = new System.Drawing.Point(660, 166);
            this.radioGroupFallos.Name = "radioGroupFallos";
            this.radioGroupFallos.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.radioGroupFallos.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupFallos.Size = new System.Drawing.Size(235, 92);
            this.radioGroupFallos.TabIndex = 41;
            this.radioGroupFallos.EditValueChanged += new System.EventHandler(this.radioGroupFallos_EditValueChanged_1);
            // 
            // memoEditObsevacion
            // 
            this.memoEditObsevacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditObsevacion.Location = new System.Drawing.Point(19, 222);
            this.memoEditObsevacion.Name = "memoEditObsevacion";
            this.memoEditObsevacion.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.memoEditObsevacion.Properties.Appearance.Options.UseBackColor = true;
            this.memoEditObsevacion.Size = new System.Drawing.Size(623, 36);
            this.memoEditObsevacion.TabIndex = 40;
            // 
            // memoEditDescripcion
            // 
            this.memoEditDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditDescripcion.Location = new System.Drawing.Point(19, 141);
            this.memoEditDescripcion.Name = "memoEditDescripcion";
            this.memoEditDescripcion.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.memoEditDescripcion.Properties.Appearance.Options.UseBackColor = true;
            this.memoEditDescripcion.Size = new System.Drawing.Size(623, 56);
            this.memoEditDescripcion.TabIndex = 39;
            this.memoEditDescripcion.EditValueChanged += new System.EventHandler(this.memoEditDescripcion_EditValueChanged);
            this.memoEditDescripcion.Click += new System.EventHandler(this.memoEditDescripcion_Click);
            this.memoEditDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.memoEditDescripcion_KeyDown);
            // 
            // lookUpFallos
            // 
            this.lookUpFallos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpFallos.Location = new System.Drawing.Point(660, 139);
            this.lookUpFallos.Name = "lookUpFallos";
            this.lookUpFallos.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.lookUpFallos.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpFallos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpFallos.Size = new System.Drawing.Size(235, 20);
            this.lookUpFallos.TabIndex = 18;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRegistrar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnRegistrar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Appearance.Options.UseBackColor = true;
            this.btnRegistrar.Appearance.Options.UseFont = true;
            this.btnRegistrar.Appearance.Options.UseTextOptions = true;
            this.btnRegistrar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnRegistrar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrar.ImageOptions.Image")));
            this.btnRegistrar.Location = new System.Drawing.Point(399, 495);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(155, 40);
            this.btnRegistrar.TabIndex = 14;
            this.btnRegistrar.Text = "Registrar Órden";
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
            this.ClientSize = new System.Drawing.Size(907, 562);
            this.Controls.Add(this.panelInferior);
            this.Name = "FormRegistrar";
            this.Load += new System.EventHandler(this.FormRegistrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCRegistrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInferior)).EndInit();
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupFallos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditObsevacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpFallos.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridCRegistrar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.GroupControl panelInferior;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelUsuario;
        private DevExpress.XtraEditors.SimpleButton btnRegistrar;
        private System.Windows.Forms.Label labelEstado;
        private DevExpress.XtraEditors.LookUpEdit lookUpFallos;
        private DevExpress.XtraEditors.MemoEdit memoEditObsevacion;
        private DevExpress.XtraEditors.MemoEdit memoEditDescripcion;
        private DevExpress.XtraEditors.RadioGroup radioGroupFallos;
       // private MaterialSkin.Controls.MaterialLabel materialLabel1;
       // private MaterialSkin.Controls.MaterialLabel materialLabel3;
      //  private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraEditors.SimpleButton btnNuevaOrden;
    }
}
