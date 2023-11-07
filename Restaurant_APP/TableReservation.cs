using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_APP
{
    public class TableReservation
    {
        public List<Table> Tables { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Menu RestaurantMenu { get; set; }

        public MenuReader menuReader = new MenuReader();


        public TableReservation()
        {
            Tables = new List<Table>()
            {
                new Table(1),
                new Table(2),
                new Table(3),
                new Table(4),
                new Table(5)
            };

            Reservations = new List<Reservation>();
            List<MenuItem> menuItems = menuReader.ReadMenu();
            RestaurantMenu = new Menu(menuItems);
        }

        private bool IsTableReserved(Table table)
        {
            return Reservations.Exists(r => r.Table == table);
        }

        public void DisplayReservations()
        {
            Console.WriteLine("Reserved tables:");
            foreach (var reservation in Reservations)
            {
                Console.WriteLine($"Table {reservation.Table.TableNumber} - {reservation.CustomerName}");
            }
            Console.ReadKey();
        }

        
        public void DisplayAvailableTables()
        {
            foreach (var table in Tables)
            {
                Console.WriteLine($"{table.TableNumber}");
            }
        }
        public void ReserveTable(Table table, string customerName)
        {
            if (!IsTableReserved(table))
            {
                Reservation newReservation = new Reservation(customerName, table);
                Reservations.Add(newReservation);
                Console.Clear();
                Console.WriteLine($"Table {table.TableNumber} reserved for {customerName}");
                RemoveTable(table);
                CreateOrder(table);
            }
            else
            {
                Console.WriteLine($"Table {table.TableNumber} is already reserver.");
            }
        }

        public Table GetTableByNumber(int tableNumber)
        {
            return Tables.FirstOrDefault(table => table.TableNumber == tableNumber);
        }

        public void CreateOrder(Table table)
        {
            if (IsTableReserved(table))
            {
                Order newOrder = new Order(table);

                RestaurantMenu.DisplayMenu();

                Console.WriteLine("");
                Console.WriteLine("Select menu items by entering their MealId (separated by commas): ");
                string[] selectedMealIds = Console.ReadLine().Split(',');
                List<MenuItem> menu = menuReader.ReadMenu();

                foreach (string mealId in selectedMealIds)
                {
                    MenuItem selectedMeal = menu.FirstOrDefault(item => item.MealId == mealId.Trim());

                    if (selectedMeal != null)
                    {
                        newOrder.AddSelectedMeal(selectedMeal);
                    }
                    else
                    {
                        Console.WriteLine($"Meal with MealId {mealId.Trim()} not found in the menu.");
                    }
                }

                Console.Clear();

                Console.WriteLine("Order details:");
                Console.WriteLine($"Table: {table.TableNumber}");
                Console.WriteLine($"Order time: {newOrder.OrderDateTime}");
                Console.WriteLine("Selected meals:");
                foreach (var meal in newOrder.SelectedMeals)
                {
                    Console.WriteLine($"{meal.Name} - {meal.Price}");                    
                }
                Console.WriteLine("");
                Console.WriteLine($"Total price: {newOrder.TotalPrice}");
            }
            else
            {
                Console.WriteLine($"Table {table.TableNumber} is not reserved. Cannot create an order.");
            }            
        }
        public void RemoveTable(Table table)
        {
            Tables.Remove(table);
        }
    }
}