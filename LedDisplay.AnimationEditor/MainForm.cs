using LedDisplay.Graphics;

namespace LedDisplay.AnimationEditor
{
    public partial class MainForm : Form
    {
        private Animation animation;

        private int frameIndex = 0;

        private int FrameIndex
        {
            get => this.frameIndex;
            set
            {
                this.frameIndex = value;
                this.animationFrameControl.Frame = this.ActiveFrame;
            }
        }

        private AnimationFrame ActiveFrame => this.animation[this.FrameIndex];

        public MainForm()
        {
            InitializeComponent();

            this.animation = new Animation();
            animation.Add(new AnimationFrame());
        }

        private void UpdateTitle()
        {
            this.Text = $"Animation Editor - [{this.FrameIndex + 1} of {this.animation.Count}]";
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (FrameIndex > 0)
            {
                this.FrameIndex--;
            }

            UpdateTitle();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if(this.FrameIndex == this.animation.Count - 1)
            {
                var frame = new AnimationFrame();
                if (copyFrameControl.Checked)
                {
                    frame.CopyFrom(this.ActiveFrame.Data);
                }

                this.animation.Add(frame);
            }

            this.FrameIndex++;
            UpdateTitle();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.animationFrameControl.Frame = this.ActiveFrame;
            UpdateTitle();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.animation = Animation.Load(openFileDialog.FileName);
            }

            this.frameIndex = 0;
            this.animationFrameControl.Frame = this.ActiveFrame;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.animation.Save(saveFileDialog.FileName);
            }
        }
    }
}