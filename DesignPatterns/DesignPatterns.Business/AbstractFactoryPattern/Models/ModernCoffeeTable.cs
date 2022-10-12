using DesignPatterns.Business.AbstractFactoryPattern.Contracts;

namespace DesignPatterns.Business.AbstractFactoryPattern.Models
{
    public class ModernCoffeeTable : IModernFurniture
    {
        public string GetName() => "This is a modern coffee table.";
    }
}