using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kata_price_calculator
{
    internal class AddtionalCosts
    {
        public AddtionalCosts(Expense transport, Expense administrative, Expense packaging)
        {
            Transport = transport;
            Administrative = administrative;
            Packaging = packaging;
        }

        Expense Transport { set; get; }
        Expense Administrative { set; get; }
        Expense Packaging { set; get; }

    }
}
