using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MidTermPOS
{
    class Validation
    {
        public static bool ValidCategory(string Category)
        {
            if (Category == "stimulant" || Category == "stimulants" || Category == "1")
            {
                return true;
            }
            else if (Category == "steroid" || Category == "steroids" || Category == "2")
            {
                return true;
            }
            else if (Category == "depressants" || Category == "depressant" || Category == "3")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again:");
                return false;
            }
        }
        public static int ValidDrug(string num)
        {
            do
            {
                if (int.TryParse(num, out int isNum))
                {
                    if (isNum <= 4 && isNum >= 1)
                    {
                        return isNum - 1;
                    }
                }
                Console.Write("Invalid Number. Try again: ");
                num = Console.ReadLine();
            } while (true);
        }
        public static int ValidPayment(string num)
        {
            do
            {
                if (int.TryParse(num, out int isNum))
                {
                    if (isNum <= 3 && isNum >= 1)
                    {
                        return isNum;
                    }
                }
                Console.Write("Invalid Number. Try again: ");
                num = Console.ReadLine();
            } while (true);
        }

        public static int Size(string isSize)
        {
            if (int.TryParse(isSize, out int size))
            {
                return size;
            }
            else
            {
                return -1;
            }
        }
        public static bool BottleSize(string sizeInt)
        {
            if (int.TryParse(sizeInt, out int result))
            {
                if (result == 30)
                {
                    return true;
                }
                else if (result == 60)
                {
                    return true;
                }
                else if (result == 90)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsCartEmpty(double item)
        {
            if(item == 0.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool PurchaseMore()
        {
            Console.Write("Would you like to Purchase More? (y/n): ");
            string userContinue = Console.ReadLine().ToLower();
            bool run;
            if (userContinue == "y")
            {
                Console.Clear();
                run = true;
            }
            else if (userContinue == "n")
            {
                run = false;
            }
            else
            {
                Console.WriteLine("Invalid response. Please try again: (y/n)");
                run = PurchaseMore();
            }
            return run;
        }
    }
}