namespace ODS.Forms
{
    partial class frmUsuarios
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
            this.gridUsuarios = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.comboTipoUsuario = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpEmpleado = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpDepartamento = new DevExpress.XtraEditors.LookUpEdit();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEiminar = new DevExpress.XtraEditors.SimpleButton();
            this.txtCorreoElectronico = new DevExpress.XtraEditors.TextEdit();
            this.labelUsuario = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTipoUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEmpleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoElectronico.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUsuarios
            // 
            this.gridUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUsuarios.BackgroundImage = global::ODS.Properties.Resources.textura3;
            this.gridUsuarios.Location = new System.Drawing.Point(3, 67);
            this.gridUsuarios.MainView = this.gridView1;
            this.gridUsuarios.Name = "gridUsuarios";
            this.gridUsuarios.Size = new System.Drawing.Size(885, 240);
            this.gridUsuarios.TabIndex = 0;
            this.gridUsuarios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridUsuarios;
            this.gridView1.Name = "gridView1";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUsuario.Location = new System.Drawing.Point(27, 348);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtUsuario.Properties.Appearance.Options.UseBackColor = true;
            this.txtUsuario.Size = new System.Drawing.Size(169, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPassword.Location = new System.Drawing.Point(27, 403);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword.Size = new System.Drawing.Size(169, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // comboTipoUsuario
            // 
            this.comboTipoUsuario.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboTipoUsuario.Location = new System.Drawing.Point(353, 348);
            this.comboTipoUsuario.Name = "comboTipoUsuario";
            this.comboTipoUsuario.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.comboTipoUsuario.Properties.Appearance.Options.UseBackColor = true;
            this.comboTipoUsuario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboTipoUsuario.Size = new System.Drawing.Size(192, 20);
            this.comboTipoUsuario.TabIndex = 3;
            // 
            // lookUpEmpleado
            // 
            this.lookUpEmpleado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lookUpEmpleado.Location = new System.Drawing.Point(679, 347);
            this.lookUpEmpleado.Name = "lookUpEmpleado";
            this.lookUpEmpleado.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.lookUpEmpleado.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEmpleado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEmpleado.Size = new System.Drawing.Size(192, 20);
            this.lookUpEmpleado.TabIndex = 4;
            // 
            // lookUpDepartamento
            // 
            this.lookUpDepartamento.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lookUpDepartamento.Location = new System.Drawing.Point(353, 401);
            this.lookUpDepartamento.Name = "lookUpDepartamento";
            this.lookUpDepartamento.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.lookUpDepartamento.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpDepartamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDepartamento.Size = new System.Drawing.Size(192, 20);
            this.lookUpDepartamento.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnGuardar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Appearance.Options.UseBackColor = true;
            this.btnGuardar.Appearance.Options.UseFont = true;
            this.btnGuardar.Location = new System.Drawing.Point(27, 436);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(142, 37);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnActualizar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnActualizar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Appearance.Options.UseBackColor = true;
            this.btnActualizar.Appearance.Options.UseFont = true;
            this.btnActualizar.Location = new System.Drawing.Point(384, 436);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(135, 37);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEiminar
            // 
            this.btnEiminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEiminar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnEiminar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEiminar.Appearance.Options.UseBackColor = true;
            this.btnEiminar.Appearance.Options.UseFont = true;
            this.btnEiminar.Location = new System.Drawing.Point(709, 436);
            this.btnEiminar.Name = "btnEiminar";
            this.btnEiminar.Size = new System.Drawing.Size(144, 37);
            this.btnEiminar.TabIndex = 8;
            this.btnEiminar.Text = "Eliminar";
            this.btnEiminar.Click += new System.EventHandler(this.btnEiminar_Click);
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCorreoElectronico.Location = new System.Drawing.Point(679, 403);
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtCorreoElectronico.Properties.Appearance.Options.UseBackColor = true;
            this.txtCorreoElectronico.Size = new System.Drawing.Size(192, 20);
            this.txtCorreoElectronico.TabIndex = 12;
            // 
            // labelUsuario
            // 
            this.labelUsuario.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelUsuario.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Appearance.Options.UseFont = true;
            this.labelUsuario.Location = new System.Drawing.Point(27, 327);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(45, 14);
            this.labelUsuario.TabIndex = 13;
            this.labelUsuario.Text = "Usuario";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(27, 383);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Contraseña";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(353, 327);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 14);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Permisos";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(679, 327);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(110, 14);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Nombre Completo";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(353, 383);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(89, 14);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "Departamento";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(679, 383);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(112, 14);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "Correo electronico";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(374, 20);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(171, 19);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "Administrar Usuarios";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(374, 45);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(121, 16);
            this.labelControl7.TabIndex = 20;
            this.labelControl7.Text = "Administrar Usuarios";
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::ODS.Properties.Resources.textura3;
            this.ClientSize = new System.Drawing.Size(889, 495);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.txtCorreoElectronico);
            this.Controls.Add(this.btnEiminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lookUpDepartamento);
            this.Controls.Add(this.lookUpEmpleado);
            this.Controls.Add(this.comboTipoUsuario);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.gridUsuarios);
            this.Name = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTipoUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEmpleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoElectronico.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridUsuarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.ComboBoxEdit comboTipoUsuario;
        private DevExpress.XtraEditors.LookUpEdit lookUpEmpleado;
        private DevExpress.XtraEditors.LookUpEdit lookUpDepartamento;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraEditors.SimpleButton btnEiminar;
        private DevExpress.XtraEditors.TextEdit txtCorreoElectronico;
        private DevExpress.XtraEditors.LabelControl labelUsuario;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}
