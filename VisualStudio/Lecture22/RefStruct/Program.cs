namespace RefStruct
{
    public ref struct TempBuffer
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }

        public void DoWork()
        {
            Console.WriteLine("Working with buffer");
        }
    }

    class Program
    {
        static void Main()
        {
            UseBuffer();
        }

        static void UseBuffer()
        {
            using var buf = new TempBuffer();
            buf.DoWork();
        }
    }
}
