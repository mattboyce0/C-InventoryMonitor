using System;
using System.Collections.Generic;
using System.Text;

namespace SDAMAssignment
{
    class AddTransaction
    {
        public int TransactionID;
        public DateTime TransactionDate;
        public int TransactionItemID;
        public string TransactionItemName;
        public double TransactionPricePaid;

        public AddTransaction(int TransactionID, DateTime TransactionDate, int TransactionItemID, string TransactionItemName, double TransactionPricePaid)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.TransactionItemID = TransactionItemID;
            this.TransactionItemName = TransactionItemName;
            this.TransactionPricePaid = TransactionPricePaid;
        }
    }
    
}
