using System;
using System.Collections.Generic;

namespace PersonDetailQ1
{
    /// <summary>
    /// Implements operations on a list of Person objects such as
    /// displaying name and address, calculating average age,
    /// and finding the maximum age.
    /// </summary>
    public class PersonImplementation
    {
        #region Business Logic Methods

        // Returns concatenated name and address details of all persons
        public string GetName(IList<Person> person)
        {
            string detail = "";
            for (int i = 0; i < person.Count; i++)
            {
                detail += person[i].Name;
                detail += " ";
                detail += person[i].Address;
                detail += " ";
            }
            return detail;
        }

        // Calculates and returns the average age of all persons
        public double Average(IList<Person> person)
        {
            double age = 0;
            foreach (var p in person)
            {
                age += p.Age;
            }
            return age / person.Count;
        }

        // Finds and returns the maximum age from the list
        public int Max(IList<Person> person)
        {
            int max = 0;
            foreach (var p in person)
            {
                if (p.Age > max)
                {
                    max = p.Age;
                }
            }
            return max;
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        public static void Main(string[] args)
        {
            IList<Person> p = new List<Person>();
            PersonImplementation pi = new PersonImplementation();

            p.Add(new Person { Name = "Aarya", Address = "A2101", Age = 69 });
            p.Add(new Person { Name = "Daniel", Address = "D104", Age = 40 });
            p.Add(new Person { Name = "Ira", Address = "H801", Age = 25 });
            p.Add(new Person { Name = "Jennifer", Address = "I1704", Age = 33 });

            Console.WriteLine(pi.GetName(p));
            Console.WriteLine(pi.Average(p));
            Console.WriteLine(pi.Max(p));
        }

        #endregion
    }
}
