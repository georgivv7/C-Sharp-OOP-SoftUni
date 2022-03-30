namespace WorkForce
{
    using System;
    using System.Collections.Generic;
    public class JobList : List<Job>    
    {
        public void AddJob(Job job)
        {
            this.Add(job);
            job.JobCompleted += this.OnJobComplete;
        }

        private void OnJobComplete(Job job)
        {
            this.Remove(job);
        }
    }
}
