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
            sqlconnect Tosql = new sqlconnect();
           
            MySqlConnection conn = Tosql.connectTobase();
            string message = string.Empty;


            valide.validationString(nom.Text);
            valide.validationString(prenom.Text);
            if (nomutilisateur != motdepasse)
            {
                MessageBox.Show("Confirmation de mot de passe incorrect", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            try
                {
                    string sql = "INSERT INTO user(Nom, prenom, nomutilisateur, courriel, motdepasse, confirmation)" +
                                 "VALUES (@nom, @prenom, @nomutilisatreur, @courriel, @motdepasse, @confirmation)";

                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@nom", user.Nom);
                    command.Parameters.AddWithValue("@prenom", prenom.Text);
                    command.Parameters.AddWithValue("@nomutilisatreur", nomutilisateur.Text);
                    command.Parameters.AddWithValue("@courriel", courriel.Text);
                    command.Parameters.AddWithValue("@motdepasse", motdepasse.Text);
                    command.Parameters.AddWithValue("@confirmation", confirmation.Text);

                    command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    message = "Something went wrong " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
                MessageBox.Show("Data has saved in database");

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
    }
}
