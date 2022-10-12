namespace DesignPatterns.Business.DecoratorPattern.Beverage
{
    public class Espresso : Drink
    {
        public override string GetDescription() => "espresso";

        public override double GetCost() => 3.50;
    }
}
