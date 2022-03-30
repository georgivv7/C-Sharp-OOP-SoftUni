using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class ProviderControllerTests
{
    private EnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void SetUpProviderController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }
    [Test]
    public void ProducesCorrectAmountOfEnergy()
    {
        List<string> providerOne = new List<string>
        {
            "Solar","1","100"
        };
        List<string> providerTwo = new List<string>
        {
            "Solar","2","100"
        };

        this.providerController.Register(providerOne);
        this.providerController.Register(providerTwo);

        for (int i = 0; i < 3; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }
    [Test]
    public void BrokenProviderIsDeleted()   
    {
        List<string> providerOne = new List<string>
        {
            "Pressure","1","100"
        };

        this.providerController.Register(providerOne);

        for (int i = 0; i < 8 ; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }
}
