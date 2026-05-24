using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenHouse
{
    public class Expenses
    {   
        public string ExpenseName { get; set; }
        public double ExpenseCost { get; set; }
        public bool ExpenseIspaid { get; set; }

        public Expenses(string expenseName, double expenseCost, bool expenseIspaid)
        {
            this.ExpenseName = expenseName;
            this.ExpenseCost = expenseCost;
            this.ExpenseIspaid = expenseIspaid;
        }
    }
}
