using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension 
{
    public class Bus : Vehicle
    {
        private const double extraConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base(fuelQuantity,fuelConsumption,tankCapacity)
        {

        }

        public string DriveWithPeople(double distance)  
        {
            double fuelNeeded = distance * (FuelConsumption + extraConsumption);
            if (fuelNeeded > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public override string Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;
            if (fuelNeeded > FuelQuantity)
            {
                return $"Bus needs refueling";
            }

            FuelQuantity -= fuelNeeded;
            return $"Bus travelled {distance} km";

        }
    }
}
