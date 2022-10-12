using DesignPatterns.Business.CommandPattern.Contracts;
using DesignPatterns.Business.CommandPattern.Models;

namespace DesignPatterns.Business.CommandPattern.Services
{
    public class TurnOnCommand : ICommand
    {
        public TurnOnCommand(Light light) => this.light = light;

        public void Do() => light.TurnOn();

        public void Undo() => light.TurnOff();

        //

        private readonly Light light;
    }
}
