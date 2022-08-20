using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mangement_System
{
    public class DBconnection
    {
        public MySqlConnection conn;
        
        public MySqlConnection Connect()
        {
            string server = "localhost";
            string database = "hoteldata";
            string username = "root";
            string password = "";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(constring);

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                MessageBox.Show("Connected");
            }
            else
            {
                MessageBox.Show("failed");
            }

            return conn;

        }
    }
}
