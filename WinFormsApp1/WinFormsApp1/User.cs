using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace WinFormsApp1
{
    internal class User
    {
        private string nom;
        private string prenom;
        private string nomUtilisateur;
        private string courriel;
        private string motDePasse;
        private string confirmation;
        private string statut;

        public string Nom { get => nom; set => nom = value; }
        public string NomUtilisateur { get => nomUtilisateur; set => nomUtilisateur = value; }
        public string Courriel { get => courriel; set => courriel = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
        public string Confirmation { get => confirmation; set => confirmation = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Statut { get => statut; set => statut = value; }

        public User()
        {

        }

    }
}
