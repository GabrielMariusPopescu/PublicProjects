using DesignPatterns.Business.AbstractFactoryPattern.Contracts;
using DesignPatterns.Business.AbstractFactoryPattern.Models;

namespace DesignPatterns.Business.AbstractFactoryPattern.Services
{
    public class CoffeeTableFurnitureFactory : IFurnitureFactory
    {
        public IModernFurniture CreateModernFurniture() =>
            new ModernCoffeeTable();

        public IVictorianFurniture CreateVictorianFurniture() =>
            new VictorianCoffeeTable();
    }
}