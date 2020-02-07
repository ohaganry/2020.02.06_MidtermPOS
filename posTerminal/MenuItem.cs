using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace posTerminal
{
    public class MenuItem
    {
        public string Name {get; set;}
        public string Category {get; set;}
        public double Price {get; set;}
        public string Description {get; set;}

        public MenuItem(){}

        public MenuItem(string name, string category, double price, string description)
        {
            Name = name;
            Category = category;
            Price = price;
            Description = description;
        }

        public static List<MenuItem> PopulateMenu()
        {
            List<MenuItem> menu = new List<MenuItem>();

            StreamReader reader = new StreamReader("Menu.txt");//("../../../Menu.txt");
            string line = reader.ReadLine();

            while(line != null)
            {
                string[] items = line.Split('|');
                menu.Add(new MenuItem(items[0], items[1], double.Parse(items[2], NumberStyles.Currency), items[3]));
                line = reader.ReadLine();
            }
            reader.Close();
            
            return menu;
        }

        public static void WriteMenu(List<MenuItem> menu)
        {
            int i = 1;
            foreach(MenuItem item in menu)
            {
                Console.WriteLine($"{i}. {item.Name} - ${item.Price}");
                i++;
            }
        }
    }
}