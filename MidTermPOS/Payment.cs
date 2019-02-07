using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;


namespace MidTermPOS
{
    class Payment
    {
        public static string creditCardNumber;
        public static string bankAccountNumber;
        public static double cashTendered;
        readonly int month = 0;
        readonly int year = 0;
        readonly string cvv = "";
        readonly double grandTotal = 0;
        readonly double subTotal = 0;
        readonly double tax = 0;

        public Payment()
        {

        }
        public enum PaymentType { cash, credit, check };

        public PaymentType paymentType { get; set; }

        private readonly string visaRegex = @"^[0-9]{13,16}$";
        private readonly string mastercardRegex = @"^[0-9]{13,16}$";
        private readonly string americanExpressRegex = @"^[0-9]{13,16}$";
        private readonly string aeCvvRegex = @"^[0-9]{4}$";
        private readonly string cvvRegex = @"^[0-9]{3,4}$";
        private readonly string accountNumberRegex = @"^[0-9]{10,12}$";
        private readonly string routingNumberRegex = @"^[0-9]{9}$";

        public static double MethodOfPayment(double total, int paymentType)
        {
            switch (paymentType)
            {
                case 1:
                    return PayingCash(total);

                case 2:
                    Credit(total);
                    return 0.00;

                case 3:
                    Check(total);
                    return 0.00;

                default:
                    return 0.00;
            }
        }

        public static double PayingCash(double grandTotal)
        {
            cashTendered = 0;
            Console.Write("Enter amount you wish to tender: $");
            cashTendered = Double.Parse(Console.ReadLine());

            while (grandTotal > cashTendered)
            {
                double changes = grandTotal - cashTendered;
                Console.WriteLine("Sorry, that's not enough.");
                Console.WriteLine("You are short: {0}", changes.ToString("C", new CultureInfo("en-US")));
                Console.Write("Please enter more: ");
                cashTendered += Double.Parse(Console.ReadLine());

            }
            double change = cashTendered - grandTotal;
            return change;
        }

        public string PayingCredit(string creditCardNumber, int month, int year, string cvv)
        {
            if (Regex.IsMatch(creditCardNumber, visaRegex))
            {
                if (month > 0 && year >= 2019)
                {
                    if (month < 2 && year < 2020)
                    {
                        return "invalid";
                    }
                    if (Regex.IsMatch(cvv, cvvRegex))
                    {
                        return "Visa";
                    }
                    Console.WriteLine("Please enter cvv.");
                    return "invalid";
                }
                Console.WriteLine("Enter a date.");
                return "invalid";
            }

            else if (Regex.IsMatch(creditCardNumber, mastercardRegex))
            {
                if ((month > 0 && month <= 12) && (year >= 2019))
                {
                    if (Regex.IsMatch(cvv, cvvRegex))
                    {
                        return "Mastercard";
                    }
                    Console.WriteLine("Please enter cvv.");
                    return "invalid";
                }
                Console.WriteLine("Enter a valid date");
                return "invalid";
            }
            else if (Regex.IsMatch(creditCardNumber, americanExpressRegex))
            {
                if ((month > 0 && month <= 12) && (year >= 2019))
                {
                    if (Regex.IsMatch(cvv, aeCvvRegex))
                    {
                        return "American Express";
                    }
                    Console.WriteLine("Please enter cvv.");
                    return "invalid";
                }
                Console.WriteLine("Enter a date.");
                return "invalid";
            }
            else
            {
                return "invalid";
            }
        }

        public string PayingCheck(string bankAccountNumber, string bankRoutingNumber)
        {
            if (Regex.IsMatch(bankAccountNumber, accountNumberRegex))
            {
                if (Regex.IsMatch(bankRoutingNumber, routingNumberRegex))
                {
                    return "Check Valid!";
                }
                Console.WriteLine("Invalid routing number");
                return "invalid";
            }
            Console.WriteLine("Invalid account number");
            return "invalid";
        }

        public static void Credit(double total)
        {
            var payment = new Payment();
            string paymentResult = "invalid";
            int month = 0;
            int year = 0;
            string cvv = "";
            double grandTotal = 0;
            double subTotal = 0;
            double tax = 0;


            while (paymentResult == "invalid")
            {
                Console.Write("Please enter credit card number (13-16 Digits): ");
                creditCardNumber = Console.ReadLine();

                bool cardMonth = false;
                while (!cardMonth)
                {
                    Console.Write("Enter expiration month (e.g. 5 for May): ");
                    cardMonth = int.TryParse(Console.ReadLine(), out month);
                }

                bool cardYear = false;
                while (!cardYear)
                {
                    Console.Write("Enter expiration year (e.g. 2019): ");
                    cardYear = int.TryParse(Console.ReadLine(), out year);
                }

                Console.Write("Enter cvv: ");
                cvv = Console.ReadLine();

                paymentResult = payment.PayingCredit(creditCardNumber, month, year, cvv);
                if (paymentResult == "invalid")
                {
                    Console.WriteLine("Payment not successful, please try again.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Payment successfully processed.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
        public static void Check(double total)
        {
            var payment = new Payment();
            string paymentResult = "invalid";
            double subTotal = 0;
            double grandTotal = 0;
            double tax = 0;

            while (paymentResult == "invalid")
            {
                Console.Write("Enter bank account number (10-12 Digits): ");
                bankAccountNumber = Console.ReadLine();

                Console.Write("Enter bank routing number (9 Digits): ");
                string bankRoutingNumber = Console.ReadLine();

                paymentResult = payment.PayingCheck(bankAccountNumber, bankRoutingNumber);

                if (paymentResult == "invalid")
                {
                    Console.WriteLine("Payment unsuccessful.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Payment successful. Thank you!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }

        public static double CalculateSubTotal(List<DrugType> cart)
        {
            double total = 0;
            double totalForOneDrug = 0;


            foreach (DrugType drug in cart)
            {
                totalForOneDrug = drug.PillCount * drug.Price;
                total += totalForOneDrug;
            }
            return total;
        }

        public static double CalculateSalesTaxTotal(double subTotal)
        {
            double tax = 0;
            tax = subTotal * 0.06;
            return tax;
        }

        public static double CalculateGrandTotal(double subTotal, double tax)
        {
            double grandTotal = 0;
            grandTotal = subTotal + tax;
            return grandTotal;
        }
    }
}