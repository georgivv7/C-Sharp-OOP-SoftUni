using System;
using System.Collections.Generic;
public class Easy : Mission
{
    private const string name = "Suppression of civil rebellion";
    private const double enduranceRequierd = 20;
    private const double wearLevelDecrement = 30;

    public Easy(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => name;

    public override double EnduranceRequired => enduranceRequierd;
    public override double WearLevelDecrement => wearLevelDecrement;
}
