using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadingExample
{
    public class ThreadingCode
    {
        #region First
        public static void Test1()
        {
            Console.WriteLine("Test1 starting");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test1: " + i);
            }
            Console.WriteLine("Test1 ending");
        }

        public static void Test2()
        {
            Console.WriteLine("Test2 starting");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test2: " + i);
                if (i == 50)
                {
                    Thread.Sleep(5000);
                }
            }
            Console.WriteLine("Test2 ending");
        }

        public static void Test3()
        {
            Console.WriteLine("Test3 starting");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test3: " + i);
            }
            Console.WriteLine("Test3 Ending");
        }
        #endregion

        #region Second

        //public static void Test1()
        //{
        //    Console.WriteLine("Test1 starting");
        //    for (int i = 1; i <= 100; i++)
        //    {
        //        Console.WriteLine("Test1: " + i);
        //    }
        //    Console.WriteLine("Test1 ending");
        //}

        //public static void Test2()
        //{
        //    Console.WriteLine("Test2 starting");
        //    for (int i = 1; i <= 100; i++)
        //    {
        //        Console.WriteLine("Test2: " + i);
        //        if (i == 50)
        //        {
        //            Thread.Sleep(5000);
        //        }
        //    }
        //    Console.WriteLine("Test2 ending");
        //}

        //public static void Test3()
        //{
        //    Console.WriteLine("Test3 starting");
        //    for (int i = 1; i <= 100; i++)
        //    {
        //        Console.WriteLine("Test3: " + i);
        //    }
        //    Console.WriteLine("Test3 Ending");
        //}

        #endregion

        #region Third

        //public void Display()
        //{
        //    //this lock helps to lock the thread if the same process is callling again in the execution.
        //    lock (this)
        //    {
        //        Console.Write("[CSharp is a ");
        //        Thread.Sleep(5000);
        //        Console.WriteLine("Object Oriented Language]");
        //    }
        //}

        #endregion

        #region Four

        //static bool stop = false;
        //static long count1, count2;

        //public static void Increment1()
        //{
        //    while (!stop)
        //    {
        //        count1 += 1;
        //    }
        //}

        //public static void Increment2()
        //{
        //    while (!stop)
        //    {
        //        count2 += 1;
        //    }
        //}

        #endregion


        static void Main(string[] args)
        {
            #region First

            Console.WriteLine("Main thread started");
            Thread T1 = new Thread(Test1);
            Thread T2 = new Thread(Test2);
            Thread T3 = new Thread(Test3);
            T1.Start(); T2.Start(); T3.Start();
            Console.WriteLine("Main thread exited");

            #endregion

            #region Second

            //Console.WriteLine("Main thread started");
            //Thread T1 = new Thread(Test1);
            //Thread T2 = new Thread(Test2);
            //Thread T3 = new Thread(Test3);
            //T1.Start(); T2.Start(); T3.Start();

            ////here .Join() helps to wait for the next execution before completing the previous one and i have passed the T2.Join(2000) this thing will make only wait for 2 seconds and after that next things can execute.
            //T1.Join(); T2.Join(2000); T3.Join();
            //Console.WriteLine("Main thread exited");

            #endregion

            #region Third

            //Program p = new Program();
            //Thread T1 = new Thread(p.Display);
            //Thread T2 = new Thread(p.Display);
            //Thread T3 = new Thread(p.Display);
            //T1.Start(); T2.Start(); T3.Start();

            #endregion

            #region Four

            //Thread T1 = new Thread(Increment1);
            //Thread T2 = new Thread(Increment2);

            //T1.Priority = ThreadPriority.Lowest;
            //T2.Priority = ThreadPriority.Highest;

            //T1.Start();
            //T2.Start();

            //Console.WriteLine("Main Thread going to sleep");
            //Thread.Sleep(10000);
            //Console.WriteLine("Main Thread woke up.");

            //stop = true;

            //T1.Join();
            //T2.Join();

            //Console.WriteLine("Count1 : " + count1);
            //Console.WriteLine("Count2 : " + count2);

            #endregion
        }
    }
}
