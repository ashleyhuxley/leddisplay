using System.Collections;

namespace LedDisplay.Graphics
{
    public static class BitArrayExtensions
    {
        public static byte ToByte(this BitArray bits)
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
