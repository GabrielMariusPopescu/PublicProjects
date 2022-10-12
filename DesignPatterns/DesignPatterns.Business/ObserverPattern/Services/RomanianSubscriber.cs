using DesignPatterns.Business.ObserverPattern.Contracts;

namespace DesignPatterns.Business.ObserverPattern.Services
{
    public class RomanianSubscriber : ISubscriber
    {
        public RomanianSubscriber(IWeather weather) =>
            this.weather = weather;

        public string Name => "Romanian subscriber";

        public string Message { get; private set; }

        public void Update()
        {
            if (weather.Degree < 0)
                Message = "It's freezing!";
        }

        //

        private readonly IWeather weather;
    }
}
