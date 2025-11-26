namespace threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //foreground threads: main thread waits for other thread to finish execution.
            //By default all threads are foreground threads.

            //Background threads: as soon as the main threads is executed it will 
            //stop the execution of other threads.


            //.join() is a waiting call. it will make the main thread wait for that
            //thread mentioned to be completed

            //Threadstart and ParameterizedThreadStart
            //
            //initializes thread....

            //ThreadPriority is an enum that is like a request to CLR about the priority
            //of a thread but CLR decides itself about the execution and may or may not
            //work as requested.

            //Threadstate class helps us to know about the current state of thread.
            //all the states are excessible from the provided enums.

            //WaitSleepJoin state is aquired if either of this happens(wait / join / sleep)

            //WaitHandled is used for working with wait() method. it is a signaling class.
            //It needs a signal to wait and to not wait 
            //Waithandled class is the base class for all signaling classes.
            //



            //ParameterizedThreadStart to pass more than one value to the function without
            //changing the return type which is void
            //we can pass it as struct/class , array/collection , anonymousmethod/lambda 


            //threadpool is a set of already created threads ready to be used.
            //since threads are available we dont have the overhead of creating and acquiring it hence
            //we acquire speed and time where as we loose all the control over thread.
            //in a threadpool all threads are background threads
            

            //threadpools have 2 types of threads : Worker threads (we use), IOthreads(used by system)
            
            //WaitHandle has AutoresetEvent and manualresetEvent
            
            //synchronization in threads
            //
            //mutex: 
            //mutually exclusive , this works for across diffrent process while others are for 
            //within the process. it allows to run 1 process at a time.the count of the process
            //running is always one. 
            //Semaphore :
            //it also requires the count of the of processes running and only that number of process
            //can run at a time.
            //locks:
            //the one who asks and acquires the lock first runs and untill completed others has to wait.
            //lock statement internally uses monitor class that has Monitor.Enter(lockobject)
            //and Monitor.Exit(lockobject).
            //Lock object was available until dotnet8 from dotnet9 we got Lock class.
            //
            //
            //interlocked class is used to perform arithematic operation on shared resources keeping them locked until process ends
            //

        }
    }
}

namespace ThreadingExamples1
{
    internal class Program
    {
        static void Main0()
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            t1.Start();

            Thread t2 = new Thread(Func2);
            t2.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main : " + i);
            }
        }
        static void Main1()
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            t1.IsBackground = true;
            t1.Start();

            Thread t2 = new Thread(Func2);
            t2.IsBackground = true;
            t2.Start();

            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Main : " + i);
            }
        }

        static void Main2()
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            t1.Start();

            Thread t2 = new Thread(Func2);
            t2.Start();

            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Main : " + i);
            }
            t1.Join(); //waiting call
            t2.Join();
            Console.WriteLine("this line should run after t1 and t2");
        }
        //Priority
        static void Main3()
        {

            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);

            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;

            t1.Start();
            t1.Start();

            t2.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main : " + i);
            }
        }

        //ThreadState
        static void Main4()
        {

            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);
            if (t1.ThreadState == ThreadState.Unstarted)
                t1.Start();
            //t1.Abort();
            //t1.Suspend();
            //t1.Resume();
            //if(t1.ThreadState== ThreadState.)            
            t2.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
                Thread.Sleep(10000);
            }
        }

        static void Main()
        {
            AutoResetEvent wh = new AutoResetEvent(false);
            Thread t1 = new Thread(delegate ()
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.WriteLine("f1:" + i);
                    if (i % 50 == 0)
                    {
                        //instead of Suspend, use this
                        Console.WriteLine("waiting");
                        wh.WaitOne();
                    }
                }
            });
            t1.Start();
            Thread.Sleep(5000);
            //Console.ReadLine();
            Console.WriteLine("resuming 1....");
            wh.Set();

            Thread.Sleep(5000);
            //Console.ReadLine();
            Console.WriteLine("resuming 2....");
            wh.Set();

            Thread.Sleep(5000);
            //Console.ReadLine();
            Console.WriteLine("resuming 3....");
            wh.Set();

            Thread.Sleep(5000);
            //Console.ReadLine();
            Console.WriteLine("resuming 4....");
            wh.Set();
        }

        static void Func1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("First : " + i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Second : " + i);

            }
        }
    }
}

