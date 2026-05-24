using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenHouse
{
    public class Items
    {
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int ItemQuantity { get; set; }

        public Items(string itemName, double itemPrice, int itemQuantity)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemQuantity = itemQuantity;
        }

    }
}
