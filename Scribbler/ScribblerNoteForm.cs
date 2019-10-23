/*
        Programmeur: Nathan Comeau,Andy Fleur, Lala et Cabrel
        Date: 10/09/2019
        But:  Creer une application MDI - Devoir 02 phase C
 
        Solution: Scribbler.sln
        Projet:   Scribbler.csproj
        Classe:   ScribblerNoteForm.cs
 
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
    public partial class ScribblerNoteForm : Form
    {
        #region Variables

        public static int numInt;
        private static string filtreString;
        private static string initialDirectory;
        public Boolean enregistrerBool;

        #endregion

        #region Initialisation
        public ScribblerNoteForm()
        {
            try
            {
                InitializeComponent();
                numInt++;
                Save = false;
                filtreString = "Fichiers rtf (*.rtf)|*.rtf|Tous les fichiers (*.*)|*.*";
                initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmInattendu]);
            }
        }

        #endregion

        #region Propriété Enregistrer
        public Boolean Save
        {
            get
            {
                return enregistrerBool;
            }
            set
            {
                enregistrerBool = value;
            }

        }
        #endregion

        #region Fermeture de la page note
        private void ScribblerNoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult enregistrer;

            try
            {
                if (noteRichTextBox.Modified && noteRichTextBox.Text.Length >= 1)
                {
                    enregistrer = MessageBox.Show(gen.MessagesErreurs[(int)em.
                        EmErreurEnregistrer], "Fermeture du document"
                                  , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    switch (enregistrer)
                    {
                        case DialogResult.Yes:
                            Enregistrer();
                            this.Dispose();
                            break;
                        case DialogResult.No:
                            this.Dispose();
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmInattendu] +
                    Environment.NewLine.ToString());
            }
        }

        #endregion

        #region Enregistrement
        public void Enregistrer()
        {
            try
            {
                if (noteRichTextBox.Modified && noteRichTextBox.Text.Length >= 1)
                {
                    if (!Save)
                        EnregistrerSous();
                    else
                    {
                        noteRichTextBox.SaveFile(this.Text);
                        noteRichTextBox.Modified = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmEnregistrementErreur]);
            }
        }

        #endregion

        #region Enregistrement sous

        public void EnregistrerSous()
        {
            try
            {
                SaveFileDialog scribblerSaveFileDialog = new SaveFileDialog();

                scribblerSaveFileDialog.DefaultExt = "rtf";
                scribblerSaveFileDialog.FilterIndex = 0;
                scribblerSaveFileDialog.CheckPathExists = true;
                scribblerSaveFileDialog.OverwritePrompt = true;
                scribblerSaveFileDialog.AddExtension = true;
                scribblerSaveFileDialog.Title = "Enregistrer le texte";
                scribblerSaveFileDialog.InitialDirectory = initialDirectory;
                scribblerSaveFileDialog.Filter = filtreString;
                scribblerSaveFileDialog.FileName = this.Text;

                if (scribblerSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.noteRichTextBox.SaveFile(scribblerSaveFileDialog.FileName);
                    this.Text = scribblerSaveFileDialog.FileName;
                    Save = true;
                    noteRichTextBox.Modified = false;

                }

                scribblerSaveFileDialog.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmEnregistrementErreur]
                    + Environment.NewLine.ToString());
            }
        }

        #endregion

        #region Selection du texte 
        private void noteRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ScribblerPrincipalForm parent = this.MdiParent as ScribblerPrincipalForm;

                if (this.noteRichTextBox.SelectionFont != null)
                {
                    //parent.policeToolStripComboBox.Text = noteRichTextBox.SelectionFont.Name;
                    parent.boldToolStripButton.Checked = noteRichTextBox.SelectionFont.Bold;
                    parent.italicToolStripButton.Checked = noteRichTextBox.SelectionFont.Italic;
                    parent.underlineToolStripButton.Checked = noteRichTextBox.SelectionFont.Underline;
                }
                else
                {
                   // parent.policeToolStripComboBox.Text = String.Empty;
                }

                if (Clipboard.ContainsText() || Clipboard.ContainsImage())
                {
                    parent.collerToolStripButton.Enabled = true;
                }
                else
                {
                    parent.collerToolStripButton.Enabled = false;
                   
                }
              
                parent.collerToolStripMenuItem.Enabled = parent.collerToolStripButton.Enabled;
                parent.copierToolStripMenuItem.Enabled = noteRichTextBox.SelectionLength > 0;
                parent.copierToolStripButton.Enabled = noteRichTextBox.SelectionLength > 0;
                parent.couperToolStripButton.Enabled = noteRichTextBox.SelectionLength > 0;
                parent.couperToolStripMenuItem.Enabled = noteRichTextBox.SelectionLength > 0;
                parent.effacerToolStripMenuItem.Enabled = noteRichTextBox.SelectionLength > 0;
                parent.selectionnerToutToolStripMenuItem.Enabled = noteRichTextBox.SelectionLength > 0;

                if (noteRichTextBox.SelectionAlignment == HorizontalAlignment.Left)
                {
                    parent.alignerGaucheToolStripButton.Checked = true;
                    parent.alignerDroiteToolStripButton.Checked = false;
                    parent.centrerToolStripButton.Checked = false;
                }
                else if (noteRichTextBox.SelectionAlignment == HorizontalAlignment.Right)
                {
                    parent.alignerGaucheToolStripButton.Checked = false;
                    parent.alignerDroiteToolStripButton.Checked = true;
                    parent.centrerToolStripButton.Checked = false;
                }
                else
                {
                    parent.alignerGaucheToolStripButton.Checked = false;
                    parent.alignerDroiteToolStripButton.Checked = false;
                    parent.centrerToolStripButton.Checked = true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmFormatText]);
            }
        }

        #endregion

        #region Note Activated

        private void ScribblerNoteForm_Activated(object sender, EventArgs e)
        {
            noteRichTextBox_SelectionChanged(null, null);
        }

        #endregion

        #region Changer Atrributs
        public void ChangerAttributFont(FontStyle style)
        {
            try
            {

                if (noteRichTextBox.SelectionFont != null)
                {
                    if (noteRichTextBox.SelectionFont.FontFamily.IsStyleAvailable(style))
                    {
                        noteRichTextBox.SelectionFont = new Font(noteRichTextBox.SelectionFont, noteRichTextBox.SelectionFont.Style ^ style);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(gen.MessagesErreurs[(int)em.EmErreurIndetermine]);
            }
        }

        #endregion

       
    }
}