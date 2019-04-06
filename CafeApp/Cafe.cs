using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeApp
{
    static class Cafe
    {
        private static List<Account> accounts = new List<Account>();

        public static Account CreateAccount(string emailAddress, PaymentMethod paymentMethod, decimal initialMoneyAdded)
        {
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
                //Throw exception
                return null;
            }
            return account;
        }

        public static void AddMoney(int membershipNumber, decimal amount)
        {
            var account = GetAccountByMembershipNumber(membershipNumber);   
            account.AddMoney(amount);
        }

        public static void Pay(int membershipNumber, decimal amount)
        {
            var account = GetAccountByMembershipNumber(membershipNumber);
            account.Pay(amount);
        }
    }
}
