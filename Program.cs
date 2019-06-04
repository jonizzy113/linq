using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from fruit in fruits
                where fruit[0] == 'L'
                select fruit;
            // Console.WriteLine("Fruits That Begin With 'L':");
            // Console.WriteLine("----------");
            // foreach (string f in LFruits)
            // {
            //     Console.WriteLine(f);
            // }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

            IEnumerable<int> fourSixMultiples = numbers.Where(multiple => multiple % 4 == 0 | multiple % 6 == 0);
            // foreach (int multiple in fourSixMultiples)
            // {
            //     Console.WriteLine(multiple);
            // }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
{
            "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
            "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
            "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
            "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
            "Francisco", "Tre"
};

            List<string> descend = names.OrderByDescending(name => name).ToList();
            // foreach (string name in descend)
            // {
            //     Console.WriteLine(name);
            // }

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

            List<int> ascend = numbers2.OrderBy(num => num).ToList();
            // foreach (int num in ascend)
            // {
            //     Console.WriteLine(num);
            // }


            // Output how many numbers are in this list
            List<int> number3 = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

                // Console.WriteLine(number3.Sum());

                // How much money have we made?
            List<double> purchases = new List<double>()
                {
                    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
                };

                // Console.WriteLine(purchases.Sum());

                // What is our most expensive product?
            List<double> prices = new List<double>()
                {
                    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
                };

                double maxPrice = prices.Max(price => price);

                // Console.WriteLine(maxPrice);


                /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
                */
            List<int> wheresSquaredo = new List<int>()
                {
                    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
                };

                IEnumerable<int> notSquaredo = wheresSquaredo.TakeWhile(num => Math.Sqrt(num) % 1 !=0);

            // foreach (int squareNum in notSquaredo){
            //     Console.WriteLine(squareNum);
            // }

            // Build a collection of customers who are millionaires
            List<Customer> customers = new List<Customer>() {
                        new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                        new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                        new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                        new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                        new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                        new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                        new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                        new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                        new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                        new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
                    };

                    IEnumerable<Customer> millionaires = (from customer in customers
                    where customer.Balance > 999999.99
                    orderby customer.Balance descending
                    select customer
                    ).ToList();

                    // foreach(Customer millionaire in millionaires){
                    //     Console.Write($"{millionaire.Name} Balance:{millionaire.Balance} ");
                    //     Console.WriteLine(" ");
                    // }

                    /*
                    Given the same customer set, display how many millionaires per bank.
                    Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                    Example Output:
                    WF 2
                    BOA 1
                    FTB 1
                    CITI 1
                */

                List<BankReport> BankReport = (from customer in customers
                group customer by customer.Bank into BankGroup
                select new BankReport {
                BankName = BankGroup.Key,
                CustomerCount = BankGroup.Count(num => num.Balance >= 1000000)
            }
                ).ToList();
        //         foreach(BankReport bank in BankReport) {
        //         Console.WriteLine($"{bank.BankName} has {bank.CustomerCount}");
        //      }

        // Create some banks and store in a List
        List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

        /*
            You will need to use the `Where()`
            and `Select()` methods to generate
            instances of the following class.

            public class ReportItem
            {
                public string CustomerName { get; set; }
                public string BankName { get; set; }
            }
        */
        List<ReportItem> millionaireReport = (from customer in customers
        where customer.Balance >= 1000000
        join bank in banks on customer.Bank equals bank.Symbol
        select new ReportItem{
            CustomerName = customer.Name,
            BankName = bank.Name
        }).ToList();

        foreach (var item in millionaireReport)
        {
            Console.WriteLine($"{item.CustomerName} at {item.BankName}");
        }

        }
    }
}