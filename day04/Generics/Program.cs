namespace Generics
{
    class IntegerStack
    {
        int[] arr;
        public IntegerStack(int Size)
        {
            arr = new int[Size];
        }
        int Pos = -1;
        public void Push(int i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public int Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
    class StringStack
    {
        string[] arr;
        public StringStack(int Size)
        {
            arr = new string[Size];
        }
        int Pos = -1;
        public void Push(string i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public string Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }

    class MyStack<T>
    //where T : class  //- T must be a reference type
    //where T : struct - T must be a value type
    //where T : ClassName - T must be either ClassName or a derived class
    //where T : InterfaceName - T must be a class that implements InterfaceName
    //where T : new() //- T must have a no parameter constructor
    {
        T[] arr;
        public MyStack(int Size)
        {
            arr = new T[Size];
            //Class1 o = new Class1();
            //T o = new T();

        }
        int Pos = -1;
        public void Push(T i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public T Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }

    internal class Program
    {
        static void Main1()
        {
            IntegerStack o = new IntegerStack(3);
            o.Push(1);
            o.Push(2);
            o.Push(3);
            //o.Push(4);
            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            #region string code
            StringStack o2 = new StringStack(3);
            o2.Push("aa");
            o2.Push("ba");
            o2.Push("pa");
            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());
            #endregion
        }

        static void Main()
        {
            MyStack<int> o = new MyStack<int>(3);
            o.Push(1);
            o.Push(2);
            o.Push(3);
            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());

            MyStack<string> o2 = new MyStack<string>(3);
            o2.Push("aa");
            o2.Push("ba");
            o2.Push("pa");
            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());
        }

    }
}
