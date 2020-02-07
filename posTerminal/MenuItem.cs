using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

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

            StreamReader reader = new StreamReader/*("Menu.txt");/*/("../../../Menu.txt");
            string line = reader.ReadLine();

            while(line != null)
            {
                string[] items = line.Split('|');
                menu.Add(new MenuItem(items[0], items[1], double.Parse(items[2]), items[3]));
                line = reader.ReadLine();
            }
            reader.Close();
            
            return menu;
        }

        public static void WriteMenu(List<MenuItem> menu)
        {
            int i = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tMEALS");
            Console.ResetColor();
            foreach(MenuItem item in menu)
            {
                if(item.Category == "Meal")
                {
                    Console.WriteLine($"{i}. {item.Name}   ${item.Price}");
                    i++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tSIDES");
            Console.ResetColor();
            foreach(MenuItem item in menu)
            {
                if(item.Category == "Side")
                {
                    Console.WriteLine($"{i}. {item.Name}   ${item.Price}");
                    i++;
                }
            }
        }
    }
}