using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();   
            car = new UnitCar("Lada", 300, 2000);
            driver = new UnitDriver("Nasko", car);
        }

        [Test]
        public void IsCounterShowingCorrectNumber() 
        {
            this.raceEntry.AddDriver(driver);

            var expectedCount = 1;
            var actualCount = this.raceEntry.Counter;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddDriverShouldThrowNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new UnitDriver(null,car));            
        }

        [Test]
        public void AddDriverShouldThrowInvalidOperationException()     
        {
            Assert.Throws<InvalidOperationException>(
                () => this.raceEntry.AddDriver(null));
        }
        [Test]
        public void AddDriverShouldThrowInvalidOperationExceptionWhenDriverIsAlreayAdded()
        {
            this.raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(
                () => this.raceEntry.AddDriver(driver));
        }

        [Test]
        public void CalculateAverageHorsePowerShouldWorkProperly()  
        {
            this.raceEntry.AddDriver(driver);
            var driver3 = new UnitDriver("Bonngo", new UnitCar("Pejo", 206, 5000));
            this.raceEntry.AddDriver(driver3);
            var expected = 253;

            var actual = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CalculateAverageHorsePowerShouldThrowInvalidOperationExceptionWhenCounterIsLessaThanTwo()
        {   
            this.raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(
                () => this.raceEntry.CalculateAverageHorsePower());
        }
    }
}