using DesignPatterns.Business.DecoratorPattern.Beverage;

namespace DesignPatterns.Business.DecoratorPattern.Decorator
{
    public abstract class Flavour : Drink
    {
        protected Flavour(Drink drink) => this.drink = drink;

        public override string GetDescription() => drink.GetDescription();

        public override double GetCost() => drink.GetCost();

        //

        private readonly Drink drink;
    }
}
