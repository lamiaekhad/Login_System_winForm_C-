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

        private void button2_Click(object sender, EventArgs e)
        {
            sqlconnect sql = new sqlconnect();
            
            int login = 0;
            bool valide = false;

            MySqlConnection conn1 = sql.connectTobase();
            try
            {
                MySqlCommand command2 = new MySqlCommand("select count(*) login from user where nomutilisateur=@nomutilisateur and motdepasse=@motdepasse", conn1);
                command2.Parameters.AddWithValue("login", login);
                command2.Parameters.AddWithValue("nomutilisateur",nomutilisateur1.Text);
                command2.Parameters.AddWithValue("motdepasse", security.Hash(motdepasse1.Text));
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
                if (login.Equals(0))
                {
                    valide = true;
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorect ", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Main main = new Main();
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("pas de connexion", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn1.Close();
            }
        
        }
    }
}
