using DesignPatterns.Business.FactoryPattern.Contracts;

namespace DesignPatterns.Business.FactoryPattern.Models
{
    public class Truck : ITransport
    {

        public string DeliverMethod { get; private set; }

        public void Deliver() => DeliverMethod = "Deliver by road!";
    }
}