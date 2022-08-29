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
    public partial class formulaireConnexion : Form
    {
        User user = new User();
       
        public formulaireConnexion()
        {
            InitializeComponent();
            motdepasse1.PasswordChar = '*';
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            FormulaireInscription formulaireInscription = new FormulaireInscription();
            this.Hide();
            formulaireInscription.ShowDialog();
            this.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int login = 0;
            sqlconnect sql = new sqlconnect();
            MySqlConnection conn1 = sql.connectTobase();

            user.NomUtilisateur = nomutilisateur1.Text;
            user.MotDePasse = motdepasse1.Text;
            string Islock = "oui";
            string IsOpen = "non";
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
                    initializecount(user.NomUtilisateur);
                    ClearBoxText();
                    nomutilisateur1.Focus();
                }
                else if (user.NomUtilisateur.Equals(""))
                {
                    Messages.MessageNomUtilisateurVide();
                    nomutilisateur1.Focus();
                }
                else if (user.MotDePasse.Equals(""))
                {
                    Messages.MessageMotDePasseVide();
                    motdepasse1.Focus();
                }
                else if (ifUserExist())
                {
                    Messages.MessageNotExist();
                    ClearBoxText();
                }
                else if (statut2.Equals(Islock))
                {
                    Messages.MessageCompteVerrouiller();
                    ClearBoxText();

                }
                else if (Getcount(user.NomUtilisateur)< 3 && statut.Equals(IsOpen))
                {
                    Messages.PasswordNotCorrect();
                    ClearBoxText();
                    Updatecount(user.NomUtilisateur, Getcount(user.NomUtilisateur));
                }
                else if (login.Equals(0) && Getcount(user.NomUtilisateur) >= 3 && statut.Equals(IsOpen))
                {
                    Updatestatut(user.NomUtilisateur);
                }
            }
            catch (Exception ex)
            {
                Messages.MessageNotConnectToBD();
            }
            finally
            {
                conn1.Close();
            }
        }
       
        public void ClearBoxText()
        {
            nomutilisateur1.Clear();
            motdepasse1.Clear();
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
                Messages.MessageNotConnectToBD();
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
                Messages.MessageNotConnectToBD();
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
               Messages.MessageNotConnectToBD();
            }
            finally
            {
                conn1.Close();
            }
            return valide;

        }
        public int Getcount(string nomutilisateur)
        {
            int count=0;
            sqlconnect sql = new sqlconnect();
            MySqlConnection conn1 = sql.connectTobase();
            try
            {
                MySqlCommand command = new MySqlCommand("select thecount from user where nomutilisateur = @nomutilisateur", conn1);
                command.Parameters.AddWithValue("nomutilisateur", nomutilisateur);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32("thecount");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.MessageNotConnectToBD();
            }
            finally
            {
                conn1.Close();

            }
            return count;
        }
        public void Updatecount(string nomutilisateur, int thecount)
        {
            sqlconnect sql = new sqlconnect();
            MySqlConnection conn1 = sql.connectTobase();
            try
            {
                MySqlCommand command = new MySqlCommand("update user set thecount = @thecount  where nomutilisateur = @nomutilisateur", conn1);
                command.Parameters.AddWithValue("thecount", ++thecount);
                command.Parameters.AddWithValue("nomutilisateur", nomutilisateur);
                command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Messages.MessageNotConnectToBD();
            }
            finally
            {
                conn1.Close();
            }
        }
        public void initializecount(string nomutilisateur)
        {
            sqlconnect sql = new sqlconnect();
            MySqlConnection conn1 = sql.connectTobase();
            try
            {
                MySqlCommand command = new MySqlCommand("update user set thecount = @thecount  where nomutilisateur = @nomutilisateur", conn1);
                command.Parameters.AddWithValue("thecount", 0);
                command.Parameters.AddWithValue("nomutilisateur", nomutilisateur);
                command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Messages.MessageNotConnectToBD();
            }
            finally
            {
                conn1.Close();
            }
        }

    }

}
