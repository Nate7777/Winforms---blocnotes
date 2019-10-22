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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using em = Scribbler.ScribblerGen.MessErreurs;

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
            EmFormatText
        }

        public static string[] MessagesErreurs = new string[6];

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
            MessagesErreurs[(int)em.EmFormatText] =
                "Erreur lors du formattage.";
        }

        #endregion

        #region Menu Mutuellement exclusif
        public static void RemoveChecks(ToolStripMenuItem oToolStripMenuItem)
        {
           foreach(ToolStripItem oToolStripItem in oToolStripMenuItem.DropDownItems)
           {
                if(oToolStripItem is ToolStripMenuItem)
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
