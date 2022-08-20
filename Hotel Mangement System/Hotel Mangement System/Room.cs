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

        public string RID { get; set; }

        public string Type { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int ID { get; set; }

        DataSet ds = new DataSet();
        public DataTable dt = new DataTable();


        public void register(string Name, string RID, string Type, int Price, string Description)
        {
            DBconnection db = new DBconnection();
            db.Connect();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO `room`(`Room_Name`, `Room_ID`, `Room_Type`, `Room_Price`, `Room_Description`) VALUES (@name,@rid,@rtype,@rprice,@rdis)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@rid", MySqlDbType.VarChar).Value = RID;
                cmd.Parameters.Add("@rtype", MySqlDbType.VarChar).Value = Type;
                cmd.Parameters.Add("@rprice", MySqlDbType.VarChar).Value = Price;
                cmd.Parameters.Add("@rdis", MySqlDbType.VarChar).Value = Description;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }


        }

        //update

        public void update(string Name, string RID, string Type, int Price, string Description)
        {
            DBconnection db = new DBconnection();
            db.Connect();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE `room` SET `Room_Name`=@name,`Room_Type`=@rtype,`Room_Price`=@rprice,`Room_Description`=@rdis WHERE `Room_ID`=@rid";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@rid", MySqlDbType.VarChar).Value = RID;
                cmd.Parameters.Add("@rtype", MySqlDbType.VarChar).Value = Type;
                cmd.Parameters.Add("@rprice", MySqlDbType.VarChar).Value = Price;
                cmd.Parameters.Add("@rdis", MySqlDbType.VarChar).Value = Description;
                


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }


        }

        //delete

        public void delete(string RID)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM `room` WHERE `Room_ID`=@rid";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;


                cmd.Parameters.Add("@rid", MySqlDbType.VarChar).Value = RID;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }
        }

        //read

        public void read()
        {
            DBconnection db = new DBconnection();
            db.Connect();
            dt.Clear();
            string sql = "SELECT * FROM `room`";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, db.conn);
            mda.Fill(ds);
            dt = ds.Tables[0];
        }


    }
}
