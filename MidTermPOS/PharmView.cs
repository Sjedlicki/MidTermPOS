using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace MidTermPOS
{
    class PharmView
    {
        DrugType DrugType;
        public PharmView()
        {
        }

        // GREETING CUSTOMER
        public static void GreetingView()
        {
            Console.WriteLine("Welcome to the Pharmaceutical Database, for all your pharmaceutical needs.");
        }

        // PRINTING DRUG TYPES
        public static string DrugTypeList()
        {
            List<string> DrugTypes = new List<string>() { "Stimulant", "Depressant", "Steroids" };
            int count = 1;
            foreach (string d in DrugTypes)
            {
                Console.WriteLine($"{count}: {d}");
                count++;
            }
            Console.Write("Which type of medicine do you require? ");
            return Input();
        }

        // PRINTING DRUG NAMES
        public static string DrugNameList(List<DrugType> Drugs)
        {
            int count = 1;
            foreach (DrugType d in Drugs)
            {
                Console.WriteLine($"{count}: {d.DrugName}");
                count++;
            }
            Console.Write("Please select the medication you require: ");
            return Input();
        }

        public static void DrugInfo(DrugType index)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {index.DrugName}");
            Console.WriteLine($"Price: ${index.Price}");
            Console.WriteLine($"Drug Information\n{index.DrugInfo}");
        }

        // PRINTING OPTION FOR BOTTLE SIZE
        public static string BottleSize()
        {
            Console.WriteLine();
            Console.Write("Select a bottle size enter: (30) (60) (90): ");

            return Input();
        }

        public static string AddToCart()
        {
            Console.Write("Would you like to add this item to your cart (y/n)? ");
            return Input();
        }

        public static void Receipt(List<DrugType> Cart)
        {
            Console.Clear();
            Console.WriteLine("Receipt");
            int count = 1;
            foreach (DrugType item in Cart)
            {            
                Console.WriteLine($"{count}: {item.DrugName} ${item.Price}  Qty: {item.PillCount}");
                count++;
            }
        }
		
       public static void ReceiptTotal(double subTotal, double tax, double grandTotal, double change)
        {
            string subT = "Subtotal: ";
            string taxes = "Tax: ";
            string grandT = "Grandtotal: ";
            string changed = "Change: ";

            Console.WriteLine();
            Console.Write("{0,12}", subT);
            Console.WriteLine("{0}", subTotal.ToString("C", new CultureInfo("en-US")));

            Console.Write("{0,12}", taxes);
            Console.WriteLine("{0}", tax.ToString("C", new CultureInfo("en-US")));

            Console.Write("{0}", grandT);
            Console.WriteLine("{0}", grandTotal.ToString("C", new CultureInfo("en-US")));

            Console.Write("{0,12}",changed);
            Console.WriteLine("{0}", change.ToString("C", new CultureInfo("en-US")));

            Console.WriteLine();
            Console.WriteLine("Thank You Come Again!");
        }		

        public static string RequestPayment()
        {
            Console.WriteLine();
            Console.WriteLine("How would you like to pay?");
            Console.WriteLine("Press 1: for Cash");
            Console.WriteLine("Press 2: for Credit");
            Console.WriteLine("Press 3: for Check");
            return Input();
        }

        // TAKING A USER INPUT
        public static string Input()
        {
            string input = Console.ReadLine().ToLower();
            return input;
        }
    }
}