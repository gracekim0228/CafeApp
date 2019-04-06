using System;

namespace CafeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******************");
            Console.WriteLine("Welcome to the cafe!");
            Console.WriteLine("******************");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Add Money");
                Console.WriteLine("3. Pay");
                Console.WriteLine("4. View all my accounts");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the cafe!");
                        return;
                    case "1":
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();

                        var paymentMethods = Enum.GetNames(typeof(PaymentMethod));
                        for (int i = 0; i < paymentMethods.Length; i++)
                        {
                            Console.WriteLine($"{i}. {paymentMethods[i]}");
                        }

                        Console.Write("Payment Method: ");
                        var paymentMethod = Enum.Parse<PaymentMethod>(Console.ReadLine());

                        Console.Write("Amount to add: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var a1 = Cafe.CreateAccount(emailAddress, paymentMethod, amount);
                        Console.WriteLine($"Membership Number: {a1.MembershipNumber}, Member Since: {a1.MemberSince}, Balance: {a1.Balance:C}, Email Address: {a1.EmailAddress}, Payment Method: {a1.PaymentMethod}");
                        break;
                    case "2":
                        ViewAllAccounts();
                        Console.Write("Membership Number: ");
                        var membershipNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to add: ");
                        var addedAmount = Convert.ToDecimal(Console.ReadLine());
                        Cafe.AddMoney(membershipNumber, addedAmount);
                        Console.WriteLine("Amount successfully added!");
                        break;
                    case "3":
                        ViewAllAccounts();
                        Console.Write("Membership Number: ");
                        membershipNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to pay: ");
                        var payAmount = Convert.ToDecimal(Console.ReadLine());
                        Cafe.Pay(membershipNumber, payAmount);
                        Console.WriteLine("Payment successfully completed!");
                        break;
                    case "4":
                        ViewAllAccounts();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ViewAllAccounts()
        {
            var accounts = Cafe.GetAllAccountsForUser();
            foreach (var account in accounts)
            {
                Console.WriteLine($"Membership Number: {account.MembershipNumber}, Member Since: {account.MemberSince}, Balance: {account.Balance:C}, Email Address: {account.EmailAddress}, Payment Method: {account.PaymentMethod}");
            }
        }
    }
}
