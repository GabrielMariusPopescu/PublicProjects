namespace DesignPatterns.Business.DecoratorPattern.Beverage
{
    public class Decaf : Drink
    {
        public override string GetDescription() => "decaf";

        public override double GetCost() => 2;
    }
}
