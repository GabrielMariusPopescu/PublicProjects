namespace DesignPatterns.Business.FactoryPattern.Contracts
{
    public interface ITransport
    {
        string DeliverMethod { get; }

        void Deliver();
    }
}