using System;
using System.Collections.Generic;
using System.Text;

namespace KingsGambit
{
    using Contracts;
    using System.Linq;

    public class Engine
    {
        private IKing king;
        public Engine(IKing king)
        {
            this.king = king;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine())!="End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "Attack")
                {
                    king.GetAttacked();
                }
                else if (command == "Kill")
                {
                    string subordinateName = tokens[1];
                    ISubordinate subordinate = king.Subordinates.First(s => s.Name == subordinateName);
                    subordinate.TakeDamage();
                }
            }
        }
    }
}
