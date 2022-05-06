using System.Collections;

namespace LedDisplay.Graphics
{
    public static class FrameConverter
    {
        public static byte[] ToByteArray(bool[,] data)
        {
            if (data.GetLength(0) != 120 || data.GetLength(1) != 7)
            {
                throw new ArgumentException("Incorrect data size. Expected 120 x 7 array.");
            }

            byte[] result = new byte[105];
            int ix = 0;

            for (int x = 120 - 8; x >= 0; x -= 8)
            {
                for (int y = 7 - 1; y >= 0; y--)
                {
                    bool[] bits = new bool[8];
                    for (int i = 0; i < 8; i++)
                    {
                        bits[7 - i] = data[x + i, y];
                    }

                    result[ix] = new BitArray(bits).ToByte();
                    ix++;
                }
            }

            return result;
        }

        public static bool[,] FromByteArray(byte[] data)
        {
            if (data.Length != 105)
            {
                throw new ArgumentException("Incorrect data length. Expected 105 bytes.");
            }

            var result = new bool[120, 7];

            int x = 120 - 8;
            int y = 7;

            for (int i = 0; i < data.Length; i++)
            {
                var bits = new BitArray(new byte[] { data[i] });

                for (int j = 0; j < 7; j++)
                {
                    result[x + j, y] = bits[j];
                }

                x -= 8;
                if (x < 0)
                {
                    y--;
                }
            }

            return result;
        }
    }
}
