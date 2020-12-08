using System;
using System.Threading.Tasks;
using AsyncPractice.Entities;

namespace AsyncPractice
{
    public class Kitchen
    {
        public Coffe PourCoffe()
        {   
            Console.WriteLine("Preparing coffe...");
            Task.Delay(1000).Wait();

            return new Coffe();
        }

        public async Task<Coffe> PourCoffeAsync()
        {   
            Console.WriteLine("Preparing coffe...");
            await Task.Delay(1000);

            return new Coffe();
        }

        public Egg FryEgg(int Quantity)
        {
            Console.WriteLine("Warmimg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Craking {Quantity} Eggs...");
            Console.WriteLine("Cooking the eggs...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        public async Task<Egg> FryEggAsync(int Quantity)
        {
            Console.WriteLine("Warmimg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"Craking {Quantity} Eggs...");
            Console.WriteLine("Cooking the eggs...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        public void ApplyKetchup(Egg egg) => 
            Console.WriteLine("Applying ketchup...");

        public void ApplyMayo(Egg egg) =>
            Console.WriteLine("Applying mayo...");

    }
}