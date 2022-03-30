namespace CosmosX.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void CreateEnergyModule()
        {
            var moduleContainer = new ModuleContainer(10);
            var module = new CryogenRod(1, 100);

            moduleContainer.AddEnergyModule(module);

            Assert.That(moduleContainer.TotalEnergyOutput, Is.EqualTo(100));
        }

        [Test]
        public void CreateAbsorbingModule()
        {
            var moduleContainer = new ModuleContainer(10);
            var module = new HeatProcessor(1, 200);

            moduleContainer.AddAbsorbingModule(module);

            Assert.That(moduleContainer.TotalHeatAbsorbing, Is.EqualTo(200));
        }

        [Test]
        public void RemoveOldestModule()
        {
            var moduleContainer = new ModuleContainer(1);
            var module1 = new HeatProcessor(1, 200);
            var module2 = new HeatProcessor(2, 300);

            moduleContainer.AddAbsorbingModule(module1);
            moduleContainer.AddAbsorbingModule(module2);

            Assert.That(moduleContainer.ModulesByInput.Count, Is.EqualTo(1));
        }
    }
}