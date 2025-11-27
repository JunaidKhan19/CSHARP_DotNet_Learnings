namespace ReflectionExplained
{
    internal class Program
    {
        //Reflection is reading metadat of an assembly at runtime.
        //it is the ability of a program to examine and modify its own structure and behavior at runtime.
        //usage scenarios:
        //1. Displaying the information what the assembly contains.
        //2. Reading assembly at suntime and creating an object of one of its classes in the assembly.
        //   It allows us to dynamically load assemblies and call code on without giving reference at compile time.
        //   It means to look at contents of assembly, create objects dynamically, call a method of that 
        //   assembly at runtime without giving reference at compile time.
        //3. reflection.emit: it is used to generate(create) a new assembly at runtime.
        static void Main(string[] args)
        {
            //starting to read an object of assembly, the topmost object is Assembly

            //Assembly.GetAssembly(typeof(Program)); //get the assembly in which Program class is defined
            //Assembly.ExecutingAssembly(); //get the currently executing assembly
            //Assembly.GetCallingAssembly(); //get the assembly of the method that called the currently executing method
            //Assembly.GetEntryAssembly(); //get the entry assembly, the assembly that contains the topmost calling entry point.

            //Assembly.Load("assemblyName"); //load an assembly by its name
            //Assembly.LoadFrom("path of assembly"); //load an assembly from a given path

            //load an assembly from a given file
            try
            {
                string path = @"C:\Users\Junaid\Desktop\Github uploads\C#DotNet\day06\LinQSampleQuestions\bin\Debug\net9.0\LinQSampleQuestions.dll";

                // Load the assembly
                Assembly assem = Assembly.LoadFile(path);

                // Display assembly metadata
                Console.WriteLine("Assembly Full Name:");
                Console.WriteLine(assem.FullName);

                Console.WriteLine("\nTypes in this assembly:");
                foreach (Type t in assem.GetTypes())
                {
                    Console.WriteLine(" - " + t.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }
}
