using System;
using System.Text;
using System.Collections.Generic;
namespace posTerminal
{
    public class Methods
    {
         public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static bool ValidateInput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string usertInput = GetUserInput(message).ToLower();
            if(usertInput == "y")
            {
                return true;
            }
            else if(usertInput == "n")
            {
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
                return ValidateInput(message);
            }
        } 

        public static int CheckRange(string prompt, int rangeLower, int rangeUpper)
        {
            int number = 0;
            bool realnum = true;
            string input = GetUserInput(prompt);
            while(realnum)
            {
                if(int.TryParse(input, out number) && number >= rangeLower && number <= rangeUpper)
                {
                    realnum = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    input = Methods.GetUserInput($"Invalid Input. Input must be {rangeLower}-{rangeUpper}");
                }
            }
            return number;
        }            
    }

}