using System;

namespace EventDelegates
{
    class Program
    {
                

        static void Main(string[] args)
        {


            // here we can subscribe to an event
            Worker worker = new Worker();
            worker.WorkCompleted += Workcompleted; // the delegete inference compile it to that >> worker.WorkCompleted +=new EventHandler<WorkPerformedEventArgs>(Workcompleted) ;   
            worker.WorkPerformed +=  WorkPerformed2;
            worker.WorkPerformed += (object sender, int hours) =>
            {
                Console.WriteLine($"Work performed is {hours} Hours in method anonymous");
            };


            worker.DoWork(3);


            // there are here 3 seperate invocatoin list in 3 seperate multicast delegates
            WorkPerformedHandler handler = WorkPerformed1;
            WorkPerformedHandler handler2 = WorkPerformed2;
            WorkPerformedHandler handler3 = WorkPerformed3;
            handler += handler2 + handler3; // handler 2 will not invoke the invocatoin list from the below code.

            handler2 += handler3 + handler2;
            handler2 += handler3;

            //handler += handler2 + handler3; handler 2 will invoke all hanler 2 from the above

            handler3 += handler;

            Console.WriteLine("handler 1 invocatrion list\n");
            DoWork(null,handler); //invoked the methode 2 times
            Console.WriteLine("\n");
            Console.WriteLine("handler 2 invocatrion list\n");
            DoWork(null,handler2);// invokes it only one time 
            Console.WriteLine("\n");
            Console.WriteLine("handler 3 invocatrion list\n");
            DoWork(null ,handler3);// invokes it only one time 
            //handler = WorkPerformed1;;
            handler += handler2 + handler3;
            Console.WriteLine("\n");
            Console.WriteLine("AGAIN: handler 1 invocatrion list\n");
            DoWork(null,handler); //invoked the methode 2 times
        }

        private static void Workcompleted(object? sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"workcompleted and the number of hours is {e.Hours}");
        }

        // this is a dynamic method
        static void DoWork(object sender,WorkPerformedHandler handler)
        { 
            handler(sender,5);
        }
         
        static void WorkPerformed1(object sender,int hours)
        {
            Console.WriteLine($"Work performed is {hours} Hours in method WorkPerformed1");
        }

        static void WorkPerformed2(object sender,int hours)
        {
            Console.WriteLine($"Work performed is {hours} Hours in method WorkPerformed2");
        }
        
        static void WorkPerformed3(object sender,int hours)
        {
            Console.WriteLine($"Work performed is {hours} Hours in method WorkPerformed3");
        }

    }
}
