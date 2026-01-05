using System.Collections.Generic;

namespace GarbageCollector
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Garbage Collector
            while (false)
            {
                var list = new List<byte[]>();
                Console.WriteLine("Total memory before Allocation: " + GC.GetTotalMemory(forceFullCollection: false));
                for (int i = 0; i < 500000; i++)
                {
                    list.Add(new byte[1304259]);
                }

                Console.WriteLine("Allocated");
                Console.WriteLine("Total memory: " + GC.GetTotalMemory(forceFullCollection: false));

                GC.Collect();

                Console.WriteLine("Cleared Memory: " + GC.GetTotalMemory(forceFullCollection: false));
            }

            #endregion

            BigBoy bigBoy = new BigBoy();
            bigBoy.Names = new System.Collections.ArrayList();
            
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    bigBoy.Names.Add(i.ToString());
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                bigBoy.Dispose();
            }
        }
    }
}
