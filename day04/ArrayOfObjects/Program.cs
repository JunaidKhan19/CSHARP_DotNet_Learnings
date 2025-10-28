/*
2. Create an array of Employee class objects
        Accept details for all Employees
        Display the Employee with highest Salary
        Accept EmpNo to be searched. Display all details for that employee.
 */

namespace ArrayOfObjects
{
    public class Employee
    {
        private int empNo;
        private string? empName;

        public int EmpNo
        {
            get { return empNo; }
            set { empNo = value; }
        }

        public string? EmpName
        {
            get { return empName; }
            set { empName = value; }
        }

        public Employee(int empNo, string? empName)
        {
            this.empNo = empNo;
            this.empName = empName;
        }

        public void Display()
        {
            Console.WriteLine($"Employee No: {empNo}, Name: {empName}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Enter number of employees: ");
            int n = int.Parse(System.Console.ReadLine());

            Employee[] employees = new Employee[n];
            for (int i = 0; i < employees.Length; i++)
            {
                //Employee emp = new Employee(1,"junaid");
                System.Console.WriteLine($"enter employee at {i + 1} employee no: ");
                int empno = int.Parse(System.Console.ReadLine());
                System.Console.WriteLine($"enter employee {i + 1} name: ");
                string empname = System.Console.ReadLine();
                employees[i] = new Employee(empno, empname);
            }

            foreach (Employee employee in employees)
            {
                System.Console.WriteLine($"empNo {employee.EmpNo} : {employee.EmpName} ");
            }
        }
    }
}
