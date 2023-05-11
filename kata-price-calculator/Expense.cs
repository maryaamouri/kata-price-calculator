using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kata_price_calculator
{
    internal class Expense
    {
        string Description { set; get; }
        double Amount { set; get; }

        public Expense(string description, double amount)
        {
            Description = description;
            Amount = amount;
        }
    }
}
