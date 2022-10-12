using DesignPatterns.Business.AbstractFactoryPattern.Contracts;

namespace DesignPatterns.Business.AbstractFactoryPattern.Models
{
    public class ModernChair : IModernFurniture
    {
        public string GetName() => "This is a modern chair.";
    }
}