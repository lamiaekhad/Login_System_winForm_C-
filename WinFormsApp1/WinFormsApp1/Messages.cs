using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    internal class Messages
    {
        public static void MessageNotConnectToBD()
        {
            MessageBox.Show("Pas de connexion", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MessageCompteExistant()
        {
            MessageBox.Show("Nom d'utilisateur exist deja", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static void MessageChampsObligatoire()
        {
            MessageBox.Show("Merci de remplir les champs obligatoires", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static void MessageWrongPassword()
        {
            MessageBox.Show("Le mot de passe ne correspond pas.", "Message", MessageBoxButtons.OK);
        }
        public static void MessageCompteCreer()
        {
            MessageBox.Show("Votre compte a été créé avec succès !", "Message", MessageBoxButtons.OK);
        }
        public static void MessageCourrielNonValide()
        {
            MessageBox.Show("Courriel Non Valide", "Message", MessageBoxButtons.OK);
        }
        public static void MessageNotExist()
        {
            MessageBox.Show("Le compte n'exist pas", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static void PasswordNotCorrect()
        {
            MessageBox.Show("Le mot de passe est incorrect. essayez à nouveau", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public static void MessageCompteVerrouiller()
        {
            MessageBox.Show("Le compte est verrouillé. Contactez l'administrateur!", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MessageBonFormat()
        {
            MessageBox.Show("La donnée n’est pas dans le bon format", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MessageMotDePasseVide()
        {
            MessageBox.Show("Insérez votre Mot de passe", "message", MessageBoxButtons.OK);
        }
        public static void MessageNomUtilisateurVide()
        {
            MessageBox.Show("Insérez votre Nom d'utilisateur", "message", MessageBoxButtons.OK);
        }
        
    }
}
