namespace BasicClassConcepts
{
    //public class Class1
    //{
    //    public int i;
    //    public void Display()
    //    {
    //        System.Console.WriteLine("Display called");
    //    }
    //}

    public class Class1
    {
        private int i;

        public int I
        {
            set
            {
                if (value <= 100) i = value;
                else System.Console.WriteLine("not a valid value");
            }
            get 
            {  
                return i; 
            }
        }
        public void Display()
        {
            System.Console.WriteLine("Display called");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            ////System.Console.WriteLine("Junaid");
            //Class1 obj1;
            //obj1 = new Class1();
            //obj1.Display();
            //obj1.i=1;

            //System.Console.WriteLine(obj1.i);

        }
    }
}
