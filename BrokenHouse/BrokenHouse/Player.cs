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

        
        public int FoodQuantity { get; set; }
        public double FoodPrice { get; set; }
        public int MedicineQuantity { get; set; }
        public double MedicinePrice { get; set; }

        public List<Expenses> Bills { get; set; }


        public Player(string name, double balance, int currentDay, double payCheck)
        {
            this.Name = name;
            this.Balance = balance;
            this.CurrentDay = currentDay;
            this.Paycheck = payCheck;

            this.FoodQuantity = 1;
            this.FoodPrice = 20.0;
            this.MedicineQuantity = 1;
            this.MedicinePrice = 40.0;

            this.Bills = new List<Expenses>
            {
                new Expenses("Rent", 180.0, false),
                //new Expenses("Utilities", 100.0, false)
            };
        }

    }
}
