namespace WorkForce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            JobList allJobs = new JobList();
            List<Employee> employees = new List<Employee>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                switch (command)
                {
                    case "StandardEmployee":
                        string employeeName = tokens[1];
                        employees.Add(new StandardEmployee(employeeName));
                        break;
                    case "PartTimeEmployee":
                        employeeName = tokens[1];
                        employees.Add(new PartTimeEmployee(employeeName));
                        break;
                    case "Job":
                        string jobName = tokens[1];
                        int hoursRequired = int.Parse(tokens[2]);
                        employeeName = tokens[3];
                        var neededEmployee = employees.First(e => e.Name == employeeName);
                        allJobs.AddJob(new Job(jobName, hoursRequired, neededEmployee));
                        break;
                    case "Pass":
                        allJobs.ToList().ForEach(j => j.Update());
                        break;
                    case "Status":
                        foreach (Job job in allJobs)
                        {
                            Console.WriteLine(job);
                        }
                        break;
                }
            }
        }
    }
}
