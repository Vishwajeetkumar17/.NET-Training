using System;
using System.Collections.Generic;
using System.Text;

namespace Example_enum
{
    public enum Semester
    {
        Semester1 = 1,
        Semester2 = 2
    };

    public enum Subject
    {
        Maths = 11,
        Python = 12,
        Physics = 13,
        Electronics = 14,
        CProgramming = 15,
        DSA = 21,
        Java = 22,
        DBMS = 23,
        OS = 24,
        Networking = 25
    }
    public class SemSubjectEnum
    {
        public static void Main()
        {
            int[,] semSubject = new int[2, 5];
            semSubject[0, 0] = (int)Subject.Maths;
            semSubject[0, 1] = (int)Subject.Python; 
            semSubject[0, 2] = (int)Subject.Physics;
            semSubject[0, 3] = (int)Subject.Electronics;
            semSubject[0, 4] = (int)Subject.CProgramming;
            semSubject[1, 0] = (int)Subject.DSA;
            semSubject[1, 1] = (int)Subject.Java;
            semSubject[1, 2] = (int)Subject.DBMS;
            semSubject[1, 3] = (int)Subject.OS;
            semSubject[1, 4] = (int)Subject.Networking;

            for (int i = 0; i < semSubject.GetLength(0); i++)
            {
                Console.WriteLine($"{(Semester)(i + 1)}:");
                for (int j = 0; j < semSubject.GetLength(1); j++)
                {
                    Console.WriteLine($"  {(Subject)semSubject[i, j]}");
                }
                Console.WriteLine();
            }
        }
        
        
    }
}
