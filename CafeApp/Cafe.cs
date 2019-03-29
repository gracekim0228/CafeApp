using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp
{
    static class Cafe
    {
        public static Account CreateAccount(string emailAddress, string paymentMethod, decimal initialMoneyAdded)
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

            return a1;
        }
    }
}
