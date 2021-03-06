using System;
using System.Collections.Generic;
using System.Text;

public class TyreFactory
{
    public Tyre CreateTyre(string[] tyreArgs)
    {
        string tyreType = tyreArgs[0];
        double tyreHardness = double.Parse(tyreArgs[1]);

        Tyre tyre = null;

        if (tyreType == "Hard")
        {
            tyre = new HardTyre(tyreHardness);
            return tyre;
        }
        else if (tyreType == "Ultrasoft")
        {
            double grip = double.Parse(tyreArgs[2]);
            tyre = new UltrasoftTyre(tyreHardness, grip);
            return tyre;
        }
        throw new ArgumentException("Invalid Tyre Type");
    }
}

