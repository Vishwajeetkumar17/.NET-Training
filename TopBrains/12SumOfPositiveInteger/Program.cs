namespace _12SumOfPositiveInteger
{
    public class Program
    {
        public static int SumPositive(int[] nums)
        {
            int sum = 0;

            if (nums == null || nums.Length == 0)
                return sum;

            foreach (int n in nums)
            {
                if (n == 0)
                    break;
                if (n < 0)
                    continue;
                sum += n;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            int result = SumPositive(nums);
            Console.WriteLine(result);
        }
    }
}
