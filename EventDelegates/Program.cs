using System;

namespace EventDelegates
{
    class Program
    {
                
        public delegate void WorkPerformedHandler (int hours);

        public event WorkPerformedHandler WorkEvent;

        static void Main(string[] args)
        {
            WorkPerformedHandler handler = WorkPerformed1;
            WorkPerformedHandler handler2 = WorkPerformed2;
            WorkPerformedHandler handler3 = WorkPerformed3;

        
            
            // there are here 3 seperate invocatoin list in 3 seperate multicast delegates
            handler += handler2 + handler3; // handler 2 will not invoke the invocatoin list from the below code.

            handler2 += handler3+handler2;
            handler2 += handler3;
            
            //handler += handler2 + handler3; handler 2 will invoke all hanler 2 from the above

            handler3 += handler;

            Console.WriteLine("handler 1 invocatrion list\n");
            DoWork(handler); //invoked the methode 2 times
            Console.WriteLine("\n");
            Console.WriteLine("handler 2 invocatrion list\n");
            DoWork(handler2);// invokes it only one time 
            Console.WriteLine("\n");
            Console.WriteLine("handler 3 invocatrion list\n");
            DoWork(handler3);// invokes it only one time 
            //handler = WorkPerformed1;;
            handler += handler2 + handler3;
            Console.WriteLine("\n");
            Console.WriteLine("AGAIN: handler 1 invocatrion list\n");
            DoWork(handler); //invoked the methode 2 times
        }
        // this is a dynamic method
        static void DoWork(WorkPerformedHandler handler)
        { 
            handler(5);
        }
         
        static void WorkPerformed1(int hours)
        {
            Console.WriteLine($"Work performed is {hours} Hours in WorkPerformed1");
        }

        static void WorkPerformed2(int hours)
        {
            Console.WriteLine($"Work performed is {hours} Hours in WorkPerformed2");
        }
        
        static void WorkPerformed3(int hours)
        {
            Console.WriteLine($"Work performed is {hours} Hours in WorkPerformed3");
        }

    }
}
