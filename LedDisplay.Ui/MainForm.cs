using LedDisplay.Graphics;
using LedDisplay.Graphics.Controller;
using LedDisplay.Graphics.Font;
using LedDisplay.Mqtt;

namespace LedDisplay.Ui
{
    public partial class MainForm : Form
    {
        private AnimationFrame frame;

        private PixelFont font;

        private Display display;

        private Animation? animation;

        private int frameIndex = 0;

        public MainForm()
        {
            InitializeComponent();

            var settings = new AppSettings();
            var driver = new MqttDriver(settings);
            display = new Display(driver);

            this.frame = new AnimationFrame();
            this.font = PixelFont.CreateDefault();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.frame.Clear();
            this.animationFrameControl.Refresh();
        }

        private async void drawTextBox_TextChanged(object sender, EventArgs e)
        {
            this.frame.Clear();

            Glyph? lastIcon = null;

            int x = 0;
            foreach (var c in drawTextBox.Text)
            {
                var icon = this.font[c.ToString()];
                if (icon != null)
                {
                    if (lastIcon != null)
                    {
                        x -= PixelFont.GetKerningOffset(lastIcon, icon);
                    }

                    if (x >= frame.Width)
                    {
                        return;
                    }

                    frame.DrawGlyph(icon, new Point(x, 0), true);
                    x += icon.Width + 1;

                    lastIcon = icon;
                }
            }

            animationFrameControl.Refresh();
            await display.DisplayFrame(this.frame);
        }

        private void loadFontButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                font = PixelFont.Load(openFileDialog.FileName);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.animationFrameControl.Frame = this.frame;
        }

        private void playAnimationButton_Click(object sender, EventArgs e)
        {
            if (openAnimationDialog.ShowDialog() == DialogResult.OK)
            {
                this.animation = Animation.Load(openAnimationDialog.FileName);
                this.animationTimer.Interval = this.animation.FrameDelay;
            }
        }

        private async void animationTimer_Tick(object sender, EventArgs e)
        {
            if (this.animation == null)
            {
                return;
            }

            await this.display.DisplayFrame(this.animation[frameIndex]);

            this.frameIndex++;
            if (this.frameIndex == this.animation.Count)
            {
                this.frameIndex = 0;
            }
        }
    }
}