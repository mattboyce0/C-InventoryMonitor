using System;
using System.Collections.Generic;
using System.Text;

namespace SDAMAssignment
{
    public class Item
    {
        public int ItemQuantity { get; set; }

        public int ItemID { get; set; }

        public string ItemName { get; set; }

        public int ItemTotalExpenditure { get; set; }

        public double ItemPrice { get; set; }

        public DateTime DateAdded { get; set; }


        public Item(int ItemID, string ItemName, int ItemQuantity, double ItemPrice, DateTime DateAdded)
        {
            this.ItemID = ItemID;
            this.ItemName = ItemName;
            this.ItemQuantity = ItemQuantity;
            this.ItemPrice = ItemPrice;
            this.DateAdded = DateAdded;
            CalculateTotalExpenditure();
        }

        public void CalculateTotalExpenditure()
        {
            ItemTotalExpenditure = Convert.ToInt32(ItemPrice) * ItemQuantity;
        }

        

    }

}
