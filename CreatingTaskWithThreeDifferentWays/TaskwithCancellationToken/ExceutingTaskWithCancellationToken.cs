using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskwithCancellationToken
{
    class ExceutingTaskWithCancellationToken
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
       
        static void Main(string[] args)
        {
            ExceutingTaskWithCancellationToken taskWithCancellation = new ExceutingTaskWithCancellationToken();
            try
            {
                Task Task1 = Task.Factory.StartNew(() => taskWithCancellation.DoWork(1, 100));               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType());
            }
            Console.ReadLine();
        }
        public void DoWork(int id, int sleep)
        {
            CancellationToken token = cancellationTokenSource.Token;
            while (!token.IsCancellationRequested)
            {
                try
                {
                    Console.WriteLine($"Task {id} is started");
                    for (int i=0;i<20;i++)
                    {
                        if(i==10)
                        {
                            cancellationTokenSource.Cancel();
                            //Console.WriteLine("Cancellation requested");
                            token.ThrowIfCancellationRequested();
                        }
                        Console.WriteLine($"i value {i}");
                        Thread.Sleep(sleep);
                    }
                    Console.WriteLine($"Task {id} is completed");
                }
                catch(Exception ex)
                {                    
                    Console.WriteLine(ex.Message);
                }
            }           
           
        }
       
    }
}
