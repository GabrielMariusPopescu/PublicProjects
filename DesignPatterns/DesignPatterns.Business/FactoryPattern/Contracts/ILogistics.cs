namespace DesignPatterns.Business.FactoryPattern.Contracts
{
    public interface ILogistics
    {
        ITransport CreateTransport();
    }
}
