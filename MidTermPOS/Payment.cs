using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MidTermPOS
{
    class Payment
    {
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

        private readonly string visaRegex = @"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$";
        private readonly string mastercardRegex = @"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$";
        private readonly string americanExpressRegex = @"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$";
        private readonly string aeCvvRegex = @"^[0-9]{4}$";
        private readonly string cvvRegex = @"^[0-9]{3}$";
        private readonly string accountNumberRegex = @"^[0-9]{10,12}$";
        private readonly string routingNumberRegex = @"^[0-9]{9}$";

        public static bool MethodOfPayment(double total, int paymentType)
        {
            switch (paymentType)
            {
                case 1:
                    //PayingCash(total);
                    return true;

                case 2:
                    Credit(total);
                    return true;

                case 3:
                    Check(total);
                    return true;

                default:
                    return false;
            }
        }

        public static double PayingCash(double grandTotal)
        {
            double cashTendered = 0;
            Console.WriteLine("Enter amount you wish to tender.");
            cashTendered = double.Parse(Console.ReadLine());

            while (grandTotal > cashTendered)
            {
                Console.WriteLine("Sorry, that's not enough.");
                Console.Write("We need more than that. Please give more: ");
                cashTendered += Double.Parse(Console.ReadLine());

            }
            double change = cashTendered - grandTotal;
            return change;
        }

        public string PayingCredit(string creditCardNumber, int month, int year, string ccv)
        {
            if (Regex.IsMatch(creditCardNumber, visaRegex))
            {
                if ((month > 0 && month <= 12) && (year >= 2019))
                {
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
                Console.WriteLine("Enter bank routing number.");
                return "invalid";
            }
            Console.WriteLine("Enter bank account number.");
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
                Console.WriteLine("Please enter credit card number: ");
                string creditCardNumber = Console.ReadLine(); 

                bool cardMonth = false;
                while (!cardMonth)
                {
                    Console.WriteLine("Enter expiration month (e.g. 2 for May): ");
                    cardMonth = int.TryParse(Console.ReadLine(), out month);
                }

                bool cardYear = false;
                while (!cardYear)
                {
                    Console.WriteLine("Enter expiration year (e.g. 2019): ");
                    cardYear = int.TryParse(Console.ReadLine(), out year);
                }

                Console.WriteLine("Enter cvv: ");
                cvv = Console.ReadLine();

                paymentResult = payment.PayingCredit(creditCardNumber, month, year, cvv);
                if (paymentResult == "invalid")
                {
                    Console.WriteLine("Payment not successful, please try again.");
                }
                else
                {
                    Console.WriteLine("Payment successfully processed.");
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
                Console.WriteLine("Enter bank account number: ");
                string bankAccountNumber = Console.ReadLine();

                Console.WriteLine("Enter bank routing nmber: ");
                string bankRoutingNumber = Console.ReadLine();

                paymentResult = payment.PayingCheck(bankAccountNumber, bankRoutingNumber);

                Console.WriteLine("Payment successful. Thank you!");

                if (paymentResult == "invalid")
                {
                    Console.WriteLine("Payment unsuccessful.");
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