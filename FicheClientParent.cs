using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devoir02
{
    public partial class FicheClientParent : Form
    {
        public FicheClientParent()
        {
            InitializeComponent();
            this.IsMdiContainer = true;  
            ficheStatusStrip1.Text = DateTime.Now.ToShortDateString();
            AssocierImages();
        }

        private void AssocierImages()
        {
            try
            {
                if (Properties.Resources.ResourceManager.GetObject("new_file") is Image newImg)
                    newToolStripButton1.Image = newImg;

                if (Properties.Resources.ResourceManager.GetObject("bold") is Image boldImg)
                    boldToolStripButton7.Image = boldImg;

                if (Properties.Resources.ResourceManager.GetObject("italic") is Image italicImg)
                    italiqueToolStripButton8.Image = italicImg;

                if (Properties.Resources.ResourceManager.GetObject("underline") is Image underlineImg)
                    underlineToolStripButton9.Image = underlineImg;

                if (Properties.Resources.ResourceManager.GetObject("app_icon") is Icon appIcon)
                    this.Icon = appIcon;
            }
            catch
            {
            }
        }
       
        private void CreerNouvelleFiche()
        {
            var child = new FicheClientChild();
            child.MdiParent = this;
            child.Show();
        }

        private FicheClientChild GetActiveFiche()
        {
            return this.ActiveMdiChild as FicheClientChild;
        }

        private void boldToolStripButton7_Click(object sender, EventArgs e)
        {
            GetActiveFiche()?.ToggleBold();
        }

        private void italiqueToolStripButton8_Click(object sender, EventArgs e)
        {
            GetActiveFiche()?.ToggleItalic();
        }

        private void underlineToolStripButton9_Click(object sender, EventArgs e)
        {
            GetActiveFiche()?.ToggleUnderline();
        }

        private void newToolStripButton1_Click(object sender, EventArgs e)
        {
            
            CreerNouvelleFiche();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ouvrirToolStripButton2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Fichiers texte|*.txt|Tous les fichiers|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var child = new FicheClientChild();
                    child.MdiParent = this;
                    child.LoadFromFile(ofd.FileName);
                    child.Show();
                }
            }
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreerNouvelleFiche();
        }
    }
}
//test de push et pull