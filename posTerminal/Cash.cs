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

        //method
        public static double CalcChange(double amountTendered , double grandTotal)
        {
            double change = grandTotal - amountTendered;
            return change;
        }


    }
}