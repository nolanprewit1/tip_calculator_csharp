using System;
using System.Threading;

namespace tip_calculator_csharp
{
    class Program
    {
        public static void GetBillInformation(Bill bill)
        {
            while (true)
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
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Check Amount $: ");
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
                    continue;
                }
                break;
            }

            while (true) 
            {
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
                    continue;
                }
                break;
            }            
        }

        public static void CalculateBill(Bill bill)
        {
            bill.CheckTip = (float) Math.Round((bill.CheckAmount / 100) * bill.TipPercentage, 2);
            bill.CheckTotal = (float) Math.Round(bill.CheckAmount + bill.CheckTip, 2);
            bill.TipPerPerson = (float) Math.Round(bill.CheckTip / bill.NumerOfPeople, 2);
            bill.TotalPerPerson = (float) Math.Round(bill.CheckTotal / bill.NumerOfPeople, 2);
        }

        public static void DisplayBillInformation(Bill bill)
        {
            Console.Clear();
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

                Console.WriteLine("");
                Console.WriteLine("Would you like to calculate another bill? (y/n): ");
                var choice = (Console.ReadLine()).ToUpper();
                if (choice == "Y")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Closing application...");
                    Thread.Sleep(3000);
                    System.Environment.Exit(1);
                }
            }
        }
    }
}
