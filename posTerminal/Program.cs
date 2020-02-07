using System;
using System.Collections.Generic;

namespace posTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the best fast food restaraunt in the world!");

            List<MenuItem> menu = MenuItem.PopulateMenu();
            List<MenuItem> cart = new List<MenuItem>();
            Cash cash = new Cash();
            Credit credit = new Credit();
            Check check = new Check();

            Bill receipt = new Bill();
            bool moreItems = true;

            while (moreItems)
            {
                //Display menu items and prices to customer
                MenuItem.WriteMenu(menu);

                //prompt customer for order number and store it as an int variable
                int item = Methods.CheckRange("Which menu item would you like?", 1, menu.Count);
                Console.WriteLine($"{menu[item - 1].Name} - {menu[item - 1].Price}");
                Console.WriteLine(menu[item - 1].Description);

                //prompt customer for quantity
                int quantity = Methods.CheckRange("How many would you like? (0-5)", 0, 5);

                for (int i = 0; i < quantity; i++)
                {
                    cart.Add(menu[item - 1]);
                }

                Console.WriteLine("You cart:");

                foreach (MenuItem m in cart)
                {
                    Console.WriteLine(m.Name + " " + m.Price);
                }

                receipt.CalcSubTotal(cart);
                Console.WriteLine($"Subtotal: {receipt.Subtotal}");

                moreItems = Methods.ValidateInput("Would you like to add more items? (y/n)");
            }

            receipt.CalcTotal();
            Console.WriteLine($"Grand Total: {receipt.Grandtotal}");

            Console.WriteLine("How would you like to pay?");
            int pay = Methods.CheckRange("1. Cash \n2. Credit \n3. Check", 1, 3);

            switch (pay)
            {
                case 1:
                    cash.AmountTendered = double.Parse(Methods.GetUserInput("Cash Tendered:"));
                    cash.CalcChange(cash.AmountTendered, receipt.Grandtotal);
                    break;

                case 2:

                    break;

                case 3:

                    break;
            }

            Console.WriteLine(cash.Change);







        }
    }
}
