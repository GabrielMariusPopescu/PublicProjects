namespace DesignPatterns.Business.ObserverPattern.Contracts
{
    public interface ISubscriber
    {
        string Name { get; }

        string Message { get; }

        void Update();
    }
}
