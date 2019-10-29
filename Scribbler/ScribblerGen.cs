/*
        Programmeur: Nathan Comeau,Andy Fleur, Lala et Cabrel
        Date: 10/09/2019
        But:  Creer une application MDI - Devoir 02 phase C
 
        Solution: Scribbler.sln
        Projet:   Scribbler.csproj
        Classe:   ScribblerGenForm.cs
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using em = Scribbler.ScribblerGen.MessErreurs;
using note = Scribbler.ScribblerNoteForm;

namespace Scribbler
{
    class ScribblerGen
    {
        #region Messages d'erreurs - Initialisation et enumeration

        public enum MessErreurs
        {
            EmDocument,
            EmInattendu,
            EmErreurEnregistrer,
            EmOuvrirErreur,
            EmEnregistrementErreur,
            EmErreurIndetermine,
            EmFormatText,
            EmErreurEdition,
            EmStylePolice
        }

        public static string[] MessagesErreurs = new string[10];

        public static void InitMessages()
        {
            MessagesErreurs[(int)em.EmDocument] = "Impossible de créer un document.";
            MessagesErreurs[(int)em.EmInattendu] = "Erreur inattendue.";
            MessagesErreurs[(int)em.EmErreurEnregistrer] =
                "Le document n'a pas été enregistré.";
            MessagesErreurs[(int)em.EmOuvrirErreur] =
                "Il est impossible d'ouvrir le fichier.";
            MessagesErreurs[(int)em.EmEnregistrementErreur] =
                "Le fichier ne peut pas etre enregistrer.";
            MessagesErreurs[(int)em.EmErreurIndetermine] = "Erreur indéterminée";
            MessagesErreurs[(int)em.EmFormatText] =
                "Erreur lors du formattage.";
            MessagesErreurs[(int)em.EmErreurEdition] =
               "Erreur lors de l'édition";
            MessagesErreurs[(int)em.EmStylePolice] =
               "Erreur lors changement de police";
        }

        #endregion

        #region Menu Mutuellement exclusif
        public static void RemoveChecks(ToolStripMenuItem oToolStripMenuItem)
        {
            foreach (ToolStripItem oToolStripItem in oToolStripMenuItem.DropDownItems)
            {
                if (oToolStripItem is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)oToolStripItem).Checked = false;

                    ToolStripMenuItem oSousMenu = (ToolStripMenuItem)(oToolStripItem);

                    if (!oSousMenu.IsMdiWindowListEntry)
                        oSousMenu.Checked = false;
                }
            }
        }

        #endregion

        
    }
}
