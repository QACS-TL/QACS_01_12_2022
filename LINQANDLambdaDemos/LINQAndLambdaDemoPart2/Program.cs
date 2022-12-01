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
            //*********** Use of explicit delegates ************

        //Calling function by name
        //Predicates are Functions that return a boolean so ok to use IsItemBiggerThan10:
        Console.WriteLine("Numbers Bigger than 10 Using FindAll a delegate and an explicit predicate function call: ");
            Predicate<int> myPredicate = IsItemBiggerThan10;
            numbersBiggerThan10 = numbers.FindAll(myPredicate);

            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }

            //Calling anonymous function using LINQ's Where method
            Console.WriteLine("Numbers Bigger than 10 Using Where and a Func<int, bool> delegate: ");
            Func<int, bool> myFunc; // = IsItemBiggerThan10;
            myFunc = (n => n > 10);
            bool result = myFunc.Invoke(11);

            numbersBiggerThan10 = numbers.Where(myFunc).ToList();
            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }

            //*********** Use of anonymous functions ************

            //Calling anonymous function using LINQ's FindAll method notation
            Console.WriteLine("Numbers Bigger than 10 Using FindAll and an anonymous function call: ");
            numbersBiggerThan10 = numbers.FindAll(delegate (int n)
            {
                return n > 10;
            }).ToList();

            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }

            //Calling anonymous function using LINQ's Where method
            Console.WriteLine("Numbers Bigger than 10 Using Where and anonymous delegate function call: ");
            numbersBiggerThan10 = numbers.Where(delegate (int n)
            {
                return n > 10;
            }).ToList();

            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }

            //Calling anonymous function using LINQ's FindAll method notation
            Console.WriteLine("Numbers Bigger than 10 Using FindAll and an anonymous function call: ");
            numbersBiggerThan10 = numbers.FindAll(n => n > 10); //limited to a single line of code
            foreach (int val in numbersBiggerThan10)
            {
                Console.WriteLine(val);
            }

            //Calling anonymous function using LINQ's Where  and "method" notation
            Console.WriteLine("Numbers Bigger than 10 Using Where and an anonymous function call: ");
            //Using "expression lambdas"
            numbersBiggerThan10 = numbers.Where(n => n > 10).ToList(); //limited to a single line of code
            numbersBiggerThan10.ForEach(n => Console.WriteLine(n));

            //Using "statement lambdas"
            Func<int, bool> IsnumberBiggerThan10TestAndPrint = n =>
            {
                if (n > 10)
                {
                    Console.WriteLine(n);
                    return true;
                }
                return false;
            };

            numbersBiggerThan10 = numbers.Where(IsnumberBiggerThan10TestAndPrint).ToList();



            //Using LINQ's query notation
            Console.WriteLine("Numbers Bigger than 10 Using LINQ's Query notation and inbuilt ForEach: ");
            List<int> twoDigitNumbers = (from i in numbers
                                            where i > 10
                                            select i).ToList();
            twoDigitNumbers.ForEach(n => Console.WriteLine(n));



            //More than a single parameter
            Console.WriteLine("Lambdas that take more than one parameter: ");

            IList<int> list = new List<int>();

            list.Add(0); // value = index
            list.Add(2);
            list.Add(2); // value = index
            list.Add(3); // value = index
            list.Add(7);
            list.Add(5); // value = index

            List<int> sublist = list.Where((i, index) => i == index).ToList();
            sublist.ForEach(n => Console.WriteLine(n));


            //ModifyInt multiplier = ((a, b) => a * b);
            Func<int, int, int> Multiplier = ((a, b) => a * b);

            List<int> multiples = new List<int>();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int a = numbers[i];
                int b = numbers[i + 1];

                multiples.Add(Multiplier(numbers[i], numbers[i + 1]));
            }
            multiples.ForEach(n => Console.WriteLine(n));

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
