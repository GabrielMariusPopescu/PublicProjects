using DesignPatterns.Business.DecoratorPattern.Beverage;
using DesignPatterns.Business.DecoratorPattern.Decorator;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class DecoratorPatternTests
    {
        [Test]
        public void DrinkAsEspresso()
        {
            Drink drink = new Espresso();

            var description = drink.GetDescription();
            var cost = drink.GetCost();

            Assert.AreEqual("espresso", description);
            Assert.AreEqual(3.50, cost);
        }

        [Test]
        public void DrinkAsDecaf()
        {
            Drink drink = new Decaf();

            var description = drink.GetDescription();
            var cost = drink.GetCost();

            Assert.AreEqual("decaf", description);
            Assert.AreEqual(2.00, cost);
        }

        [Test]
        public void EspressoWithCaramel()
        {
            Drink drink = new Espresso();
            Flavour flavour = new Caramel(drink);

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.AreEqual("espresso with caramel flavour", description);
            Assert.AreEqual(5.50, cost);
        }

        [Test]
        public void EspressoWithSoy()
        {
            Drink drink = new Espresso();
            Flavour flavour = new Soy(drink);

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.AreEqual("espresso with soy flavour", description);
            Assert.AreEqual(7.50, cost);
        }

        [Test]
        public void DecafWithCaramel()
        {
            Drink drink = new Decaf();
            Flavour flavour = new Caramel(drink);

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.AreEqual("decaf with caramel flavour", description);
            Assert.AreEqual(4.00, cost);
        }

        [Test]
        public void DecafWithSoy()
        {
            Drink drink = new Decaf();
            Flavour flavour = new Soy(drink);

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.AreEqual("decaf with soy flavour", description);
            Assert.AreEqual(6.00, cost);
        }

        [Test]
        public void AddCaramelAndSoyInEspresso()
        {
            Drink drink = new Espresso();
            Flavour flavour = new Caramel(new Soy(drink));

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.AreEqual("espresso with soy flavour with caramel flavour", description);
            Assert.AreEqual(9.50, cost);
        }

        [Test]
        public void AddSoyAndCaramelInDecaf()
        {
            Drink drink = new Decaf();
            Flavour flavour = new Soy(new Caramel(drink));

            var description = flavour.GetDescription();
            Assert.AreEqual("decaf with caramel flavour with soy flavour", description);

            var cost = flavour.GetCost();
            Assert.AreEqual(8.00, cost);
        }
    }
}
