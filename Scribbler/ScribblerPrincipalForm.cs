/*
        Programmeur: Nathan Comeau,Andy Fleur, Lala et Cabrel
        Date: 10/25/2019
        But:  Creer une application MDI - Devoir 02 phase E
 
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
using System.Globalization;

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
        private ComboBox oComboBox;

        #endregion

        #region Load
        private void ScribblerPrincipalForm_Load(object sender, EventArgs e)
        {
            AssocierImages();
            gen.InitMessages();
            DesactiverOperationsMenusBarreOutils();

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

            //Status strip labels
            noteToolStripStatusLabel.Text = "Créer ou ouvrir une note";

            cultureToolStripStatusLabel.Text = CultureInfo.CurrentCulture.NativeName;

            if(System.Console.CapsLock)
            {
                majToolStripStatusLabel.Text = "MAJ";
            }
            insToolStripStatusLabel.Text = "INS";

            policeToolStripComboBox.SelectedIndexChanged -= policeToolStripComboBox_SelectedIndexChanged;
            sizeToolStripComboBox.SelectedIndexChanged -= sizeToolStripComboBox_SelectedIndexChanged;

            oComboBox = policeToolStripComboBox.ComboBox;
            oComboBox.DisplayMember = "Name";

            InitPolice();

            policeToolStripComboBox.SelectedIndexChanged += policeToolStripComboBox_SelectedIndexChanged;
            sizeToolStripComboBox.SelectedIndexChanged += sizeToolStripComboBox_SelectedIndexChanged;

            scribblerFontDialog.MinSize = 8;
            scribblerFontDialog.MaxSize = 14;
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
                ActiverOperationsMenusBarreOutils();

                Note = new ScribblerNoteForm();
                Note.MdiParent = this;
                Note.Show();
                Note.Text += countFen;

                Note.ModeInserer = true; //Mode inserer actif

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
                    sizeToolStripComboBox.Visible = false;

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
                    sizeToolStripComboBox.Visible = true;
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
                ActiverOperationsMenusBarreOutils();

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

                        scribbler.ModeInserer = true; // Mode inserer actif
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

        #region Edition
        private void Edition(object sender, EventArgs e)
        {
            try
            {
                RichTextBox oRichtextBox = (this.ActiveMdiChild as
                    ScribblerNoteForm).noteRichTextBox;

                if (sender == couperToolStripMenuItem || sender == couperToolStripButton)
                    oRichtextBox.Cut();
                else if (sender == copierToolStripMenuItem || sender == copierToolStripButton)
                    oRichtextBox.Copy();
                else if (sender == collerToolStripMenuItem || sender == collerToolStripButton)
                    oRichtextBox.Paste();
                else if (sender == effacerToolStripMenuItem)
                    oRichtextBox.Clear();
                else if (sender == selectionnerToutToolStripMenuItem)
                    oRichtextBox.SelectAll();

            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmErreurEdition] +
                   Environment.NewLine.ToString());
            }
        }

        #endregion

        #region MDIChilActivated
        private void ScribblerPrincipalForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                DesactiverOperationsMenusBarreOutils();
                noteToolStripStatusLabel.Text = "Créer ou ouvrir une note";
                //if(this.OwnedForms.Length > 0)
                //{
                //    this.OwnedForms[0].Close();
                //}
            }
            else
            {
                if(((ScribblerNoteForm)this.ActiveMdiChild).ModeInserer)
                {
                    insToolStripStatusLabel.Text = "RFP";
                }
                else
                {
                    insToolStripStatusLabel.Text = "INS";
                }
                noteToolStripStatusLabel.Text = this.ActiveMdiChild.Text;
            }
            
        }

        #endregion

        #region Polices

        #region Style de police
        private void StylePolice(object sender, EventArgs e)
        {
            try
            {
                ScribblerNoteForm oNote;
                oNote = (ScribblerNoteForm)this.ActiveMdiChild;

                if (sender == boldToolStripButton)
                    oNote.ChangerAttributFont(FontStyle.Bold);
                else if (sender == italicToolStripButton)
                    oNote.ChangerAttributFont(FontStyle.Italic);
                else
                    oNote.ChangerAttributFont(FontStyle.Underline);

            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmStylePolice] +
                   Environment.NewLine.ToString());
            }
        }

        #endregion

        #region Initialisation des polices

        void InitPolice()
        {
            try
            {
                System.Drawing.Text.InstalledFontCollection oInstalledFonts = new System.Drawing.Text.InstalledFontCollection();
                
                foreach(FontFamily oFont in oInstalledFonts.Families)
                {
                    policeToolStripComboBox.Items.Add(oFont.Name);
                }
            }
            catch(Exception)
            {
                MessageBox.Show(em.EmStylePolice.ToString());
            }
        }

        #endregion

        #region Selected index changed des polices
        private void policeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = (this.ActiveMdiChild as ScribblerNoteForm).noteRichTextBox;
            Font oFont = rtb.SelectionFont;

            if(oFont != null)
            {
                try
                {

                }
                catch(Exception)
                {
                    MessageBox.Show(em.EmStylePolice.ToString());
                }
            }
        }

        #endregion

        #region Selected index changed des tailles
        private void sizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Menu item police

        private void policeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScribblerNoteForm oScribbler = this.ActiveMdiChild as ScribblerNoteForm;
            RichTextBox rtb = oScribbler.noteRichTextBox;

            try
            {
                scribblerFontDialog.Font = oScribbler.noteRichTextBox.SelectionFont;

                if(scribblerFontDialog.ShowDialog() == DialogResult.OK)
                {
                    rtb.SelectionFont = scribblerFontDialog.Font;
                }
            }
            catch(Exception)
            {
                MessageBox.Show(em.EmStylePolice.ToString());
            }
        }

        #endregion

        #endregion

        #region Alignement
        private void Alignement(object sender, EventArgs e)
        {
            try
            {
                ScribblerNoteForm oNote;
                oNote = (ScribblerNoteForm)this.ActiveMdiChild;

                if (sender == alignerGaucheToolStripButton)
                {
                    oNote.noteRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                    alignerDroiteToolStripButton.Checked = false;
                    centrerToolStripButton.Checked = false;

                }
                else if(sender == alignerDroiteToolStripButton)
                {
                    oNote.noteRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
                    alignerDroiteToolStripButton.Checked = false;
                    centrerToolStripButton.Checked = false;
                }
                else
                {
                    oNote.noteRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
                    alignerDroiteToolStripButton.Checked = false;
                    alignerGaucheToolStripButton.Checked = false;
                }


            }
            catch(Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmErreurIndetermine]);
            }
        }
        #endregion

        #region Rechercher
        private void RechercherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.OwnedForms.Length == 0) // pas de fenetre de recherche
                {
                    RechercherForm rf = new RechercherForm();
                    rf.Owner = this;
                    rf.Mot = (this.ActiveMdiChild.ActiveControl as RichTextBox).SelectedText;
                    rf.Show();
                }
            }
            catch(Exception)
            {

            }
        }

        #endregion

        #region Desactiver les barre d'outils
        void DesactiverOperationsMenusBarreOutils()
        {
            //Menus
            foreach (ToolStripItem item in scribblerMenuStrip.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    foreach (ToolStripItem drowpdownMenuItem in ((ToolStripMenuItem)item).DropDownItems)
                    {
                        if (drowpdownMenuItem is ToolStripMenuItem)
                        {
                            ((ToolStripMenuItem)drowpdownMenuItem).Enabled = false;
                        }
                    }
                }
            }

            //Barre d'outils
            foreach (ToolStripItem item in scribblerToolStrip.Items)
            {
                item.Enabled = false;
            }

            nouveauToolStripButton.Enabled = true;
            ouvrirToolStripButton.Enabled = true;
            nouveauToolStripButton.Enabled = true;
            ouvrirToolStripButton.Enabled = true;
            quitterToolStripMenuItem.Enabled = true;
            aideToolStripMenuItem.Enabled = true;
        }

        #endregion

        #region Activer les barres d'outils

        void ActiverOperationsMenusBarreOutils()
        {
            //Menus
            foreach (ToolStripItem item in scribblerMenuStrip.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    foreach (ToolStripItem drowpdownMenuItem in ((ToolStripMenuItem)item).DropDownItems)
                    {
                        if (drowpdownMenuItem is ToolStripMenuItem)
                        {
                            ((ToolStripMenuItem)drowpdownMenuItem).Enabled = true;
                        }
                    }
                }
            }

            //Barre d'outils
            foreach (ToolStripItem item in scribblerToolStrip.Items)
            {
                item.Enabled = true;
            }
            copierToolStripMenuItem.Enabled = false;
            copierToolStripButton.Enabled = false;
            couperToolStripMenuItem.Enabled = false;
            couperToolStripButton.Enabled = false;
            effacerToolStripMenuItem.Enabled = false;

            if (Clipboard.ContainsText() || Clipboard.ContainsImage())
                collerToolStripButton.Enabled = true;
            else
                collerToolStripButton.Enabled = true;
        }


        #endregion

        #region Key down pour touche MAJ

        private void ScribblerPrincipalForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(Control.IsKeyLocked(Keys.CapsLock))
            {
                majToolStripStatusLabel.Text = "MAJ";
            }
            else
            {
                majToolStripStatusLabel.Text = "";
            }

            if(e.KeyCode == Keys.Insert)
            {
                if(insToolStripStatusLabel.Text == "INS")
                {

                    insToolStripStatusLabel.Text = "RFP";
                    if (this.ActiveMdiChild != null)
                        (this.ActiveMdiChild as ScribblerNoteForm).ModeInserer = false;
                }
            }
            else
            {
                insToolStripStatusLabel.Text = "INS";
                if (this.ActiveMdiChild != null)
                    (this.ActiveMdiChild as ScribblerNoteForm).ModeInserer = true;
            }

            insToolStripStatusLabel.Text = "INS";
        }

        #endregion

        #endregion
    }
}
