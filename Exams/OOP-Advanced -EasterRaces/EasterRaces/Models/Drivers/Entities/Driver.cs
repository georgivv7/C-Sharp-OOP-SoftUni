﻿namespace EasterRaces.Models.Drivers.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public class Driver : IDriver
    {
        private string name;
        public Driver(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName,
                        value, 5));
                }
                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get
            {
                if (this.Car != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
