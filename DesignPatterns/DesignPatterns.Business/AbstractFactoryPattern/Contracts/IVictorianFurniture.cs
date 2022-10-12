namespace DesignPatterns.Business.AbstractFactoryPattern.Contracts
{
    public interface IVictorianFurniture
    {
        string GetName();

        string GetCollaboratorName(IModernFurniture furniture);
    }
}