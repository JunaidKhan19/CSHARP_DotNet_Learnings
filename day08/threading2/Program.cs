namespace threading2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            string[] arr = new string[2];
            arr[0] = "a";
            arr[1] = "b";
            t1.Start(arr);
            //t1.Start("passed value");

            Thread t2 = new Thread(Func2);
            Class1 obj = new Class1 { P1 = 1, P2 = "aaa" };
            t2.Start(obj);
            //t2.Start(1234);
        }

        //problem statement - pass more than one value to func
        //1. create a class/struct with the properties to be passed.
        //   create an object , and pass the object
        //2. create an array/collection. 
        //3. create a local func/anon method/lambda.
        //local variables can be directly accessed, no need to pass them.
        static void Func1(object o)
        {
            string[] arr = (string[])o;
            Console.WriteLine("First : " + arr[0]);
            Console.WriteLine("First : " + arr[1]);

            //Console.WriteLine("First : " + o);
        }
        static void Func2(object o)
        {
            Class1 obj = (Class1)o;
            Console.WriteLine("Second : " + obj.P1);
            Console.WriteLine("Second : " + obj.P2);

            //Console.WriteLine("Second : " + o);
        }
    }

    public class Class1
    {
        public int P1 { get; set; }
        public string P2 { get; set; }

    }
}
