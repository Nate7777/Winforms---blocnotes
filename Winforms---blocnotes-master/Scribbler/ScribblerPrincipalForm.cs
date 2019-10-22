/*
        Programmeur: Nathan Comeau,Andy Fleur, Lala et Cabrel
        Date: 10/09/2019
        But:  Creer une application MDI - Devoir 02 phase C
 
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
using System.Drawing.Text;
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

        private static int countFen;
        private string filtreString;
        private string initialdirectory;
        int Filtreint = 0;
        string extensionDefautString = "rtf";

        #endregion

        #region Load
        private void ScribblerPrincipalForm_Load(object sender, EventArgs e)
        {
            AssocierImages();
            gen.InitMessages();

            filtreString = "Fichiers rtf (*.rtf)|*.rtf|Tous les fichiers (*.*)|*.*";
            initialdirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            scribblerOpenFileDialog.InitialDirectory = initialdirectory;
            scribblerOpenFileDialog.AddExtension = true;
            scribblerOpenFileDialog.CheckFileExists = true;
            scribblerOpenFileDialog.CheckPathExists = true;
            scribblerOpenFileDialog.DefaultExt = extensionDefautString;
            scribblerOpenFileDialog.Title = "Ouvrir un texte";
            scribblerOpenFileDialog.FilterIndex = Filtreint;
            scribblerOpenFileDialog.Filter = filtreString;

            //policeToolStripComboBox.SelectedIndexChanged -= policeToolStripComboBox_SelectedIndexChanged;
        }

        #endregion

        #endregion

        #region Méthodes privées

        #region Insertion des images
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

        #region Initialiser les polices

        //private void InitPolices()
        //{
        //    InstalledFontCollection polices = new InstalledFontCollection();

        //    foreach(FontFamily famille in polices.Families)
        //    {
        //        policeToolStripComboBox.Items.Add(famille.Name);
        //    }
        //}

        //private void policeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ScribblerNoteForm oNote = this.ActiveMdiChild as ScribblerNoteForm;
        //    RichTextBox rtb = oNote.noteRichTextBox;

        //    Font oFont = rtb.SelectionFont;

        //    if(oFont != null)
        //    {
        //        rtb.SelectionFont = new Font(policeToolStripComboBox.Text,oFont.Size,oFont.Style);
        //        this.ActiveMdiChild.ActiveControl.Focus();
        //    }
        //}

        #endregion

        #region Creation d'une nouvelle note

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
            catch (Exception)
            {
                MessageBox.Show(em.EmDocument.ToString());
            }
        }

        #endregion

        #region Orientation des fenetres MDI

        /// <summary>
        /// Change la disposition des MDIchildren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FenetreMDILayout_Click(object sender, EventArgs e)
        {
            gen.RemoveChecks(fenetreToolStripMenuItem);
            int pos = fenetreToolStripMenuItem.DropDownItems.IndexOf(sender as ToolStripMenuItem);
            this.LayoutMdi((MdiLayout)pos);

            ((ToolStripMenuItem)sender).Checked = true;
        }

        #endregion

        #region Orientation de la barre d'outil et de la barre de menu

        /// <summary>
        /// Méthode partagée entre les 4 toolstrip panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panneaux_ControlAdded(object sender, ControlEventArgs e)
        {
            if (sender == scribblerLeftToolStripPanel || sender == scribblerRightToolStripPanel)
            {
                if (e.Control == scribblerMenuStrip)
                {
                    questionToolStripComboBox.Visible = false;
                    scribblerMenuStrip.TextDirection = ToolStripTextDirection.Vertical270;

                }
                else
                {
                    policeToolStripComboBox.Visible = false;
                    tailleToolStripComboBox.Visible = false;

                }
            }
            else
            {
                if (e.Control == scribblerMenuStrip)
                {
                    questionToolStripComboBox.Visible = true;
                    scribblerMenuStrip.TextDirection = ToolStripTextDirection.Horizontal;
                }
                else
                {
                    policeToolStripComboBox.Visible = true;
                    tailleToolStripComboBox.Visible = true;
                }
            }
        }

        #endregion

        #region Enregistrer le fichier

        private void Enregistrement_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.MdiChildren.Count() >= 1 && this.ActiveMdiChild
                    != null)
                {
                    ScribblerNoteForm scribbler;
                    scribbler = this.ActiveMdiChild as ScribblerNoteForm;

                    if (sender == enregistrerToolStripButton || sender ==
                        enregistrerToolStripMenuItem)
                        scribbler.Enregistrer();
                    else
                        scribbler.EnregistrerSous();
                }
                else
                {
                    ScribblerNoteForm scribbler = this.ActiveMdiChild as
                        ScribblerNoteForm;
                    scribbler.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmEnregistrementErreur]
                    + Environment.NewLine.ToString());
            }
        }

        #endregion

        #region Ouvrir le fichier

        private void Ouvrir_Click(object sender, EventArgs e)
        {
            try
            {
                scribblerOpenFileDialog.InitialDirectory = initialdirectory;

                if (scribblerOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (scribblerOpenFileDialog.FileName.EndsWith
                        ("rtf", StringComparison.CurrentCulture))
                    {
                        ScribblerNoteForm scribbler = new
                            ScribblerNoteForm();
                        scribbler.Text = scribblerOpenFileDialog.FileName;
                        scribbler.MdiParent = this;
                        scribbler.noteRichTextBox.LoadFile
                            (scribblerOpenFileDialog.FileName);
                        scribbler.noteRichTextBox.Modified = false;
                        scribbler.enregistrerBool = true;
                        scribbler.Show();
                        scribblerOpenFileDialog.InitialDirectory =
                            scribblerOpenFileDialog.FileName;
                        initialdirectory = scribblerOpenFileDialog.FileName;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmOuvrirErreur] +
                    Environment.NewLine.ToString());

            }
        }
        #endregion

        #endregion

        #region Fermeture du bloc note
        private void Fermer_Click(object sender, EventArgs e)
        {
            ScribblerNoteForm scribbler = this.ActiveMdiChild as
                ScribblerNoteForm;

            if (this.ActiveControl != null)
            {
                scribbler.Close();
            }
        }
        #endregion

        #region Quitter le formulaire

        private void Quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion
    }
}
