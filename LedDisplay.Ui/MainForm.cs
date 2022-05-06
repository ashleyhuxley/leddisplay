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

        private const int pixelSize = 12;

        private bool currentDrawVal = false;

        public MainForm()
        {
            InitializeComponent();

            var settings = new AppSettings();
            var driver = new MqttDriver(settings);

            this.frame = new AnimationFrame();
            this.font = PixelFont.CreateDefault();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }



        private async void drawTextBox_TextChanged(object sender, EventArgs e)
        {
            //Glyph? lastIcon = null;

            //int x = 0;
            //foreach (var c in drawTextBox.Text)
            //{
            //    var icon = this.font[c.ToString()];
            //    if (icon != null)
            //    {
            //        if (lastIcon != null)
            //        {
            //            x -= PixelFont.GetKerningOffset(lastIcon, icon);
            //        }

            //        if (x >= frame.Width)
            //        {
            //            return;
            //        }

            //        frame.DrawGlyph(icon, new Point(x, 0), true);
            //        x += icon.Width + 1;

            //        lastIcon = icon;
            //    }
            //}

            //displayBox.Refresh();
            //await frame.UpdateDisplay();
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
    }
}