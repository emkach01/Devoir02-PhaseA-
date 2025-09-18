/*
    Programmeur:    Lydianne, Mohamed, Labib
    Date:           Septembre 17 2025

    Solution:       BibliothequeParentForm.sln
    Projet:         BibliothequeParentForm.csproj
    Namespace:      {BibliothequeParentForm}
    Assembly:       BibliothequeParentForm.exe
    Classe:         BibliothequeParentForm.cs

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestionBibliotheque
{
    public partial class BibliothequeParentForm : Form
    {
        public BibliothequeParentForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
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

        #region Methode controlAdded

        private void QuatrePaneaux_ControlAdded(object sender, ControlEventArgs e)
        {

            if (e.Control is MenuStrip menu)
            {
                // Si c’est un menu, changer son style
                menu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                menu.TextDirection = ToolStripTextDirection.Horizontal;

                // Exemple : afficher une ComboBox spéciale
                toolStripComboBox3.Visible = true;
            }
            else if (e.Control is ToolStrip toolbar)
            {
                // Si c’est une barre d’outils, masquer la ComboBox
                toolStripComboBox3.Visible = false;
            }

            // Vérifier dans quel panneau le contrôle a été ajouté
            if (sender is ToolStripPanel panel)
            {
                if (panel.Dock == DockStyle.Top)
                    MessageBox.Show("Contrôle ajouté en haut");
                else if (panel.Dock == DockStyle.Bottom)
                    MessageBox.Show("Contrôle ajouté en bas");
                else if (panel.Dock == DockStyle.Left)
                    MessageBox.Show("Contrôle ajouté à gauche");
                else if (panel.Dock == DockStyle.Right)
                    MessageBox.Show("Contrôle ajouté à droite");
            }

        }

        #endregion

        #region reorganiser fenetre
        private void fenetreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem clickedItem)
            {
                // Décoche tous les sous-menus
                foreach (ToolStripMenuItem item in fenetreToolStripMenuItem.DropDownItems)
                    item.Checked = false;

                // Cocher uniquement celui qu'on a cliqué
                clickedItem.Checked = true;

                // Appliquer l’organisation selon le choix
                if (clickedItem == cascadeToolStripMenuItem)
                    this.LayoutMdi(MdiLayout.Cascade);
                else if (clickedItem == mosaiqueHToolStripMenuItem)
                    this.LayoutMdi(MdiLayout.TileHorizontal);
                else if (clickedItem == mosaiqueVToolStripMenuItem)
                    this.LayoutMdi(MdiLayout.TileVertical);
                else if (clickedItem == iconesToolStripMenuItem)
                    this.LayoutMdi(MdiLayout.ArrangeIcons);
            }
        }
        #endregion
    }
}
