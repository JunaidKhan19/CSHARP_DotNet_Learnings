namespace ImplicitVariables
{
    internal class Program
    {
        static void Main()
        {
            int i = 100;
            var j = 100; //implicit variable
                         //used only for local variables
                         //cant be used for class level vars,fn params and return types
            j = 200;
            //i = "aa";  //error

            var k = "aaa";
            //k = 1234;  //error

            Console.WriteLine(j);
            Console.WriteLine(j.GetType());
        }
    }
}

namespace AnonymousTypes
{
    internal class Program
    {
        static void Main2()
        {
            var obj = new { a = 1, b = "aaa", c = true };
            var obj2 = new { a = 2, b = "bbb", c = false, d = 1 };

            Console.WriteLine(obj.a);
            Console.WriteLine(obj.b);
            Console.WriteLine(obj.c);

            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj2.GetType());

        }
    }
}