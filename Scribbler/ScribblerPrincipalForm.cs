/*
        Programmeur: Nathan Comeau,Andy Fleur, Lala et Cabrel
        Date: 10/09/2019
        But:  Creer une application MDI - Devoir 02 phase B
 
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
        /// <summary>
        /// Crée une nouvelle note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NouvelleNote_Click(object sender, EventArgs e)
        {
            ScribblerNoteForm Note;
            countFen++;
            try
            {
                Note = new ScribblerNoteForm();
                Note.MdiParent = this;
                Note.Show();
                Note.Text += countFen;
                
            }
            catch(Exception)
            {
                MessageBox.Show(em.EmDocument.ToString());
            }
        }

        /// <summary>
        /// Change la disposition des midchildren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FenetreMDILayout_Click(object sender, EventArgs e)
        {
            gen.RemoveChecks(fenetreToolStripMenuItem);
            ToolStripMenuItem oFormat;
            oFormat = sender as ToolStripMenuItem;

            int pos = fenetreToolStripMenuItem.DropDownItems.IndexOf((ToolStripMenuItem)sender);
            this.LayoutMdi((MdiLayout)pos);

            ((ToolStripMenuItem)sender).Checked = true;
        }

        /// <summary>
        /// Méthode partagée entre les 4 toolstrip panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panneaux_ControlAdded(object sender, ControlEventArgs e)
        {
            ToolStripPanel oPanel;
            oPanel = sender as ToolStripPanel;

            if (e.Control == ScribblerToolStrip || e.Control == scribblerMenuStrip)
            {
                if(sender == hautToolStripPanel)
                {
                    //Pour menu strip

                    scribblerMenuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                    scribblerMenuStrip.TextDirection = ToolStripTextDirection.Horizontal;
                    menuToolStripComboBox.Visible = true;

                    //Pour tool strip

                    policeToolStripComboBox.Visible = true;
                    tailleToolStripComboBox.Visible = true;
                }
                else if(sender == gaucheToolStripPanel)
                {
                    //Pour menu strip

                    scribblerMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                    scribblerMenuStrip.TextDirection = ToolStripTextDirection.Vertical270;
                    menuToolStripComboBox.Visible = false;

                    //Pour tool strip

                    policeToolStripComboBox.Visible = false;
                    tailleToolStripComboBox.Visible = false;
                }
                else if(sender == droiteToolStripPanel)
                {
                    //Pour menu strip

                    scribblerMenuStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                    scribblerMenuStrip.TextDirection = ToolStripTextDirection.Vertical90;
                    menuToolStripComboBox.Visible = false;

                    //Pour tool strip

                    policeToolStripComboBox.Visible = false;
                    tailleToolStripComboBox.Visible = false;
                }
                else
                {
                    //Pour menu strip

                    scribblerMenuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                    scribblerMenuStrip.TextDirection = ToolStripTextDirection.Horizontal;
                    menuToolStripComboBox.Visible = true;

                    //Pour tool strip

                    policeToolStripComboBox.Visible = true;
                    tailleToolStripComboBox.Visible = true;
                }
            }
        }
    }
}
