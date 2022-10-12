using DesignPatterns.Business.CommandPattern;
using DesignPatterns.Business.CommandPattern.Contracts;
using DesignPatterns.Business.CommandPattern.Models;
using DesignPatterns.Business.CommandPattern.Services;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
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

            Assert.AreEqual("Light is turned on.", light.State);

            invoker.UndoClickOn();

            Assert.AreEqual("Light is turned off.", light.State);
        }

        [Test]
        public void TurnOffCommandInvoked()
        {
            invoker.ClickOff();

            Assert.AreEqual("Light is turned off.", light.State);

            invoker.UndoClickOff();

            Assert.AreEqual("Light is turned on.", light.State);
        }

        [Test]
        public void DimCommandInvoked()
        {
            invoker.ClickDim();

            Assert.AreEqual("Light is dimmed.", light.State);

            invoker.UndoClickDim();

            Assert.AreEqual("Light is brighter.", light.State);
        }

        [Test]
        public void BrightCommandInvoked()
        {
            invoker.ClickBright();

            Assert.AreEqual("Light is brighter.", light.State);

            invoker.UndoClickBright();

            Assert.AreEqual("Light is dimmed.", light.State);
        }

        //

        private Light light;
        private RemoteControl invoker;
    }
}
