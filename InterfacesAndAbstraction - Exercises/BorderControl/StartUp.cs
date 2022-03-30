using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> AllIds = new List<string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();
                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    Citizen citizen = new Citizen(name, age, id);
                    AllIds.Add(id);
                }
                else if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];
                    Robot robot = new Robot(model, id);
                    AllIds.Add(id);
                }
            }
            string neededDigit = Console.ReadLine();

            foreach (var id in AllIds)
            {
                if (id.EndsWith(neededDigit))
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
