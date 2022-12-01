using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQANDLambdaDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Tommy","Fred","Rashid","Bobby"};

            IEnumerable<string> query = (from s in names
                                        where s.Length == 5
                                        select s).ToList();
            foreach (string s in query)
            {

                Console.WriteLine(s);

            }

            names[0] = "Susie";

            foreach (string s in query)
            {

                Console.WriteLine(s);
            }
        }
    }
}
