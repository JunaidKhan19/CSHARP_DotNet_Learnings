namespace RefOutIn
{
    internal class Program
    {

        void DataTypes()
        {
            byte b; //Byte -1
            sbyte sb; //SByte
            short sh; //Int16 -2
            ushort ush; //UInt16
            int i; //System.Int32 - 4
            uint ui; //UInt32
            long l; //Int64 -8
            ulong ul; //UInt64

            float f; //Single - 4
            double d; //Double - 8
            decimal dec; //Decimal - 16

            bool boo; //Boolean
            char ch; //Char - 2

            string s; //String
            object obj; //Object
        }

        void Boxing()
        {
            int i = 100;

            object obj;
            obj = i;//from stack onto heap - Boxing

            int j;
            j = (int)obj; //from heap back to stack - Unboxing

        }
        static void Main()
        {
            int i = 1, j = 2;  //local variables - unassigned
            Init(out i, out j);
            Swap(ref i, ref j);
            //Console.WriteLine(i);
            //Console.WriteLine(j);
            Print(in i);
            Print(j);

        }
        //ref - changes made in func reflect back in calling code
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        //out - changes made in func reflect back in calling code
        //the initial value is discarded
        //out variables MUST be initialized in the function
        static void Init(out int a, out int b)
        {
            //Console.WriteLine(a); //error
            a = 123;
            b = 456;
        }
        static void Print(in int x)
        {
            //x is a readonly value
            //x = 100; //error
            Console.WriteLine(x);

        }
    }

}
