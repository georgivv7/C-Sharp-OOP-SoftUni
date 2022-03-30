namespace WorkForce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public delegate void JobCompleteHandler(Job job);
    public class Job
    {
        public event JobCompleteHandler JobCompleted;

        private int hoursRequired;
        private Employee employee;
        public Job(string name, int hoursRequired, Employee employee)
        {
            this.Name = name;
            this.hoursRequired = hoursRequired;
            this.employee = employee;
        }

        public string Name { get; }
        public void Update()
        {
            this.hoursRequired -= this.employee.HoursPerWeek;
            if (this.hoursRequired <= 0)
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.JobCompleted.Invoke(this);
            }
        }
        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.hoursRequired}";
        }
    }
}
