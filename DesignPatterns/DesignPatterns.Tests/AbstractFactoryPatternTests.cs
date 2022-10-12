using DesignPatterns.Business.AbstractFactoryPattern.Contracts;
using DesignPatterns.Business.AbstractFactoryPattern.Services;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class AbstractFactoryPatternTests
    {
        [SetUp]
        public void Init()
        {
            chairFactory = new ChairFurnitureFactory();
            coffeeTableFactory = new CoffeeTableFurnitureFactory();
        }

        [Test]
        public void FirstFactoryCreatesChairs()
        {
            var modernFurniture = chairFactory.CreateModernFurniture();
            var victorianFurniture = chairFactory.CreateVictorianFurniture();

            Assert.AreEqual("This is a victorian chair.", victorianFurniture.GetName());
            Assert.AreEqual("This is a victorian chair. collaborating with the (This is a modern chair.)", victorianFurniture.GetCollaboratorName(modernFurniture));
        }

        [Test]
        public void SecondFactoryCreatesCoffeeTables()
        {
            var modernFurniture = coffeeTableFactory.CreateModernFurniture();
            var victorianFurniture = coffeeTableFactory.CreateVictorianFurniture();

            Assert.AreEqual("This is a victorian coffee table.", victorianFurniture.GetName());
            Assert.AreEqual("This is a victorian coffee table. collaborating with the (This is a modern coffee table.)", victorianFurniture.GetCollaboratorName(modernFurniture));
        }

        [Test]
        public void ModernFurnitureIsCreated()
        {
            var chair = chairFactory.CreateModernFurniture();
            var coffeeTable = coffeeTableFactory.CreateModernFurniture();

            Assert.AreEqual("This is a modern chair.", chair.GetName());
            Assert.AreEqual("This is a modern coffee table.", coffeeTable.GetName());
        }

        [Test]
        public void VictorianFurnitureIsCreated()
        {
            var chair = chairFactory.CreateVictorianFurniture();
            var coffeeTable = coffeeTableFactory.CreateVictorianFurniture();

            Assert.AreEqual("This is a victorian chair.", chair.GetName());
            Assert.AreEqual("This is a victorian coffee table.", coffeeTable.GetName());
        }

        //

        private IFurnitureFactory chairFactory;
        private IFurnitureFactory coffeeTableFactory;
    }
}