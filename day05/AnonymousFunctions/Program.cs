namespace AnonymousFunctions
{
    public class Class1
    {
        public void Display()
        {
            int i = 100;
            System.Console.WriteLine($"value of i in Display : {i}");
            DoSomething();
            void DoSomething()
            {
                i++;
                System.Console.WriteLine($"value of i in doSomething local function : {i}");
            }
        }
    }

    public class Employee
    {
        public int basic = 12000;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Local functions :
            //local functions are the functions made locally i.e inside a function.
            //local function can access the variables declared in the outer function
            // they are implicitly private and cannot be overloaded
            Class1 lclfunc = new Class1();
            lclfunc.Display();

            //Anonymous methods does not have name and can be called using deligates 
            //Anonymous methods can access the local variables 
            //local methods cant work with anonymous types(i.e. class) but Anonymous methods can 
            Func<int, int, int> addAnonym = delegate(int a, int b)
            {
                return a + b;
            };
            System.Console.WriteLine(addAnonym(1, 2));


            //way 2: Lambda expressions
            //Lambda is an example of anonymous method 
            //which means that it is a method without name but is written as expression
            //hence shortening the code
            Func<string> getTime = () => DateTime.Now.ToLongTimeString();
            System.Console.WriteLine(getTime());

            Func<int, int, int> addLambda = (a, b) => a + b;
            System.Console.WriteLine(addLambda(1, 2));

            Predicate<int> isEven = a => a % 2 == 0;
            System.Console.WriteLine(isEven(1));

            Employee obj = new Employee();
            Predicate<Employee> isBasicGreater = obj => obj.basic > 10000;
            System.Console.WriteLine(isBasicGreater(obj));

        }
    }
}
