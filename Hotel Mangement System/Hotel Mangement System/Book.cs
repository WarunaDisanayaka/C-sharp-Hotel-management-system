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
        public string Nochild { get; set; }
        public string Noadults { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }

        DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        public AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        public AutoCompleteStringCollection client = new AutoCompleteStringCollection();
        public float totalprice = 0;


        public void register(string RoomID, string ClientID, int Price, string BookDate, string DeDate, int NoOfRoom, string Nochild, string Noadults, string Breakfast, string Lunch, string Dinner)
        {
            DBconnection db = new DBconnection();
            db.Connect();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO `books`(`Booked_Room_ID`, `Booked_Client_ID`, `Booked_Price`, `Booked_Date`, `Booked_Departure_Date`, `No_Of_Rooms`, `No_Of_Children`, `No_Of_Adults`, `Breakfast`, `Lunch`, `Dinner`) VALUES (@rid,@cid,@bprice,@bdate,@bddate,@noroom,@nochild,@noadults,@break,@lunch,@dinner)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@rid", MySqlDbType.VarChar).Value = RoomID;
                cmd.Parameters.Add("@cid", MySqlDbType.VarChar).Value = ClientID;
                cmd.Parameters.Add("@bprice", MySqlDbType.VarChar).Value = Price;
                cmd.Parameters.Add("@bdate", MySqlDbType.VarChar).Value = BookDate;
                cmd.Parameters.Add("@bddate", MySqlDbType.VarChar).Value = DeDate;
                cmd.Parameters.Add("@noroom", MySqlDbType.VarChar).Value = NoOfRoom;
                cmd.Parameters.Add("@nochild", MySqlDbType.VarChar).Value = Nochild;
                cmd.Parameters.Add("@noadults", MySqlDbType.VarChar).Value = Noadults;
                cmd.Parameters.Add("@break", MySqlDbType.VarChar).Value = Breakfast;
                cmd.Parameters.Add("@lunch", MySqlDbType.VarChar).Value = Lunch;
                cmd.Parameters.Add("@dinner", MySqlDbType.VarChar).Value = Dinner;


                cmd.ExecuteNonQuery();
                db.conn.Close();
            }


        }

        //update

        public void update(string RoomID,int Price, string BookDate, string DeDate, int NoOfRoom, int Nochild, int Noadults, string Breakfast, string Lunch, string Dinner,string ClientID)
        {
            DBconnection db = new DBconnection();
            db.Connect();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE `books` SET `Booked_Room_ID`=@rid,`Booked_Price`=@bprice,`Booked_Date`=@bdate,`Booked_Departure_Date`=@bddate,`No_Of_Rooms`=@noroom,`No_Of_Children`=@nochild,`No_Of_Adults`=@noadults,`Breakfast`=@break,`Lunch`=@lunch,`Dinner`=@dinner WHERE `Booked_Client_ID`=@cid";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;

                cmd.Parameters.Add("@rid", MySqlDbType.VarChar).Value = RoomID;
                cmd.Parameters.Add("@bprice", MySqlDbType.VarChar).Value = Price;
                cmd.Parameters.Add("@bdate", MySqlDbType.VarChar).Value = BookDate;
                cmd.Parameters.Add("@bddate", MySqlDbType.VarChar).Value = DeDate;
                cmd.Parameters.Add("@noroom", MySqlDbType.VarChar).Value = NoOfRoom;
                cmd.Parameters.Add("@nochild", MySqlDbType.VarChar).Value = Nochild;
                cmd.Parameters.Add("@noadults", MySqlDbType.VarChar).Value = Noadults;
                cmd.Parameters.Add("@break", MySqlDbType.VarChar).Value = Breakfast;
                cmd.Parameters.Add("@lunch", MySqlDbType.VarChar).Value = Lunch;
                cmd.Parameters.Add("@dinner", MySqlDbType.VarChar).Value = Dinner;
                cmd.Parameters.Add("@cid", MySqlDbType.VarChar).Value = ClientID;



                cmd.ExecuteNonQuery();
                db.conn.Close();
            }


        }

        //delete

        public void delete(string ClientID)
        {
            DBconnection db = new DBconnection();
            db.Connect();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM `books` WHERE `Booked_Client_ID`=@cid";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db.conn;


                
                cmd.Parameters.Add("@cid", MySqlDbType.VarChar).Value = ClientID;


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
                collection.Add(reader["Room_ID"].ToString());

            }
        }

        public void clientdata()
        {
            DBconnection db = new DBconnection();
            db.Connect();
            dt.Clear();
            string sql = "SELECT * FROM `customer`";
            MySqlCommand cmd = new MySqlCommand(sql, db.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                client.Add(reader["Customer_NIC"].ToString());

            }
        }

        public void pricecal(string RoomID, string BookDate, string DeDate, int NoOfRoom)
        {
            float price = 0;
            int bdate = int.Parse(BookDate);
            int dedate = int.Parse(DeDate);
            int nroom = NoOfRoom;

            DBconnection db = new DBconnection();
            db.Connect();
            string sql = "SELECT * FROM `room` where Room_ID = '"+RoomID+"'";

            MySqlCommand cmd = new MySqlCommand(sql, db.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                price = float.Parse(reader["Room_Price"].ToString());
            }

            int stdays = dedate - bdate;

            float sum = stdays * nroom * price;

            totalprice = sum;
            



        }
    }
}
