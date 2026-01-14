namespace ThreadingExample
{
    public class Program
    {
        public async Task AsyncMethod()
        {
            Console.WriteLine("Task Started");
            await Task.Delay(3000);
            Console.WriteLine("Task completed after 3 seconds");
        }
        public async void CallMethod()
        {
            string result = await FetchDataAsync("https://jsonplaceholder.typicode.com/todos");
            Console.WriteLine(result);
            await AsyncMethod();
        }

        public async Task<string> FetchDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                return response;
            }
        }
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.CallMethod();

            Console.ReadLine();
        }
    }
}
