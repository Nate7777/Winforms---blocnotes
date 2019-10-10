using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
