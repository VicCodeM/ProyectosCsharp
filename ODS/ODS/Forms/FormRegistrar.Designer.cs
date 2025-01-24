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
            this.resourcesComboBoxControl1 = new DevExpress.XtraScheduler.UI.ResourcesComboBoxControl();
            this.resourcesComboBoxControl2 = new DevExpress.XtraScheduler.UI.ResourcesComboBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesComboBoxControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesComboBoxControl2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit1.Location = new System.Drawing.Point(91, 86);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(408, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // resourcesComboBoxControl1
            // 
            this.resourcesComboBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resourcesComboBoxControl1.Location = new System.Drawing.Point(206, 158);
            this.resourcesComboBoxControl1.Name = "resourcesComboBoxControl1";
            this.resourcesComboBoxControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resourcesComboBoxControl1.Size = new System.Drawing.Size(91, 20);
            this.resourcesComboBoxControl1.TabIndex = 1;
            // 
            // resourcesComboBoxControl2
            // 
            this.resourcesComboBoxControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resourcesComboBoxControl2.Location = new System.Drawing.Point(367, 158);
            this.resourcesComboBoxControl2.Name = "resourcesComboBoxControl2";
            this.resourcesComboBoxControl2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resourcesComboBoxControl2.Size = new System.Drawing.Size(91, 20);
            this.resourcesComboBoxControl2.TabIndex = 2;
            // 
            // FormRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resourcesComboBoxControl2);
            this.Controls.Add(this.resourcesComboBoxControl1);
            this.Controls.Add(this.textEdit1);
            this.Name = "FormRegistrar";
            this.Size = new System.Drawing.Size(608, 342);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesComboBoxControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesComboBoxControl2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraScheduler.UI.ResourcesComboBoxControl resourcesComboBoxControl1;
        private DevExpress.XtraScheduler.UI.ResourcesComboBoxControl resourcesComboBoxControl2;
    }
}
