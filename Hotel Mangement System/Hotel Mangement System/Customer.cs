using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

    }
}
