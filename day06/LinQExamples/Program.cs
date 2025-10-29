namespace LinQExamples
{
    internal class Program
    {
        public class Employee
        {
            public int EmpNo { get; set; }
            public string? Name { get; set; }
            public decimal Basic { get; set; }
            public int DeptNo { get; set; }
            public string? Gender { get; set; }
            public override string ToString()
            {
                string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
                return s;
            }
        }
        public class Department
        {
            public int DeptNo { get; set; }
            public string? DeptName { get; set; }
        }
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

        static void Main()
        {
            //LinQ - Language Integrated Query
            //allows us to write db_queries in the language we are working in e.g- Vbdotnet
            //they work with any thing that impliments IEnumerable or IQueryable.
            
            AddRecs();

            //selecting the whole object
            var emps  = from emp in lstEmp select emp;
            foreach (var emp in emps)
            {
                System.Console.WriteLine(emp);
            }
            //datatype : emps -> IEnumerable list of employees 
            //           from emp -> Employee
            //           lstEmp -> list of Employees
            //           select emp -> Employee.object


            //selecting property of object 
            var emps1 = from emp in lstEmp select emp.Name; // note multiple properties arent allowed
            foreach (var emp in emps1)
            {
                System.Console.WriteLine(emp);
            }
            //datatype : emps -> IEnumerable list of strings 
            //           from emp -> Employee
            //           lstEmp -> list of Employees
            //           select emp -> Employee.object


            //selecting multiple properties as anonymous types objects from objects 
            var emps2 = from emp in lstEmp select new {emp.EmpNo ,emp.Name};
            foreach (var emp in emps2)
            {
                System.Console.WriteLine($"{emp.EmpNo}: {emp.Name}");
            }
            //datatype : emps -> IEnumerable list of anonymous types having 2 properties 
            //           from emp -> Employee
            //           lstEmp -> list of Employees
            //           select new {..} -> Anonymous type


            //selecting the whole object with conditions 
            //note do not think/write Sql syntax. this will give error
            var emps3 = from emp in lstEmp
                        where emp.Basic > 10000
                        select emp;
            foreach (var emp in emps3)
            {
                System.Console.WriteLine(emp);
            }


            //selecting the whole object with conditions
            var emps4 = from emp in lstEmp
                        where emp.Name.StartsWith("v") 
                        select emp;
            foreach (var emp in emps4)
            {
                System.Console.WriteLine(emp);
            }


            //selecting the whole object ordered by : default is ascending
            var emps5 = from emp in lstEmp
                        orderby emp.Name 
                        select emp;
            foreach (var emp in emps5)
            {
                System.Console.WriteLine(emp);
            }


            //selecting the whole object ordered by : descending
            var emps6 = from emp in lstEmp
                        orderby emp.Name descending
                        select emp;
            foreach (var emp in emps6)
            {
                System.Console.WriteLine(emp);
            }


            //selecting the whole object ordered by both (the first order and in that the second)
            var emps7 = from emp in lstEmp
                        orderby emp.DeptNo ascending ,emp.Name descending
                        select emp;
            foreach (var emp in emps7)
            {
                System.Console.WriteLine(emp);
            }


            //orderby .. where
            var emps8 = from emp in lstEmp
                        orderby emp.DeptNo ascending, emp.Name descending 
                        where emp.Basic > 10000
                        select emp;
            foreach (var emp in emps8)
            {
                System.Console.WriteLine(emp);
            }


            //groupby 
            //var emps9 = from emp in lstEmp
            //           group emp by emp.DeptNo;

            var emps9 = from emp in lstEmp
                       group emp by emp.DeptNo into group1
                       select group1;
            foreach (var item in emps9)
            {
                Console.WriteLine(item.Key); //deptno
                foreach (var e in item)  //e is an Employee, item is a grouping of Employee
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
            }


            //group by properties
            var emps10 = from emp in lstEmp
                       group emp by emp.DeptNo into group1
                       select new { group1, Count = group1.Count(), Max = group1.Max(x => x.Basic), Min = group1.Min(x => x.Basic) };

            foreach (var item in emps10)
            {
                Console.WriteLine(item.group1.Key); //DeptNo
                Console.WriteLine(item.Count); //count
                Console.WriteLine(item.Min);  //min
                Console.WriteLine(item.Max); //max
                //emp.group1.Key;  //DeptNo

                foreach (var e in item.group1)  //e is an Employee
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
            }


            //group with orderby and where
            var emps11 = from emp in lstEmp
                         group emp by emp.DeptNo ascending, emp.Name descending into group1
                         where emp.Basic > 10000
                         select group1;
            foreach (var emp in emps11)
            {
                System.Console.WriteLine(emp);
            }

        }
    }
}


