﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double MILLILITERS = 50;
        private const decimal PRICE = 3.50m;
        public double Caffeine { get; set; }
        public Coffee(string name, double caffeine)
            : base(name, PRICE, MILLILITERS)
        {
            Caffeine = caffeine;
        }
    }
}
