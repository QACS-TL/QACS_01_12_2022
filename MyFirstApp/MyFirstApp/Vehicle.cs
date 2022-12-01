using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Vehicle : IMovable
    {
        public string Move(string direction, int speed)
        {
            return $"I'm a car spinning my wheels {direction} at {speed} mph";
        }
    }
}
