using System;
using System.CommandLine;
using Brewing;

namespace coffeemaker
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootCommand = new RootCommand() { new Brewing.Brew("brew") };
            rootCommand.InvokeAsync(args).Wait();
        }
    }
}
