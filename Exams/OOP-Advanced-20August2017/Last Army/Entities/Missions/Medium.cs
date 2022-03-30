public class Medium : Mission
{
    private const string name = "Capturing dangerous criminals";
    private const double enduranceRequierd = 50;
    private const double wearLevelDecrement = 50;

    public Medium(double scoreToComplete) : base(scoreToComplete)   
    {
    }

    public override string Name => name;

    public override double EnduranceRequired => enduranceRequierd;
    public override double WearLevelDecrement => wearLevelDecrement;
}
