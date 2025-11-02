using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

namespace LinQSampleQuestions
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public int Marks { get; set; }
        public string? City { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender}, Marks: {Marks}, City: {City}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>{
                new Student{ Id=1, Name="Amit", Age=20, Gender="Male", Marks=85, City="Mumbai"},
                new Student{ Id=2, Name="Priya", Age=22, Gender="Female", Marks=92, City="Pune"},
                new Student{ Id=3, Name="Rohan", Age=19, Gender="Male", Marks=76, City="Delhi"},
                new Student{ Id=4, Name="Sneha", Age=21, Gender="Female", Marks=81, City="Mumbai"},
                new Student{ Id=5, Name="Vikram", Age=23, Gender="Male", Marks=89, City="Chennai"},
                new Student{ Id=6, Name="Neha", Age=20, Gender="Female", Marks=98, City="Pune"},
                new Student{ Id=7, Name="Karan", Age=22, Gender="Male", Marks=72, City="Kolkata"},
                new Student{ Id=8, Name="Divya", Age=19, Gender="Female", Marks=68, City="Delhi"},
                new Student{ Id=9, Name="Rahul", Age=24, Gender="Male", Marks=90, City="Bangalore"},
                new Student{ Id=10, Name="Pooja", Age=21, Gender="Female", Marks=88, City="Mumbai"}
            };

            //1. Display all student names.
            var allStudentsName = from s in students select s.Name;
            foreach (var name in allStudentsName)
            {
                Console.WriteLine(name);
            }

            //2.Display all students from Mumbai.
            var studentsFromMumbai = from student in students
                                     where student.City.Contains("Mumbai")
                                     select student;
            foreach (var student in studentsFromMumbai)
            {
                Console.WriteLine(student);
            }

            //3.Display names and marks of students who scored more than 80.
            var studentMarks80 = from s in students
                                 where s.Marks > 80
                                 select new { s.Name, s.Marks };
            foreach (var student in studentMarks80)
            {
                Console.WriteLine(student);
            }

            //4.Find all female students.
            var femaleStudents = from s in students where s.Gender == "Female" select s;
            foreach (var student in femaleStudents)
            {
                Console.WriteLine(student);
            }

            //5.Find all male students with marks above 85.
            var maleStudentsAbove85 = from s in students where s.Marks > 85 && s.Gender == "Male" select s;
            foreach (var student in maleStudentsAbove85)
            {
                Console.WriteLine(student);
            }

            //6.Find the student with Id = 5.
            var studentWithId5 = from s in students where s.Id == 5 select s;
            foreach (var student in studentWithId5)
            {
                Console.WriteLine(student);
            }

            //7.Display students sorted by name.
            var studentsSortedByName = from s in students orderby s.Name select s;
            foreach (var student in studentsSortedByName)
            {
                Console.WriteLine(student);
            }

            //8.Display students sorted by marks descending.
            var studentsSortedByMarksDesc = from s in students orderby s.Marks descending select s;
            foreach (var student in studentsSortedByMarksDesc)
            {
                Console.WriteLine(student);
            }

            //9.Display names of students between age 20 and 22.
            var studentsBetween20And22 = from s in students where s.Age >= 20 && s.Age <= 22 select s.Name;
            foreach (var name in studentsBetween20And22)
            {
                Console.WriteLine(name);
            }

            //10.Display distinct city names.
            var distinctCityNames = (from s in students select s.City).Distinct();
            foreach (var city in distinctCityNames)
            {
                Console.WriteLine(city);
            }

            //11.Count total number of students.
            var numberOfStudents = students.Count();
            Console.WriteLine(numberOfStudents);

            //12.Count number of male students.
            var countMaleStudents = (from s in students where s.Gender == "Male" select s).Count();
            Console.WriteLine(countMaleStudents);

            //13.Find the average marks of all students.
            var averageMarks = (from s in students select s.Marks).Average();
            Console.WriteLine(averageMarks);

            //14.Find maximum marks scored.
            var maxMarks = (from s in students select s.Marks).Max();
            Console.WriteLine(maxMarks);

            //15.Find minimum marks scored.
            var minMarks = (from s in students select s.Marks).Min();
            Console.WriteLine(minMarks);

            //16.Find the top 3 students by marks.
            var topThreeByMarks = (from s in students orderby s.Marks descending select s).Take(3);
            foreach (var t in topThreeByMarks)
            {
                Console.WriteLine(t);
            }

            //17.Find all students whose name starts with “P”.
            var nameStartWithP = from s in students where s.Name.StartsWith("P") select s;
            foreach (var st in nameStartWithP)
            {
                Console.WriteLine(st);
            }

            //18.Find all students from Pune or Mumbai.
            var studentsFromMumPune = from s in students where (s.City == "Mumbai" || s.City == "Pune") select s;
            foreach (var student in studentsFromMumPune)
            {
                Console.WriteLine(student);
            }

            //19.Display names in uppercase.
            var nameUpperCase = from s in students select s.Name.ToUpper();
            foreach (var student in nameUpperCase)
            {
                Console.WriteLine(student);
            }

            //20.Check if any student scored 100.
            var checkMarks100 = from s in students where s.Marks == 100 select s;
            if (checkMarks100.Any()) // (checkMarks100 != null)  will not work for else statement
            {
                foreach (var s in checkMarks100)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("No student scored 100");
            }

            //21.Group students by city.
            var grpByCity = from s in students
                            group s by s.City into group1
                            select group1;
            foreach (var item in grpByCity)
            {
                Console.WriteLine(item.Key);
                foreach (var student in item)
                {
                    Console.WriteLine(student);
                }
            }

            //22.Count how many students are there in each city.
            var countStudentPerCity = from s in students
                                      group s by s.City into cityGrp
                                      select new { City = cityGrp.Key, Countstd = cityGrp.Count() };
            foreach (var item in countStudentPerCity)
            {
                Console.WriteLine($"City: {item.City}, Count: {item.Countstd}");
            }

            //23.Find average marks per city.
            var avgMarksPerCity = from s in students
                                  group s by s.City into citygrp
                                  select new
                                  {
                                      City = citygrp.Key,
                                      avgMarks = citygrp.Average(s => s.Marks)
                                  };
            foreach (var item in avgMarksPerCity)
            {
                Console.WriteLine($"City: {item.City}, Average Marks: {item.avgMarks}");
            }

            //24.Find highest marks per city.
            var HighestMarksPerCity = from s in students
                                      group s by s.City into citygrp
                                      select new
                                      {
                                          City = citygrp.Key,
                                          highest = citygrp.Max(s => s.Marks)
                                      };
            foreach (var item in HighestMarksPerCity)
            {
                Console.WriteLine($"City: {item.City}, Average Marks: {item.highest}");
            }

            //25.Find the city with the most students.
            var mostPopulatedCity = (from s in students
                                     group s by s.City into cityGrp
                                     select new
                                     {
                                         City = cityGrp.Key,
                                         Counts = cityGrp.Count()
                                     }).OrderByDescending(s => s.Counts).FirstOrDefault();
            if (mostPopulatedCity != null)
            {
                Console.WriteLine($"City with most populations is: {mostPopulatedCity.City}");
            }
            else
            {
                Console.WriteLine("No students found");
            }

            //26.Display cities having at least 2 students.
            var cityAtleast2std = from s in students
                                  group s by s.City into citygrp
                                  where citygrp.Count() >= 2
                                  select citygrp;
            if (cityAtleast2std.Any())
            {
                Console.WriteLine("Cities with at least 2 students:");
                foreach (var group in cityAtleast2std)
                {
                    Console.WriteLine($"City: {group.Key}, Count: {group.Count()}");
                }
            }
            else
            {
                Console.WriteLine("No city has at least 2 students.");
            }

            //27.Group students by gender and find average marks for each.
            var avgMarksByGender = from s in students
                                   group s by s.Gender into genderGrp
                                   select new
                                   {
                                       Gender = genderGrp.Key,
                                       avgMarks = genderGrp.Average(s => s.Marks)
                                   };
            foreach (var item in avgMarksByGender)
            {
                Console.WriteLine($"Gender: {item.Gender}, Average marks: {item.avgMarks}");
            }

            //28.Group students by age and list names under each age.
            var stdListByAge = from s in students
                               group s by s.Age into ageGrp
                               select ageGrp;
            foreach (var item in stdListByAge)
            {
                Console.WriteLine($"Age: {item.Key}");
                foreach (var std in item)
                {
                    Console.WriteLine($"Name: {std.Name}");
                }
                Console.WriteLine();
            }

            //29.Find all students living in cities that start with ‘D’.
            var stdOfCitiesD = from s in students
                               where s.City.StartsWith("D")
                               select s;
            foreach (var std in stdOfCitiesD)
            {
                Console.WriteLine(std);
            }

            //30.Find total marks of all students combined.
            var totalMarks = (from s in students select s.Marks).Sum();
            Console.WriteLine($"Total marks of all students are {totalMarks}");

            //31.Display names and marks of students ordered first by city, then by marks descending.
            var stdlistOrdered = from s in students
                                 orderby s.City, s.Marks descending
                                 select s;
            foreach (var student in stdlistOrdered)
            {
                Console.WriteLine(student);
            }

            //32.Select only Name and City into an anonymous object.
            var nameAndCity = from s in students select new { Name = s.Name, City = s.City };
            foreach (var std in nameAndCity)
            {
                Console.WriteLine($"{std.Name} lives in {std.City}");
            }

            //33.Find students whose names contain “a”.
            var nameHasA = from s in students
                           where s.Name.Contains("a")
                           select s;
            foreach (var std in students)
            {
                Console.WriteLine(std);
            }

            //34.Find students with even Ids.
            var stdEvenId = from s in students
                            where s.Id % 2 == 0
                            select s;
            foreach (var std in stdEvenId)
            {
                Console.WriteLine(std);
            }

            //35.Skip first 3 students and display the rest.
            var stdSkip3 = (from s in students select s).Skip(3);
            foreach (var std in stdSkip3)
            {
                Console.WriteLine(std);
            }

            //36.Take first 5 students only.
            var stdFirst5 = (from s in students select s).Take(5);
            foreach (var std in stdFirst5)
            {
                Console.WriteLine(std);
            }

            //37.Find second highest marks.
            var secondHighestMarks = (from s in students
                                      orderby s.Marks descending
                                      select s).Skip(1).FirstOrDefault();
            Console.WriteLine($"second highest marks: {secondHighestMarks}");

            //38.Find students who have marks between 70 and 90.
            var marksbet70and90 = from s in students
                                  where (s.Marks > 70 && s.Marks < 90)
                                  select s;
            foreach (var std in marksbet70and90)
            {
                Console.WriteLine(std);
            }

            //39.Find students whose age is not 21.
            var ageNot21 = from s in students
                           where s.Age != 21
                           select s;
            foreach (var student in ageNot21)
            {
                Console.WriteLine(student);
            }

            //40.Display all names separated by commas as a single string.
            var allNames = from s in students select s.Name;
            foreach (var name in allNames)
            {
                Console.Write($"{name}, ");
            }

            //41.Check if all students are above 18 years of age.
            var checkAbove18 = students.All(s => s.Age > 18);
            if (checkAbove18) Console.WriteLine("All students are above 18 years of age.");
            else Console.WriteLine("Not all students are above 18 years of age.");

            //42.Find students grouped by gender and city together.
            var stdGroupByGenderCity = from s in students
                                       group s by new { s.Gender, s.City } into grp
                                       select new
                                       {
                                           Gender = grp.Key.Gender,
                                           City = grp.Key.City,
                                           Students = grp.ToList()
                                       };
            foreach (var group in stdGroupByGenderCity)
            {
                Console.WriteLine($"Gender: {group.Gender}, City: {group.City}");
                foreach (var std in group.Students)
                {
                    Console.WriteLine($"   {std.Name}");
                }
            }

            //43.Create a new list of only names of female students.
            var femaleStdName = from s in students
                                where s.Gender == "Female"
                                select s.Name;
            foreach (var std in femaleStdName)
            {
                Console.WriteLine(std);
            }

            //44.Check if there is any student from Hyderabad.
            var checkStdFromCity = students.All(s => s.City == "Hyderabad");
            if (checkStdFromCity) Console.WriteLine("There are students from Hyderabad");
            else Console.WriteLine("there are no students from Hyderabad");

            //45.Find average marks of male students only.
            var avgMarksOfMale = students.Where(y => y.Gender == "Male").Average(s.Marks);
            Console.WriteLine($"Average of male marks: {avgMarksOfMale}");

            //46.Find the youngest student.
            var youngestStd = (from s in students
                               orderby s.Age
                               select s).FirstOrDefault();
            Console.WriteLine($"youngest student is {youngestStd.Name} of age {youngestStd.Age}");

            //47.Find the oldest student.
            var oldestStd = (from s in students
                             orderby s.Age descending
                             select s).FirstOrDefault();
            Console.WriteLine($"youngest student is {oldestStd.Name} of age {oldestStd.Age}");

            //48.Order students by marks descending and select top 1.
            var topStd = (from s in students
                          orderby s.Marks descending
                          select s).FirstOrDefault();
            Console.WriteLine(topStd);

            //49.Display students in alphabetical order of city, then name.
            var orderedCityAndName = from s in students
                                     orderby (s.City, s.Name)
                                     select s;
            foreach (var std in orderedCityAndName)
            {
                Console.WriteLine(std);
            }

            //50.Find the total marks of all female students.
            var totalMarksofFemale = (from s in students
                                      where s.Gender == "Female"
                                      select s.Marks).Sum();
            Console.WriteLine($"Total marks of Female students : {totalMarksofFemale}");
        }
    }
}
