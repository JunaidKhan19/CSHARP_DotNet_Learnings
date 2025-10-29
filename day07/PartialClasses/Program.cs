namespace PartialClasses
{
    //PARTIAL CLASSES: 
    //partial classes must be in the same assembly
    //partial classes must be in the same namespace
    //partial classes must have the same name

    public partial class Class1
    {
        public int i;
    }

    //partial class written in same directory or file
    public partial class Class1
    {
        public int j;
    }
    public class Program
    {
        public static void Main3()
        {
            Class1 o = new Class1();
            o.i = 10;
            o.j = 20;
            o.k = 30;
        }
    }
}

//partial class written in other directory or elsewhere
namespace PartialClasses
{
    public partial class Class1
    {
        public int k;
    }
}