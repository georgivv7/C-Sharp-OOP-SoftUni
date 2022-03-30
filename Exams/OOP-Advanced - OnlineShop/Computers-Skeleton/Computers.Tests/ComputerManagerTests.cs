//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Computers.Tests
//{
//    public class Tests
//    {
//        private ComputerManager computerManager;
//        private Computer computer;
//        [SetUp]
//        public void Setup()
//        {
//            this.computer = new Computer("Dell", "Vostro", 1500m);
//            this.computerManager = new ComputerManager();
//        }


//        [Test]
//        public void ShouldReturnCollectionCount()
//        {
//            this.computerManager.AddComputer(this.computer);
//            int expected = 1;
//            int actual = this.computerManager.Count;
//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void AddComputer_ShouldThrowAegumentNullException()
//        {
//            Assert.Throws<ArgumentNullException>(() =>
//            this.computerManager.AddComputer(null));
//        }

//        [Test]
//        public void AddComputer_ShouldThrowArgumentExceptionWhenAddingExistingComputer()
//        {
//            this.computerManager.AddComputer(this.computer);

//            Assert.That(
//                () => this.computerManager.AddComputer(this.computer),
//                Throws
//                .ArgumentException
//                .With
//                .Message
//                .EqualTo("This computer already exists."));
//        }
//        [Test]
//        public void AddComputer_ShouldAddComputer()
//        {
//            int expectedCount = 1;

//            this.computerManager.AddComputer(this.computer);
//            int actualCount = this.computerManager.Computers.Count;

//            Assert.AreEqual(expectedCount, actualCount);
//        }

//        [Test]
//        public void RemoveComputer_ShouldRemoveComputerWithGivenManufacturerAndModel()
//        {
//            this.computerManager.AddComputer(this.computer);
//            var expectedComp = this.computer;

//            var actualComp = this.computerManager.RemoveComputer
//                (expectedComp.Manufacturer, expectedComp.Model);
//            Assert.AreEqual(expectedComp, actualComp);
//        }
//        [Test]
//        public void RemoveComputer_ShouldRemoveTheCorrectComputerWithGivenManufacturerAndModel()
//        {
//            this.computerManager.AddComputer(this.computer);
//            var expectedComp = this.computer;

//            var actualComp = this.computerManager.RemoveComputer(this.computer.Manufacturer, 
//                this.computer.Model);

//            Assert.AreEqual(expectedComp, actualComp);
//        }
//        [Test]
//        public void GetComputer_ShouldThrowArgumentNullExceptionWhenGivenNullManufacturer()
//        {
//            Assert.Throws<ArgumentNullException>(() =>
//            this.computerManager.GetComputer(null, "Vostro"));
//        }

//        [Test]
//        public void GetComputer_ShouldThrowArgumentNullExceptionWhenGivenNullModel()
//        {
//            Assert.Throws<ArgumentNullException>(() =>
//            this.computerManager.GetComputer("Dell", null));
//        }

//        [Test]
//        public void GetComputer_ShouldThrowArgumentExceptionWhenComputerDoesntExist()
//        {
//            Assert.Throws<ArgumentException>(
//                () => this.computerManager.GetComputer("No", "Stress"));
//        }
//        [Test]
//        public void GetComputer_ShouldReturnComputerWithGivenManufacturerAndModel()
//        {
//            this.computerManager.AddComputer(this.computer);
//            var expected = this.computer;

//            var actual = this.computerManager.GetComputer(this.computer.Manufacturer,
//                this.computer.Model);
//            Assert.AreEqual(expected, actual);
//        }
//        [Test]
//        public void GetComputersByManufacturer_ShouldThrowArgumentNullExceptionWhenGivenNullManufacturer()
//        {
//            Assert.Throws<ArgumentNullException>(() =>
//            this.computerManager.GetComputersByManufacturer(null));
//        }
//        [Test]
//        public void GetComputersByManufacturer_ShouldReturnCollectionOfAllCompsWithGivenManufacturer()
//        {
//            this.computerManager.AddComputer(this.computer);
//            var comp = new Computer("Dell", "Blue", 1100m);
//            this.computerManager.AddComputer(comp);
//            var otherComp = new Computer("IBM", "model", 1300m);
//            this.computerManager.AddComputer(otherComp);
//            ICollection<Computer> expectedCollection = new List<Computer>()
//            {
//                this.computer,
//                comp
//            };

//            var actualCollection = this.computerManager.GetComputersByManufacturer("Dell");

//            Assert.AreEqual(expectedCollection, actualCollection);
//        }
//    }
//}

using NUnit.Framework;
using System;
using System.Collections.Generic;
 
namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {

        private Computer computer;
        private ComputerManager computerManager;
        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Test", "abc", 10);
            this.computerManager = new ComputerManager();
        }


        [Test]
        public void AddMethodShouldThrowNullExceptionWhenVariableIsNull()
        {
            Computer testComputer = null;
            Assert.Throws<ArgumentNullException>(()
                => computerManager.AddComputer(testComputer));
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenAddSameComputer()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(()
                => computerManager.AddComputer(computer));
        }
        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            computerManager.AddComputer(computer);

            var exp = 1;
            Assert.AreEqual(exp, computerManager.Count);
        }
        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenManufacturerIsNull()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer(null, "a"));
        }

        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenModelIsNull()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer("sony", null));
        }
        [Test]
        public void RemoveMethodShouldWorkCorectlly()
        {
            //computerManager.AddComputer(computer);
            //var exp = computer;
            //.AreEqual(exp, computerManager.RemoveComputer("Test", "abc"));

            this.computerManager.AddComputer(this.computer);
            var test = this.computerManager.RemoveComputer("Test", "abc");
            Assert.That(test.Model == "abc" && test.Manufacturer == "Test");
        }
        [Test]
        public void GetComputerShouldThrowExcpetionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(()
                => computerManager.GetComputer(null, "abc"));
        }
        [Test]
        public void GetComputerShouldThrowExcpetionWhenModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(()
                => computerManager.GetComputer("Test", null));
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentException>(()
                => computerManager.GetComputer("abc", "abc"));
        }
        [Test]
        public void GetComputerShouldWorkCorectlly()
        {
            computerManager.AddComputer(computer);
            var test = this.computerManager.GetComputer("Test", "abc");
            Assert.That(test == computer);
        }

        [Test]
        public void GetComputersShouldThrowExceptionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(()
                => computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersShouldWorkCorrectly()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("a", "a", 10));

            var exp = 1;
            Assert.AreEqual(exp, computerManager.GetComputersByManufacturer("a").Count);

        }

    }
}