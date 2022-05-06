using LedDisplay.Graphics.Font;
using System.Drawing;

namespace LedDisplay.Graphics.Controller
{
    public class Display
    {
        private readonly ILedDisplayDriver driver;

        private bool[,] buffer = new bool[120, 7];

        public int Width { get; }

        public int Height { get; }

        public bool LiveUpdate { get; set; }

        public Display(ILedDisplayDriver driver)
        {
            this.driver = driver;

            this.Width = buffer.GetLength(0);
            this.Height = buffer.GetLength(1);

            this.LiveUpdate = false;
        }

        public bool this[int x, int y]
        {
            get => this.buffer[x, y];
            set
            {
                if (this.buffer[x, y] == value)
                {
                    return;
                }

                this.buffer[x, y] = value;
                if (LiveUpdate)
                {
                    UpdateDisplay().FireAndForget();
                }
            }
        }

        public void DrawGlyph(Glyph g, Point point, bool transparent)
        {
            if (point.X < 0 || point.Y < 0 || point.X >= this.Width || point.Y >= this.Height)
            {
                throw new ArgumentOutOfRangeException("Could not place the glyph at the specified point - Out of range");
            }

            for (int i = 0; i < g.Width; i++)
            {
                for (int j = 0; j < g.Height; j++)
                {
                    if (point.X + i < this.Width && point.Y + j < this.Height)
                    {
                        buffer[point.X + i, point.Y + j] = transparent ? buffer[point.X + i, point.Y + j] || g[i,j] : g[i, j];
                    }
                }
            }
        }

        public void Clear()
        {
            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    buffer[x, y] = false;
                }
            }
        }

        public async Task UpdateDisplay()
        {
            await this.driver.SendDataAsync(FrameConverter.ToByteArray(this.buffer));
        }
    }
}
