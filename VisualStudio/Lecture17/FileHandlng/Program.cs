namespace FileHandling
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\1 Capgemini Training Program\VisualStudio\Lecture17\TextFile\Text.txt";
            try
            {
                File.WriteAllText(path, "Hello, World! This is the first line.");
                Console.WriteLine("Text written to file successfully.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An I/O error occurred: {e.Message}");
            }

            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path);
                    Console.WriteLine("Contents of the file:");
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File not found: {e.Message}");
            }


            string additionalContent = "\nThis is a second line appended later.";

            File.AppendAllText(path, additionalContent);
            Console.WriteLine("Text appended to file successfully.");

            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //    Console.WriteLine("File deleted successfully.");
            //}
        }
    }
}
