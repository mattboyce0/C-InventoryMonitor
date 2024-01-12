using System;

using System.Collections.Generic;
using System.Text;

namespace SDAMAssignment
{
    public class ItemManager
    {
        public int ItemIDCounter = 0;
        private List<Item> ItemList = new List<Item>();


        public void IncrementIDCounter()
        {
            ItemIDCounter = ItemIDCounter + 1;
        }

        // Prints a description of every item instance in the ItemList
        public void GetItemList()
        {
            foreach (Item ItemInstance in ItemList)
            {
                Console.WriteLine("==================================");
                Console.WriteLine("ItemID:         {0}", ItemInstance.ItemID);
                Console.WriteLine("Name:           {0}", ItemInstance.ItemName);
                Console.WriteLine("Stock Quantity: {0}", ItemInstance.ItemQuantity);
                Console.WriteLine("Total Exp:      {0}", ItemInstance.ItemTotalExpenditure);
                Console.WriteLine("Date Added:     {0}", ItemInstance.DateAdded);
            }
        }
        
        //Check required quantity in stock - Returns bool
        public bool CheckStockAvailability(int ItemID, int QuantityRequired)
        {
            foreach (Item ItemInstance in ItemList)
            {
                if (ItemInstance.ItemID == ItemID)
                {
                    if( ItemInstance.ItemQuantity >= QuantityRequired)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }
            return false;
        }

        // Add a new instance of Item class
        public bool AddItemToList(int ItemID, string ItemName, int ItemQuantity, double ItemPrice, DateTime DateAdded)
        {

            foreach (Item ItemInstance in ItemList)
            {
                if (ItemInstance.ItemName == ItemName)
                {
                    Console.WriteLine("[-] Item already in database!");
                    Console.WriteLine("[>] Do you wish to overwite item? (Y/N)");
                    try
                    {
                        string Menuchoice = Console.ReadLine();
                        if(Menuchoice.ToUpper() == "Y")
                        {
                            ItemInstance.ItemQuantity += ItemQuantity;
                            ItemInstance.ItemPrice = ItemPrice;
                            ItemInstance.DateAdded = DateAdded;
                            return true;
                        }
                        else if (Menuchoice.ToUpper() == "N")
                        {
                            Console.WriteLine("[!] Item entry cancelled.");
                            return false;
                        }
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("[!] Please enter a valid option.");
                        return false;
                    }
                }
            }

            Item newItem = new Item(ItemIDCounter, ItemName, ItemQuantity,ItemPrice,  DateAdded);
            ItemList.Add(newItem);
            IncrementIDCounter();
            return true;
            
        }
        // Subtract a quantity of an item from a list
        public void SubtractItemQuantity(int ItemID, int QuantityRequired)
        {
            foreach (Item ItemInstance in ItemList)
            {
                if (ItemInstance.ItemID == ItemID)
                {
                    if(ItemInstance.ItemQuantity >= QuantityRequired)
                    {
                        ItemInstance.ItemQuantity -= QuantityRequired;
                    }
                }
            }
        }

        // Returns an Item object based on ID.
        public Item GetItemByID(int ItemID)
        {
            foreach (Item ItemInstance in ItemList)
            {
                if (ItemInstance.ItemID == ItemID)
                {
                    return ItemInstance;
                }
            }
            return null;
        }

        // Generate a report for every item in the inventory (ItemList)
        public void ViewInventoryReport()
        {
            Console.WriteLine("Inventory Report:");
            foreach (Item ItemInstance in ItemList)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("] Item ID:                 {0}", ItemInstance.ItemID);
                Console.WriteLine("] Item Name:               {0}", ItemInstance.ItemName);
                Console.WriteLine("] Quantity in stock:       {0}", ItemInstance.ItemQuantity);
                Console.WriteLine("===============================================================================");
                Console.WriteLine("");
            }
        }

        public void ViewFinancialReport()
        {
            double TotalCostCount = 0;
            foreach (Item ItemInstance in ItemList)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("] Item Name:               {0}", ItemInstance.ItemName);
                Console.WriteLine("] Item Price:             £{0}", ItemInstance.ItemPrice);
                Console.WriteLine("===============================================================================");
                Console.WriteLine("");
                TotalCostCount += ItemInstance.ItemPrice;
            }

            Console.WriteLine("Total Cost of Inventory:       {0}", TotalCostCount);

        }


    }
}
