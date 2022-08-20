using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hotel_Mangement_System
{
    public class Book
    {
        public string RoomID { get; set; }
        public string ClientID { get; set; }
        public int Price { get; set; }
        public string BookDate { get; set; }
        public string DeDate { get; set; }
        public int NoOfRoom { get; set; }
        public int ID { get; set; }

        DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        public AutoCompleteStringCollection collection = new AutoCompleteStringCollection();


        public void register(string RoomID, string ClientID, int Price, string BookDate, string DeDate, int NoOfRoom)
        {
            DBconnection db = new DBconnection();
            db.Connect();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO `books`(`Booked_Room_ID`, `Booked_Client_ID`, `Booked_Price`, `Booked_Date`, `Booked_Departure_Date`, `No_Of_Rooms`) VALUES (@rid,@cid,@bprice,@bdate,@bddate,@noroom)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@rid", MySqlDbType.VarChar).Value = RoomID;
                cmd.Parameters.Add("@cid", MySqlDbType.VarChar).Value = ClientID;
                cmd.Parameters.Add("@bprice", MySqlDbType.VarChar).Value = Price;
                cmd.Parameters.Add("@bdate", MySqlDbType.VarChar).Value = BookDate;
                cmd.Parameters.Add("@bddate", MySqlDbType.VarChar).Value = DeDate;
                cmd.Parameters.Add("@noroom", MySqlDbType.VarChar).Value = NoOfRoom;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }


        }

        //update

        public void update(int ID, string RoomID, string ClientID, int Price, string BookDate, string DeDate, int NoOfRoom)
        {
            DBconnection db = new DBconnection();
            db.Connect();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE `books` SET `Booked_Room_ID`=@rid,`Booked_Client_ID`=@cid,`Booked_Price`=@bprice,`Booked_Date`=@bdate,`Booked_Departure_Date`=@bddate,`No_Of_Rooms`=@noroom WHERE id = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@rid", MySqlDbType.VarChar).Value = RoomID;
                cmd.Parameters.Add("@cid", MySqlDbType.VarChar).Value = ClientID;
                cmd.Parameters.Add("@bprice", MySqlDbType.VarChar).Value = Price;
                cmd.Parameters.Add("@bdate", MySqlDbType.VarChar).Value = BookDate;
                cmd.Parameters.Add("@bddate", MySqlDbType.VarChar).Value = DeDate;
                cmd.Parameters.Add("@noroom", MySqlDbType.VarChar).Value = NoOfRoom;
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID;



                cmd.ExecuteNonQuery();
                db.conn.Close();
            }


        }

        //delete

        public void delete(int ID)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM `books` WHERE `id`=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;


                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID;


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
            string sql = "SELECT * FROM `books`";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, db.conn);
            mda.Fill(ds);
            dt = ds.Tables[0];
        }

        // get room data

        public void roomdata()
        {
            DBconnection db = new DBconnection();
            db.Connect();
            dt.Clear();
            string sql = "SELECT * FROM `room`";
            MySqlCommand cmd = new MySqlCommand(sql,db.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                collection.Add(reader["Room_Name"].ToString());

            }
        }
    }
}
