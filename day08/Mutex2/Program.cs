using System;
using System.Threading;

namespace Mutex2
{
    internal class Program
    {
        // Give the mutex a unique system-wide name
        private static Mutex? mutex = null;

        static void Main()
        {
            //const string mutexName = "MyUniqueAppMutex"; // by default local, other apps can make this mutex
            const string mutexName = "Global\\MyUniqueAppMutex"; // "Global\\" makes it visible system-wide,
                                       //other apps cant make this mutex and will wait for it to be released

            bool createdNew;
            // Try to create the named mutex
            mutex = new Mutex(initiallyOwned: true, name: mutexName, createdNew: out createdNew);

            if (!createdNew)
            {
                Console.WriteLine("Another instance of this program is already running!");
                return; // Exit the program
            }

            try
            {
                Console.WriteLine("This is the only running instance of the program.");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
            finally
            {
                // Always release and close the mutex
                mutex.ReleaseMutex();
                mutex.Dispose();
            }
        }
    }
}

