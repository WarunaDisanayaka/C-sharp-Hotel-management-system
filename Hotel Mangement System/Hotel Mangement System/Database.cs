using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Hotel_Mangement_System
{
    public class databaseconnect
    {
        public void connect()
        {
            string myConnectionString = "server=localhost;database=hoteldata;uid=root;pwd='';";


            MySqlConnection cnn;

            cnn = new MySqlConnection(myConnectionString);
            try
            {
                cnn.Open();
                
                Console.WriteLine("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("can not connect");
            }

        }

    }

    internal class Database
    {
        
    }
}
