using System;
using System.Collections.Generic;
using System.Text;

namespace PersonClass
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }

        public Person()
        {
            Id = 0;
            Name = string.Empty;
            age = 0;
        }

        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            age = age;
        }
    }
    public class Man : Person
    {
        public string Playing { get; set; }

        public Man()
        {
            Id = 0;
            Name = string.Empty;
            age = 0;
            Playing = string.Empty;
        }

        public Man(int id, string name, int age, string playing) : base(id, name, age)
        {
            Playing = playing;
        }
    }

    public class Woman : Person
    {
        public string PlayAndManage { get; set; }

        public Woman()
        {
                       Id = 0;
            Name = string.Empty;
            age = 0;
            PlayAndManage = string.Empty;

        }
    }

    public class Child : Person
    {
        public string Study { get; set; }

        public Child()
        {
                       Id = 0;
            Name = string.Empty;
            age = 0;
            Study = string.Empty;

        }
    }
}
