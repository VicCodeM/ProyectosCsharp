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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.dateTimeOffsetEdit1 = new DevExpress.XtraEditors.DateTimeOffsetEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeOffsetEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(151, 68);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(154, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // dateTimeOffsetEdit1
            // 
            this.dateTimeOffsetEdit1.EditValue = null;
            this.dateTimeOffsetEdit1.Location = new System.Drawing.Point(151, 156);
            this.dateTimeOffsetEdit1.Name = "dateTimeOffsetEdit1";
            this.dateTimeOffsetEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimeOffsetEdit1.Properties.MaskSettings.Set("mask", "dd/MM/yyyy hh:mm:ss tt zzz");
            this.dateTimeOffsetEdit1.Properties.MaskSettings.Set("useAdvancingCaret", null);
            this.dateTimeOffsetEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateTimeOffsetEdit1.TabIndex = 1;
            // 
            // FormRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimeOffsetEdit1);
            this.Controls.Add(this.textEdit1);
            this.Name = "FormRegistrar";
            this.Size = new System.Drawing.Size(476, 311);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeOffsetEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.DateTimeOffsetEdit dateTimeOffsetEdit1;
    }
}
