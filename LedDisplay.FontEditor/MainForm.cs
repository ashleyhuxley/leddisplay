using LedDisplay.Graphics.Font;
using System.Text;

namespace LedDisplay.FontEditor
{
    public partial class MainForm : Form
    {
        private PixelFont font;

        private const int pixelSize = 25;

        private bool currentDrawVal = false;

        private bool fontSaved = true;

        private string? loadedFileName = null;

        public MainForm()
        {
            InitializeComponent();

            this.font = PixelFont.CreateDefault();
            LoadFont(font);
        }

        private Glyph? SelectedGlyph
        {
            get
            {
                if (this.glyphListView.SelectedItems.Count != 1)
                {
                    return null;
                }

                return (Glyph)this.glyphListView.SelectedItems[0].Tag;
            }
        }

        private string GetImageKey(string glyphId)
        {
            return char.IsUpper(glyphId[0]) ? $"U{glyphId}" : $"L{glyphId}";
        }

        private void LoadFont(PixelFont font)
        {
            this.glyphListView.Clear();
            this.glyphImages.Images.Clear();

            foreach (var glyph in font)
            {
                this.glyphImages.Images.Add(GetImageKey(glyph.Id), GetImage(glyph));

                var item = new ListViewItem(glyph.Id);

                item.ImageKey = GetImageKey(glyph.Id);
                item.Tag = glyph;
                item.Text = glyph.Id;

                this.glyphListView.Items.Add(item);
            }

            this.glyphDrawBox.Refresh();

            this.UpdateStatus();
        }

        private Bitmap GetImage(Glyph g)
        {
            var bmp = new Bitmap(32, 32);

            for (int x = 0; x < g.Width; x++)
            {
                for(int y = 0; y < g.Height; y++)
                {
                    if (g[x, y])
                    {
                        var ax = (x * 4) + 2;
                        var ay = (y * 4) + 2;

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                bmp.SetPixel(ax+i, ay+j, Color.Red);
                            }
                        }
                    }
                }
            }

