﻿using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    public double Grip { get; }
    public UltrasoftTyre(double hardness, double grip)
        : base("Ultrasoft", hardness)
    {
        Grip = grip;
    }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            base.Degradation = value;
        }
    }
    public override void CompleteLap()
    {
        base.CompleteLap();
        Degradation -= Grip;
    }
}
