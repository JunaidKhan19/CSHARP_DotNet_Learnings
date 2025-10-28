/*
1. CDAC has certain number of batches. each batch has certain number of students
         accept number of batches. for each batch accept number of students.
         create an array to store mark for each student (1 student has only 1 subject mark)
        accept the marks.
        display the marks.
 */
namespace Arrays1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("eneter no of batches held in Cdac : ");
            int noOfBatches = int.Parse(System.Console.ReadLine());
            int[][] cdac = new int[noOfBatches][];

            for (int i = 0; i < noOfBatches; i++)
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"enter no of students in branch{i + 1}");
                int noOfStudents = int.Parse(System.Console.ReadLine());
                cdac[i] = new int[noOfStudents];
                System.Console.WriteLine();
                for (int j = 0; j < noOfStudents; j++)
                {
                    System.Console.WriteLine($"enter marks of student in {i + 1} student {j + 1}");
                    cdac[i][j] = int.Parse(System.Console.ReadLine());
                }
            }

            for (int i = 0; i < noOfBatches; i++)
            {
                for (int j = 0; j < cdac[i].Length; j++)
                {
                    System.Console.WriteLine($"cdac branch : {i}, student {j} got {cdac[i][j]}");
                }
            }

        }
    }
}

