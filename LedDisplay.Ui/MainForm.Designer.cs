namespace LedDisplay.Ui
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
            this.components = new System.ComponentModel.Container();
            this.clearButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drawTextBox = new System.Windows.Forms.TextBox();
            this.loadFontButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.animationFrameControl = new LedDisplay.Controls.AnimationFrameControl();
            this.playAnimationButton = new System.Windows.Forms.Button();
            this.openAnimationDialog = new System.Windows.Forms.OpenFileDialog();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameControl)).BeginInit();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 115);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(110, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(12, 144);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(110, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drawTextBox);
            this.groupBox1.Location = new System.Drawing.Point(139, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 52);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw Text";
            // 
            // drawTextBox
            // 
            this.drawTextBox.Location = new System.Drawing.Point(6, 22);
            this.drawTextBox.Name = "drawTextBox";
            this.drawTextBox.Size = new System.Drawing.Size(354, 23);
            this.drawTextBox.TabIndex = 0;
            this.drawTextBox.TextChanged += new System.EventHandler(this.drawTextBox_TextChanged);
            // 
            // loadFontButton
            // 
            this.loadFontButton.Location = new System.Drawing.Point(12, 173);
            this.loadFontButton.Name = "loadFontButton";
            this.loadFontButton.Size = new System.Drawing.Size(110, 23);
            this.loadFontButton.TabIndex = 4;
            this.loadFontButton.Text = "Load Font...";
            this.loadFontButton.UseVisualStyleBackColor = true;
            this.loadFontButton.Click += new System.EventHandler(this.loadFontButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Pixel Fonts (*.pix)|*.pix|All Files (*.*)|*.*";
            this.openFileDialog.Title = "Open Pixel Font";
            // 
            // animationFrameControl
            // 
            this.animationFrameControl.Frame = null;
            this.animationFrameControl.Location = new System.Drawing.Point(12, 12);
            this.animationFrameControl.Name = "animationFrameControl";
            this.animationFrameControl.PixelSize = 12;
            this.animationFrameControl.Size = new System.Drawing.Size(1455, 97);
            this.animationFrameControl.TabIndex = 5;
            this.animationFrameControl.TabStop = false;
            // 
            // playAnimationButton
            // 
            this.playAnimationButton.Location = new System.Drawing.Point(548, 115);
            this.playAnimationButton.Name = "playAnimationButton";
            this.playAnimationButton.Size = new System.Drawing.Size(110, 23);
            this.playAnimationButton.TabIndex = 6;
            this.playAnimationButton.Text = "Play Animation";
            this.playAnimationButton.UseVisualStyleBackColor = true;
            this.playAnimationButton.Click += new System.EventHandler(this.playAnimationButton_Click);
            // 
            // openAnimationDialog
            // 
            this.openAnimationDialog.Filter = "Animations (*.ani)|*.ani|All Files (*.*)|*.*";
            this.openAnimationDialog.Title = "Open Animation";
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 214);
            this.Controls.Add(this.playAnimationButton);
            this.Controls.Add(this.animationFrameControl);
            this.Controls.Add(this.loadFontButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.clearButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED Display Controller";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationFrameControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button clearButton;
        private Button updateButton;
        private GroupBox groupBox1;
        private TextBox drawTextBox;
        private Button loadFontButton;
        private OpenFileDialog openFileDialog;
        private Controls.AnimationFrameControl animationFrameControl;
        private Button playAnimationButton;
        private OpenFileDialog openAnimationDialog;
        private System.Windows.Forms.Timer animationTimer;
    }
}