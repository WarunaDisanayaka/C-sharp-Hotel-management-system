﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mangement_System
{
    
    class Customer : DBconnection
    {

        public string Name { get; set; }
        public string Address { get; set; }

        public string Nic { get; set; }

        public string Phone { get; set; }


        public void register(string Name,string Address,string Nic,string Phone)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            
            string sql = "INSERT INTO customer(cname,caddress,ctel,cnic)VALUES('"+Name+"','"+Address+"','"+Nic+"','"+Phone+"')";
          
            MySqlCommand cm = new MySqlCommand(sql,conn);
            conn.Open();
            if (cm.ExecuteNonQuery()==1)
            {

            }
            else
            {
                MessageBox.Show("Data not instered");
            }

           

        }


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
