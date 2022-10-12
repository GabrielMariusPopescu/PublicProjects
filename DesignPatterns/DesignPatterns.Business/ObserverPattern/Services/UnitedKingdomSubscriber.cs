using DesignPatterns.Business.ObserverPattern.Contracts;

namespace DesignPatterns.Business.ObserverPattern.Services
{
    public class UnitedKingdomSubscriber : ISubscriber
    {
        public UnitedKingdomSubscriber(IWeather weather)
        {
            this.weather = weather;
        }

        public string Name => "United Kingdom subscriber";

        public string Message { get; private set; }

        public void Update()
        {
            if (weather.Degree >= 20)
                Message = "It's roasting!";
        }

        //

        private readonly IWeather weather;
    }
}
