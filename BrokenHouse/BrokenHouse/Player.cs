using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenHouse
{
    public class Player
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public int CurrentDay { get; set; }
        public double Paycheck { get; set; }
        public List<Items> Inventory { get; set; }
        public List<Expenses> Bills { get; set; }


        public Player(string name, double balance, int currentDay, double payCheck)
        {
            this.Name = name;
            this.Balance = 200;
            this.CurrentDay = currentDay;
            this.Paycheck = payCheck;

            this.Inventory = new List<Items>
            {
                new Items("Food", 50.0, 1),
                new Items("Medicine", 100.0, 1)
            };

            this.Bills = new List<Expenses>
            {
                new Expenses("Rent", 500.0, false),
                //new Expenses("Utilities", 100.0, false)
            };
        }

    }
}
