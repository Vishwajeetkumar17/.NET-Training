using System;
using System.Security.Cryptography.X509Certificates;

namespace PersonClass
{
    public class Program
    {

        public string getDetails(Person p)
        {
            if (p is Man)
            {
                Man man = (Man)p;
                return $"id : {man.Id}, Name : {man.Name}, Age : {man.age}, Playing : {man.Playing}";

            }

            if (p is Man)
            {
                Man man1 = (Man)p;
                return $"id : {man1.Id}, Name : {man1.Name}, Age : {man1.age}, Playing : {man1.Playing}";

            }
            if (p is Woman)
            {
                Woman woman = (Woman)p;
                return $"id : {woman.Id}, Name : {woman.Name}, Age : {woman.age}, Play and Manage : {woman.PlayAndManage}";
            }
            if (p is Child)
            {
                Child child = (Child)p;
                return $"id : {child.Id}, Name : {child.Name}, Age : {child.age}, Study : {child.Study}";
            }
            return $"id : {p.Id}, Name : {p.Name}, Age : {p.age}";
        }
        public static void Main(string[] args)
        {
            Program program = new Program();

            Person person = new Person
            {
                Id = 1,
                Name = "Rohan",
                age = 30
            };

            program.getDetails(person);



            Person p = new Man
            {
                Id = 2,
                Name = "A",
                age = 25,
                Playing = "Football"
            };

            program.getDetails(p);

            Person p1 = new Man(5, "D", 32, "Cricket");

            program.getDetails(p1);


            Person p2 = new Woman
            {
                Id = 3,
                Name = "B",
                age = 28,
                PlayAndManage = "Yes"
            };

            program.getDetails(p2);


            Person p3 = new Child
            {
                Id = 4,
                Name = "C",
                age = 10,
                Study = "Maths"
            };

            program.getDetails(p3);

            Console.WriteLine(program.getDetails(person));
            Console.WriteLine(program.getDetails(p));
            Console.WriteLine(program.getDetails(p1));
            Console.WriteLine(program.getDetails(p2));
            Console.WriteLine(program.getDetails(p3));
        }
    }
}