using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_APP
{
    public class Reservation
    {
        public string CustomerName { get; set; }
        public  Table Table{ get; set; }

        public Reservation(string customerName, Table table)
        {
            CustomerName = customerName;
            Table = table;
        }
    }
}
