public class PressureProvider : Provider
{
    private const double DecreaseDurability = 300;
    private const double EnergyOutputMultiplier = 2;    

    public PressureProvider(int id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.Durability -= DecreaseDurability;
        this.EnergyOutput *= EnergyOutputMultiplier;
    }
}

