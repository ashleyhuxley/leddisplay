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
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameControl)).BeginInit();
            this.SuspendLayout();
            // 
            // prevButton
            // 
            this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevButton.Image = global::LedDisplay.AnimationEditor.Properties.Resources.arrow_left;
            this.prevButton.Location = new System.Drawing.Point(12, 114);
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
            this.nextButton.Location = new System.Drawing.Point(1408, 114);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 176);
            this.Controls.Add(this.animationFrameControl);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Name = "MainForm";
            this.Text = "Animation Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button prevButton;
        private Button nextButton;
        private Controls.AnimationFrameControl animationFrameControl;
    }
}