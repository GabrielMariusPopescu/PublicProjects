using DesignPatterns.Business.CommandPattern.Contracts;
using DesignPatterns.Business.CommandPattern.Models;

namespace DesignPatterns.Business.CommandPattern.Services
{
    public class DimCommand : ICommand
    {
        public DimCommand(Light light) => this.light = light;

        public void Do() => light.Dim();

        public void Undo() => light.Bright();

        //

        private readonly Light light;
    }
}
