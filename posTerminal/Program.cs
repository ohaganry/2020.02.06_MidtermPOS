using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace posTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the best fast food restaraunt in the world!");

            List<MenuItem> menu = MenuItem.PopulateMenu();

            bool open = true;
            while (open)
            {
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int item = Methods.CheckRange("Which menu item would you like?", 1, menu.Count);
                    Console.WriteLine($"{menu[item - 1].Name}  {menu[item - 1].Price}");
                    Console.WriteLine(menu[item - 1].Description);

                    //prompt customer for quantity
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int quantity = Methods.CheckRange("How many would you like? (0-5)", 0, 5);

                    for (int i = 0; i < quantity; i++)
                    {
                        cart.Add(menu[item - 1]);
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You cart:");
                    Console.ResetColor();

                    foreach (MenuItem m in cart)
                    {
                        Console.WriteLine(m.Name + " " + m.Price);
                    }

                    receipt.CalcSubTotal(cart);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Subtotal: {receipt.Subtotal:C2}");

                    moreItems = Methods.ValidateInput("Would you like to add more items? (y/n)");
                }

                receipt.CalcTotal();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Grand Total: {receipt.Grandtotal:C2}");

                Console.WriteLine("How would you like to pay?");
                int pay = Methods.CheckRange("1. Cash \n2. Credit \n3. Check", 1, 3);
                string payType = "";

                switch (pay)
                {
                    case 1:

                        bool validCash = true;
                        while (validCash)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            string s = (Methods.GetUserInput("Cash Tendered:"));

                            if (Regex.IsMatch(s, @"^((\d{3})|\d+)\.\d{2}$") || Regex.IsMatch(s, @"^(\d{1,3})$"))
                            {
                                
                                cash.AmountTendered = double.Parse(s);
                                validCash = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid entry. Please enter a valid cash amount please.");
                                Console.ResetColor();

                            }
                            if (cash.AmountTendered >= receipt.Grandtotal)
                            {
                               
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("more money please");
                                Console.ResetColor();
                                validCash = true;
                            }
                            cash.CalcChange(cash.AmountTendered, receipt.Grandtotal);
                            payType = "Cash";
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Thank you!");
                        Console.ResetColor();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Credit.ValidateCardNumber(Methods.GetUserInput("Enter 15-16 digit card number:"));
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Credit.ValidateExpirationDate(Methods.GetUserInput("Enter expiration date (mm/yyyy):"));
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Credit.ValidateCVV(Methods.GetUserInput("Enter the 3-4 digit CVV number:"));
                        payType = "Credit";
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Check.ValidateCheckNumber(Methods.GetUserInput("Enter the 3-4 digit check number:"));
                        payType = "Check";
                        break;
                }

                //receipt
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nReceipt");
                Console.ResetColor();
                foreach (MenuItem m in cart)
                {
                    Console.WriteLine($"{m.Name} \t {m.Price}");
                }
                Console.WriteLine("");
                Console.WriteLine($"Subtotal: {receipt.Subtotal:C2}");
                Console.WriteLine($"Tax: {receipt.Subtotal * receipt.Salestax:C2}");
                Console.WriteLine($"Total: {receipt.Grandtotal:C2}");
                Console.WriteLine($"Payment type: {payType}");
                if (payType == "Cash")
                {
                    Console.WriteLine($"Amount Tendered: {cash.AmountTendered:C2}");
                    Console.WriteLine($"Change Due: {cash.Change:C2}");
                }
                else
                {

                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                open = Methods.ValidateInput("Would you like to make another order? (y/n)");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Thank you, come again!");
        }
    }
}
