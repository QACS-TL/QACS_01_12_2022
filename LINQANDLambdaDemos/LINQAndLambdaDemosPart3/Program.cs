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
            int total = numbers.Sum();


            //Summarising Data:
            //Max Value
            int maxNumber = (from i in numbers
                             where i > 10
                             select i).Max();
            Console.WriteLine($"Maximum value in numbers is {maxNumber}");

            //Min Value
            int minNumber = numbers.Min();
            Console.WriteLine($"Minimum value in numbers is {minNumber}");

            //Min Value greater than 10
            int minNumberGreaterThanTen = (from i in numbers
                                           where i > 10
                                           select i).Min();
            Console.WriteLine($"Minimum value in numbers that is greater than 10 using 'Query' syntax is {minNumberGreaterThanTen}");

            //Or using Method syntax:
            minNumberGreaterThanTen = numbers.Where(n => n > 10).Min();
            Console.WriteLine($"Minimum value in numbers that is greater than 10 using 'Method' syntax is {minNumberGreaterThanTen}");

            double averageOfNumbersGreaterThan10 = numbers.Where(n => n > 10).Average();
            Console.WriteLine($"The average of numbers greater than 10 is {averageOfNumbersGreaterThan10}");

            Console.WriteLine("Numbers Bigger than 10 in sequence with no duplicates using 'Query' syntax: ");

            // LINQ Query syntax
            List<int> orderedTwoDigitNumbers = (from i in numbers
                                                where i > 10
                                                orderby i
                                                select i).Distinct().ToList();
            orderedTwoDigitNumbers.ForEach(n => Console.WriteLine(n));

            // LINQ Method syntax
            Console.WriteLine("Numbers Bigger than 10 in sequence with no duplicates using 'Method' syntax: ");
            orderedTwoDigitNumbers = numbers.Where(n => n > 10).OrderBy(n => n).Distinct().ToList();
            orderedTwoDigitNumbers.ForEach(n => Console.WriteLine(n));

            Console.WriteLine("Average of numbers bigger than 10 using 'Method' syntax: ");
            double averageOfDistinctNumbersBiggerThanTen = numbers.Where(n => n > 10).Distinct().Average();
            Console.WriteLine($"Average of numbers greater than 10 using 'Method' syntax is {averageOfDistinctNumbersBiggerThanTen}");

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
