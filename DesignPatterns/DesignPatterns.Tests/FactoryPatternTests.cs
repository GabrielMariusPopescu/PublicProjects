using System.Diagnostics.CodeAnalysis;
using DesignPatterns.Business.FactoryPattern.Contracts;
using DesignPatterns.Business.FactoryPattern.Models;
using DesignPatterns.Business.FactoryPattern.Services;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class FactoryPatternTests
    {
        [Test]
        public void RoadLogisticImplemented()
        {
            ILogistics logistics = new RoadLogistics();
            var transport = logistics.CreateTransport();
            transport.Deliver();

            Assert.That(transport, Is.InstanceOf<Truck>());
            Assert.Equals("Deliver by road!", transport.DeliverMethod);
        }

        [Test]
        public void SeaLogisticsImplemented()
        {
            ILogistics logistics = new SeaLogistics();
            var transport = logistics.CreateTransport();
            transport.Deliver();

            Assert.That(transport, Is.TypeOf<Ship>());
            Assert.Equals("Deliver by sea!", transport.DeliverMethod);
        }
    }
}
