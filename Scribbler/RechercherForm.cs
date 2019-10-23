using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scribbler
{
    public partial class RechercherForm : Form
    {
        public RechercherForm()
        {
            InitializeComponent();
        }

        public String Mot
        {
            get
            {
                return rechercheTextBox.Text;
            }
            set
            {
                rechercheTextBox.Text = value;
            }
        }
        /// <summary>
        /// Recherche circulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuivantButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.Owner.ActiveMdiChild != null)
                {
                    RichTextBox rtb = (this.Owner.ActiveMdiChild as ScribblerNoteForm).noteRichTextBox;

                    int positionDepart = rtb.SelectionStart;

                    // TODO: une sélection(commence à la position + 1), aucune sélection(commence à la position)
                    //À vérifier
                    
                    // pas de texte sélectionné commence au point d'insertion
                    if (rtb.Find(Mot, positionDepart, RichTextBoxFinds.None) == -1)
                        rtb.Find(Mot, 0, RichTextBoxFinds.None);

                    // du texte sélectionné, commence au point d'insertion + 1;
                    if (rtb.Find(Mot, positionDepart + 1, RichTextBoxFinds.None) == -1)
                        rtb.Find(Mot, 0, RichTextBoxFinds.None);
                }
            }
            catch(Exception)
            {

            }
        }

        private void AnnulerButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
