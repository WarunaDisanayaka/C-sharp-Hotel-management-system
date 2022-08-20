using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mangement_System
{
     class Room : DBconnection
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public string Type { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }


        public void register(string Name, string Address, string Nic, string Phone)
        {
            DBconnection db = new DBconnection();
            db.Connect();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO customer(cname,caddress,ctel,cnic) VALUES(@name,@address,@tel,@nic)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = Address;
                cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = Phone;
                cmd.Parameters.Add("@nic", MySqlDbType.VarChar).Value = Nic;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }


        }


    }
}
