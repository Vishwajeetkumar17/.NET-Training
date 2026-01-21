namespace _10SortedArrays
{
    public class Program
    {
        public static T[] Merge<T>(T[] a, T[] b) where T : IComparable<T>
        {
            int n = a.Length;
            int m = b.Length;

            T[] merged = new T[n + m];

            int i = 0, j = 0, k = 0;
            while(i < n && j < m)
            {
                if (a[i].CompareTo(b[j]) <= 0)
                {
                    merged[k++] = a[i++];
                }
                else
                {
                    merged[k++] = b[j++];
                }
            }
            while(i < n)
            {
                merged[k++] = a[i++];
            }
            while(j < m)
            {
                merged[k++] = b[j++];
            }
            return merged;
        }
        static void Main(string[] args)
        {
            int[] arr1 = new int[5];
            int[] arr2 = new int[5];
            Console.WriteLine("Enter elements in First Array: ");
            for(int i=0;i<5;i++)
            {
                arr1[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter elements in Second Array: ");
            for (int i = 0; i < 5; i++)
            {
                arr2[i] = int.Parse(Console.ReadLine());
            }
            int[] mergeArr = Merge(arr1, arr2);

            Console.Write("Merged Array: ");
            Console.WriteLine(string.Join(" ", mergeArr));

            Console.ReadLine();
        }
    }
}
