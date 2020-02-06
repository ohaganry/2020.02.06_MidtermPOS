using System;
using System.Text.RegularExpressions;

namespace posTerminal
{
    public class Credit : Payment
    {
        //properties
        public int CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int CVV { get; set; }

        //constructors
        public Credit()
        {

        }

        public Credit(int cardNumber, string expirationDate, int cvv)
        {
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            CVV = cvv;
        }


        //methods
        public static string ValidateExpirationDate(string expirationDate)
        {
            if (Regex.IsMatch(expirationDate, @"^\d{15,16}$"))
            {
                return $"Thank you. {expirationDate} is valid.\n";
            }
            else
            {
                return ValidateCardNumber(GetUserInput("Invalid entry. Please enter a valid expiration date. (mm/yy)"));
            }
        }

        public static string ValidateCardNumber(string cardNumber)
        {
            if (Regex.IsMatch(cardNumber, @"^\d{15,16}$"))
            {
                return $"Thank you. Card number valid.\n";
            }
            else
            {
                return ValidateCardNumber(GetUserInput("Invalid entry. Please enter a valid card number."));
            }
        }

        public static string ValidateCVV(string cvv)
        {
            if (Regex.IsMatch(cvv, @"^\d{3,4}$"))
            {
                return $"Thank you. CVV is valid.\n";
            }
            else
            {
                return ValidateCardNumber(GetUserInput("Invalid entry. Please enter a valid CVV number."));
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