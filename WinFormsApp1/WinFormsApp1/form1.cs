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
                command2.Parameters.AddWithValue("motdepasse", security.HashSalt(user.MotDePasse));
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
                else if (ifUserExist())
                {
                    MessageNotExist();
                    ClearBoxText();
                }
                else if (statut2.Equals("oui"))
                {
                    MessageCompteVerrouiller();
                    ClearBoxText();
                }
                else if (count < 3 && statut.Equals("non"))
                {
                     PasswordNotCorrect();
                     ClearBoxText();
                     count = count + 1;
                }
                else if (login.Equals(0) && count >= 3 && statut.Equals(IsOpen))
                {
                    Updatestatut(nomutilisateur1.Text);
                }
              
            }
            catch (Exception ex)
            {
                MessageNotConnectToBD();
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
                MessageNotConnectToBD();
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
                MessageNotConnectToBD();
            }
            finally
            {
                conn1.Close();

            }
            return user.Statut;
        }
        public bool ifUserExist()
        {
            int exist = 0;
            bool valide = false;
            sqlconnect sql = new sqlconnect();
            MySqlConnection conn1 = sql.connectTobase();
            try
            {
                MySqlCommand command2 = new MySqlCommand("select count(*) exist from user where nomutilisateur=@nomutilisateur ", conn1);
                command2.Parameters.AddWithValue("exist", exist);
                command2.Parameters.AddWithValue("nomutilisateur", user.NomUtilisateur);
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
        public void MessageNotExist()
        {
            MessageBox.Show("Le compte n'exist pas", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public void PasswordNotCorrect()
        {
            MessageBox.Show("Le mot de passe est incorrect. essayez à nouveau", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        public void MessageNotConnectToBD()
        {
            MessageBox.Show("Pas de connexion", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void MessageCompteVerrouiller()
        {
            MessageBox.Show("Le compte est verrouillé. Contactez l'administrateur!", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void nomutilisateur1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
