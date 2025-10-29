namespace Params
{
    internal class Program
    {
        //static int Add(int a, params int[] arr) //-- always write params at last.
        //static int Add( params int[] arr, int a) //-- dont write params first.
        static int Add(params int[] arr)
        {
            int sum = 0;
            foreach (int item in arr)
            {
                sum += item;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Add(10, 20));
            Console.WriteLine(Add(10, 20, 30, 40, 50, 60, 70, 80, 90));
        }
    }
}
