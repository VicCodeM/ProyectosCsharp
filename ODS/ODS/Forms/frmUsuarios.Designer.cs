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
            this.txtNombreEmpleado = new DevExpress.XtraEditors.TextEdit();
            this.txtApellidoPaterno = new DevExpress.XtraEditors.TextEdit();
            this.txtApellidoMaterno = new DevExpress.XtraEditors.TextEdit();
            this.txtCorreoElectronico = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTipoUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEmpleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreEmpleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoPaterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoMaterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoElectronico.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUsuarios
            // 
            this.gridUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUsuarios.Location = new System.Drawing.Point(0, 219);
            this.gridUsuarios.MainView = this.gridView1;
            this.gridUsuarios.Name = "gridUsuarios";
            this.gridUsuarios.Size = new System.Drawing.Size(1004, 461);
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
            this.txtUsuario.Location = new System.Drawing.Point(90, 32);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(169, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 71);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(169, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // comboTipoUsuario
            // 
            this.comboTipoUsuario.Location = new System.Drawing.Point(329, 32);
            this.comboTipoUsuario.Name = "comboTipoUsuario";
            this.comboTipoUsuario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboTipoUsuario.Size = new System.Drawing.Size(100, 20);
            this.comboTipoUsuario.TabIndex = 3;
            // 
            // lookUpEmpleado
            // 
            this.lookUpEmpleado.Location = new System.Drawing.Point(329, 71);
            this.lookUpEmpleado.Name = "lookUpEmpleado";
            this.lookUpEmpleado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEmpleado.Size = new System.Drawing.Size(100, 20);
            this.lookUpEmpleado.TabIndex = 4;
            // 
            // lookUpDepartamento
            // 
            this.lookUpDepartamento.Location = new System.Drawing.Point(329, 111);
            this.lookUpDepartamento.Name = "lookUpDepartamento";
            this.lookUpDepartamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDepartamento.Size = new System.Drawing.Size(100, 20);
            this.lookUpDepartamento.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(44, 190);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(184, 190);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEiminar
            // 
            this.btnEiminar.Location = new System.Drawing.Point(329, 190);
            this.btnEiminar.Name = "btnEiminar";
            this.btnEiminar.Size = new System.Drawing.Size(75, 23);
            this.btnEiminar.TabIndex = 8;
            this.btnEiminar.Text = "Eliminar";
            this.btnEiminar.Click += new System.EventHandler(this.btnEiminar_Click);
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.Location = new System.Drawing.Point(632, 56);
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.Size = new System.Drawing.Size(100, 20);
            this.txtNombreEmpleado.TabIndex = 9;
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.Location = new System.Drawing.Point(632, 99);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoPaterno.TabIndex = 10;
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.Location = new System.Drawing.Point(632, 134);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoMaterno.TabIndex = 11;
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Location = new System.Drawing.Point(632, 177);
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(100, 20);
            this.txtCorreoElectronico.TabIndex = 12;
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCorreoElectronico);
            this.Controls.Add(this.txtApellidoMaterno);
            this.Controls.Add(this.txtApellidoPaterno);
            this.Controls.Add(this.txtNombreEmpleado);
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
            this.Size = new System.Drawing.Size(1007, 695);
           // this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboTipoUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEmpleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreEmpleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoPaterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoMaterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoElectronico.Properties)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.TextEdit txtNombreEmpleado;
        private DevExpress.XtraEditors.TextEdit txtApellidoPaterno;
        private DevExpress.XtraEditors.TextEdit txtApellidoMaterno;
        private DevExpress.XtraEditors.TextEdit txtCorreoElectronico;
    }
}
