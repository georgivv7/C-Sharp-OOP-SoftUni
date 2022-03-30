using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : Item
{
    private double energyOutput;
    protected Provider(string id, double energyOutput)
        :base(id)
    {
        EnergyOutput = energyOutput;
    }
    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }
    public override string ToString()
    {
        return $"{Type} Provider - {Id}" + Environment.NewLine + 
               $"Energy Output: {EnergyOutput}";
    }
}

