using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;
        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName,lastName)
        {
            this.FacultyNumber = facultyNumber;
        }      
        public string FacultyNumber 
        {
            get { return this.facultyNumber; }
            private set
            {
                if (value.Length >= 5 && value.Length <= 10 && value.All(x=> char.IsLetterOrDigit(x)))
                {
                    this.facultyNumber = value;                
                }
                else
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                
            }
        }

        public override string ToString()
        {

            return string.Format($"First Name: {this.FirstName}\n" +
            $"Last Name: {this.LastName}\n" +
            $"Faculty number: {this.FacultyNumber}"+
            Environment.NewLine);
        }
    }
}
