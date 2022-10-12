using DesignPatterns.Business.FactoryPattern.Contracts;

namespace DesignPatterns.Business.FactoryPattern.Models
{
    public class Ship : ITransport
    {
        public string DeliverMethod { get; private set; }

        public void Deliver() => DeliverMethod = "Deliver by sea!";
    }
}
