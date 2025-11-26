using System;

namespace DelegateDemo
{
    //Step 1: Define a delegate (like a contract or function pointer)
    public delegate void CoffeeReadyDelegate(string message);

    //Step 2: Coffee Machine (the one that will call the delegate)
    class CoffeeMachine
    {
        // This variable will hold a reference to any method that matches the delegate signature
        public CoffeeReadyDelegate? CoffeeReadyHandler;

        public void Start()
        {
            Console.WriteLine("CoffeeMachine: Starting the coffee process...");
            System.Threading.Thread.Sleep(1000); // simulate time
            Console.WriteLine("CoffeeMachine: Coffee is ready!");

            //Step 3: Call the delegate (if any method is assigned)
            CoffeeReadyHandler?.Invoke("--- Your coffee is ready! ---");
            //invoke passes this as string like this ,
            //CoffeeReadyHandler("--- Your coffee is ready! ---"); 
        }
    }

    //Step 4: Display Screen (the one that reacts)
    class DisplayScreen
    {
        public void ShowMessage(string msg)
        {
            Console.WriteLine($"DisplayScreen: {msg}");
        }
    }

    //Step 5: Main Program
    class Program
    {
        static void Main()
        {
            CoffeeMachine machine = new CoffeeMachine();
            DisplayScreen screen = new DisplayScreen();

            // connect the delegate to the method
            machine.CoffeeReadyHandler = screen.ShowMessage;

            // start the process
            machine.Start();

            Console.WriteLine("\n-- Process Complete --");
        }
    }
}
