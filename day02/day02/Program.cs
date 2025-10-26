namespace day02
{
    public class Employee
    {
        private string name;
        private static int empNo;
        private decimal basic;
        private short deptNo;
        public string Name
        {
            set
            {
                if (value != "" && value != null)
                {
                    name = value;
                }
                else System.Console.WriteLine("Dont enter the empty name");
            }
            get
            {
                return name;
            }
        }

        public int EmpNo
        {
            get;
        }

        public decimal Basic
        {
            set
            {
                if (value > 0 && value <= 50000)
                {
                    basic = value;
                }
                else System.Console.WriteLine("enter value between 0 - 50000");
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
                else System.Console.WriteLine("enter value above 0");
            }
            get
            {
                return deptNo;
            }
        }

        public Employee(string name = " ", decimal basic = 0, short deptNo = 0)
        {
            Name = name;
            Basic = basic;
            DeptNo = deptNo;
            EmpNo = ++empNo;
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
            Employee emp;
            emp = new Employee("Junaid", 10220, 1);
            System.Console.WriteLine("Name: " + emp.Name);
            System.Console.WriteLine("Department.No: " + emp.DeptNo);
            System.Console.WriteLine("Emp.No: " + emp.EmpNo);
            System.Console.WriteLine("Basic salary: " + emp.Basic);
            System.Console.WriteLine("Net Salary: " + emp.GetNetSalary());

            Employee emp2;
            emp2 = new Employee("Junaid", 10220, 1);
            System.Console.WriteLine("Emp.No: " + emp2.EmpNo);

            Employee emp3;
            emp3 = new Employee("Junaid", 10220, 1);
            System.Console.WriteLine("Emp.No: " + emp3.EmpNo);

            System.Console.WriteLine("Emp.No: " + emp3.EmpNo);
            System.Console.WriteLine("Emp.No: " + emp2.EmpNo);
            System.Console.WriteLine("Emp.No: " + emp.EmpNo);
        }
    }
}
