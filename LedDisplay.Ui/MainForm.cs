using LedDisplay.Graphics.Controller;
using LedDisplay.Graphics.Font;
using LedDisplay.Mqtt;

namespace LedDisplay.Ui
{
    public partial class MainForm : Form
    {
        private Display display;

        private PixelFont font;

        private const int pixelSize = 12;

        private bool currentDrawVal = false;

        public MainForm()
        {
            InitializeComponent();

            var settings = new AppSettings();
            var driver = new MqttDriver(settings);
            this.display = new Display(driver);
            this.font = PixelFont.CreateDefault();
        }

        private void displayBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, 120 * pixelSize, 5 * pixelSize);

            var pixOn = new SolidBrush(Color.Red);
            var pixOff = new SolidBrush(Color.DarkGray);

            var gridPen = new Pen(Color.Gray);

            for (int x = 0; x < 7; x++)
            {
                e.Graphics.DrawLine(gridPen, 0, x * pixelSize, 120 * pixelSize, x * pixelSize);
            }

            for (int y = 0; y < 121; y++)
            {
                e.Graphics.DrawLine(gridPen, y * pixelSize, 0, y * pixelSize, 7 * pixelSize);
            }

            for (int i = 0; i < 120; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int x = (i * pixelSize) + 1;
                    int y = (j * pixelSize) + 1;
                    e.Graphics.FillRectangle(display[i, j] ? pixOn : pixOff, x, y, pixelSize - 2, pixelSize - 2);
                }
            }
        }

        private void displayBox_MouseDown(object sender, MouseEventArgs e)
        {
            var point = Map(e.X, e.Y);
            if (point.X >= 120 || point.Y >= 7 || point.X < 0 || point.Y < 0)
            {
                return;
            }

            display[point.X, point.Y] = !display[point.X, point.Y];
            this.currentDrawVal = display[point.X, point.Y];

            displayBox.Refresh();
        }

        private Point Map(int x, int y)
        {
            return new Point(x / pixelSize, y / pixelSize);
        }

        private void displayBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!e.Button.HasFlag(MouseButtons.Left))
            {
                return;
            }

            var point = Map(e.X, e.Y);
            if (point.X < 120 && point.Y < 7 && point.X >= 0 && point.Y >= 0)
            {
                if (display[point.X, point.Y] != currentDrawVal)
                {
                    display[point.X, point.Y] = currentDrawVal;
                }
            }

            displayBox.Refresh();
        }

        private async void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            await this.display.UpdateDisplay();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            display.Clear();
            displayBox.Refresh();
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            await display.UpdateDisplay();
        }

        private async void drawTextBox_TextChanged(object sender, EventArgs e)
        {
            display.Clear();
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

                    if (x >= display.Width)
                    {
                        return;
                    }

                    display.DrawGlyph(icon, new Point(x, 0), true);
                    x += icon.Width + 1;

                    lastIcon = icon;
                }
            }

            displayBox.Refresh();
            await display.UpdateDisplay();
        }
    }
}