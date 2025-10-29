namespace DelegatesExamples
{
    //step: 1
    public delegate void Deli1();
    public delegate int Deli2(int a, int b);

    internal class Program
    {
        static void Main(string[] args)
        {
            //step:2

            //way 1
            //Deli1 obj = new Deli1(Display);
            //obj();

            //way 2
            //Deli1 obj = Display;
            //obj();
            //obj = Show;
            //obj();

            //step:3
            //way 1 calling multiple functions at same time
            //the += adds and -= removes the function as lastin first out
            //only the last occurnce is removed of that function
            //Deli1 obj = Display;
            //obj();
            //obj += Show;
            //obj();
            //obj += Display;
            //obj();
            //obj += Display;
            //obj();
            //obj += Show;
            //obj();
            //obj += Show;
            //obj();
            //obj -= Display;
            //obj();
            //obj -= Display;
            //obj();
            //obj -= Show;
            //obj();


            ////way 2 calling multiple functions at same time
            //Deli1 obj = (Deli1)Delegate.Combine(new Deli1(Display), new Deli1(Show), new Deli1(Show));
            //obj();

            ////to remove single occurance
            //obj = (Deli1)Delegate.Remove(obj, new Deli1(Display));
            ////to remove all occurance from the callstack
            //obj = (Deli1)Delegate.RemoveAll(obj, new Deli1(Display));


            //if a delegator has a return type and it points to multiple function then the values 
            //of the functions get overrided by the upcoming function and only the value returned
            //by the last function called in the stack will be shown
            Deli2 obj = Add;
            obj(4,5);

            obj = Subtract;
            obj(4,5);

        }

        static void Display()
        {
            System.Console.WriteLine("Displaying");
        }
        static void Show()
        {
            System.Console.WriteLine("Showing");
        }

        static int Add(int a, int b)
        {
            return a+b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
