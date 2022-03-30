using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetClinic
{
    public class Clinic
    {
        private Pet[] pets;
        public Clinic(string name, int roomsCount)
        {
            this.Name = name;
            this.ValidateRoom(roomsCount);
            this.pets = new Pet[roomsCount];
        }
        public string Name { get; }
        public int Center => this.pets.Length / 2;
        public bool HasEmptyRooms => this.pets.Any(p => p == null);
        private void ValidateRoom(int roomsCount)
        {
            if (roomsCount % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }           
        }
        public bool Add(Pet pet)
        {
            int currentRoom = this.Center;

            for (int i = 0; i < this.pets.Length; i++)
            {
                if (i % 2 != 0)
                {
                    currentRoom -= i;
                }
                else
                {
                    currentRoom += i;
                }

                if (this.pets[currentRoom] == null)
                {
                    this.pets[currentRoom] = pet;
                    return true;
                }
            }
            return false;
        }
        public bool Release()
        {
            for (int i = 0; i < this.pets.Length; i++)
            {
                int index = (this.Center + i) % this.pets.Length;
                if (this.pets[index] != null)
                {
                    this.pets[index] = null;
                    return true;
                }
            }
            return false;
        }
        public void Print(int roomNum)
        {
            if (this.pets[roomNum - 1] != null)
            {
                Console.WriteLine(this.pets[roomNum - 1]);
            }
            else
            {
                Console.WriteLine("Room empty");
            }

        }
        public void PrintAll()
        {
            foreach (var pet in this.pets)
            {
                if (pet == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(pet);
                }
            }
        }

    }
}
