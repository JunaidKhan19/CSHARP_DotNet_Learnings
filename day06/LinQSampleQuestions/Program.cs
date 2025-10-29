using System.Collections.Generic;
using System.Linq;

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
                new Student{ Id=6, Name="Neha", Age=20, Gender="Female", Marks=95, City="Pune"},
                new Student{ Id=7, Name="Karan", Age=22, Gender="Male", Marks=72, City="Kolkata"},
                new Student{ Id=8, Name="Divya", Age=19, Gender="Female", Marks=68, City="Delhi"},
                new Student{ Id=9, Name="Rahul", Age=24, Gender="Male", Marks=90, City="Bangalore"},
                new Student{ Id=10, Name="Pooja", Age=21, Gender="Female", Marks=88, City="Mumbai"}
            };

            // Write your LINQ queries here
            //1. Display all student names.
            //2.Display all students from Mumbai.
            //3.Display names and marks of students who scored more than 80.
            //4.Find all female students.
            //5.Find all male students with marks above 85.
            //6.Find the student with Id = 5.
            //7.Display students sorted by name.
            //8.Display students sorted by marks descending.
            //9.Display names of students between age 20 and 22.
            //10.Display distinct city names.
            //11.Count total number of students.
            //12.Count number of male students.
            //13.Find the average marks of all students.
            //14.Find maximum marks scored.
            //15.Find minimum marks scored.
            //16.Find the top 3 students by marks.
            //17.Find all students whose name starts with “P”.
            //18.Find all students from Pune or Mumbai.
            //19.Display names in uppercase.
            //20.Check if any student scored 100.
            //21.Group students by city.
            //22.Count how many students are there in each city.
            //23.Find average marks per city.
            //24.Find highest marks per city.
            //25.Find the city with the most students.
            //26.Display cities having at least 2 students.
            //27.Group students by gender and find average marks for each.
            //28.Group students by age and list names under each age.
            //29.Find all students living in cities that start with ‘D’.
            //30.Find total marks of all students combined.
            //31.Display names and marks of students ordered first by city, then by marks descending.
            //32.Select only Name and City into an anonymous object.
            //33.Find students whose names contain “a”.
            //34.Find students with even Ids.
            //35.Skip first 3 students and display the rest.
            //36.Take first 5 students only.
            //37.Find second highest marks.
            //38.Find students who have marks between 70 and 90.
            //39.Find students whose age is not 21.
            //40.Display all names separated by commas as a single string.
            //41.Check if all students are above 18 years of age.
            //42.Find students grouped by gender and city together.
            //43.Create a new list of only names of female students.
            //44.Check if there is any student from Hyderabad.
            //45.Find average marks of male students only.
            //46.Find the youngest student.
            //47.Find the oldest student.
            //48.Order students by marks descending and select top 1.
            //49.Display students in alphabetical order of city, then name.
            //50.Find the total marks of all female students.
        }
    }
}
