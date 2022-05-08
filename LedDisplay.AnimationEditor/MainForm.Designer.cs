namespace LedDisplay.AnimationEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.animationFrameControl = new LedDisplay.Controls.AnimationFrameControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.copyFrameControl = new System.Windows.Forms.CheckBox();
            this.frameDelayInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDelayInput)).BeginInit();
            this.SuspendLayout();
            // 
            // prevButton
            // 
            this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevButton.Image = global::LedDisplay.AnimationEditor.Properties.Resources.arrow_left;
            this.prevButton.Location = new System.Drawing.Point(12, 117);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(50, 50);
            this.prevButton.TabIndex = 1;
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Image = global::LedDisplay.AnimationEditor.Properties.Resources.arrow_right;
            this.nextButton.Location = new System.Drawing.Point(1408, 117);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(50, 50);
            this.nextButton.TabIndex = 2;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // animationFrameControl
            // 
            this.animationFrameControl.Frame = null;
            this.animationFrameControl.Location = new System.Drawing.Point(12, 12);
            this.animationFrameControl.Name = "animationFrameControl";
            this.animationFrameControl.PixelSize = 12;
            this.animationFrameControl.Size = new System.Drawing.Size(1446, 86);
            this.animationFrameControl.TabIndex = 3;
            this.animationFrameControl.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Animations (*.ani)|*.ani|All Files (*.*)|*.*";
            this.openFileDialog.Title = "Load Animation";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Animations (*.ani)|*.ani|All Files (*.*)|*.*";
            this.saveFileDialog.Title = "Save Animation";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(108, 114);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(132, 23);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load Animation";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(108, 143);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(132, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save Animation";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // copyFrameControl
            // 
            this.copyFrameControl.AutoSize = true;
            this.copyFrameControl.Location = new System.Drawing.Point(288, 117);
            this.copyFrameControl.Name = "copyFrameControl";
            this.copyFrameControl.Size = new System.Drawing.Size(172, 19);
            this.copyFrameControl.TabIndex = 6;
            this.copyFrameControl.Text = "Copy last frame on creation";
            this.copyFrameControl.UseVisualStyleBackColor = true;
            // 
            // frameDelayInput
            // 
            this.frameDelayInput.Location = new System.Drawing.Point(288, 143);
            this.frameDelayInput.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.frameDelayInput.Name = "frameDelayInput";
            this.frameDelayInput.Size = new System.Drawing.Size(172, 23);
            this.frameDelayInput.TabIndex = 7;
            this.frameDelayInput.ValueChanged += new System.EventHandler(this.frameDelayInput_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 179);
            this.Controls.Add(this.frameDelayInput);
            this.Controls.Add(this.copyFrameControl);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.animationFrameControl);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Name = "MainForm";
            this.Text = "Animation Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDelayInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button prevButton;
        private Button nextButton;
        private Controls.AnimationFrameControl animationFrameControl;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private Button loadButton;
        private Button saveButton;
        private CheckBox copyFrameControl;
        private NumericUpDown frameDelayInput;
    }
}