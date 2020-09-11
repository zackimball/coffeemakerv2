using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Brewing
{
    public class Brew : System.CommandLine.Command
    {
        public Brew(string name, string description = null) : base(name, description)
        {
            Add(new Option<BrewStyle>("--coffeeType"));
            Handler = CommandHandler.Create<BrewStyle>(BrewCoffee);
        }

        public void BrewCoffee(BrewStyle coffeeType)
        {
            var coffee = CoffeeFactory.Create(coffeeType);
            coffee.Brew();
            coffee.Pour();
        }
    }
}