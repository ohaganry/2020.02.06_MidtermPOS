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
            Salestax = 0.06;
        }

        public void CalcSubTotal(List<MenuItem> userCart)
        {
            Subtotal = 0;
            foreach (var c in userCart)
            {
                Subtotal += c.Price;

            }
        }

        public void CalcTotal()
        {
            Grandtotal = Subtotal * (1 + Salestax);
        }
    }
}
