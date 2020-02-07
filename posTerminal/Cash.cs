namespace posTerminal
{
    public class Cash : Payment
    {

        //properties
        public double AmountTendered { get; set; }
        public double Change { get; set; }

        //constructors
        public Cash()
        {
         
        }

        public Cash(double amountTendered)
        {
            AmountTendered = amountTendered;

        }

        //methods

            //take user's cash and give them change
        public static double CalcChange(double amountTendered , double grandTotal)
        {
            double change = grandTotal - amountTendered;
            return change;
        }


        //Call this method when user wants to pay with CASH
        public static double CashPayment(double amountTendered, double grandTotal)
        {
            return CalcChange(amountTendered, grandTotal);
        }
    }
}