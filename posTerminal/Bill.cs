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

        //public Bill (double subTotal, double grandTotal)
        //{
        //    Subtotal = subTotal;
        //    Salestax = 0.06;
        //    Grandtotal = grandTotal;
        //}

        public void CalcSubTotal(List<MenuItem> userCart)
        {
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
