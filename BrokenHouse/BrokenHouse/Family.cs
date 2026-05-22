using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BrokenHouse
{
    public class Family
    {
        public int Food { get; set; }

        public int Medicine { get; set; }

        public int Heating { get; set; }

        public List<FamilyMember> Members { get; set; }

        public Family() 
        {
            this.Food = 5;
            this.Medicine = 0;
            this.Heating = 0;

            Members = new List<FamilyMember>();
            Members.Add(new FamilyMember("Spouse", "Joanna", 32, true, false));
            Members.Add(new FamilyMember("Daughter", "Eve", 6, true, false));
        }

    }
}
