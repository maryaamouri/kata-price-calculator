using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kata_price_calculator
{
    internal class Expense
    {
        public Expense(string description, double amount)
        {
            Description = description;
            Amount = amount;
        }
        public string Description { set; get; }
        public double Amount { set; get; }
    }
}
