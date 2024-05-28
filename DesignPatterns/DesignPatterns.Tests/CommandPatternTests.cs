using System.Diagnostics.CodeAnalysis;
using DesignPatterns.Business.CommandPattern;
using DesignPatterns.Business.CommandPattern.Contracts;
using DesignPatterns.Business.CommandPattern.Models;
using DesignPatterns.Business.CommandPattern.Services;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class CommandPatternTests
    {
        [SetUp]
        public void Init()
        {
            light = new Light();
            ICommand onCommand = new TurnOnCommand(light);
            ICommand offCommand = new TurnOffCommand(light);
            ICommand dimCommand = new DimCommand(light);
            ICommand brightCommand = new BrightCommand(light);
            invoker = new RemoteControl(onCommand, offCommand, dimCommand, brightCommand);
        }

        [Test]
        public void TurnOnCommandInvoked()
        {
            invoker.ClickOn();

            Assert.Equals("Light is turned on.", light.State);

            invoker.UndoClickOn();

            Assert.Equals("Light is turned off.", light.State);
        }

        [Test]
        public void TurnOffCommandInvoked()
        {
            invoker.ClickOff();

            Assert.Equals("Light is turned off.", light.State);

            invoker.UndoClickOff();

            Assert.Equals("Light is turned on.", light.State);
        }

        [Test]
        public void DimCommandInvoked()
        {
            invoker.ClickDim();

            Assert.Equals("Light is dimmed.", light.State);

            invoker.UndoClickDim();

            Assert.Equals("Light is brighter.", light.State);
        }

        [Test]
        public void BrightCommandInvoked()
        {
            invoker.ClickBright();

            Assert.Equals("Light is brighter.", light.State);

            invoker.UndoClickBright();

            Assert.Equals("Light is dimmed.", light.State);
        }

        //

        private Light light;
        private RemoteControl invoker;
    }
}
