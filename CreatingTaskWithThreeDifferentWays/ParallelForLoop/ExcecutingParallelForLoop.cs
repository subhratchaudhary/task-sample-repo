using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForLoop
{
    class ExcecutingParallelForLoop
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Standard For Loop");
            for(int i=1;i<=5;i++)
            {
                Console.WriteLine($"Value of i={i}, Thread={Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            }
            Console.WriteLine("\nParallel For Loop");
            Parallel.For(0, 10, (j) => {
                Console.WriteLine($"Value of j={j},Thread={Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            });
            Console.ReadLine();
        }
    }
}
