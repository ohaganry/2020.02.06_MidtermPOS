using System;
using System.Collections.Generic;

namespace posTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MenuItem> menu = MenuItem.PopulateMenu(); 
            MenuItem.WriteMenu(menu);

            int item = Methods.CheckRange("Which menu item would you like?", 1, menu.Count);
            Console.WriteLine(menu[item - 1].Name);
        }
    }
}
