using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount   
{
    public class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

        public Person(string name, int age)
            :this(name,age,new List<BankAccount>())
        {
            
        }
        public Person(string name, int age, List<BankAccount> accounts)         
        {
            Name = name;
            Age = age;
            Accounts = accounts;
        }
        public string Name 
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age 
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public List<BankAccount> Accounts 
        {
            get { return this.accounts; }
            set { this.accounts = value; }
        }

        public decimal GetBalance()
        {
            return Accounts.Sum(x => x.Balance);
        }
    }
}
