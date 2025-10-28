namespace Nullabletypes
{
    internal class Program
    {
        static void Main1()
        {
            int? i = 10;
            i = null;
            int j;
            if (i != null)
                j = (int)i;
            else
                j = 0;
            if (i.HasValue)
                j = i.Value;
            else
                j = 0;
            j = i.GetValueOrDefault();
            j = i.GetValueOrDefault(5);
            j = i ?? 0; //null coalesence operator

            Console.WriteLine(j);
        }
        static void Main()
        {
            //nullable reference type
            string? s;
            s = Console.ReadLine()!; //single line suppress
            s = Console.ReadLine();

            //string printing ways
            int[] arr = new int[5];
            //arr[0].....arr[4]
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter arr[__] : ");
                Console.Write("Enter arr[" + i + "] : "); //string concatenation
                Console.Write("Enter arr[{0}] : ", i); //placeholder
                Console.Write($"Enter arr[{i}] : "); //string interpolation
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
