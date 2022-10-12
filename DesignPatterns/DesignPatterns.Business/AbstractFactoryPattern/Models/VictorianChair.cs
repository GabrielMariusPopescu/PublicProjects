using DesignPatterns.Business.AbstractFactoryPattern.Contracts;

namespace DesignPatterns.Business.AbstractFactoryPattern.Models
{
    public class VictorianChair : IVictorianFurniture
    {
        public string GetName() => "This is a victorian chair.";

        public string GetCollaboratorName(IModernFurniture furniture)
        {
            var name = furniture.GetName();
            return $"{GetName()} collaborating with the ({name})";
        }
    }
}