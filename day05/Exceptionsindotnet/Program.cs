namespace Exceptionsindotnet
{
    public class ValueException : ApplicationException
    {
        public ValueException(string message) : base(message) { }
    }

    public class Employee
    {
        private string? name;
        private int empNo;
        private decimal basic;
        private short deptNo;
        public string? Name
        {
            set
            {
                if (value != "" && value != null)
                {
                    name = value;
                }
                else throw new ValueException("Dont enter empty name");
            }
            get
            {
                return name;
            }
        }

        public int EmpNo
        {
            set
            {
                if (value > 0)
                {
                    empNo = value;
                }
                else throw new ValueException("enter value for employee no. above 0 for employee");
            }
            get
            {
                return empNo;
            }
        }

        public decimal Basic
        {
            set
            {
                if (value > 0 && value <= 50000)
                {
                    basic = value;
                }
                else throw new ValueException("enter value for basic salary between 0 - 50000");
            }
            get
            {
                return basic;
            }
        }

        public short DeptNo
        {
            set
            {
                if (value > 0)
                {
                    deptNo = value;
                }
                else throw new ValueException("department no must not be null or 0");
            }
            get
            {
                return deptNo;
            }
        }

        public decimal GetNetSalary()
        {
            decimal netSal = basic - (basic * 10 / 100);
            return netSal;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Exceptions are inherited either directly or inDirectly from Exception Class
            //Exception Class has properties like: Message, Source, Targetsite, stack trace, inner exception, etc. 

            //Exception class is inherited to Systemexception and Applicationexception
            //Systemexception has all the exceptions occured w.r.t dotnet defined inbuilt classes and is inherited to 
            //different types of system exceptions like arithematic exception, null reference exception, etc.
            //Applicationexception are used to inherit and create user defined exceptions
            try
            {
                Employee emp1 = new Employee();
                emp1.DeptNo = 10;
                emp1.EmpNo = 10;
                emp1.Basic = -1;
                emp1.Name = "Junaid";
                emp1.GetNetSalary();
            } catch (ApplicationException e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
                System.Console.WriteLine(e.InnerException);
            } finally
            {
                System.Console.WriteLine("Process terminated");
            }
        }
    }
}
