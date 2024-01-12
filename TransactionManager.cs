using System;
using System.Collections.Generic;
using System.Text;

namespace SDAMAssignment
{
    class TransactionManager
    {
        // Transaction Lists
        private List<AddTransaction> AddTransactionList = new List<AddTransaction>();
        private List<TakeTransaction> TakeTransactionList = new List<TakeTransaction>();
        
        // Transaction ID increment counters
        public int AddTransactionIDCount = 0;
        public int TakeTransactionIDCount = 0;


        //Increments the ID counters so that new instances have a valid ID
        public void IncrementIDCounters()
        {
            AddTransactionIDCount = (AddTransactionList.Count + 1);
            TakeTransactionIDCount = (TakeTransactionList.Count + 1);
        }

        //Creates a new AddTransaction object
        public void CreateAddTransaction(int TransactionItemID, string TransactionItemName, double TransactionPricePaid)
        {
            IncrementIDCounters();
            int NewTransactionID = AddTransactionIDCount;
            AddTransaction NewAddTransaction = new AddTransaction(AddTransactionIDCount + 1, DateTime.Now, TransactionItemID, TransactionItemName, TransactionPricePaid);
            AddTransactionList.Add(NewAddTransaction);
        }

        // Creates a new TakeTransaction object
        public void CreateTakeTransaction(int TransactionItemID, string TransactionItemName, string TransactionUserName)
        {
            IncrementIDCounters();
            int NewTransactionID = TakeTransactionIDCount;
            TakeTransaction NewTakeTransaction = new TakeTransaction(NewTransactionID, DateTime.Now, TransactionItemID, TransactionItemName, TransactionUserName);
            TakeTransactionList.Add(NewTakeTransaction);
        }

        // Displays a list of both types of transaction.
        public void DisplayTransactionLog()
        {
            Console.WriteLine("TRANSACTION LOG:");
            Console.WriteLine(AddTransactionList.Count);
            Console.WriteLine(TakeTransactionList.Count);
            foreach (AddTransaction AddTransactionInstance in AddTransactionList)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("] Transaction Type:        ADD");
                Console.WriteLine("] Item ID:                 {0}", AddTransactionInstance.TransactionItemID);
                Console.WriteLine("] Transaction ID:          {0}", AddTransactionInstance.TransactionID);
                Console.WriteLine("] Transaction Date:        {0}", AddTransactionInstance.TransactionDate);
                Console.WriteLine("] Item Name:               {0}", AddTransactionInstance.TransactionItemName);
                Console.WriteLine("] Price paid for item:     {0}", AddTransactionInstance.TransactionPricePaid);
                Console.WriteLine("===============================================================================");
                Console.WriteLine("");
            }

            foreach (TakeTransaction TakeTransactionInstance in TakeTransactionList)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("] Transaction Type:        TAKE");
                Console.WriteLine("] Item ID:                 {0}", TakeTransactionInstance.TransactionItemID);
                Console.WriteLine("] Transaction ID:          {0}", TakeTransactionInstance.TransactionID);
                Console.WriteLine("] Transaction Date:        {0}", TakeTransactionInstance.TransactionDate);
                Console.WriteLine("] Item Name:               {0}", TakeTransactionInstance.TransactionItemName);
                Console.WriteLine("] Transaction User:        {0}", TakeTransactionInstance.TransactionUserName);
                Console.WriteLine("===============================================================================");
                Console.WriteLine("");
            }
        }

        public void ReportPersonalUsage(string UserName)
        {
            List<TakeTransaction> TakeTransactionsBySpecifiedName =  GetTransactionsByName(UserName);
            foreach (TakeTransaction TakeTransactionNameInstance in TakeTransactionsBySpecifiedName)
            {
                Console.WriteLine("] Transaction log for user: {0}", TakeTransactionNameInstance.TransactionUserName);
                Console.WriteLine("===============================================================================");
                Console.WriteLine("] Transaction Type:        Take");
                Console.WriteLine("] Item ID:                 {0}", TakeTransactionNameInstance.TransactionItemID);
                Console.WriteLine("] Transaction ID:          {0}", TakeTransactionNameInstance.TransactionID);
                Console.WriteLine("] Transaction Date:        {0}", TakeTransactionNameInstance.TransactionDate);
                Console.WriteLine("] Item Name:               {0}", TakeTransactionNameInstance.TransactionItemName);
                Console.WriteLine("] Date Taken:              {0}", TakeTransactionNameInstance.TransactionDate);
                Console.WriteLine("===============================================================================");
                Console.WriteLine("");
            }
        }

        public List<TakeTransaction> GetTransactionsByName(string UserName)
        {
            List<TakeTransaction> TakeTransactionsBySpecifiedName = new List<TakeTransaction>();
            foreach (TakeTransaction TakeTransactionInstance in TakeTransactionList)
            {
                if (TakeTransactionInstance.TransactionUserName == UserName)
                {
                    TakeTransactionsBySpecifiedName.Add(TakeTransactionInstance);
                }
                
            }
            return TakeTransactionsBySpecifiedName;
        }
    }
}
