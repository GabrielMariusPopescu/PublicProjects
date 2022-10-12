using DesignPatterns.Business.CommandPattern.Contracts;
using DesignPatterns.Business.CommandPattern.Models;

namespace DesignPatterns.Business.CommandPattern.Services
{
    public class BrightCommand : ICommand
    {
        public BrightCommand(Light light) => this.light = light;

        public void Do() => light.Bright();

        public void Undo() => light.Dim();

        //

        private readonly Light light;
    }
}