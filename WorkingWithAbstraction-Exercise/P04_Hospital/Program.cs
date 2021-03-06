using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + secondName;

                if (doctors.ContainsKey(firstName + secondName) == false)
                {
                    doctors[fullName] = new List<string>();
                }
                if (departments.ContainsKey(departament) == false)
                {
                    departments[departament] = new List<List<string>>();
                    for (int room = 0; room < 20; room++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool hasSpace = departments[departament].SelectMany(x => x).Count() < 60;
                FillRooms(doctors, departments, departament, patient, fullName, hasSpace);

            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]]
                        .Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }
            }
        }

        private static void FillRooms(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string fullName, bool hasSpace)
        {
            if (hasSpace)
            {
                int room = 0;
                doctors[fullName].Add(patient);
                for (int roomNum = 0; roomNum < departments[departament].Count; roomNum++)
                {
                    if (departments[departament][roomNum].Count < 3)
                    {
                        room = roomNum;
                        break;
                    }
                }
                departments[departament][room].Add(patient);
            }
        }
    }
}
