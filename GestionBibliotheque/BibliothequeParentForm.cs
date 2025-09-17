using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBibliotheque
{
    public partial class BibliothequeParentForm : Form
    {
        public BibliothequeParentForm()
        {
            InitializeComponent();
        }

        #region Load
        private void BibliothequeParentForm_Load(object sender, EventArgs e)
        {
            AfficherIcones();
        }

        #endregion

        #region Methode afficher images
        private void AfficherIcones()
        {
            //utilisation d'un bloc try catch pour gerer les erreurs
            try
            {
                NouveauToolStripMenuItem.Image = Properties.Resources.page;
                OuvrirToolStripMenuItem.Image = Properties.Resources.dossier;
                EnregistrerSousToolStripMenuItem.Image = Properties.Resources.enregistrer;
                couperToolStripMenuItem.Image = Properties.Resources.cut;
                copierToolStripMenuItem.Image = Properties.Resources.copie;
                collerToolStripMenuItem.Image = Properties.Resources.coller;
                rechercherToolStripMenuItem.Image = Properties.Resources.rechercher;


               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement icônes : " + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region style MenuStrip

        private void professionnelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //caster le sender en ToolStripMenuItem
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            if (clickedItem == null) return;

            // Trouver le menu parent car on travail avec un sous-menu
            ToolStripMenuItem parentMenu = (ToolStripMenuItem)clickedItem.OwnerItem;

            // Trouver l’index de l’item cliqué dans le sous-menu
            int index = parentMenu.DropDownItems.IndexOf(clickedItem);

            // Enlever crochets 
            foreach (ToolStripMenuItem item in parentMenu.DropDownItems)
                item.Checked = false;

            clickedItem.Checked = true;

            // Changer le RenderMode selon l’index
            if (index == 0)
            {
                menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            }
            else if (index == 1)
            {
                menuStrip1.RenderMode = ToolStripRenderMode.System;
            }
            else if (index == 2)
            {
                menuStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode; // CORRECT
            }
        }


        #endregion

        #region nouveau livre

        int compt = 1;    //on initialise le compteur
        private void nouveauLivre()
        {
            //utilisation d'un bloc try catch pour gerer les erreurs
            try
            {
                LivreEnfantForm livreForm = new LivreEnfantForm();
                livreForm.Text = "Nouveau Livre" + compt++; //on change le titre du form child
                livreForm.MdiParent = this;     //set le form parent
                livreForm.Show();   //afficher le form child
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création d'un nouveau livre : " + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }


        //on appelle la methode nouveauLivre lors du click sur le menu
        private void NouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nouveauLivre();
        }

        #endregion
    }
}
