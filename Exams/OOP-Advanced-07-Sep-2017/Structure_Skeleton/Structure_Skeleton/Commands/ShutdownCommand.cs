using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    public ShutdownCommand(IList<string> args, IHarvesterController harvesterController
        , IProviderController providerController)   
        : base(args)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }
    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Constants.SystemShutdown);
        sb.AppendLine(string.Format(Constants.TotalEnergy, this.providerController.TotalEnergyProduced));
        sb.AppendLine(string.Format(Constants.TotalMinedOre, this.harvesterController.OreProduced));

        return sb.ToString();

    }
}
