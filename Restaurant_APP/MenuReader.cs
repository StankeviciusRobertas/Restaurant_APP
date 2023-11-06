using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Restaurant_APP
{
    public class MenuReader
    {
        const string path = "Menu.txt";

        public List<MenuItem> ReadMenu()
        {
            try
            {
                var lines = File.ReadAllLines(path);
                List<MenuItem> menu = new List<MenuItem>();

                foreach (var line in lines)
                {
                    var parts = line.Split('-');                    

                    if (parts.Length == 3)
                    {
                        var mealId = parts[0].Trim();
                        var itemName = parts[1].Trim();
                        var priceString = parts[2].Trim();

                        if (decimal.TryParse(priceString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal itemPrice))
                        {
                            menu.Add(new MenuItem { MealId = mealId, Name = itemName, Price = itemPrice });
                        }
                        else
                        {
                            Console.WriteLine($"Failed to parse decimal: {parts[1].Trim()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Pateiktas blokas Menu formatas: {line}");
                    }
                }
                return menu;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Klaida nuskaitant faila: {ex.Message}");

                throw new Exception("Failed to read the menu.");
            }
        }
    }
}
