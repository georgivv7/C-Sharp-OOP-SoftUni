using System;
using System.Collections.Generic;
using System.Text;

public abstract class Driver
{
    private const double boxDefaultTime = 20.0;
    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        Name = name;
        TotalTime = 0.0;
        Car = car;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
        IsRacing = true;
    }
    public string Name { get; }
    public double TotalTime { get; set; }
    public Car Car { get; }
    public double FuelConsumptionPerKm { get; }
    public virtual double Speed => Car.Hp + Car.Tyre.Degradation / Car.FuelAmount;
    private void Box()
    {
        TotalTime += boxDefaultTime;
    }
    public string FailureReason { get; private set; }
    public bool IsRacing { get; private set; }
    private string Status => IsRacing ? this.TotalTime.ToString("f3") : this.FailureReason;
    internal void ChangeTyres(Tyre tyre)
    {
        this.Box();
        Car.ChangeTyre(tyre);
    }

    internal void Refuel(string[] methodArgs)
    {
        this.Box();
        double fuelAmount = double.Parse(methodArgs[0]);
        Car.Refuel(fuelAmount);
    }
    public override string ToString()
    {
        return $"{Name} {Status}";
    }

    internal void CompleteLap(int trackLength)
    {
        TotalTime += 60 / (trackLength / Speed);

        Car.CompleteLap(trackLength,this.FuelConsumptionPerKm);
    }

    internal void Fail(string crashReason)
    {
        IsRacing = false;
        FailureReason = crashReason;
    }
}
