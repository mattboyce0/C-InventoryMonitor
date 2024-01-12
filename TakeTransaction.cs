using System;
using System.Collections.Generic;
using System.Text;

namespace SDAMAssignment
{
    class TakeTransaction
    {
        public int TransactionID;
        public DateTime TransactionDate;
        public int TransactionItemID;
        public string TransactionItemName;
        public string TransactionUserName;

        public TakeTransaction(int TransactionID, DateTime TransactionDate, int TransactionItemID, string TransactionItemName, string TransactionUserName)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.TransactionItemID = TransactionItemID;
            this.TransactionItemName = TransactionItemName;
            this.TransactionUserName = TransactionUserName;
        }
    }

}
