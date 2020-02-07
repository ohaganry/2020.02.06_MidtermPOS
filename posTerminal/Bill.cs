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

<<<<<<< HEAD
        public double CalcSubTotal(List<MenuItem> userCart)
=======
        //public Bill (double subTotal, double grandTotal)
        //{
        //    Subtotal = subTotal;
        //    Salestax = 0.06;
        //    Grandtotal = grandTotal;
        //}

        public void CalcSubTotal(List<MenuItem> userCart)
>>>>>>> master
        {
            foreach (var c in userCart)
            {
                Subtotal += c.Price;
<<<<<<< HEAD
            }
            return Subtotal;
        }

        public double CalcTotal()
=======
            }             
        }

        public void CalcTotal()
>>>>>>> master
        {
            Grandtotal = Subtotal * (1 + Salestax);
        }        
    }
}
