namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //arrays methods
            int[] arr = new int[5] { 10, 20, 30, 40, 50 };
            //int[] arr2 = { 10, 20, 30 };
            //int[] arr3 = new int[] { 10, 20, 30, 40, 50,60 };
            int pos;
            pos = Array.IndexOf(arr, 30);//2
            pos = Array.IndexOf(arr, 35);//-1

            pos = Array.LastIndexOf(arr, 30);
            pos = Array.BinarySearch(arr, 30);// negative no if not found

            Array.Clear(arr);

            //Array.Copy(arr, 0, arr2, 1, arr.Length);
            //Array.Copy(arr,arr2, arr.Length);

            //Array.ConstrainedCopy(arr,0,arr2,1,arr.Length);

            int[] arr3 = (int[])Array.CreateInstance(typeof(int), 5);
            Array.Sort(arr);
            Array.Reverse(arr);
            
        }
    }
}
