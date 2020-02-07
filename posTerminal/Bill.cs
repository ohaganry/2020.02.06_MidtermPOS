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

        public double CalcSubTotal(List<MenuItem> userCart)
        {
            foreach (var c in userCart)
            {
                Subtotal += c.Price;
            }
            return Subtotal;
        }

        public double CalcTotal()
        {
            return Subtotal * (1 + Salestax);
        }

        
    }
}
