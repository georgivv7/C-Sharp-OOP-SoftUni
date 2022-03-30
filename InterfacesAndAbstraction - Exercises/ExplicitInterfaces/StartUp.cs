using System;

namespace ExplicitInterfaces
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();
                Citizen citizen = new Citizen(input[0], input[1], int.Parse(input[2]));
                IPerson person = citizen;
                IResident resident = citizen;
                person.GetName();
                resident.GetName();
            }
        }
    }
}
