using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenHouse
{
    public class FamilyMember
    {
        public string MemberType { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsAlive { get; set; }
        public bool IsSick { get; set; }


        public FamilyMember(string memberType, string name, int age, bool isAlive, bool isSick)
        {
            this.MemberType = memberType;
            this.Name = name;
            this.Age = age;
            this.IsAlive = true;
            this.IsSick = false;
        }
    }
}
