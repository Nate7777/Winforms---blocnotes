/*
        Programmeur: Nathan Comeau,Andy Fleur, Lala et Cabrel
        Date: 10/09/2019
        But:  Devoir 02 phase B 
 
        Solution: Scribbler.sln
        Projet:   Scribbler.csproj
        Classe:   ScribblerPrincipalForm.cs
 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gen = Scribbler.ScribblerGen;
using em = Scribbler.ScribblerGen.MessErreurs;

namespace Scribbler
{
    public partial class ScribblerPrincipalForm : Form
    {

        #region Initialisation des composantes

        public ScribblerPrincipalForm()
        {
            InitializeComponent();
        }

        #region Variables

        private int countFen;

        #endregion
        private void ScribblerPrincipalForm_Load(object sender, EventArgs e)
        {
            AssocierImages();
            gen.InitMessages();
        }

        #endregion

        #region Méthodes privées

        #region Association des images
        private void AssocierImages()
        {
            nouveauToolStripMenuItem.Image = nouveauToolStripButton.Image;
            ouvrirToolStripMenuItem.Image = ouvrirToolStripButton.Image;
            enregistrerToolStripMenuItem.Image = enregistrerToolStripButton.Image;
            imprimerToolStripMenuItem.Image = imprimerToolStripButton.Image;
            couperToolStripMenuItem.Image = couperToolStripButton.Image;
            copierToolStripMenuItem.Image = copierToolStripButton.Image;
            collerToolStripMenuItem.Image = collerToolStripButton.Image;
            aiderSurScribblerToolStripMenuItem.Image = aideToolStripButton.Image;
        }

        #endregion

        #endregion

        private void NouvelleNote_Click(object sender, EventArgs e)
        {
            ScribblerNoteForm Note;
            countFen++;
            try
            {
                Note = new ScribblerNoteForm();
                Note.MdiParent = this;
                Note.Show();
                Note.Text = Note.Text + countFen;
                
            }
            catch(Exception)
            {
                MessageBox.Show(em.EmDocument.ToString());
            }
        }

        private void FenetreMDILayout_Click(object sender, EventArgs e)
        {
            gen.RemoveChecks(fenetreToolStripMenuItem);
            ToolStripMenuItem oFormat;
            oFormat = sender as ToolStripMenuItem;
            oFormat.Checked = true;

            int pos = fenetreToolStripMenuItem.DropDownItems.IndexOf((ToolStripMenuItem)sender);
            this.LayoutMdi();
        }
    }
}
