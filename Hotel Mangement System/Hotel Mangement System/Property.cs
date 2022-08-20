using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mangement_System
{
    class Property
    {

        public string itemName { get; set; }

        public string itemCategory { get; set; }

        public int itemNo { get; set; }

        public decimal itemPrice { get; set; }

        public string date { get; set; }


        DataSet ds = new DataSet();
        public DataTable dt = new DataTable();


        public void add(string itemName, string itemCategory ,int itemNo, decimal itemPrice,string date)
        {
            DBconnection db = new DBconnection();
            db.Connect();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO property(itemName,itemCategory,itemNo,itemPrice,addDate) VALUES(@itemName,@itemCategory,@itemNo,@itemPrice,@date)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@itemName", MySqlDbType.VarChar).Value = itemName;
                cmd.Parameters.Add("@itemCategory", MySqlDbType.VarChar).Value = itemCategory;
                cmd.Parameters.Add("@itemNo", MySqlDbType.VarChar).Value = itemNo;
                cmd.Parameters.Add("@itemPrice", MySqlDbType.VarChar).Value = itemPrice;
                cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }


        }


        public void update(string itemName, string itemCategory, int itemNo, decimal itemPrice, string date,int id)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE property SET `itemName`=@itemName,`itemCategory`=@itemCategory,`itemNo`=@itemNo ,`itemPrice`=@itemPrice ,`addDate`=@addDate WHERE `id`=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@itemName", MySqlDbType.VarChar).Value = itemName;
                cmd.Parameters.Add("@itemCategory", MySqlDbType.VarChar).Value = itemCategory;
                cmd.Parameters.Add("@itemNo", MySqlDbType.VarChar).Value = itemNo;
                cmd.Parameters.Add("@itemPrice", MySqlDbType.VarChar).Value = itemPrice;
                cmd.Parameters.Add("@addDate", MySqlDbType.VarChar).Value = date;
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }
        }


        public void delete(int id)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM `property` WHERE `id`=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;


                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }
        }


        public void read()
        {
            DBconnection db = new DBconnection();
            db.Connect();
            dt.Clear();
            string sql = "SELECT * FROM `property`";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, db.conn);
            mda.Fill(ds);
            dt = ds.Tables[0];
        }


    }
}
