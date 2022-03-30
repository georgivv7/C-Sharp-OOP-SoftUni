using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double extraConsumption = 1.6;
        private const double FuelLoss = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += extraConsumption;
        }
        public override void Refuel(double refuelAmount)
        {
            FuelQuantity += refuelAmount * FuelLoss;
        }
    }
}
