using System;
using System.Collections.Generic;
using System.Text;

namespace SDAMAssignment
{
    class UserInterface
    {
        ItemManager ItemMgr = new ItemManager();
        TransactionManager TransMgr = new TransactionManager();
        int CurrentItemID = 0;
        int CurrentTakeID = 0;
        int CurrentAddID = 0;

        public void RefreshCurrentIDCounters()
        {
            CurrentItemID = ItemMgr.ItemIDCounter;
            CurrentTakeID = TransMgr.TakeTransactionIDCount;
            CurrentAddID = TransMgr.AddTransactionIDCount;
        }

        public void AddToStock(string ItemName, int ItemQuantity, double ItemPrice, DateTime DateAdded)
        {
            // Check that item does not already exist -- WIP
            // Add instance of Item() through ItemMgr -- FINISHED
            // Add instance of AddTransaction through TransMgr --FINISHED
            // Generate AddTransaction for log -- WIP
            RefreshCurrentIDCounters();
            if (ItemMgr.AddItemToList(CurrentItemID, ItemName, ItemQuantity, ItemPrice, DateAdded))
            {
                TransMgr.CreateAddTransaction(CurrentAddID + 1, ItemName, ItemPrice);
            }
        }

        public void TakeFromStock(int ItemID, string UserName, int QuantityTaken, DateTime DateTaken)
        {
            // Subtract quantity of specified Item() through ItemMgr
            // if Quantity > Stock then return error
            // Add instance of TakeTransaction through transmgr if succsesful
            //Check req quantity available in stock

            if(ItemMgr.CheckStockAvailability(ItemID, QuantityTaken))
            {
                // Subtract item quantity
                ItemMgr.SubtractItemQuantity(ItemID, QuantityTaken);

                // Generate TakeTransaction for log
                Item SelectedItem = ItemMgr.GetItemByID(ItemID);
                TransMgr.CreateTakeTransaction(ItemID, SelectedItem.ItemName, UserName);

                // Remove an item of stock if there are no longer any items in stock -- WIP

            }
            else
            {
                Console.WriteLine("Not enough items in stock.");          
            }
        }

        public void ViewFinancialReport()
        {
            // Generate and display a financial report
            ItemMgr.ViewFinancialReport();
        }

        public void ViewInventoryReport()
        {
            // Generate and view an inventory report
            ItemMgr.ViewInventoryReport();
        }

        public void DisplayTransactionLog()
        {
            // Generate and display a log of all transactions
            Console.Clear();
            TransMgr.DisplayTransactionLog();
        }

        public void ReportPersonalUsage(string Name)
        {
            // Generate a report of the personal usage for each user
            TransMgr.ReportPersonalUsage(Name);

        }        
    }
}
