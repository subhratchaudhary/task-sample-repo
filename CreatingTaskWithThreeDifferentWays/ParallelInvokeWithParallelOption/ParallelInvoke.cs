using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelInvokeWithParallelOption
{
    class ParallelInvoke
    {
        static void Main(string[] args)
        {
            //Allowing two task to execute at a time
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2
            };
            //parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount - 1;

            //Passing ParallelOptions as the first parameter
            Parallel.Invoke(
                    parallelOptions,
                    () => DoWork(1),
                    () => DoWork(2),
                    () => DoWork(3),
                    () => DoWork(4),
                    () => DoWork(5),
                    () => DoWork(6)                 
                );
            Console.ReadKey();
        }
        static void DoWork(int no)
        {
            Console.WriteLine($"Task {no} started by Thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            Console.WriteLine($"Task {no} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
    
}
