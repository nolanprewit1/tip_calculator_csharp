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
            public int NumerOfPeople { get; set; }
            public float CheckAmount { get; set; }
            public int TipPercentage { get; set; }
            public float CheckTip { get; set; }
            public float CheckTotal { get; set; }             
            public float TipPerPerson { get; set; }
            public float TotalPerPerson { get; set; }
        }
        public static void GetBillInformation(Bill bill)
        {
            Console.Write("Number of people to split the check by: ");
            try
            {
                bill.NumerOfPeople = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number...");
                Console.WriteLine("Press any key to restart...");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Console.Write("Check Amount: ");
            try
            {
                bill.CheckAmount = float.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valide check amount...");
                Console.WriteLine("Press any key to restart...");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Console.Write("Tip %: ");
            try
            {
                bill.TipPercentage = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a tip percentage...");
                Console.WriteLine("Press any key to restart...");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }

        public static void CalculateBill(Bill bill)
        {
            bill.CheckTip = (bill.CheckAmount / 100) * bill.TipPercentage;
            bill.CheckTotal = bill.CheckAmount + bill.CheckTip;
            bill.TipPerPerson = bill.CheckTip / bill.NumerOfPeople;
            bill.TotalPerPerson = bill.CheckTotal / bill.NumerOfPeople;
        }

        public static void DisplayBillInformation(Bill bill)
        {
            Console.WriteLine("");
            Console.WriteLine("#### CALCULATED TOTALS ####");
            Console.Write("Check total: \t\t\t $");
            Console.WriteLine(Convert.ToString(bill.CheckTotal));
            Console.Write("Check tip: \t\t\t $");
            Console.WriteLine(Convert.ToString(bill.CheckTip));
            Console.Write("Check total per person: \t $");
            Console.WriteLine(Convert.ToString(bill.TotalPerPerson));
            Console.Write("Check tip per person: \t\t $");
            Console.WriteLine(Convert.ToString(bill.TipPerPerson));
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
                CalculateBill(bill);
                DisplayBillInformation(bill);
            }
        }
    }
}
