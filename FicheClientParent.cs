using System;
using System.Drawing;
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

            AfficherIcones();
        }


        private void AfficherIcones()
        {
            try
            {
                newToolStripButton1.Image = Properties.Resources.DocumentHS;
                ouvrirToolStripButton2.Image = Properties.Resources.openfolderHS;
                saveToolStripButton3.Image = Properties.Resources.saveHS;
                couperToolStripButton4.Image = Properties.Resources.CutHS;
                copierToolStripButton5.Image = Properties.Resources.CopyHS;
                collerToolStripButton6.Image = Properties.Resources.PasteHS;


                //this.Icon = Properties.Resources.;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement icônes : " + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // === Boutons de formatage ===
        private void boldToolStripButton7_Click(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).ToggleBold();
        }

        private void italiqueToolStripButton8_Click(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).ToggleItalic();
        }

        private void underlineToolStripButton9_Click(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).ToggleUnderline();
        }

        // === Nouveau ===
        private void newToolStripButton1_Click(object sender, EventArgs e)
        {
            var child = new FicheClientChild();
            child.MdiParent = this;
            child.Show();
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = new FicheClientChild();
            child.MdiParent = this;
            child.Show();
        }

        // === Ouvrir ===
        private void ouvrirToolStripButton2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Fichiers texte|.txt|Tous les fichiers|.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var child = new FicheClientChild();
                    child.MdiParent = this;
                    child.LoadFromFile(ofd.FileName);
                    child.Show();
                }
            }
        }

        // === Quitter ===
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void saveToolStripButton3_Click(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).SaveToFile();
        }

        private void couperToolStripButton4_Click_1(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).Cut();
        }

        private void copierToolStripButton5_Click_1(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).Copy();
        }

        private void collerToolStripButton6_Click_1(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).Paste();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenue dans l'aide !\n\n" +
                            "- Nouveau / Ouvrir : gérer vos fiches\n" +
                            "- Enregistrer : sauvegarder la fiche\n" +
                            "- Gras / Italique / Souligné : formatage\n" +
                            "- Couper / Copier / Coller : édition\n" +
                            "- Alignement : mise en page",
                            "Aide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).AlignLeft();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).AlignCenter();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            ((FicheClientChild)this.ActiveMdiChild).AlignRight();
        }
    }
}