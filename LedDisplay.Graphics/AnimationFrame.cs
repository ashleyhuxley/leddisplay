using LedDisplay.Graphics.Font;
using System.Drawing;

namespace LedDisplay.Graphics
{
    [Serializable]
    public class AnimationFrame
    {
        private byte[] data;

        public byte[] Data
        {
            get => this.data;
            set => this.data = value;
        }

        public AnimationFrame()
        {
            this.data = new byte[105];
            for (byte i = 0; i < 105; i++)
            {
                this.data[i] = 0;
            }
        }

        public bool this[int x, int y]
        {
            get
            {
                var (i, p) = this.GetByteIndexAndOffset(x, y);
                return (this.data[i] & p) == p;
            }
            set
            {
                var (i, p) = this.GetByteIndexAndOffset(x, y);
                this.data[i] = 
                    value 
                    ? (byte)(this.data[i] | p)
                    : (byte)(this.data[i] & (~p & 0xff));
            }
        }

        public int Width => 120;

        public int Height => 7;

        private (int, byte) GetByteIndexAndOffset(int x, int y)
        {
            int r = (119 - x) / 8;
            int i = (r * 7) + (6 - y);
            byte p = (byte)(1 << (byte)(7-(x % 8)));

            return (i, p);
        }

        public override string ToString()
        {
            return Convert.ToBase64String(this.data);
        }

        public void CopyFrom(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            for (int i = 0; i < data.Length; i++)
            {
                this.data[i] = data[i];
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
                        this[point.X + i, point.Y + j] = transparent ? this[point.X + i, point.Y + j] || g[i, j] : g[i, j];
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
                    this[x, y] = false;
                }
            }
        }
    }
}
