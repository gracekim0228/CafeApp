using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeApp
{
    static class Cafe
    {
        private static CafeContext db = new CafeContext();

        /// <summary>
        /// Creates account for the cafe application
        /// </summary>
        /// <param name="emailAddress">Email address of the account</param>
        /// <param name="paymentMethod">Payment method of user</param>
        /// <param name="initialMoneyAdded">Initial amount added</param>
        /// <returns>Newly created account</returns>
        /// <exception cref="ArgumentNullException" />
        public static Account CreateAccount(string emailAddress, PaymentMethod paymentMethod, decimal initialMoneyAdded)
        {
            if (string.IsNullOrEmpty(emailAddress)|| string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException("emailAddress","Email Address is required!");
            }

            var a1 = new Account
            {
                EmailAddress = emailAddress,
                PaymentMethod = paymentMethod,
            };

            if (initialMoneyAdded > 0)
            {
                a1.AddMoney(initialMoneyAdded);
            }

            db.Accounts.Add(a1);
            db.SaveChanges();
            return a1;
        }

        public static IEnumerable<Account> GetAllAccountsForUser(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static IEnumerable<Transaction> GetTransactionsForMembershipNumber(int membershipNumber)
        {
            return db.Transactions
                .Where(t => t.MembershipNumber == membershipNumber)
                .OrderByDescending(t => t.TransactionDate);
        }

        private static Account GetAccountByMembershipNumber(int membershipNumber)
        {
            var account = db.Accounts.SingleOrDefault(a => a.MembershipNumber == membershipNumber);

            if (account == null)
            {
                throw new ArgumentNullException("membership", "Membership number is invalid");
            }
            return account;
        }

        public static void AddMoney(int membershipNumber, decimal amount)
        {
            var account = GetAccountByMembershipNumber(membershipNumber);   
            account.AddMoney(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Reload,
                Description = "Money Added",
                Amount = amount,
                MembershipNumber = membershipNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void Pay(int membershipNumber, decimal amount)
        {
            var account = GetAccountByMembershipNumber(membershipNumber);
            if (amount > account.Balance)
            {
                throw new ArgumentOutOfRangeException("amount", "Amount exceeds the balance.");
            }
            account.Pay(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Payment,
                Description = "Payment",
                Amount = amount,
                MembershipNumber = membershipNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}
