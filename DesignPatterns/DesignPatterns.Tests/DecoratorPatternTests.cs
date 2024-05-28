using System.Diagnostics.CodeAnalysis;
using DesignPatterns.Business.DecoratorPattern.Beverage;
using DesignPatterns.Business.DecoratorPattern.Decorator;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class DecoratorPatternTests
    {
        [Test]
        public void DrinkAsEspresso()
        {
            Drink drink = new Espresso();

            var description = drink.GetDescription();
            var cost = drink.GetCost();

            Assert.Equals("espresso", description);
            Assert.Equals(3.50, cost);
        }

        [Test]
        public void DrinkAsDecaf()
        {
            Drink drink = new Decaf();

            var description = drink.GetDescription();
            var cost = drink.GetCost();

            Assert.Equals("decaf", description);
            Assert.Equals(2.00, cost);
        }

        [Test]
        public void EspressoWithCaramel()
        {
            Drink drink = new Espresso();
            Flavour flavour = new Caramel(drink);

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.Equals("espresso with caramel flavour", description);
            Assert.Equals(5.50, cost);
        }

        [Test]
        public void EspressoWithSoy()
        {
            Drink drink = new Espresso();
            Flavour flavour = new Soy(drink);

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.Equals("espresso with soy flavour", description);
            Assert.Equals(7.50, cost);
        }

        [Test]
        public void DecafWithCaramel()
        {
            Drink drink = new Decaf();
            Flavour flavour = new Caramel(drink);

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.Equals("decaf with caramel flavour", description);
            Assert.Equals(4.00, cost);
        }

        [Test]
        public void DecafWithSoy()
        {
            Drink drink = new Decaf();
            Flavour flavour = new Soy(drink);

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.Equals("decaf with soy flavour", description);
            Assert.Equals(6.00, cost);
        }

        [Test]
        public void AddCaramelAndSoyInEspresso()
        {
            Drink drink = new Espresso();
            Flavour flavour = new Caramel(new Soy(drink));

            var description = flavour.GetDescription();
            var cost = flavour.GetCost();

            Assert.Equals("espresso with soy flavour with caramel flavour", description);
            Assert.Equals(9.50, cost);
        }

        [Test]
        public void AddSoyAndCaramelInDecaf()
        {
            Drink drink = new Decaf();
            Flavour flavour = new Soy(new Caramel(drink));

            var description = flavour.GetDescription();
            Assert.Equals("decaf with caramel flavour with soy flavour", description);

            var cost = flavour.GetCost();
            Assert.Equals(8.00, cost);
        }
    }
}
