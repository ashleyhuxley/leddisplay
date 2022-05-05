using LedDisplay.Graphics.Font;
using System.Collections;
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
            byte[] data = new byte[105];
            int ix = 0;

            for (int x = this.Width - 8; x >= 0; x -= 8)
            {
                for (int y = this.Height - 1; y >= 0; y--)
                {
                    bool[] bits = new bool[8];
                    for (int i = 0; i < 8; i++)
                    {
                        bits[7 - i] = buffer[x + i, y];
                    }

                    data[ix] = ConvertToByte(new BitArray(bits));
                    ix++;
                }
            }

            await this.driver.SendDataAsync(data);
        }

        private byte ConvertToByte(BitArray bits)
        {
            if (bits.Length != 8)
            {
                throw new ArgumentException("There must be 8 bits to convert to a byte", nameof(bits));
            }

            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }
    }
}
