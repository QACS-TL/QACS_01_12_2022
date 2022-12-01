

namespace Conditionals
{
    public class Program
    {
        static void Main(string[] args)
        {

            Dog dog = null;


            Console.WriteLine($"Will my dog bark? {dog?.Bark()}");

      



            Mammal m = new Mammal();
            Dog d = (Dog)m.GetMammal(Animal.Dog);
            Console.WriteLine(d.Bark());

            Cat c = (Cat)m.GetMammal(Animal.Cat);
            Console.WriteLine(c.Meow());
            Console.WriteLine(m.Move());

            Mammal nm = m.GetMammal(Animal.Elephant);
            Console.WriteLine($"{(nm == null ? "Squeak" : nm.Move())}");

            DisplayMeasurements(7, 6);
            DisplayMeasurements(8, 8);
            DisplayMeasurements(5, -3);

            Point p = new Point(2, 4);
            Point transformedP = Transform(p);
            Console.WriteLine($"X is {transformedP.X} and Y is {transformedP.Y}");

        }

        public static void DisplayMeasurements(int a, int b)
        {
            switch (a, b)
            {
                case ( > 0, > 0) when a == b:
                    Console.WriteLine($"Both measurements are valid and equal to {a}.");
                    break;
                case ( > 0, > 0):
                    Console.WriteLine($"First measurement is {a}, second measurement is {b}.");
                    break;
                default:
                    Console.WriteLine("One or both measurements are invalid");
                    break;

            }
        }

        public static Point Transform(Point point) => point switch
        {
            { X: 0, Y: 0 } => new Point(0, 0),
            { X: var x, Y: var y } when x < y => new Point(x + y, y),
            { X: var x, Y: var y } when x > y => new Point(x - y, y),
            { X: var x, Y: var y } => new Point(2 * x, 2 * y),
        };
    }

    public class Dog : Mammal
    {
        public string Bark()
        {
            return "Woof";
        }
    }

    public class Cat : Mammal
    {
        public string Meow()
        {
            return "Meow";
        }
    }

    public class Mammal
    {
        public Mammal GetMammal(Animal mammalNumber)
        {
            //switch (mammalNumber)
            //{
            //    case Animal.Dog:

            //        return new Dog();
            //    case Animal.Cat:
            //        return new Cat();
            //}
            //return null;

            Mammal mammal = mammalNumber switch
            {
                Animal.Dog => new Dog(),
                Animal.Cat => new Cat(),
                _ => null
            };
            return mammal;


        }

        public string Move()
        {
            return "Plod plod";
        }
    }

    public enum Animal
    {
        Dog,
        Cat,
        Mouse,
        Elephant
    }

    public readonly struct Point
    {
        public Point(int x, int y) => (X, Y) = (x, y);

        public int X { get; }
        public int Y { get; }
    }
}
