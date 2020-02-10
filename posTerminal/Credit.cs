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
        //validate expiration date is in correct format
        public static string ValidateExpirationDate(string expirationDate)
        {
            DateTime dt;
            while(!DateTime.TryParse(expirationDate, out dt))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                expirationDate = Methods.GetUserInput("Invalid expiration date. Use format mm/yyyy");
            }
            DateTime expDate = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
            if (Regex.IsMatch(expirationDate, @"^\d{2}/\d{4}$") && DateTime.Compare(DateTime.Now, expDate) <= 0)
            {
                return $"Thank you. {expirationDate} is valid.\n";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return ValidateExpirationDate(Methods.GetUserInput("Invalid entry. Please enter a valid expiration date. (mm/yyyy)"));
            }
        }

        //validate card number is 15 or 16 digits
        public static string ValidateCardNumber(string cardNumber)
        {
            if (Regex.IsMatch(cardNumber, @"^\d{15,16}$"))
            {
                return $"Thank you. Card number valid.\n";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return ValidateCardNumber(Methods.GetUserInput("Invalid entry. Please enter a valid card number."));
            }
        }

        //validate cvv number is 3 or 4 digitd
        public static string ValidateCVV(string cvv)
        {
            if (Regex.IsMatch(cvv, @"^\d{3,4}$"))
            {
                return $"Thank you. CVV is valid.\n";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return ValidateCVV(Methods.GetUserInput("Invalid entry. Please enter a valid CVV number."));
            }
        }

    }
}