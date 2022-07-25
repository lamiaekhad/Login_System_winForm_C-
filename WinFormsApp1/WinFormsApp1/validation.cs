﻿using System;
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
                MessageBonFormat();
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
                MessageBonFormat();
            }
            return valide;
        }
        public bool validationCourriel(string courriel)
        {
            Form2 form2 = new Form2();
            string message = string.Empty;
            bool valide = false;
            if (!Regex.Match(courriel, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                valide = true;
                
            }
            return valide;
        }
        public void MessageBonFormat()
        {
            MessageBox.Show("La donnée n’est pas dans le bon format","message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
