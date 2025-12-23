using ConstrutorClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorCLass
{
    /// <summary>
    /// In this file we are  creating object of Program class to test different constructors.
    /// </summary>
    internal class One
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Requirment { get; set; }

        private One()
        {
            Console.WriteLine("Default Constructor Called");
        }

        public One(int id)
        {
            Id = id;
            if (id <= 0)
            {
                throw new Exception("Id should be greater than 0.");
            }
        }

        public One(int id, string name)
        {
            Id = id;
            Name = name;
            if (name.ToLower().Contains("idiot"))
            {
                throw new Exception("You idiot, Don't use this kind of words.");
            }
        }

        public One(int id, string name, string requirment)
        {
            Id = id;
            Name = name;
            Requirment = requirment;
        }
    }
}