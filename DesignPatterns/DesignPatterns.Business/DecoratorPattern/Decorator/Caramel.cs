using DesignPatterns.Business.DecoratorPattern.Beverage;

namespace DesignPatterns.Business.DecoratorPattern.Decorator
{
    public class Caramel : Flavour
    {
        public Caramel(Drink drink)
            : base(drink) =>
            this.drink = drink;

        public override string GetDescription() => $"{drink.GetDescription()} with caramel flavour";

        public override double GetCost() => drink.GetCost() + 2;

        //

        private readonly Drink drink;
    }
}
