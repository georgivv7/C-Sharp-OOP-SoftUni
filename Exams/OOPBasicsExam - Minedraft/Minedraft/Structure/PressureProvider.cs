using System;
using System.Collections.Generic;
using System.Text;


public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        EnergyOutput *= 1.50;
    }

    public override string Type => "Pressure";
}
