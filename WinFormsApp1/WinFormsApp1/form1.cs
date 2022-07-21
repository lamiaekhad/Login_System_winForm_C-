using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        User user = new User();
        public Form1()
        {
            InitializeComponent();
            motdepasse1.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        int count = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            int login = 0;
            sqlconnect sql = new sqlconnect();
            MySqlConnection conn1 = sql.connectTobase();

            user.NomUtilisateur = nomutilisateur1.Text;
            user.MotDePasse = motdepasse1.Text;

            try
            {
                string statut2 = GetStatut(nomutilisateur1.Text);
                string statut= "non";
                MySqlCommand command2 = new MySqlCommand("select count(*) login from user where nomutilisateur=@nomutilisateur and motdepasse=@motdepasse and statut=@statut", conn1);
                command2.Parameters.AddWithValue("login", login);
                command2.Parameters.AddWithValue("nomutilisateur", user.NomUtilisateur);
                command2.Parameters.AddWithValue("motdepasse", security.Hash(user.MotDePasse + security.Selage()));
                command2.Parameters.AddWithValue("statut",statut);

                using (MySqlDataReader reader = command2.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            login = reader.GetInt32("login");
                        }
                    }
                }
               
                if (!login.Equals(0))
                {
                    Main main = new Main();
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
                    ClearBoxText();
                    nomutilisateur1.Focus();
                }
                else if (statut2=="oui")
                {
                    MessageBox.Show("Le compte est verrouille. Contactez l'administrateur!", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearBoxText();
                }
                else if (count < 3 && statut=="non")
                {
                     MessageBox.Show("Le mot de passe est incorrect. essayez à nouveau", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     ClearBoxText();
                     count = count + 1;
                
                }
                else if (login.Equals(0) && count >= 3 && statut == "non")
                {
                    Updatestatut(nomutilisateur1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pas de connexion", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn1.Close();
            }
        }

        public void ClearBoxText()
        {
            nomutilisateur1.Text = "";
            motdepasse1.Text = "";
        }
        public void Updatestatut(string nomutilisateur)
        {
            sqlconnect sql = new sqlconnect();
            MySqlConnection conn1 = sql.connectTobase();
            try
            {
                MySqlCommand command = new MySqlCommand("update user set statut = @statut  where nomutilisateur = @nomutilisateur", conn1);
                command.Parameters.AddWithValue("statut", "oui");
                command.Parameters.AddWithValue("nomutilisateur", nomutilisateur);
                command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pas de connexion", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn1.Close();
            }
        }
        public string GetStatut(string nomutilisateur)
        {
            sqlconnect sql = new sqlconnect();
            MySqlConnection conn1 = sql.connectTobase();
            try
            {

                MySqlCommand command = new MySqlCommand("select statut from user where nomutilisateur = @nomutilisateur", conn1);
                command.Parameters.AddWithValue("nomutilisateur", nomutilisateur);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.Statut = reader.GetString("statut");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pas de connexion", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn1.Close();

            }
            return user.Statut;
        }

        private void motdepasse1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
