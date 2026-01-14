using System;
using System.Collections.Generic;
using System.Text;

namespace FileHandling
{
    public class ArrayFile
    {
        public static void Main()
        {
            string[] lines = { "First line", "Second line", "Third line" };

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(docPath, "test.txt");

            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
            Console.WriteLine("Added");
        }
}
}
