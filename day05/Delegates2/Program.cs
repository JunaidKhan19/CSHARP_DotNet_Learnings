using System.Reflection.Metadata.Ecma335;

namespace Deligates2
{
    public class Employee
    {
        public int basic = 15000;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee obj = new Employee();

            //Actions are delegates only to be used when the return type is void
            //we can pass parameters in the range 0-16 
            Action<Employee> objAct = Display;
            objAct(obj);

            //Func are delegates only to be used when the return type is not void.
            //we can pass parameters in the range 0-16 and with them a return type as last parameter.
            //the return type is to be passed as the last parameter,
            //even if there are no parameters to be passed a return type is to be mentioned so as to
            //return a value
            Func<Employee, bool> pro2 = returnBasic;
            System.Console.WriteLine(pro2(obj));

            //Predicate are only to be used when there is only one parameter of any type and a boolean return type
            //we do noot need to pass the return type just the parameter type,
            //for example int here
            Predicate<Employee> pro1 = returnBasic;
            System.Console.WriteLine(pro1(obj));
        }

        static bool returnBasic(Employee obj)
        {
            if (obj.basic > 10000)
            {
                return true;
            }
            else return false;
        }

        static void Display(Employee obj) {
            Console.WriteLine($"base salary is {obj.basic}");
        }
    }
}
