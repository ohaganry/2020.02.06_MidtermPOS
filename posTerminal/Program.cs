using System;
using System.Collections.Generic;

namespace posTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MenuItem> menu = new List<MenuItem>();
            menu = MenuItem.PopulateMenu();
            MenuItem.WriteMenu(menu);
        }
    }
}
