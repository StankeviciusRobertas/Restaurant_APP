namespace Restaurant_APP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Restaurant APP!");

            MenuReader menuReader = new MenuReader();
            List<MenuItem> menuItems = menuReader.ReadMenu();

            Menu menu = new Menu(menuItems);
            TableReservation tableReservation = new TableReservation();

            Console.WriteLine("Laisvi stalai:");
            Console.WriteLine("");
            tableReservation.DisplayAvailableTables();

            Console.WriteLine("Pasirinkite staliuka, kuriam bus uzsakymas: ");
            int selectedTableNumber = Convert.ToInt32(Console.ReadLine());
            Table selectedTable = tableReservation.GetTableByNumber(selectedTableNumber);
            if (selectedTable != null)
            {
                Console.WriteLine("Iveskite varda: ");
                string customerName = Console.ReadLine();
                tableReservation.ReserveTable(selectedTable, customerName);
            }
            else
            {
                Console.WriteLine($"Staliukas {selectedTableNumber} nerastas.");
            }

            tableReservation.CreateOrder(selectedTable);
            Console.WriteLine("");
            Console.WriteLine("Laisvi staliukai: ");
            tableReservation.DisplayAvailableTables();

        }
    }
}