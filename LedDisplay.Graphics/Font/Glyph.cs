using System.Collections;

namespace LedDisplay.Graphics.Font
{
    [Serializable]
    public class Glyph
    {
        private bool[,] data;

        public bool[,] Data
        {
            get => this.data;
            set => this.data = value;
        }

        public int Width => data.GetLength(0);

        public int Height => data.GetLength(1);

        public bool this[int x, int y]
        {
            get => this.data[x, y];
            set => this.data[x, y] = value;
        }

        public string Id { get; set; }

        private Glyph() { this.data = new bool[0, 0]; this.Id = String.Empty; }

        public static Glyph Create(byte[] sourceData, string id)
        {
            var result = new Glyph
            {
                Id = id,
                data = new bool[sourceData.Length, 7]
            };

            for (int j = 0; j < sourceData.Length; j++)
            {
                var bits = new BitArray(new byte[] { sourceData[j] });

                for (int i = 0; i < 7; i++)
                {
                    result.data[j, i] = bits[6 - i];
                }
            }

            return result;
        }

        public static Glyph Create(bool[,] sourceData, string id)
        {
            var result = new Glyph
            {
                Id = id,
                data = sourceData
            };

            return result;
        }

        public void ReplaceData(bool[,] buffer)
        {
            this.data = buffer;
        }
    }
}
