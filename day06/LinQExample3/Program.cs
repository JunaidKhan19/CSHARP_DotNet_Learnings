namespace LinQExample3
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }

    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();

        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vishal", Basic = 11000, DeptNo = 10, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }

        public static void AddRecs2()
        {
            for (int i = 0; i < 200; i++)
            {
                lstEmp.Add(new Employee { EmpNo = i + 1, Name = "Vikram" + (i + 1), Basic = 10000, DeptNo = 10, Gender = "M" });
            }
        }

        static void Main()
        {
            AddRecs();

            //Single
            //without default
            Employee emp1 = lstEmp.Single(e => e.EmpNo == 1); //one record if present
            //Employee emp2 = lstEmp.Single(e => e.EmpNo == 10);  //no records = error
            //Employee emp3 = lstEmp.Single(e => e.Basic > 5000); //multiple records => error

            //Single
            //with default
            Employee emp4 = lstEmp.SingleOrDefault(e => e.EmpNo == 1); //one record if present
            Employee emp5 = lstEmp.SingleOrDefault(e => e.EmpNo == 10); //no records => null
            //Employee emp6 = lstEmp.SingleOrDefault(e => e.Basic > 5000);//multiple records =>  error

            //lstEmp.ElementAt(10);// error
            //lstEmp.ElementAtOrDefault(10); //null if no records
            //lstEmp.First();// can give error
            //lstEmp.First(e => e.Basic > 10000); //error if condition doesnt match
            //lstEmp.FirstOrDefault(); //null if no records
            //lstEmp.Last(); // can give error
            //lstEmp.LastOrDefault(); //null if no records
        }
    }
}