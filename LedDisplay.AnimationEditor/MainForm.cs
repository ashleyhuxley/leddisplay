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

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (FrameIndex > 0)
            {
                this.FrameIndex--;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if(this.FrameIndex == this.animation.Count - 1)
            {
                this.animation.Add(new AnimationFrame());
            }

            this.FrameIndex++;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.animationFrameControl.Frame = this.ActiveFrame;
        }
    }
}