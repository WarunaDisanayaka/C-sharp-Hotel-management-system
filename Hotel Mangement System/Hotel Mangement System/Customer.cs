using MySql.Data.MySqlClient;
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

        DataSet ds = new DataSet();
        public DataTable dt = new DataTable();



        public void register(string Name,string Address,string Nic,string Phone)
        {
            DBconnection db = new DBconnection();
            db.Connect();
       
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO customer(Customer_Name,Customer_Address,Customer_Tel,Customer_NIC) VALUES(@name,@address,@tel,@nic)";
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


        public void update(string Name, string Address, string Nic, string Phone)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE customer SET `Customer_Name`=@name,`Customer_Address`=@address,`Customer_Tel`=@tel WHERE `Customer_NIC`=@nic";
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

        //delete

        public void delete(string Nic)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM `customer` WHERE `Customer_NIC`=@nic";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;


                cmd.Parameters.Add("@nic", MySqlDbType.VarChar).Value = Nic;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }
        }

        public void read()
        {
            DBconnection db = new DBconnection();
            db.Connect();
            dt.Clear();
            string sql = "SELECT * FROM `customer`";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql,db.conn);
            mda.Fill(ds);
            dt = ds.Tables[0];
        }

    }
}
