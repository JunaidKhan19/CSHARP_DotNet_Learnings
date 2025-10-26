namespace assignment1
{
    public class Employee
    {
        private string name;
        private int empNo;
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
            set
            {
                if (value > 0)
                {
                    empNo = value;
                }
                else System.Console.WriteLine("enter value above 0 for employee");
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
            emp = new Employee();
            emp.Name = "Junaid";
            emp.DeptNo = 1;
            emp.EmpNo = 1;
            emp.Basic = 10220;
            System.Console.WriteLine("Name: "+ emp.Name);
            System.Console.WriteLine("Department.No: " + emp.DeptNo);
            System.Console.WriteLine("Emp.No: "+ emp.EmpNo);
            System.Console.WriteLine("Basic salary: " + emp.Basic);
            System.Console.WriteLine("Net Salary: " + emp.GetNetSalary());
        }
    }
}
