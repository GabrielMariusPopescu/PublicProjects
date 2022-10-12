using DesignPatterns.Business.AbstractFactoryPattern.Contracts;
using DesignPatterns.Business.AbstractFactoryPattern.Models;

namespace DesignPatterns.Business.AbstractFactoryPattern.Services
{
    public class ChairFurnitureFactory : IFurnitureFactory
    {
        public IModernFurniture CreateModernFurniture() =>
            new ModernChair();

        public IVictorianFurniture CreateVictorianFurniture() =>
            new VictorianChair();
    }
}