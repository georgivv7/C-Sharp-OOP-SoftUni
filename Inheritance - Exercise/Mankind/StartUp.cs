using System;

namespace Mankind
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);

                string[] workerInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Worker worker = new Worker(workerInfo[0], workerInfo[1], 
                    double.Parse(workerInfo[2]), double.Parse(workerInfo[3]));

                Console.WriteLine(student.ToString());
                Console.WriteLine(worker.ToString());
            }
            catch (ArgumentException ec)
            {
                Console.WriteLine(ec.Message);
            }          
        }
    }
}
