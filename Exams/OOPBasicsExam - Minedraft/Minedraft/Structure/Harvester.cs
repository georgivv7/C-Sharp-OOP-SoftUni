using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : Item
{
    private const double MaxEnergyRequired = 10000;

    private double oreOutput;
    private double energyRequirement;
    
    protected Harvester(string id, double oreOutput, double energyRequirement)
        :base(id)
    {
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }
    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 || value >= MaxEnergyRequired)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }
    public override string ToString()
    {
        return $"{Type} Harvester - {Id}" + Environment.NewLine +
               $"Ore Output: {OreOutput}" + Environment.NewLine + 
               $"Energy Requirement: {EnergyRequirement}";
    }
}
