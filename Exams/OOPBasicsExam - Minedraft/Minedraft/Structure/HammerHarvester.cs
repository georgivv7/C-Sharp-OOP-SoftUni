using System;
using System.Collections.Generic;
using System.Text;
public class HammerHarvester : Harvester
{ 
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
           : base(id, oreOutput, energyRequirement)
    {
        OreOutput *= 3.0;
        EnergyRequirement *= 2.0;
    }

    public override string Type => "Hammer";
}
