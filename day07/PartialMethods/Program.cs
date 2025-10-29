namespace PartialMethods
{
    //Partial methods can only be defined within a partial class.
    //Partial methods must return void.
    //Partial methods can be static or instance level.
    //Partial methods cannnot have out params
    //Partial methods are always implicitly private.
    //You may declare and define in the same part
    //or also declare them in a part and use them in other part.
    public partial class Class1
    {
        private bool isValid = true;
        partial void Validate(); //partial method declaration
        public bool Check()
        {
            //.....
            Validate();
            return isValid;
        }
    }
    public partial class Class1
    {
        partial void Validate()
        {
            //perform some validation code here
            isValid = false;
        }
    }

    public class MainClass
    {
        public static void Main()
        {
            Class1 o = new Class1();
            Console.WriteLine(o.Check());
            Console.ReadLine();
        }
    }
}