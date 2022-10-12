using DesignPatterns.Business.CommandPattern.Contracts;
using DesignPatterns.Business.CommandPattern.Models;

namespace DesignPatterns.Business.CommandPattern.Services
{
    public class TurnOffCommand : ICommand
    {
        public TurnOffCommand(Light light) => this.light = light;

        public void Do() => light.TurnOff();

        public void Undo() => light.TurnOn();

        //

        private readonly Light light;
    }
}