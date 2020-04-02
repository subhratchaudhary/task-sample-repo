using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskwtihContiueWtihMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Task Task1 = Task.Factory.StartNew(() => program.DoWork(1,1000)).ContinueWith((prev)=> program.DoOtherWork(4,1000));
           
            Task Task2 = Task.Factory.StartNew(() => program.DoWork(2,1500));
            
            Task Task3 = Task.Factory.StartNew(() => program.DoWork(3,2000));

            Task.WaitAll();
            Console.ReadLine();
        }
        public void DoWork(int id ,int sleep)
        {
            Console.WriteLine($"Task {id} is started");
            Thread.Sleep(sleep);
            Console.WriteLine($"Task {id} is completed");
        }
        public void DoOtherWork(int id, int sleep)
        {
            Console.WriteLine($"Other Task {id} is started");
            Thread.Sleep(sleep);
            Console.WriteLine($"Other Task {id} is completed");
        }
    }
}
