using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeApp
{
    static class Cafe
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();

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

            accounts.Add(a1);
            return a1;
        }

        public static IEnumerable<Account> GetAllAccountsForUser()
        {
            return accounts;
        }

        private static Account GetAccountByMembershipNumber(int membershipNumber)
        {
            var account = accounts.SingleOrDefault(a => a.MembershipNumber == membershipNumber);

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

            transactions.Add(transaction);
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

            transactions.Add(transaction);
        }
    }
}
