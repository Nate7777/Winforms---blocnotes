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
        public enum MessErreurs
        {
            EmDocument,
            EmInattendu
        }

        public static string[] MessagesErreurs = new string[4];

        public static void InitMessages()
        {
            MessagesErreurs[(int)em.EmDocument] = "Impossible de créer un document.";
            MessagesErreurs[(int)em.EmInattendu] = "Erreur inattendue.";
        }

        public static void RemoveChecks(ToolStripMenuItem menu)
        {
            if (menu != null)
            {
                foreach (ToolStripMenuItem item in menu.DropDownItems)
                {
                    if (item is ToolStripMenuItem)
                        (item as ToolStripMenuItem).Checked = false;
                }
            }
        }
    }
}
