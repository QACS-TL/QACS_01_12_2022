using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQANDLambdaDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers;
            List<int> numbersBiggerThan10 = new List<int>();

            numbers = GetNumbers();

            //Traditional Approach
            foreach (int val in numbers)
            {
                if (val > 10)
                    numbersBiggerThan10.Add(val);
            }
            Console.WriteLine("Numbers Bigger than 10: ");
            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }

            numbersBiggerThan10.Clear();
            //Traditional Approach Calling comparison Function
            foreach (int val in numbers)
            {
                if (IsItemBiggerThan10(val))
                    numbersBiggerThan10.Add(val);
            }
            Console.WriteLine("Numbers Bigger than 10: ");
            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }

            List<int> firstThreeNumbers = numbersBiggerThan10.Take(3).ToList();
            foreach (int val in firstThreeNumbers)
            {
                Console.WriteLine(val);
            }

            //Is every value in collection bigger than 10?
            if (numbersBiggerThan10.All(IsItemBiggerThan10))
                Console.WriteLine("All the numbers in the collection are bigger than 10");

            List<int> oddNumbers = new List<int>(){ 1, 3, 5, 7 };
            List<int> evenNumbers = new List<int>() { 2, 4, 6, 8 };
            // numbers will contain all values from both collections including duplicates
            List<int> allNumbers = oddNumbers.Union(evenNumbers).ToList();
            foreach (int val in allNumbers)
            {
                Console.WriteLine(val);
            }

            //numbers will contain integers that occur in one or other of the collections
            //but not both
            List<int> assortedNumbers = new List<int>() { 3, 4, 5, 6, 8 };
            List<int> exceptedNumbers = oddNumbers.Except(assortedNumbers).ToList();
            foreach (int val in exceptedNumbers)
            {
                Console.WriteLine(val);
            }

            numbers = GetNumbers();
            //Calling function by name
            Console.WriteLine("Numbers Bigger than 10 Using FindAll and an explicit function call: ");
            //Predicates are Functions that return a boolean so ok to use IsItemBiggerThan10:
            numbersBiggerThan10 = numbers.FindAll(IsItemBiggerThan10);
            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }

            //Calling anonymous function using LINQ's Where method (needs a using System.Linq directive)
            Console.WriteLine("Numbers Bigger than 10 Using Where an explicit function call: ");
            numbersBiggerThan10 = numbers.Where(IsItemBiggerThan10).ToList();
            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }

            foreach( int val in numbers.Where(IsItemBiggerThan10))
            {
                Console.WriteLine(val);
            }



            Console.WriteLine(numbersBiggerThan10.First());
            Console.WriteLine(numbersBiggerThan10.Last());
            Console.WriteLine(numbersBiggerThan10.Max());
            Console.WriteLine(numbersBiggerThan10.Min());
            Console.WriteLine(numbersBiggerThan10.Average());
            Console.WriteLine(numbersBiggerThan10.Any()); //Returns boolean indicating if collection has at least one item
            numbersBiggerThan10.Reverse();
            numbersBiggerThan10 = numbersBiggerThan10.Distinct().ToList();

            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }
 

        }

        static bool IsItemBiggerThan10(int n)
        {
            return (n > 10);
        }

        static List<int> GetNumbers()
        {
            return new List<int>() { 12, 4, 56, 8, 44, 2, 11, 10, 9, 17, 44 };
        }
    }

    public delegate int ModifyInt(int a, int b);

}
