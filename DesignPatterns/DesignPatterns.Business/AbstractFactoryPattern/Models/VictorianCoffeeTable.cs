using DesignPatterns.Business.AbstractFactoryPattern.Contracts;

namespace DesignPatterns.Business.AbstractFactoryPattern.Models
{
    public class VictorianCoffeeTable : IVictorianFurniture
    {
        public string GetName() => "This is a victorian coffee table.";

        public string GetCollaboratorName(IModernFurniture furniture)
        {
            var name = furniture.GetName();
            return $"{GetName()} collaborating with the ({name})";
        }
    }
}