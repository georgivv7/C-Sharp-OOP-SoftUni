﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double extraConsumption = 0.9;
      
        public Car(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity,fuelConsumption)
        {
            FuelConsumption += extraConsumption;
        }
    }
}
