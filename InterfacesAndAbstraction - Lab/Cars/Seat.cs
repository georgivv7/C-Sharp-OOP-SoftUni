﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }
        public string Model { get; private set; }
        public string Color { get; private set; }
        
        public override string ToString()
        {
            return string.Format($"{Color} {Model}");      
        }
        
    }
}
