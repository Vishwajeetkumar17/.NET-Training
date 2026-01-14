namespace LinqExample
{
    public class Program
    {
        public string name;
        static void Main(string[] args)
        {
            string[] names = {"A", "B", "C"};
            foreach(var item in names)
            {
                if (item == "B") Console.WriteLine("B is Present");
            }

            var findName = from item in names where item == "B" select item;
            if (findName != null)
                Console.WriteLine("B is Present");
            else Console.WriteLine("Not Present");

            var findNames = from item in names orderby item descending select item;
            foreach (var item in findNames)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            var printNames = from item in names select new Program() { name = item };
            foreach (var item in printNames)
            {
                Console.WriteLine(item.name);
            }

            //LinqExample2();
            LinqExample3();

            
        }

        private static void LinqExample2()
        {
            var precCollection = from p in System.Diagnostics.Process.GetProcesses() select new MyProcess() { Name = p.ProcessName, Id =  p.Id };
            foreach(var prec in precCollection)
            {
                Console.WriteLine($"Process Name = {prec.Name}, Id = {prec.Id}");
            }
        }

        private static void LinqExample3()
        {
            var precCollection = from p in System.Diagnostics.Process.GetProcesses() select new { Name = p.ProcessName, Id = p.Id };
            foreach (var prec in precCollection)
            {
                Console.WriteLine($"Process Name = {prec.Name}, Id = {prec.Id}");
            }
        }
    }
}