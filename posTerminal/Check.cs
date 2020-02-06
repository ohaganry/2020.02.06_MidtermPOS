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

    public static string ValidateCheckNumber(string checkNumber)
        {
            if (Regex.IsMatch(checkNumber, @"^\d{3,4}$"))
            {
                return $"Thank you! Check number added.\n";
            }
            else
            {
                return ValidateCheckNumber(GetUserInput("Invalid entry. Please enter a valid check number."));
            }
        }

        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
           string input = Console.ReadLine();
           return input;
        }
    }
}