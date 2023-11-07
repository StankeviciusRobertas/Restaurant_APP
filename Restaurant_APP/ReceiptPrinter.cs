using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_APP
{
    public class ReceiptPrinter : IReceipt
    {
        private readonly TableReservation tableReservation;

        public ReceiptPrinter(TableReservation tableReservation)
        {
            this.tableReservation = tableReservation;
        }

        public void ReceiptPrint()
        {
            Console.WriteLine("Order Receipt");
            Console.WriteLine($"Table: {tableReservation.table.TableNumber}");
            Console.WriteLine($"Order time: {tableReservation.newOrder.OrderDateTime}");
            Console.WriteLine("Ordered meals: ");
            foreach (var meal in tableReservation.newOrder.SelectedMeals)
            {
                Console.WriteLine($"{meal.Name} - {meal.Price}");
            }
            Console.WriteLine("");
            Console.WriteLine($"Total price: {tableReservation.newOrder.TotalPrice}");
            Console.ReadKey();
        }
    }
}
