using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnaValueFromaTask
{
    class ReturnValueFromTask
    {
        static void Main(string[] args)
        {
            ReturnValueFromTask valueFromTask = new ReturnValueFromTask();
            /*Using this Task<T> class we can return data or value from a task. In Task<T>,
             * T represents the data type that you want to returns as a result of the task.*/
            Task<double> Task1 = Task.Run(() => {
                return valueFromTask.CalculateSum(10);
            });
            Console.WriteLine($"Task 1 Sum is {Task1.Result}");

            //writing the logic as part of the Anonymous method
            Task<int> Task2 = Task.Run(() =>
            {
                int sum = 0;
                for (int i = 1; i <= 5; i++)
                {
                    sum = sum + i;
                }
                return sum;
            });
            Console.WriteLine($"Task 2 Sum is {Task2.Result}");

            
            //Returning Complex Type Value From a task
            Task<Employee> Task3 = Task<Employee>.Factory.StartNew(()=> {
                Employee employee = new Employee()
                {
                    ID=101,
                    Name="Vikrant",
                    Salary=10000
                };
                return employee;
            });
            Employee emp = Task3.Result;
            Console.WriteLine($"Employee Details ID:{emp.ID}, Name:{emp.Name}, Salary:{emp.Salary}");
            Console.ReadLine();
        }

        public double CalculateSum(int num)
        {
            double sum = 0;
            for (int i = 1; i <= num;i++)
            {
                sum = sum + i;
            }
            return sum;
        }

    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
}
