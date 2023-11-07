namespace Restaurant_APP
{
    public class Program
    {
        static void Main(string[] args)
        {           
            MenuReader menuReader = new MenuReader();
            List<MenuItem> menuItems = menuReader.ReadMenu();

            Menu menu = new Menu(menuItems);
            TableReservation tableReservation = new TableReservation();

            Table selectedTable;
            int selectedTableNumber;
            string choise = "";

            while (choise != "6")
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Restaurant APP!");
                Console.WriteLine("");
                Console.WriteLine("1. Show avalaible tables");
                Console.WriteLine("2. Show reserved tables");
                Console.WriteLine("3. Show Menu");
                Console.WriteLine("4. Create order for table");
                Console.WriteLine("5. Print Receipt");
                Console.WriteLine("6. Exit");

                choise = Console.ReadLine();

                if (choise == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Available Tables for reservation:");
                    tableReservation.DisplayAvailableTables();
                    Console.ReadKey();
                }
                else if (choise == "2")
                {                    
                    tableReservation.DisplayReservations();
                }
                else if (choise == "3")
                {
                    menu.DisplayMenu();
                    Console.ReadKey();
                }
                else if (choise == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Available Tables for reservation:");
                    tableReservation.DisplayAvailableTables();
                    Console.WriteLine("");
                    Console.WriteLine("Choise table to create order: ");
                    selectedTableNumber = Convert.ToInt32(Console.ReadLine());
                    selectedTable = tableReservation.GetTableByNumber(selectedTableNumber);
                    if (selectedTable != null)
                    {
                        Console.WriteLine("Enter customer name: ");
                        string customerName = Console.ReadLine();
                        tableReservation.ReserveTable(selectedTable, customerName);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Table {selectedTableNumber} not found.");
                    }
                }
                else if (choise == "5")
                {
                    tableReservation.ReceiptPrint();
                }
                else if (choise == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Your input from the keyboard is not readable, try again!");
                }
            }
        }
    }
}