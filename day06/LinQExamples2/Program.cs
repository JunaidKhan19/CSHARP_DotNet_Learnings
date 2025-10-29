namespace LinQExamples2
{
    internal class Program
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

        static Employee GetEmployee(Employee obj)
        {
            return obj;
        }
        static string GetEmployeeName(Employee obj)
        {
            return obj.Name;
        }
        
        static bool IsBasicGreaterThan10000(Employee obj)
        {
            return obj.Basic > 10000;
        }

        static void Main()
        {
            //calling functions(deligates / arrow) in linQ

            AddRecs();

            //1.selecting the whole object
            var emps = from emp in lstEmp select emp;
            var emps = lstEmp.Select(GetEmployee);
            var emps2 = lstEmp.Select(delegate (Employee obj)
            {
                return obj;
            });
            var emps3 = lstEmp.Select(obj => obj);
            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }


            //2.selecting property of object like emp.Name
            var emps = from emp in lstEmp select emp.Name;
            var emps = lstEmp.Select(GetEmployeeName);
            var emps2 = lstEmp.Select(delegate (Employee obj)
            {
                return obj.Name;
            });
            var emps3 = lstEmp.Select(obj => obj.Name);

            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }


            //3.selecting multiple properties as anonymous types objects from objects
            var emps = from emp in lstEmp select new { emp.EmpNo, emp.Name };
            var emps = lstEmp.Select(delegate (Employee obj)
            {
                return new { obj.EmpNo, obj.Name };
            });

            var emps2 = lstEmp.Select(obj => new { obj.EmpNo, obj.Name });

            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }


            //4.selecting the whole object with conditions, where clause
            var emps = from emp in lstEmp
                       where emp.Basic > 10000
                       select emp;

            var emps1 = lstEmp.Where(IsBasicGreaterThan10000);
            var emps2 = lstEmp.Where(delegate (Employee obj)
            {
                return obj.Basic > 10000;
            });

            var emps3a = lstEmp.Where(obj => obj.Basic > 10000);
            var emps3b = lstEmp.Where(obj => obj.Basic > 10000).Select(obj => obj);
            var emps3c = lstEmp.Select(obj => obj).Where(obj => obj.Basic > 10000);

            //always make sure to put where first and then select afterwards
            //var emps4c = lstEmp.Select(obj => obj.Name).Where(obj => obj.Basic > 10000); //this is wrong
            var emps4b = lstEmp.Where(obj => obj.Basic > 10000).Select(obj => obj.Name);

            //var emps5a = lstEmp.Select(obj => obj.Basic).Where(obj => obj.Basic > 10000); 
            //this is wrong as here obj is Basic bcoz of previous select 
            var emps5b = lstEmp.Where(obj => obj.Basic > 10000).Select(obj => obj.Basic);
            var emps5c = lstEmp.Select(obj => obj.Basic).Where(obj => obj > 10000);
            //here obj is Basic bcoz of previous select 

            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }


            //5.selecting with ordering
            var emps = from emp in lstEmp
                       orderby emp.Name
                       select emp;

            var emps1 = lstEmp.OrderBy(obj => obj.Name);
            var emps2 = lstEmp.OrderByDescending(obj => obj.Name);
            var emps3 = lstEmp.OrderBy(obj => obj.DeptNo).ThenByDescending(obj => obj.Name);

            var emps4 = from emp in lstEmp
                       orderby emp.Name descending
                       select emp;

            var emps5 = from emp in lstEmp
                        orderby emp.DeptNo ascending, emp.Name descending
                        select emp;
            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
            }

            //6.joining two collections selecting whole objects
            //var emps = from obj1 in c1
            //           join obj2 in c2
            //           on    what_to_match_from_obj1   equals   with_to_match_in_obj2
            //           select ;
            var emps = from emp in lstEmp
                       join dept in lstDept
                       on emp.DeptNo equals dept.DeptNo
                       select new { emp, dept }; 

            var emps2 = lstEmp.Join(
                                lstDept, 
                                emp => emp.DeptNo, 
                                dept => dept.DeptNo, 
                                (emp, dept) => new { emp, dept }
            );

            foreach (var item in emps)
            {
                Console.WriteLine(item.emp.Name);
                Console.WriteLine(item.dept.DeptName);

            }

            //joining two collections selecting specific properties
            var emps3 = from emp in lstEmp
                        join dept in lstDept
                        on emp.DeptNo equals dept.DeptNo
                        select new { emp.Name, dept.DeptName };
            foreach (var item in emps2)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.DeptName);

            }
        }
    }
}