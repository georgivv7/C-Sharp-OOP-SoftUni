using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension 
{
    public class Truck : Vehicle
    {
        private const double extraConsumption = 1.6;
        private const double FuelLoss = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption,tankCapacity)
        {
            FuelConsumption += extraConsumption;
        }
        public override void Refuel(double refuelAmount)
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
                FuelQuantity += refuelAmount*FuelLoss;
            }
        }
    }
}
