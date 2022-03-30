using System;
using System.Collections.Generic;
using System.Text;
public class Car
{
    private const double maxFuel = 160;

    private double fuelAmount;
    public Car(int horsePower, double fuelAmount, Tyre tyre)
    {
        Hp = horsePower;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }
    public int Hp { get; }
    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            fuelAmount = Math.Min(value, maxFuel);
        }
    }
    public Tyre Tyre { get; private set; }

    internal void Refuel(double fuelAmount)
    {
        FuelAmount += fuelAmount;
    }

    internal void ChangeTyre(Tyre tyre)
    {
        Tyre = tyre;
    }

    internal void CompleteLap(int trackLength, double fuelConsumption)
    {
        FuelAmount -= trackLength * fuelConsumption;
    }
}
