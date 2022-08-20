using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mangement_System
{
    class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public int Nic { get; set; }

        public int Phone { get; set; }


        public void register(string Name,string Address,int Nic,int Phone)
        {
            
        }

    }
}
