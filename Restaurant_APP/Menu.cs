using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_APP
{
    public class Menu
    {
        public List<MenuItem> MenuItems { get; private set; }

        public Menu(List<MenuItem> menuItems)
        {
            MenuItems = menuItems;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Restaurant Menu:");
            foreach (var menuItem in MenuItems)
            {
                Console.WriteLine($"{menuItem}");
            }            
        }
    }
}
