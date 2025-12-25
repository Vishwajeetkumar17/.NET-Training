using System;
using System.Collections.Generic;
using System.Text;

namespace IMultipleInheritance
{
    public interface IVegEater
    {
        void EatVeggies();
        void GetTaste();
    }

    public interface INonVegEater
    {
        void EatNonVeggies();
        void GetTaste();
    }

    public class Visistor : IVegEater, INonVegEater
    {
        public void EatVeggies()
        {
            Console.WriteLine("Eating vegetarian food.");
        }
        public void EatNonVeggies()
        {
            Console.WriteLine("Eating non-vegetarian food.");
        }

        void IVegEater.GetTaste()
        {
            Console.WriteLine("VegEater Test method.");
        }

        void INonVegEater.GetTaste()
        {
            Console.WriteLine("NonVegEater Test method.");
        }

        public void Visit()
        {
            Console.WriteLine("Visitor is visiting.");
        }
    }
}
