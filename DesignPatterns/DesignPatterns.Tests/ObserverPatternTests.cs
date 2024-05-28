using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DesignPatterns.Business.ObserverPattern.Contracts;
using DesignPatterns.Business.ObserverPattern.Services;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class ObserverPatternTests
    {
        [SetUp]
        public void Init()
        {
            subscribers = new List<ISubscriber> { australianSubscriber, romanianSubscriber, unitedKingdomSubscriber };
            weather = new Weather(subscribers);
            australianSubscriber = new AustralianSubscriber(weather);
            romanianSubscriber = new RomanianSubscriber(weather);
            unitedKingdomSubscriber = new UnitedKingdomSubscriber(weather);
        }

        [Test]
        public void EverybodySubscribed()
        {
            subscribers.Add(australianSubscriber);
            weather.Subscribe(australianSubscriber);

            Assert.Equals("Australian subscriber", australianSubscriber.Name);
            Assert.Equals("Australian subscriber subscribed!", weather.Message);

            subscribers.Add(romanianSubscriber);
            weather.Subscribe(romanianSubscriber);

            Assert.Equals("Romanian subscriber", romanianSubscriber.Name);
            Assert.Equals("Romanian subscriber subscribed!", weather.Message);

            subscribers.Add(unitedKingdomSubscriber);
            weather.Subscribe(unitedKingdomSubscriber);

            Assert.Equals("United Kingdom subscriber", unitedKingdomSubscriber.Name);
            Assert.Equals("United Kingdom subscriber subscribed!", weather.Message);
        }

        [Test]
        public void EverybodyUnsubscribed()
        {
            subscribers.Add(australianSubscriber);
            weather.Unsubscribe(australianSubscriber);

            Assert.Equals("Australian subscriber", australianSubscriber.Name);
            Assert.Equals("Australian subscriber unsubscribed!", weather.Message);

            subscribers.Add(romanianSubscriber);
            weather.Unsubscribe(romanianSubscriber);

            Assert.Equals("Romanian subscriber", romanianSubscriber.Name);
            Assert.Equals("Romanian subscriber unsubscribed!", weather.Message);

            subscribers.Add(unitedKingdomSubscriber);
            weather.Unsubscribe(unitedKingdomSubscriber);

            Assert.Equals("United Kingdom subscriber", unitedKingdomSubscriber.Name);
            Assert.Equals("United Kingdom subscriber unsubscribed!", weather.Message);
        }

        [Test]
        public void AustralianSubscriberIsNotified()
        {
            weather.Subscribe(australianSubscriber);
            weather.Degree = 40;
            weather.Notify();

            Assert.Equals("It's normal out here!", australianSubscriber.Message);
        }

        [Test]
        public void RomanianSubscriberIsNotified()
        {
            weather.Subscribe(romanianSubscriber);
            weather.Degree = -10;
            weather.Notify();

            Assert.Equals("It's freezing!", romanianSubscriber.Message);
        }

        [Test]
        public void EnglishSubscriberIsNotified()
        {
            weather.Subscribe(unitedKingdomSubscriber);
            weather.Degree = 250;
            weather.Notify();

            Assert.Equals("It's roasting!", unitedKingdomSubscriber.Message);
        }

        [Test]
        public void AustralianAndEnglishSubscribersAreNotified()
        {
            weather.Subscribe(unitedKingdomSubscriber);
            weather.Subscribe(australianSubscriber);
            weather.Degree = 40;
            weather.Notify();

            Assert.Equals("It's roasting!", unitedKingdomSubscriber.Message);
            Assert.Equals("It's normal out here!", australianSubscriber.Message);
        }

        //

        private IWeather weather;
        private List<ISubscriber> subscribers;
        private ISubscriber australianSubscriber;
        private ISubscriber romanianSubscriber;
        private ISubscriber unitedKingdomSubscriber;
    }
}
