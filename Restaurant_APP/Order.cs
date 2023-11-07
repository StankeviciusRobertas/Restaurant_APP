using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_APP
{
    public class Order
    {
        public Table Table { get; set; }
        public List<MenuItem> SelectedMeals { get; set; }
        public DateTime OrderDateTime { get; }
        public decimal TotalPrice { get; set; }

        public Order(Table table)
        {
            Table = table;
            SelectedMeals = new List<MenuItem>();
            OrderDateTime = DateTime.Now;
            TotalPrice = 0;
        }

        public Order()
        {
        }

        public void AddSelectedMeal(MenuItem selectedMeal)
        {
            SelectedMeals.Add(selectedMeal);
            TotalPrice += selectedMeal.Price; 
        }
    }
}
