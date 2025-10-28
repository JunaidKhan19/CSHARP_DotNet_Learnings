namespace Employee_inheritence
{
    public interface IDBfunctions
    {
        void Select();
        void Delete();
    }

    public abstract class Employee : IDBfunctions
    {
        private string? name;
        private short deptNo;
        protected decimal basic;
        public abstract decimal Basic { set; get; }

        private static int lastEmpCount = 0;

        public string? Name
        {
            get { return name; }
            set
            {
                if (value != null || value != " ")
                {
                    name = value;
                }
                else System.Console.WriteLine("Please enter name dont enter empty values");
            }
        }

        public int EmpNo
        {
            get;
        }

        public short DeptNo
        {

            get { return deptNo; }
            set
            {
                if (value > 0)
                {
                    deptNo = value;
                }
                else System.Console.WriteLine("Invalid value for dept.no, enter value > 0");
            }
        }

        public Employee(string Name = "default", decimal Basic = 10000, short DeptNo = 1)
        {
            this.EmpNo = ++lastEmpCount;
            this.Name = Name;
            this.Basic = Basic; //SINCE ABSTRACT FUNCTION IS A PURE VIRTUAL FUNCTION THIS LINE OF CODE WILL CALL THE CORRECT MEMORY ALLOCATED FOR THE ABSTRACT PROPERTY
            this.DeptNo = DeptNo;
        }

        public abstract decimal CalcNetSalary();

        public virtual void Select()
        {
            System.Console.WriteLine("calling the select from Employee");
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }

    public class Manager : Employee
    {
        private string? designation;
        public string? Designation
        {
            get { return designation; }
            set
            {
                if (value != null || value != " ")
                {
                    designation = value;
                }
                else System.Console.WriteLine("Please enter name dont enter empty values");
            }
        }
        public Manager(string Name = "default", decimal Basic = 10000, short DeptNo = 1, string Designation = "Manager") : base(Name, Basic, DeptNo)
        {
            this.Designation = Designation;
        }

        public override decimal Basic
        {
            get { return basic; }

            set
            {
                if (value > 10000 && value < 40000)
                {
                    basic = value;
                }
                else System.Console.WriteLine("enter value greater than 10000 and less than 40000");
            }
        }

        public override decimal CalcNetSalary()
        {
            return (basic - (basic * 18 / 100));
        }

        public override void Select()
        {
            System.Console.WriteLine("calling the select from Manager");
        }
    }

    public class GeneralManager : Manager
    {
        public string? Perks { set; get; }

        public GeneralManager(string Name = "default", decimal Basic = 10000, short DeptNo = 1, string Designation = "Manager", string Perks = "less tax deduction") : base(Name, Basic, DeptNo, Designation)
        {
            this.Perks = Perks;
        }

        public override decimal Basic
        {
            get { return basic; }

            set
            {
                if (value > 10000 && value < 80000)
                {
                    basic = value;
                }
                else System.Console.WriteLine("enter value greater than 10000 and less than 80000");
            }
        }

        public override decimal CalcNetSalary()
        {
            return (basic - (basic * 15 / 100));
        }
    }

    public class CEO : Employee
    {
        public override decimal Basic
        {
            get { return basic; }
            set { basic = value; }
        }

        public CEO(string Name = "default", decimal Basic = 10000, short DeptNo = 1) : base(Name, Basic, DeptNo)
        {
            this.Basic = Basic;
        }


        public sealed override decimal CalcNetSalary()
        {
            return (basic - (basic * 10 / 100));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GeneralManager obj = new GeneralManager("Junaid", 70000, 2, "General Manager", "less tax more bonus");
            System.Console.WriteLine(obj.EmpNo);
            System.Console.WriteLine(obj.Name);
            System.Console.WriteLine(obj.Basic);
            System.Console.WriteLine(obj.Perks);
            System.Console.WriteLine(obj.Designation);
            System.Console.WriteLine(obj.CalcNetSalary());
        }
    }
}
