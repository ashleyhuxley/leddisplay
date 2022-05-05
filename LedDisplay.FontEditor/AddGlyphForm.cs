namespace LedDisplay.FontEditor
{
    public partial class AddGlyphForm : Form
    {
        public AddGlyphForm()
        {
            InitializeComponent();
        }

        public string GlyphId => this.idTextBox.Text;

        public int GlyphWidth => Convert.ToInt32(this.widthInput.Value);

        public int GlyphHeight => Convert.ToInt32(this.heightInput.Value);

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        public void EditGlyph(string id, int width, int height)
        {
            this.Text = "Edit Glyph";

            this.idTextBox.Text = id;
            this.idTextBox.Enabled = false;
            this.widthInput.Value = width;
            this.heightInput.Value = height;
        }

        private void AddGlyphForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK && this.idTextBox.Text == String.Empty)
            {
                MessageBox.Show("ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
