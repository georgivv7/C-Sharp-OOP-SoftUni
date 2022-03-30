using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinic
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandCount = int.Parse(Console.ReadLine());
            List<Pet> pets = new List<Pet>();
            List<Clinic> clinics = new List<Clinic>();

            for (int i = 0; i < commandCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                switch (command)
                {
                    case "Create":
                        try
                        {
                            string typeOfCreation = input[1];
                            if (typeOfCreation == "Pet")
                            {
                                string name = input[2];
                                int age = int.Parse(input[3]);
                                string kind = input[4];
                                Pet pet = new Pet(name, age, kind);
                                pets.Add(pet);
                            }
                            else
                            {
                                string name = input[2];
                                int roomCount = int.Parse(input[3]);
                                Clinic clinic = new Clinic(name, roomCount);
                                clinics.Add(clinic);
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;
                    case "Add":
                        Pet petToAdd = pets.FirstOrDefault(p => p.Name == input[1]);
                        Clinic clinicToAdd = clinics.FirstOrDefault(c => c.Name == input[2]);
                        Console.WriteLine(clinicToAdd.Add(petToAdd));
                        break;
                    case "Release":
                        Clinic clinicToRelease = clinics.FirstOrDefault(c => c.Name == input[1]);
                        Console.WriteLine(clinicToRelease.Release());
                        break;
                    case "HasEmptyRooms":
                        Clinic clinicToCheck = clinics.FirstOrDefault(c => c.Name == input[1]);
                        Console.WriteLine(clinicToCheck.HasEmptyRooms);
                        break;
                    case "Print":
                        Clinic clinicToPrint = clinics.FirstOrDefault(c => c.Name == input[1]);
                        if (input.Length == 3)
                        {
                            int roomNumber = int.Parse(input[2]);
                            clinicToPrint.Print(roomNumber);
                        }
                        else
                        {
                            clinicToPrint.PrintAll();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
