using System;
using System.Text.RegularExpressions;

namespace posTerminal
{
    public class Check : Payment
    {
        //properties
        public int CheckNumber { get; set; }

        //contructors
        public Check()
        {

        }

        public Check(int checkNumber)
        {
            CheckNumber = checkNumber;

        }

        //Methods

        //validate check number is between 3 and 4 digits
        public static string ValidateCheckNumber(string checkNumber)
        {
            //Console.WriteLine("Please enter check number:");
            //checkNumber = Console.ReadLine();
            if (Regex.IsMatch(checkNumber, @"^\d{3,4}$"))
            {
                return $"Thank you! Check number added.\n";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return ValidateCheckNumber(Methods.GetUserInput("Invalid entry. Please enter a valid check number."));
            }
        }

        //call this method user chooses to pay with CHECK. 
        public static string CheckPayment(double amountTendered, double grandTotal)
        {
            Console.WriteLine("Please enter the check amount:");
            bool checkAmountValid = false;
            while (checkAmountValid)
            {
                if (amountTendered == grandTotal)
                {
                    checkAmountValid = true;

                }
                else if (amountTendered < grandTotal)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not enough to cover the total.");
                    Console.ResetColor();
                }
                else if (amountTendered > grandTotal)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your check is for too much money!");
                    Console.WriteLine("You can try again, or we can keep the extra as a tip...");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid entry.");
                    Console.ResetColor();
                }
            }
            return "Total: $0.00";
        }
    }
}

    