
namespace ExtensionMethods
{
    //step 1 :
    //create a  static method in a static class
    public static class MyExtClass
    {
        public static int Add(this int i, int j)
        {
            return i + j;
        }
        //step 2 : the 1st parameter must be the type for
        //which you are writing the extension method,
        //preceded by the 'this' keyword
        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }
        public static void Show(this string i)
        {
            Console.WriteLine(i);
        }

        //if you add an ext method for the base class,
        //it is also available for the derived class
        public static void ExtMethodForBaseClass(this object o)
        {
            Console.WriteLine(o);
        }

        //if you add an ext method for an interface,
        //it is also available for all classes that implement that interface
        public static int Subtract(this IMathOperations oIMath, int a, int b)
        {
            return a - b;
        }
    }

    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }
    public class ClsMaths : IMathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    internal class Program
    {
        static void Main1()
        {
            int i = 100;
            i = i.Add(10);
            i.Display();
            i.ExtMethodForBaseClass();

            string s = "aaaa";
            s.Show();
            s.ExtMethodForBaseClass();
        }
        static void Main2()
        {
            int i = 100;
            i = MyExtClass.Add(i, 10);
            MyExtClass.Display(i);
            string s = "aaaa";
            MyExtClass.Show(s);
        }
        static void Main()
        {
            ClsMaths oMaths = new ClsMaths();
            Console.WriteLine(oMaths.Add(10, 2));
            Console.WriteLine(oMaths.Multiply(10, 2));
            Console.WriteLine(oMaths.Subtract(10, 2));

        }
    }
}