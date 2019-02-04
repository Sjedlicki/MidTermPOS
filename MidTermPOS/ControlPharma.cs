using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermPOS
{
    class ControlPharma
    {
        public static void PharmaStart()
        {
            string catagory = " ";
            DrugType selectedDrug;
            int bottleSize = 0;
            double grandTotal = 0;
            double tax = 0;
            double subTotal = 0;

            List<DrugType> Cart = new List<DrugType> { };

            do
            {
                catagory = PickCatagory();

                selectedDrug = PickDrug(catagory);

                bottleSize = PickPillCount();

                DrugType temp = AddtoCart(selectedDrug, bottleSize);
                if (temp.PillCount != 0)
                {
                    Cart.Add(temp);
                }


            } while (Validation.PurchaseMore());

			subTotal = Payment.CalculateSubTotal(Cart); //added
            tax = Payment.CalculateSalesTaxTotal(subTotal);
            grandTotal = Payment.CalculateGrandTotal(subTotal, tax);
            Console.WriteLine("Your total is " + grandTotal);
            string paymentType = PharmView.RequestPayment();
            int selectedPayment = Validation.ValidPayment(paymentType);
            Payment.MethodOfPayment(grandTotal, selectedPayment);

            double change = Payment.PayingCash(grandTotal);
            PharmView.Receipt(Cart);
            PharmView.ReceiptTotal(subTotal, tax, grandTotal, change);

        }

        public static string PickCatagory()
        {
            string catagory;
            bool isValid;
            do
            {
                PharmView.GreetingView();
                catagory = PharmView.DrugTypeList();
                isValid = Validation.ValidCategory(catagory);
                catagory = catagory.ToLower();
            }
            while (isValid == false);

            return catagory;
        }

        public static DrugType PickDrug(string catagory)
        {
            DrugType selectedDrug = new DrugType("SomethingWent WRong", -1.1, "Something went wrong");
            string drug;

            if (catagory == "stimulants" || catagory == "stimulant")
            {
                StimulantsDB stims = new StimulantsDB();
                drug = PharmView.DrugNameList(stims.DrugName);
                selectedDrug = stims.DrugName[Validation.ValidDrug(drug)];
                PharmView.DrugInfo(selectedDrug);
            }
            else if (catagory == "steroids" || catagory == "steroid")
            {
                SteroidsDB ster = new SteroidsDB();
                drug = PharmView.DrugNameList(ster.DrugName);
                selectedDrug = ster.DrugName[Validation.ValidDrug(drug)];
                PharmView.DrugInfo(selectedDrug);
            }
            else if (catagory == "depressants" || catagory == "depressant")
            {
                DepressantDB depr = new DepressantDB();
                drug = PharmView.DrugNameList(depr.DrugName);
                selectedDrug = depr.DrugName[Validation.ValidDrug(drug)];
                PharmView.DrugInfo(selectedDrug);
            }

            return selectedDrug;
        }

        private static int PickPillCount()
        {
            int sizeInt;
            string sizeSTR;
            do
            {
                sizeSTR = PharmView.BottleSize();

            } while (Validation.BottleSize(sizeSTR) == false);
            sizeInt = int.Parse(sizeSTR);

            return sizeInt;
        }

        private static DrugType AddtoCart(DrugType selectedDrug, int bottleSize)
        {
            string input = PharmView.AddToCart();
            if (input.ToLower() == "y")
            {
                selectedDrug.PillCount = bottleSize;
                Console.WriteLine("Item added to cart");
            }
            else
            {
                Console.WriteLine("Item not added to cart");
            }
            return selectedDrug;
        }

    }
}
