using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    internal class validation
    {
        public bool validationString(string nom)
        {
            bool valide = false;
            if (!Regex.Match(nom, "^[a-zA-Z]*$").Success)
            {
                valide = true;
                Messages.MessageBonFormat();
            }
            return valide;
        }
        public bool validationStringUtilisateur(string nomutilisateur)
        {
            string message = string.Empty;
            bool valide = false;
            if (!Regex.Match(nomutilisateur, "^[a-zA-Z0-9]+$").Success)
            {
                valide = true;
                Messages.MessageBonFormat();
            }
            return valide;
        }
        public bool validationCourriel(string courriel)
        {
            FormulaireInscription form2 = new FormulaireInscription();
            string message = string.Empty;
            bool valide = false;
            if (!Regex.Match(courriel, @"^([^.@]+)(\.[^.@]+)*@([^.@]+\.)+([^.@]+)$").Success)
            {
                valide = true;
            }
            return valide;
        }
    }
}
