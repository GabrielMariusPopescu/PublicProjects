using DesignPatterns.Business.FactoryPattern.Contracts;
using DesignPatterns.Business.FactoryPattern.Models;
using DesignPatterns.Business.FactoryPattern.Services;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class FactoryPatternTests
    {
        [Test]
        public void RoadLogisticImplemented()
        {
            ILogistics logistics = new RoadLogistics();
            var transport = logistics.CreateTransport();
            transport.Deliver();

            Assert.IsInstanceOf<Truck>(transport);
            Assert.AreEqual("Deliver by road!", transport.DeliverMethod);
        }

        [Test]
        public void SeaLogisticsImplemented()
        {
            ILogistics logistics = new SeaLogistics();
            var transport = logistics.CreateTransport();
            transport.Deliver();

            Assert.IsInstanceOf<Ship>(transport);
            Assert.AreEqual("Deliver by sea!", transport.DeliverMethod);
        }
    }
}
