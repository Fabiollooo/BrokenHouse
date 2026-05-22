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
        public double DailyIncome { get; set; }

        //Add later:
        //Family constructors

        public Player(string name, double balance, int currentDay, double dailyIncome)
        {
            this.Name = name;
            this.Balance = balance;
            this.CurrentDay = currentDay;
            this.DailyIncome = dailyIncome;
        }

    }
}
