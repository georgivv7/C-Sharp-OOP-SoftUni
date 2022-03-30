using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {    
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get;  set; }
        public double FuelConsumption { get;  set; }
        public string Drive(double distance)
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
            FuelQuantity += refuelAmount;
        }
    }
}
