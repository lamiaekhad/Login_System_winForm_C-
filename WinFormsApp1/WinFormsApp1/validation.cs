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
            string message = string.Empty;
            bool valide = false;
            if (!Regex.Match(nom, "^[a-zA-Z]*$").Success)
            {
                valide = true;
                MessageBox.Show("Choix non valide ");
            }
            return valide;
        }
    }
}
