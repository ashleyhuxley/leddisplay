namespace LedDisplay.FontEditor
{
    partial class AddGlyphForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.propertiesGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.heightInput = new System.Windows.Forms.NumericUpDown();
            this.widthInput = new System.Windows.Forms.NumericUpDown();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.propertiesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthInput)).BeginInit();
            this.SuspendLayout();
            // 
            // propertiesGroup
            // 
            this.propertiesGroup.Controls.Add(this.label3);
            this.propertiesGroup.Controls.Add(this.label2);
            this.propertiesGroup.Controls.Add(this.heightInput);
            this.propertiesGroup.Controls.Add(this.widthInput);
            this.propertiesGroup.Controls.Add(this.idTextBox);
            this.propertiesGroup.Controls.Add(this.label1);
            this.propertiesGroup.Location = new System.Drawing.Point(12, 12);
            this.propertiesGroup.Name = "propertiesGroup";
            this.propertiesGroup.Size = new System.Drawing.Size(273, 134);
            this.propertiesGroup.TabIndex = 0;
            this.propertiesGroup.TabStop = false;
            this.propertiesGroup.Text = "Glyph Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Height:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Width:";
            // 
            // heightInput
            // 
            this.heightInput.Location = new System.Drawing.Point(114, 92);
            this.heightInput.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.heightInput.Name = "heightInput";
            this.heightInput.Size = new System.Drawing.Size(93, 23);
            this.heightInput.TabIndex = 3;
            this.heightInput.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // widthInput
            // 
            this.widthInput.Location = new System.Drawing.Point(114, 63);
            this.widthInput.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.widthInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthInput.Name = "widthInput";
            this.widthInput.Size = new System.Drawing.Size(93, 23);
            this.widthInput.TabIndex = 2;
            this.widthInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(114, 34);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(93, 23);
            this.idTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID (Character):";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Image = global::LedDisplay.FontEditor.Properties.Resources.tick;
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(198, 166);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(89, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Image = global::LedDisplay.FontEditor.Properties.Resources.cancel;
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(103, 166);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(89, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AddGlyphForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(297, 201);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.propertiesGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddGlyphForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Glyph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddGlyphForm_FormClosing);
            this.propertiesGroup.ResumeLayout(false);
            this.propertiesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox propertiesGroup;
        private NumericUpDown heightInput;
        private NumericUpDown widthInput;
        private TextBox idTextBox;
        private Label label1;
        private Button okButton;
        private Button cancelButton;
        private Label label3;
        private Label label2;
    }
}