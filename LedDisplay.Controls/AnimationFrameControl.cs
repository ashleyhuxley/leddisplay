using LedDisplay.Graphics;
using System.Runtime.Versioning;

namespace LedDisplay.Controls
{
    [SupportedOSPlatform("windows")]
    public class AnimationFrameControl : PictureBox
    {
        private AnimationFrame? frame;

        public AnimationFrame? Frame
        {
            get => this.frame;
            set
            {
                this.frame = value;
                this.Refresh();
            }
        }

        public Brush PixelOnBrush { get; set; } = new SolidBrush(Color.Red);

        public Brush PixelOffBrush {  get; set; } = new SolidBrush(Color.White);

        public Brush BackgroundBrush { get; set; } = new SolidBrush(Color.White);

        public Pen GridPen { get; set; } = new Pen(Color.DarkGray);

        public int PixelSize
        {
            get => this.pixelSize;
            set
            {
                if (value <= 0)
                {
                    pixelSize = 1;
                }
                else if (value > 100)
                {
                    pixelSize = 100;
                }
                else
                {
                    pixelSize = value;
                }
            }
        }
        
        private bool drawingValue;

        private int pixelSize = 10;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(this.BackgroundBrush, 0, 0, 120 * this.PixelSize, 5 * this.PixelSize);

            if (this.Frame == null)
            {
                return;
            }

            var pixOn = new SolidBrush(Color.Red);
            var pixOff = new SolidBrush(Color.DarkGray);

            var gridPen = new Pen(Color.Gray);

            for (int x = 0; x < 7; x++)
            {
                e.Graphics.DrawLine(gridPen, 0, x * this.PixelSize, 120 * this.PixelSize, x * this.PixelSize);
            }

            for (int y = 0; y < 121; y++)
            {
                e.Graphics.DrawLine(gridPen, y * this.PixelSize, 0, y * this.PixelSize, 7 * this.PixelSize);
            }

            for (int i = 0; i < 120; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int x = (i * this.PixelSize) + 1;
                    int y = (j * this.PixelSize) + 1;
                    e.Graphics.FillRectangle(this.Frame[i, j] ? pixOn : pixOff, x, y, this.PixelSize - 2, this.PixelSize - 2);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.Frame == null)
            {
                return;
            }

            var point = Map(e.X, e.Y);

            if (point.X >= this.Frame.Width || point.Y >= this.Frame.Height || point.X < 0 || point.Y < 0)
            {
                return;
            }

            this.Frame[point.X, point.Y] = !this.Frame[point.X, point.Y];
            this.drawingValue = this.Frame[point.X, point.Y];

            this.Refresh();

            base.OnMouseDown(e);
        }

        private Point Map(int x, int y)
        {
            return new Point(x / this.PixelSize, y / this.PixelSize);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!e.Button.HasFlag(MouseButtons.Left) || this.Frame == null)
            {
                return;
            }

            var point = Map(e.X, e.Y);

            if (point.X < 120 && point.Y < 7 && point.X >= 0 && point.Y >= 0)
            {
                if (this.Frame[point.X, point.Y] != drawingValue)
                {
                    this.Frame[point.X, point.Y] = drawingValue;
                }
            }

            this.Refresh();

            base.OnMouseMove(e);
        }
    }
}