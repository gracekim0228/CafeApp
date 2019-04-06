using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp
{
    enum PaymentMethod
    {
        DebitCard,
        CreditCard,
        Paypal,
        GooglePay
    }
    /// <summary>
    /// Cafe application account for customers.
    /// Customers can add money and make payments using the application.
    /// </summary>
    class Account
    {
        #region statics
        private static int lastMembershipNumber = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Unique number for the customer
        /// </summary>
        public int MembershipNumber { get; private set; }
        /// <summary>
        /// Customer's email address
        /// </summary>
        public string EmailAddress { get; set; }
        public decimal Balance { get; private set; }
        /// <summary>
        /// Customer can choose the payment option
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }
        /// <summary>
        /// Account created date
        /// </summary>
        public DateTime MemberSince { get; private set; }
        #endregion

        #region Constructor
        public Account()
        {
            //lastMembershipNumber++;
            //MembershipNumber = lastMembershipNumber;

            MembershipNumber = ++lastMembershipNumber;
            MemberSince = DateTime.Now;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add money in the account
        /// </summary>
        /// <param name="amount">Amount to be added</param>
        public void AddMoney(decimal amount)
        {
            //Balance = Balance + amount;
            Balance += amount;
        }
        /// <summary>
        /// Make payments using the funds available in the account
        /// </summary>
        /// <param name="amount">Amount to be paid</param>
        public void Pay(decimal amount)
        {
            Balance -= amount;
        }
        #endregion

    }
}
