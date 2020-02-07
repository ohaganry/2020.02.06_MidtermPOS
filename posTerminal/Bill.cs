using System;
using System.Collections.Generic;
using System.Text;

namespace posTerminal
{
    class Bill
    {
        public double Subtotal { get; set; }

        public double Salestax { get; set; }

        public double Grandtotal { get; set; }

        public Bill()
        {

        }

        public Bill (double subTotal, double grandTotal)
        {
            Subtotal = subTotal;
            Salestax = 0.06;
            Grandtotal = grandTotal;
        }

        public static double CalcSubTotal(List<MenuItem> userCart)
        {
            foreach (var c in userCart)
            {
                var amount = c.Price * c.Quantity;
                Subtotal += amount;
            }
            return Subtotal;
        }

        public static double CalcTotal()
        {
            return Subtotal * (1 + Salestax);
        }

        
    }
}
