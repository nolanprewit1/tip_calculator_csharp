using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

namespace tip_calculator_csharp
{
    class Program
    {
        public class Bill
        {
            public int numerOfPeople { get; set; }
            public float tipPercentage { get; set; }
            public float checkTip { get; set; }
            public float checkTotal { get; set; } 
            public float checkAmount { get; set; }
            public float tipPerPerson { get; set; }
        }
        static void Main()
        {
            // Create new bill oject
            var bill = new Bill();

            while (true)
            {
                Console.WriteLine("Welcome to Tip Calculator C#");
                Console.WriteLine("");

                GetBillInformation(bill);               
            }
        }
        public static void GetBillInformation(Bill bill)
        {
            Console.Write("Number of people to split the check by [1]:");
            try
            {
                bill.numerOfPeople = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception exception)
            {
                if (exception.GetType().Name == "FormatException")
                {
                    Console.WriteLine("Please enter a number...");
                }
                else
                {
                    bill.numerOfPeople = 1;
                }
            }

            Console.Write("Check Amount:");
            try
            {
                bill.checkAmount = (float) Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception exception)
            {
                if (exception.GetType().Name == "FormatException")
                {
                    Console.WriteLine("Please enter a valide check amount...");
                }
                else
                {
                    bill.numerOfPeople = 1;
                }
            }
        }
    }
}
