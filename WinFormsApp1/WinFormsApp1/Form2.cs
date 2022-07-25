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
        public bool ifUserNameExist()
        {
            int exist = 0;
            bool valide = false;
            sqlconnect sql = new sqlconnect();
            MySqlConnection conn1 = sql.connectTobase();
            try
            {
                MySqlCommand command2 = new MySqlCommand("select count(*) exist from user where nomutilisateur=@nomutilisateur ", conn1);
                command2.Parameters.AddWithValue("exist", exist);
                command2.Parameters.AddWithValue("nomutilisateur", nomutilisateur.Text);
                using (MySqlDataReader reader = command2.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            exist = reader.GetInt32("exist");
                        }
                    }
                }
                if (exist.Equals(0))
                {
                    valide = true;
                }
                command2.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageNotConnectToBD();
            }
            finally
            {
                conn1.Close();

            }
            return valide;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            user.Nom = nom.Text;
            user.Prenom = prenom.Text;
            user.NomUtilisateur = nomutilisateur.Text;
            user.Courriel = courriel.Text;
            user.MotDePasse = motdepasse.Text;
            user.Confirmation = confirmation.Text;

            if (user.NomUtilisateur.Equals("") || user.MotDePasse.Equals("") || user.Nom.Equals("") || user.Prenom.Equals("") || user.Courriel.Equals("") || user.Confirmation.Equals(""))
            {
                MessageChampsObligatoire();
            }
            else if (!motdepasse.Text.Equals(confirmation.Text))
            {
                MessageWrongPassword();
                confirmation.Text = "";
                confirmation.Focus();
            }
            else if (!ifUserNameExist())
            {
                MessageCompteExistant();
                nomutilisateur.Text = "";
                nomutilisateur.Focus();
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
                   command.Parameters.AddWithValue("@nom", user.Nom);
                   command.Parameters.AddWithValue("@prenom", user.Prenom);
                   command.Parameters.AddWithValue("@nomutilisatreur", user.NomUtilisateur);
                   command.Parameters.AddWithValue("@courriel", user.Courriel);
                   command.Parameters.AddWithValue("@motdepasse", security.HashSalt(user.MotDePasse));
                   command.Parameters.AddWithValue("@confirmation", security.Hash(user.Confirmation));
                   command.Parameters.AddWithValue("@statut", "non");
                   command.ExecuteReader();

                   MessageBox.Show("Vous avez creer un nouveau compte");
                    
                   Form1 newform = new Form1();
                   this.Hide();
                   newform.ShowDialog();
                   this.Show();
               }
               catch (Exception ex)
               {
                   MessageNotConnectToBD();
               }
                finally
               {
                   conn.Close();

               }
                
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (valide.validationString(nom.Text))
            {
                nom.Text = "";
            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (valide.validationString(prenom.Text))
            {
                prenom.Text = "";
            }
        }
        private void nomutilisateur_TextChanged(object sender, EventArgs e)
        {
           if(valide.validationStringUtilisateur(nomutilisateur.Text))
            {
                nomutilisateur.Text = "";
            }
        }
        private void courriel_TextChanged(object sender, EventArgs e)
        {
            if (valide.validationCourriel(courriel.Text))
            {
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
            }
            else
            {
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
        }
        public void MessageNotConnectToBD()
        {
            MessageBox.Show("Pas de connexion", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void MessageCompteExistant()
        {
            MessageBox.Show("Nom d'utilisateur exist deja", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public void MessageChampsObligatoire()
        {
            MessageBox.Show("Merci de remplir les champs obligatoires", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public void MessageWrongPassword()
        {
            MessageBox.Show("Le mot de passe ne correspond pas.");
        }

        
    }
}
