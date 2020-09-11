using System;
using System.Collections.Generic;
using System.Linq;

namespace Brewing
{
    public class CoffeeFactory
    {
        public static List<iCoffee> coffees = new List<iCoffee>();
        internal static iCoffee Create(BrewStyle coffeeType)
        {
            if (!coffees.Exists(coffee => coffee.Style == coffeeType))
                coffees.Add(CoffeeSwitch(coffeeType));

            return coffees.First(coffee => coffee.Style == coffeeType);
        }

        internal static iCoffee CoffeeSwitch(BrewStyle coffeeType) =>
            coffeeType switch
            {
                BrewStyle.FrenchPress => new FrenchPress(),
                BrewStyle.PodSystem => new PodSystem(),
                BrewStyle.FrisbeeBrew => new FrisbeeBrew()
            };
    }
}