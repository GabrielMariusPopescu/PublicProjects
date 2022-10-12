namespace DesignPatterns.Business.AbstractFactoryPattern.Contracts
{
    public interface IFurnitureFactory
    {
        IModernFurniture CreateModernFurniture();

        IVictorianFurniture CreateVictorianFurniture();
    }
}