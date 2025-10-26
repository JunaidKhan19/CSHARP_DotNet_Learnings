namespace day03
{
    public interface IFileFunctions
    {
        void Open();

        void Close();

        void Delete();
    }

    public interface IDBFunctions
    {
        void Delete();

        void Update();

        void Select();
    }

    public class Project : IFileFunctions, IDBFunctions
    {
        public string Name { get; set; }

        public void Close()
        {
            System.Console.WriteLine("closed the file in IFileFunctions");
        }

        void IFileFunctions.Delete()
        {
            System.Console.WriteLine("deleted the file in IFileFunctions");
        }

        public void Open()
        {
            System.Console.WriteLine("opened the file in IFileFunctions");
        }

        public void Select()
        {
            System.Console.WriteLine("selected the file in IDBFunctions");
        }

        public void Update()
        {
            System.Console.WriteLine("updated the file in IDBFunctions");
        }

        void IDBFunctions.Delete()
        {
            System.Console.WriteLine("deleted the file in IFileFunctions");
        }
    }
    /*
     * all the methods of the interfaces have been implimented normally
     * but the delete method i.e present in both interfaces has been 
     * implimented explicitly but binded implicitly to its respective interface.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            //method 1: reference of project => object of project
            //here all the method s were available except Delete methods from both interfaces
            Project obj = new Project();
            obj.Select();
            obj.Update();
            obj.Open();
            obj.Close();


            //method 2 explicit ref : reference of interface => object of project
            //now we were able to use Delete method but all the methods are from the referenced interface 
            IDBFunctions obj1 = new Project();
            obj1.Select();
            obj1.Update();
            obj1.Delete();

            IFileFunctions obj2 = new Project();
            obj2.Open();
            obj2.Close();
            obj2.Delete();


            //method 3 implicit ref by type-casting : reference of interface => object of project
            //now we were able to use Delete method but all the methods are from the referenced interface 
            //also this time we used the object initialized in method 1 which earlier didnt gave delete method 
            ((IDBFunctions)obj).Select();
            ((IDBFunctions)obj).Update();
            ((IDBFunctions)obj).Delete();

            ((IFileFunctions)obj).Open();
            ((IFileFunctions)obj).Close();
            ((IFileFunctions)obj).Delete();

            //method 4 implicit ref by using as :  reference of interface => object of project
            //now we were able to use Delete method but all the methods are from the referenced interface 
            //also this time we used the object initialized in method 1 which earlier didnt gave delete method
            (obj as IDBFunctions).Select();
            (obj as IDBFunctions).Update();
            (obj as IDBFunctions).Delete();

            (obj as IFileFunctions).Open();
            (obj as IFileFunctions).Close();
            (obj as IFileFunctions).Delete();
        }
    }
}
