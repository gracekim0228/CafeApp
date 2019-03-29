using System;

namespace CafeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = Cafe.CreateAccount("cafe@cafe.com", "Paypal", 0);

            Console.WriteLine($"MN: {a1.MembershipNumber}, B: {a1.Balance}, MS: {a1.MemberSince}, EA: {a1.EmailAddress}, PM: {a1.PaymentMethod}");

            var a2 = Cafe.CreateAccount("cafe2@cafe.com", "Debit Card", 100);

            Console.WriteLine($"MN: {a2.MembershipNumber}, B: {a2.Balance}, MS: {a2.MemberSince}, EA: {a2.EmailAddress}, PM: {a2.PaymentMethod}");
        }
    }
}
