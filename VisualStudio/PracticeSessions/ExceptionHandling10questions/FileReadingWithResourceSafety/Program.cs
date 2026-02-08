namespace FileReadingWithResourceSafety
{
    using System;
    using System.IO;

    class FileReader
    {
        static void Main()
        {
            StreamReader reader = null;
            string filePath = "data.txt";

            // TODO:
            // 1. Read file content
            try
            {
                reader = new StreamReader(filePath);
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            // 2. Handle FileNotFoundException
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: You do not have permission to access this file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error: {ex.Message}");
            }
            // 3. Handle UnauthorizedAccessException
            // 4. Ensure resource is closed properly
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                    Console.WriteLine("File Closed");
                }
            }
        }
    }
}
