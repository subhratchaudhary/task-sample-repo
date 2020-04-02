using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreatingTaskWithThreeDifferentWays
{
    class CreateTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");
            CreateTask createTask = new CreateTask();
            //creating a task using task class and start method
            Task Task1 = new Task(createTask.PrintNumber);
            Task1.Start();

            //Creating a task object using Factory Property
            Task Task2 = Task.Factory.StartNew(createTask.PrintNumber);

            //Creating a Task object using the Run method
            Task Task3 = Task.Run(() => { createTask.PrintNumber(); });

            //Task using Wait, calling wait() method on Task3
            Task3.Wait();

            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
            Console.ReadLine();
        }

        public void PrintNumber()
        {
            Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Started");
            for(int i=0;i<=10;i++)
            {
                Console.WriteLine($"i value: {i} for Task {Task.CurrentId}");
            }
            Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
        }
    }
}
