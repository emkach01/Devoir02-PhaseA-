using System;
using System.Drawing;
using System.Windows.Forms;

namespace Devoir02
{
    public partial class FicheClientChild : Form
    {
        public FicheClientChild()
        {
            InitializeComponent();
        }

        // Charger un fichier texte
        public void LoadFromFile(string path)
        {
            try
            {
                richTextBox1.Text = System.IO.File.ReadAllText(path);
                this.Text = System.IO.Path.GetFileName(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ouverture fichier : " + ex.Message);
            }
        }

        // Appliquer styles
        public void ToggleBold() => ToggleStyle(FontStyle.Bold);
        public void ToggleItalic() => ToggleStyle(FontStyle.Italic);
        public void ToggleUnderline() => ToggleStyle(FontStyle.Underline);

        private void ToggleStyle(FontStyle style)
        {
            var currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
            var newStyle = currentFont.Style ^ style; // toggle = ajoute/retire
            richTextBox1.SelectionFont = new Font(currentFont, newStyle);
        }
    }
}
