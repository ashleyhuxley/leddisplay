using System.Text;

namespace LedDisplay.Graphics
{
    public class AnimationFrame
    {
        private byte[] data;

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
                this.data[i] = (byte)(this.data[i] ^ p);
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

        public bool[,] GetRawData()
        {
            return FrameConverter.FromByteArray(this.data);
        }

        public override string ToString()
        {
            return Convert.ToBase64String(this.data);
        }
    }
}