            return bmp;
        }

        private void glyphDrawBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.DarkGray), 0, 0, glyphDrawBox.Width, glyphDrawBox.Height);

            if (SelectedGlyph == null)
            {
                return;
            }

            this.glyphDrawBox.Width = SelectedGlyph.Width * pixelSize + 1;
            this.glyphDrawBox.Height = SelectedGlyph.Height * pixelSize + 1;
            this.glyphDrawBox.Left = (this.splitContainer1.Panel2.Width / 2) - (this.glyphDrawBox.Width / 2);
            this.glyphDrawBox.Top = (this.splitContainer1.Panel2.Height / 2) - (this.glyphDrawBox.Height / 2);

            var pixOn = new SolidBrush(Color.Red);
            var pixOff = new SolidBrush(Color.DarkGray);

            var gridPen = new Pen(Color.Gray);

            for (int x = 0; x < SelectedGlyph.Height + 1; x++)
            {
                e.Graphics.DrawLine(gridPen, 0, x * pixelSize, SelectedGlyph.Width * pixelSize, x * pixelSize);
            }

            for (int y = 0; y < SelectedGlyph.Width + 1; y++)
            {
                e.Graphics.DrawLine(gridPen, y * pixelSize, 0, y * pixelSize, SelectedGlyph.Height * pixelSize);
            }

            for (int i = 0; i < SelectedGlyph.Width; i++)
            {
                for (int j = 0; j < SelectedGlyph.Height; j++)
                {
                    int x = (i * pixelSize) + 1;
                    int y = (j * pixelSize) + 1;
                    e.Graphics.FillRectangle(SelectedGlyph[i, j] ? pixOn : pixOff, x, y, pixelSize - 2, pixelSize - 2);
                }
            }
        }

        private void glyphListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasSelection = this.glyphListView.SelectedItems.Count == 1;

            this.glyphDrawBox.Visible = hasSelection;
            resizeToolStripMenuItem.Enabled = hasSelection;

            this.glyphDrawBox.Refresh();
        }

        private void addGlyphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addGlyphForm = new AddGlyphForm
            {
                Owner = this
            };

            if (addGlyphForm.ShowDialog() == DialogResult.OK)
            {
                if (this.font.ContainsKey(addGlyphForm.GlyphId))
                {
                    MessageBox.Show("A glyph with that ID already exists.");
                    return;
                }

                bool[,] buffer = new bool[addGlyphForm.GlyphWidth, addGlyphForm.GlyphHeight];
                var glyph = Glyph.Create(buffer, addGlyphForm.GlyphId);
                this.font.AddGlyph(glyph);

                foreach (ListViewItem item in this.glyphListView.Items)
                {
                    item.Selected = false;
                }

                this.glyphImages.Images.Add(GetImageKey(glyph.Id), GetImage(glyph));
                this.glyphListView.Items.Add(new ListViewItem { Text = glyph.Id, Tag = glyph, ImageKey = GetImageKey(glyph.Id), Selected = true });

                this.fontSaved = false;
                this.UpdateStatus();
            }
        }

        private void glyphDrawBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedGlyph == null)
            {
                return;
            }

            var point = Map(e.X, e.Y);

            if (point.X >= SelectedGlyph.Width || point.Y >= SelectedGlyph.Height || point.X < 0 || point.Y < 0)
            {
                return;
            }

            SelectedGlyph[point.X, point.Y] = !SelectedGlyph[point.X, point.Y];
            currentDrawVal = SelectedGlyph[point.X, point.Y];

            SaveGlyph();

            glyphDrawBox.Refresh();
        }

        private Point Map(int x, int y)
        {
            return new Point(x / pixelSize, y / pixelSize);
        }

        private void glyphDrawBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!e.Button.HasFlag(MouseButtons.Left) || SelectedGlyph == null)
            {
                return;
            }

            var point = Map(e.X, e.Y);
            if (point.X >= SelectedGlyph.Width || point.Y >= SelectedGlyph.Height || point.X < 0 || point.Y < 0)
            {
                return;
            }

            if (SelectedGlyph[point.X, point.Y] != currentDrawVal)
            {
                SelectedGlyph[point.X, point.Y] = currentDrawVal;
                glyphDrawBox.Refresh();
                //SaveGlyph();
            }
        }

        private void SaveGlyph()
        {
            if (glyphListView.SelectedItems.Count != 1 || SelectedGlyph == null)
            {
                return;
            }

            this.glyphImages.Images[this.glyphImages.Images.IndexOfKey(GetImageKey(SelectedGlyph.Id))] = GetImage(SelectedGlyph);
            this.glyphListView.Refresh();

            fontSaved = false;
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedGlyph == null)
            {
                return;
            }

            var addGlyphForm = new AddGlyphForm
            {
                Owner = this
            };

            addGlyphForm.EditGlyph(SelectedGlyph.Id, SelectedGlyph.Width, SelectedGlyph.Height);

            if (addGlyphForm.ShowDialog() == DialogResult.OK)
            {
                var buffer = new bool[addGlyphForm.GlyphWidth, addGlyphForm.GlyphHeight];
                for (int x = 0; x < Math.Min(SelectedGlyph.Width, addGlyphForm.GlyphWidth); x++)
                {
                    for (int y = 0; y < Math.Min(SelectedGlyph.Height, addGlyphForm.GlyphHeight); y++)
                    {
                        buffer[x, y] = SelectedGlyph[x, y];
                    }
                }

                SelectedGlyph.ReplaceData(buffer);

                SaveGlyph();

                this.glyphDrawBox.Refresh();
            }
        }

        private bool CheckFontSaved()
        {
            if (!fontSaved)
            {
                var result = MessageBox.Show("Loaded font is not saved. Save it now?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }

                if (result == DialogResult.Yes)
                {
                    SaveFont();
                }
            }

            return true;
        }

        private void SaveFont()
        {
            if (string.IsNullOrEmpty(this.loadedFileName))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                this.loadedFileName = saveFileDialog.FileName;
            }

            this.font.Save(this.loadedFileName);
            this.fontSaved = true;
            this.UpdateStatus();
        }

        private void UpdateStatus()
        {
            var status = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.loadedFileName))
            {
                status.Append("New File");
            }
            else
            {
                status.Append("Filename: " + this.loadedFileName);
            }

            status.Append(" | ");

            status.Append($"{this.font.Count()} glyphs.");

            this.statusText.Text = status.ToString();
        }

        private void newFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckFontSaved())
            {
                return;
            }

            this.font = new PixelFont();
            this.LoadFont(font);
            fontSaved = true;
            this.loadedFileName = null;

            this.UpdateStatus();
        }

        private void openFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            this.font = PixelFont.Load(openFileDialog.FileName);
            this.loadedFileName = openFileDialog.FileName;
            this.LoadFont(font);
            this.fontSaved = true;
            this.UpdateStatus();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveFont();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loadedFileName = null;
            this.SaveFont();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckFontSaved())
            {
                e.Cancel = true;
                return;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedGlyph == null)
            {
                return;
            }

            this.font.Remove(SelectedGlyph.Id);
            this.glyphListView.Items.RemoveAt(this.glyphListView.SelectedIndices[0]);
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void glyphDrawBox_MouseUp(object sender, MouseEventArgs e)
        {
            SaveGlyph();
        }
    }
}