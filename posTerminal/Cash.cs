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
        public void CalcChange(double amountTendered , double grandTotal)
        {
            Change = amountTendered - grandTotal;

        }

    }
}