using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> birthdays = new List<string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();
                if (input[0] == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdate = input[4];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    birthdays.Add(birthdate);
                }
                else if (input[0] == "Pet")
                {
                    string name = input[1];
                    string birthdate = input[2];
                    Pet pet = new Pet(name, birthdate);
                    birthdays.Add(birthdate);
                }
                else if (input[0] == "Robot")
                {
                    string model = input[1];
                    string id = input[2];
                    Robot robot = new Robot(model, id);
                }
            }
            string neededYear = Console.ReadLine();
            foreach (var birthdate in birthdays)
            {
                if (birthdate.EndsWith(neededYear))
                {
                    Console.WriteLine(birthdate);
                }
            }

        }
    }
}
