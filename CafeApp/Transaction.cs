using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp
{   
    enum TransactionType
    {
        Reload,
        Payment
    }
    class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType TransactionType { get; set; }

        public int MembershipNumber { get; set; }
        public virtual Account Account { get; set; }
    }
}
