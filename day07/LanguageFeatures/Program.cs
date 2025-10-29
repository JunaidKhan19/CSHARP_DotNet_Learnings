namespace LanguageFeatures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Implicit variables: 
            //var j = 100;
            //they are type-immutable and can be assigned data and type once only at the time of declaration
            //after declaration only that type of data is going to be stored in that variable.
            //they are local variables and cant be used for class level vars, function parameters and return.
            //It is used in LinQ's where either we dont know the dataType or the data is complex to have a type.

            //Anonymous Types:
            //

            //Partial class:
            //can be used when 1.two or more people are working on a same class
            //2. when Vstudio is writing some code in the class and the developer is also
            //they gets combined at the time of object initialization. and declaring a variable twice isnt allowed


            //partial method:
            //is to be written inside the partial class and have return type void they cant have out parameter
            //and are implicitly private.
            //it acts as a placeholder where there are two posssiblities either the code will be written else not,
            //so in case if the code is written it will be excepted and if not the space would be freed


            //Extension method: 
            //allows us to write and use methods for a predefined class.
            //they look like they are being added as new functions but
            //the logic behind is they are static methods written in a static class for a predefined static class
            //to be called as if they are the part of that class.
            //they compulsorily take the predefined class(the class for which you are writing the method) as the first parameter
            //having prefix as "this" and if you want you can write as many parameters after it.
            //
            Console.WriteLine("Hello, World!");
        }
    }
}
