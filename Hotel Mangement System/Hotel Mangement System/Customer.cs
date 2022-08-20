using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hotel_Mangement_System
{
    class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int Nic { get; set; }

        public int Phone { get; set; }

        DBconnection db = new DBconnection();

        

        //update

        public void update(string Name, string Address, string Nic, string Phone)
        {
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE customer SET `cname`=@name,`caddress`=@address,`ctel`=@tel WHERE `cnic`=@nic";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = Address;
                cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = Phone;
                cmd.Parameters.Add("@nic", MySqlDbType.VarChar).Value = Nic;
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = Id;

                cmd.ExecuteNonQuery();
                db.conn.Close();
            }
        }

    }
}
