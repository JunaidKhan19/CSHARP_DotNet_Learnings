using System;
using System.Threading;

namespace MutexThreads
{
    internal class Program
    {
        /*
         mutex.WaitOne() → thread waits until it can safely enter.
         Only one thread holds the mutex at a time.
         Other threads are blocked until the mutex is released using mutex.ReleaseMutex().
         */

        // Create a Mutex instance shared by all threads
        private static Mutex mutex = new Mutex();

        static void Main()
        {
            // Create and start multiple threads
            for (int i = 1; i <= 3; i++)
            {
                Thread thread = new Thread(AccessResource);
                thread.Name = $"Thread {i}";
                thread.Start();
            }
        }

        static void AccessResource()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting to enter the critical section...");

            // Request ownership of the mutex
            mutex.WaitOne();  // This will block until the mutex is available

            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the critical section.");

            // Simulate some work in the critical section
            Thread.Sleep(2000);

            Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the critical section.\n");

            // Release the mutex so other threads can enter
            mutex.ReleaseMutex();
        }
    }
}

