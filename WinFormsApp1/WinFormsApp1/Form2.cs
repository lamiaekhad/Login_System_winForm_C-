using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        User user = new User();
        validation valide = new validation();

        public Form2()
        {
            InitializeComponent();
            motdepasse.PasswordChar = '*';
            confirmation.PasswordChar = '*';
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            user.Nom = nom.Text;
            user.Prenom = prenom.Text;
            user.NomUtilisateur = nomutilisateur.Text;
            user.Courriel = courriel.Text;
            user.MotDePasse = motdepasse.Text;
            user.Confirmation = confirmation.Text;

            if (nomutilisateur.Text == "" || motdepasse.Text == "")
            {
                MessageBox.Show("Merci de remplir les champs obligatoires");
            }
            else if (motdepasse.Text != confirmation.Text)
            {
                MessageBox.Show("Le mot de passe ne correspond pas");
            }
            else if (valide.validationString(user.Nom) && valide.validationString(user.Prenom))
            {
                MessageBox.Show("Champ reserver pour les lettres");
            }
            else
            {
                sqlconnect Tosql = new sqlconnect();
                MySqlConnection conn = Tosql.connectTobase();

                try
                {
                    string sql = "INSERT INTO user(Nom, prenom, nomutilisateur, courriel, motdepasse, confirmation, statut)" +
                                 "VALUES (@nom, @prenom, @nomutilisatreur, @courriel, @motdepasse, @confirmation, @statut)";

                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@nom",user.Nom);
                    command.Parameters.AddWithValue("@prenom", user.Prenom);
                    command.Parameters.AddWithValue("@nomutilisatreur", user.NomUtilisateur);
                    command.Parameters.AddWithValue("@courriel", user.Courriel);
                    command.Parameters.AddWithValue("@motdepasse", security.Hash(user.MotDePasse));
                    command.Parameters.AddWithValue("@confirmation", security.Hash(user.Confirmation));
                    command.Parameters.AddWithValue("@statut", "non");
                    command.ExecuteReader();
                    
                    MessageBox.Show("Vous avez creer un nouveau compte");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("pas de connexion", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    conn.Close();
                }
            }
            Form1 newform = new Form1();
            this.Hide();
            newform.ShowDialog();
            this.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void courriel_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmation_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
       
    }
}
