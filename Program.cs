using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AsyncPractice.Entities;

namespace AsyncPractice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            Kitchen kitchen = new Kitchen();

            /* At this point we are initializing 
            all task at the same Time */
            var coffeTask = kitchen.PourCoffeAsync();
            var eggTask = kitchen.FryEggAsync(2);

            var breakfast = new List<Task> { coffeTask, eggTask };

            while (breakfast.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfast);
                if(finishedTask == coffeTask)
                {
                    Console.WriteLine("Coffe is Ready!!");
                }
                else if (finishedTask == eggTask)
                {
                    Egg eggs = eggTask.Result;
                    kitchen.ApplyKetchup(eggs);
                    kitchen.ApplyMayo(eggs);
                    Console.WriteLine("Eggs are ready!!");
                }
                breakfast.Remove(finishedTask);
            }

            Console.WriteLine("Breakfast is ready!");

            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
