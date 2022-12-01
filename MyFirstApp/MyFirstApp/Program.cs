

namespace MyFirstApp
{
    public class Program
    {
        static void Main(string[] args)
        {


            Mammal.MammalCount = 100;
            Console.WriteLine($"{Mammal.MammalCount} animals were created");

            Dog dg = new Dog(wagSpeed:5);

            //Mammal m = new Mammal("Mary", 3);

            int i = -1;

            //m.LimbCount = i;
            //Console.WriteLine(m.LimbCount);


            Dog d = (Dog)Mammal.GetMammal(Animal.Dog);

            Console.WriteLine(d.Eat("bones"));

            Cat c = (Cat)Mammal.GetMammal(Animal.Cat);
            Console.WriteLine(c.Meow());

            Console.WriteLine($"{Mammal.MammalCount} animals were created");

            List<Mammal> mammals = new List<Mammal>();
            //mammals.Add(m);
            mammals.Add(dg);
            mammals.Add(d);
            mammals.Add(c);

            foreach(Mammal mammal in mammals)
            {
                Console.WriteLine(mammal.Eat("cheese"));
                if (mammal is Cat)
                {
                    Console.WriteLine(((Cat)mammal).Meow());
                }
                Dog dog = mammal as Dog;
                Console.WriteLine($"{dog?.Bark()}");

                Console.WriteLine(mammal.ToString());

            }

            List<IMovable> movableThings = new();
            movableThings.AddRange(mammals);
            movableThings.Add(new Vehicle());

            foreach(IMovable thing in movableThings)
            {
                Console.WriteLine(thing.Move("Left", 10));
            }


            //Mammal nm = m.GetMammal(Animal.Elephant);
            //Console.WriteLine($"{(nm==null?"Squeak":nm.Move())}");


        }

    }

    public class Dog : Mammal
    {
        int AverageTailWagSpeed;


        public Dog(string name = "Fido", int wagSpeed = 2) : base(name, 4)
        {
            AverageTailWagSpeed = wagSpeed;
        }

        public string Bark()
        {
            return "Woof";
        }

        public override string Eat(string food)
        {
            return  $"I'm a dog using some of my {LimbCount} limbs to gobble {food}";
        }

        public override string ToString()
        {
            return $"Dog called {MammalName}";
        }
    }

    public class Cat : Mammal
    {
        public Cat(string name):base(name, 0)
        {
            
        }

        public string Meow()
        {
            
            return "Meow";
        }

        public override string Eat(string food)
        {
            return $"I'm a cat using some of my {LimbCount} limbs to play with {food}";
        }

        public override string ToString()
        {
            return $"Cat called {MammalName}";
        }
    }

    public abstract class Mammal: IMovable
    {


        public static int MammalCount = 0;
        protected string MammalName;
        private int limbCount = 0;


        public string Squeak()
        {
            return "Squeak";
        }
        public abstract string Eat(string food);

        public int LimbCount
        {
            get { return limbCount; }
            set {
                if (value > 100 || value < 0)
                {
                    value = 0;
                }
                limbCount = value; 
            }
        }

        public int MyProperty { get; }

        //public void SetLimbCount(int limbCount)
        //{
        //    if (limbCount > 100 || limbCount < 0)
        //    {
        //        limbCount = 0;
        //    }
        //    this.limbCount = limbCount;
        //}

        //public int GetLimbCount()
        //{
        //    return this.limbCount;
        //}




        public static int GetMammalCount()
        {
            return MammalCount;
        }

        public Mammal():this("Anon", 4)
        {

        }

        public Mammal(string name, int limbCount)
        {
            MammalName = name;
            MammalCount++;
            LimbCount = limbCount;
        }

        public static Mammal GetMammal(Animal mammalNumber)
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
                Animal.Cat => new Cat("Fifi"),
                _ => null
            };
            return mammal;


        }


        public string Move(string direction, int speed)
        {
            return $"I'm a mammal using my {LimbCount} limbs to move {direction} at {speed} kph";
        }
    }

    public enum Animal
    {
        Dog,
        Cat,
        Mouse,
        Elephant
    }


}



