using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace LedDisplay.Graphics.Font
{
    [Serializable]
    public class PixelFont : IEnumerable<Glyph>
    {
        private List<Glyph> glyphs;

        public PixelFont()
        {
            glyphs = new List<Glyph>();
        }

        public Glyph? this[string ix]
        {
            get
            {
                return glyphs.FirstOrDefault(i => i.Id == ix);
            }
        }

        public bool ContainsKey(string key)
        {
            return this.glyphs.Any(g => g.Id == key);
        }

        public static int GetKerningOffset(Glyph g1, Glyph g2)
        {
            if (g1.Id == " " || g2.Id == " ")
            {
                return 0;
            }

            int[] max = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            int result = g2.Width;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < g1.Width; j++)
                {
                    if (g1[j, i])
                    {
                        max[i] = Math.Max(j, max[i]);
                        if (i < 6) max[i + 1] = j;
                        if (i > 0) max[i - 1] = Math.Max(j, max[i - 1]);
                    }
                }
            }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < g2.Width; j++)
                {
                    if (g2[j, i])
                    {
                        var kern = j + g1.Width - (max[i] + 1);
                        result = Math.Min(result, kern);
                        break;
                    }
                }
            }

            return result;
        }

        public void Save(string filename)
        {
            using (var stream = File.Create(filename))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Close();
            }
        }

        public static PixelFont Load(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                var formatter = new BinaryFormatter();
                var result = (PixelFont)formatter.Deserialize(stream);
                stream.Close();

                return result;
            }
        }

        public static PixelFont CreateDefault()
        {
            var font = new PixelFont();

            byte[][] bytes = new byte[][] {
                 new byte[] { 0,0 },                          // space       ASCII 32
                 new byte[] { 253 },                               // !           ASCII 33
                 new byte[] { 96,0,96 },                           // "           ASCII 34
                 new byte[] { 20,127,20,127,20},                   // #           ASCII 35
                 new byte[] { 36,42,127,42,18},                    // $           ASCII 36
                 new byte[] { 17,2,4,8,17},                        // %           ASCII 37
                 new byte[] { 54,73,85,34,5},                      // &           ASCII 38
                 new byte[] { 104,112 },                           // '           ASCII 39
                 new byte[] { 28,34,65 },                          // (           ASCII 40
                 new byte[] { 65,34,28 },                          // )           ASCII 41
                 new byte[] { 20,8,62,8,20},                       // *           ASCII 42
                 new byte[] { 8,8,62,8,8},                         // +           ASCII 43
                 new byte[] {  5,6 },                              // ,           ASCII 44
                 new byte[] { 8,8,8,8,8},                          // -           ASCII 45
                 new byte[] { 1 },                                 // .           ASCII 46
                 new byte[] { 1,2,4,8,16},                         // /           ASCII 47
                 new byte[] { 62,69,73,81,62},                     // 0           ASCII 48
                 new byte[] { 0,33,127,1,0},                       // 1           ASCII 49
                 new byte[] { 33,67,69,73,49},                     // 2           ASCII 50
                 new byte[] { 66,65,81,105,70},                    // 3           ASCII 51
                 new byte[] { 12,20,36,127,4},                     // 4           ASCII 52
                 new byte[] { 113,81,81,81,78},                    // 5           ASCII 53
                 new byte[] { 30,41,73,73,6},                      // 6           ASCII 54
                 new byte[] { 64,64,79,80,96},                     // 7           ASCII 55
                 new byte[] { 54,73,73,73,54},                     // 8           ASCII 56
                 new byte[] { 48,73,73,74,60},                     // 9           ASCII 57 
                 new byte[] { 0,0,54,54,0},                        // :           ASCII 58
                 new byte[] { 0,0,53,54,0},                        // ;           ASCII 59
                 new byte[] { 0,8,20,34,65},                       // <           ASCII 60
                 new byte[] { 20,20,20,20,20},                     // =           ASCII 61
                 new byte[] { 0,65,34,20,8},                       // >           ASCII 62
                 new byte[] { 32,64,69,72,48},                     // ?           ASCII 63
                 new byte[] { 38,73,77,65,62},                     // @           ASCII 64
                 new byte[] { 31,36,68,36,31},                     // A           ASCII 65
                 new byte[] { 127,73,73,73,54},                    // B           ASCII 66
                 new byte[] { 62,65,65,65,34},                     // C           ASCII 67
                 new byte[] { 127,65,65,34,28},                    // D           ASCII 68
                 new byte[] { 127,73,73,65,65},                    // E           ASCII 69
                 new byte[] { 127,72,72,72,64},                    // F           ASCII 70
                 new byte[] { 62,65,65,69,38},                     // G           ASCII 71
                 new byte[] { 127,8,8,8,127},                      // H           ASCII 72
                 new byte[] { 65,127,65 },                         // I           ASCII 73
                 new byte[] { 2,1,1,1,126},                        // J           ASCII 74
                 new byte[] { 127,8,20,34,65},                     // K           ASCII 75
                 new byte[] { 127,1,1,1,1},                        // L           ASCII 76
                 new byte[] { 127,32,16,32,127},                   // M           ASCII 77
                 new byte[] { 127,32,16,8,127},                    // N           ASCII 78
                 new byte[] { 62,65,65,65,62},                     // O           ASCII 79
                 new byte[] { 127,72,72,72,48},                    // P           ASCII 80
                 new byte[] { 62,65,69,66,61},                     // Q           ASCII 81
                 new byte[] { 127,72,76,74,49},                    // R           ASCII 82
                 new byte[] { 50,73,73,73,38},                     // S           ASCII 83
                 new byte[] { 64,64,127,64,64},                    // T           ASCII 84
                 new byte[] { 126,1,1,1,126},                      // U           ASCII 85
                 new byte[] { 124,2,1,2,124},                      // V           ASCII 86
                 new byte[] { 126,1,6,1,126},                      // W           ASCII 87
                 new byte[] { 99,20,8,20,99},                      // X           ASCII 88
                 new byte[] { 96,16,15,16,96},                     // Y           ASCII 89
                 new byte[] { 67,69,73,81,97},                     // Z           ASCII 90
                 new byte[] { 127,65,65 },                         // [           ASCII 91
                 new byte[] { 16,8,4,2,1 },                        // \           ASCII 92
                 new byte[] { 65,65,127 },                         // ]           ASCII 93
                 new byte[] { 16,32,64,32,16},                     // ^           ASCII 94
                 new byte[] { 1,1,1,1,1},                          // _           ASCII 95
                 new byte[] { 64,32,16 },                          // `           ASCII 96
                 new byte[] { 2,21,21,21,15},                      // a           ASCII 97
                 new byte[] { 127,5,9,9,6},                        // b           ASCII 98
                 new byte[] { 14,17,17,17,2},                      // c           ASCII 99
                 new byte[] { 6,9,9,5,127},                        // d           ASCII 100
                 new byte[] { 14,21,21,21,12},                     // e           ASCII 101
                 new byte[] { 8,63,72,64,32},                      // f           ASCII 102
                 new byte[] { 24,37,37,37,62},                     // g           ASCII 103
                 new byte[] { 127,8,16,16,15},                     // h           ASCII 104
                 new byte[] { 47 },                                // i           ASCII 105
                 new byte[] { 2,1,17,94 },                         // j           ASCII 106
                 new byte[] { 127,4,10,17,0},                      // k           ASCII 107
                 new byte[] { 65,127,1 },                          // l           ASCII 108
                 new byte[] { 31,16,12,16,31},                     // m           ASCII 109
                 new byte[] { 31,8,16,16,15},                      // n           ASCII 110
                 new byte[] { 14,17,17,17,14},                     // o           ASCII 111
                 new byte[] { 31,20,20,20,8},                      // p           ASCII 112
                 new byte[] { 8,20,20,12,31},                      // q           ASCII 113
                 new byte[] { 31,8,16,16,8},                       // r           ASCII 114
                 new byte[] { 9,21,21,21,2},                       // s           ASCII 115
                 new byte[] { 16,126,17,1,2},                      // t           ASCII 116
                 new byte[] { 30,1,1,2,31},                        // u           ASCII 117
                 new byte[] { 28,2,1,2,28},                        // v           ASCII 118
                 new byte[] { 30,1,6,1,30},                        // w           ASCII 119
                 new byte[] { 17,10,4,10,17},                      // x           ASCII 120
                 new byte[] { 24,5,5,5,30},                        // y           ASCII 121
                 new byte[] { 17,19,21,25,17},                     // z           ASCII 122
                 new byte[] { 8,54,65 },                           // {           ASCII 123
                 new byte[] { 0,127,0},                            // |           ASCII 124
                 new byte[] { 65,54,8 },                           // }           ASCII 125/Z
                };

            for (int i = 0; i < 94; i++)
            {
                font.glyphs.Add(Glyph.Create(bytes[i], Convert.ToChar(i + 32).ToString()));
            }

            return font;
        }

        public void AddGlyph(Glyph glyph)
        {
            if (this.ContainsKey(glyph.Id))
            {
                throw new InvalidOperationException("Glyph ID must be unique.");
            }

            this.glyphs.Add(glyph);
        }

        public void Remove(string id)
        {
            if (!this.ContainsKey(id))
            {
                throw new InvalidOperationException($"Cannot remove item with ID: {id} - Does not exist");
            }

            var glyph = this[id];
            this.glyphs.Remove(glyph);
        }

        public IEnumerator<Glyph> GetEnumerator()
        {
            return this.glyphs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.glyphs.GetEnumerator();
        }
    }
}
