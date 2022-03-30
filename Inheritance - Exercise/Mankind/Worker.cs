using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private double weekSalary;
        private double hoursPerDay;
        public Worker(string firstName, string lastName, double weekSalary, double hoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
        }     
        public double WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }
        public double HoursPerDay
        {
            get { return this.hoursPerDay; }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.hoursPerDay = value;
            }
        }

        public double CalculateSalaryPerHour()
        {
            double result = this.WeekSalary / (this.HoursPerDay * 5);
            return result;
        }

        public override string ToString()
        {
            
           return string.Format($"First Name: {this.FirstName}\n" +
            $"Last Name: {this.LastName}\n" +
            $"Week Salary: {this.WeekSalary:F2}\n" +
            $"Hours per day: {this.HoursPerDay:F2}\n" +
            $"Salary per hour: {this.CalculateSalaryPerHour():F2}");
            
        }
    }
}
