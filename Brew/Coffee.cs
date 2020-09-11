using System;

namespace Brewing
{
    public enum BrewStyle
    {
        FrenchPress, PodSystem, FrisbeeBrew
    }
    public enum Granularity
    {
        Fine = 0, KindaFine = 1, Medium = 3, KindaCoarse = 4, Coarse = 5, Chunky = 6, WholeBean = 7
    }

    public interface iCoffee
    {
        int Temperature { get; set; }
        BrewStyle Style { get; }
        Granularity GrindGranularity { get; set; }
        iCoffee Brew();
        iCoffee Pour();
    }

    public class FrenchPress : iCoffee
    {
        public int Temperature { get; set; } = 70;
        public BrewStyle Style => BrewStyle.FrenchPress;
        public Granularity GrindGranularity { get; set; } = Granularity.WholeBean;
        public iCoffee Brew()
        {
            BoilWater();
            GrindBeans();
            WaitAMinute();
            return this;
        }

        private void WaitAMinute()
        {
            for (int i = 0; i < 100; i++)
                Write($"\r{GetChar(i)}  ");
            Console.WriteLine();
        }

        private char GetChar(int position) =>
            (position % 4) switch
            {
                0 => '|',
                1 => '/',
                2 => '-',
                3 => '\\'
            };

        private void GrindBeans()
        {
            Console.WriteLine("Grinding beans.");
            while (GrindGranularity != Granularity.KindaCoarse)
                Write($"\rCurrent granularity: {--GrindGranularity}.");

            Console.WriteLine();
        }
        private void BoilWater()
        {
            Console.WriteLine("Boiling water.");
            while (Temperature < 200)
                Write($"\rCurrent temperature is {++Temperature}°F.");
            Console.WriteLine();
        }

        private void Write(string line)
        {
            Console.Write(line);
            System.Threading.Thread.Sleep(100);
        }

        public iCoffee Pour()
        {
            Console.WriteLine("Pouring.");
            Console.WriteLine("Enjoy!");
            return this;
        }
    }


    public class PodSystem : iCoffee
    {
        public int Temperature { get; set; }
        public BrewStyle Style => BrewStyle.PodSystem;
        public Granularity GrindGranularity { get; set; } = Granularity.KindaFine;
        public iCoffee Brew()
        {
            InsertPod();
            PushButton();
            return this;
        }

        private void InsertPod()
        {
            Console.WriteLine("Inserting pod.");
        }

        private void PushButton()
        {
            Console.WriteLine("Button pressed.");
            Console.WriteLine("Waiting for coffee.");
            Console.WriteLine("Done.");
        }

        public iCoffee Pour()
        {
            return this;
        }
    }
    public class FrisbeeBrew : iCoffee
    {
        public int Temperature { get; set; } = 70;
        public BrewStyle Style => BrewStyle.FrisbeeBrew;
        public Granularity GrindGranularity { get; set; } = Granularity.WholeBean;
        public iCoffee Brew()
        {
            BoilWater();
            GrindBeans();
            Console.WriteLine("Stirring.");
            Stir();
            WaitAMinute();
            return this;
        }

        private void Write(string line)
        {
            Console.Write(line);
            System.Threading.Thread.Sleep(100);
        }
        private void BoilWater()
        {
            Console.WriteLine("Boiling water.");
            while (Temperature < 200)
                Write($"\rCurrent temperature is {++Temperature}°F.");
            Console.WriteLine();
        }
        private void GrindBeans()
        {
            Console.WriteLine("Grinding beans.");

            while (GrindGranularity != Granularity.Fine)
                Write($"\rCurrent granularity: {--GrindGranularity}.".PadRight(50));

            Console.WriteLine();
        }

        private void Stir()
        {
            for (int i = 0; i < 50000; i++)
                Console.Write($"\r{GetChar(i)}  ");

            Console.WriteLine();
        }

        private void WaitAMinute()
        {
            for (int i = 0; i < 100; i++)
                Write($"\r{GetChar(i)}  ");

            Console.WriteLine();
        }

        private char GetChar(int position) =>
            (position % 4) switch
            {
                0 => '|',
                1 => '/',
                2 => '-',
                3 => '\\'
            };
        public iCoffee Pour()
        {
            Console.WriteLine("Pouring.");
            return this;
        }
    }
}