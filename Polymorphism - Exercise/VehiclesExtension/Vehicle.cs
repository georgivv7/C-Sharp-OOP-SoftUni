using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {    
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }

            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get;  set; }
        public double FuelConsumption { get;  set; }
        public double TankCapacity { get; set; }    
        public virtual string Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;
            if (fuelNeeded > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";               
            }

            FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";

        }
        public virtual void Refuel(double refuelAmount)
        {
            if (refuelAmount <= 0)
            {
                 Console.WriteLine("Fuel must be a positive number");
            }
            else if (refuelAmount > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {refuelAmount} fuel in the tank");
            }
            else
            {
                FuelQuantity += refuelAmount;
            }          
        }
    }
}
