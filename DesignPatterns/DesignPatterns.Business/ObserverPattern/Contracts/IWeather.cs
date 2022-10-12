namespace DesignPatterns.Business.ObserverPattern.Contracts
{
    public interface IWeather
    {
        string Message { get; }

        int Degree { get; set; }

        void Subscribe(ISubscriber subscriber);

        void Unsubscribe(ISubscriber subscriber);

        void Notify();
    }
}
