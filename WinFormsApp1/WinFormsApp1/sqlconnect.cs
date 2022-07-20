using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    internal class sqlconnect
    {
        public MySqlConnection connectTobase()
        {
            MySqlConnection cnn;
            string connectionString = "server=localhost;database=data_login;uid=root;pwd=;";
            cnn = new MySqlConnection(connectionString);

            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Pas de connexion", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return cnn;
        }

    }
}
