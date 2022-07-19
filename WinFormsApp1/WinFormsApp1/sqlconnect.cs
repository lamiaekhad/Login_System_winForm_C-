using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class sqlconnect
    {
        public MySqlConnection connectTobase()
        {
            MySqlConnection cnn;
            string connectionString = "server=localhost;database=security_project;uid=root;pwd=;";
            cnn = new MySqlConnection(connectionString);

            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                
            }
            return cnn;
        }

    }
}
