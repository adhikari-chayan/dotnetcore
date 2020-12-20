using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncBasics
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await MakeTeaAsync();


        }

        public static string MakeTea()
        {
            var water=BoilWater();
            
            "take the cups out".Dump();

            "put tea in cups".Dump();

            var tea = $"pour {water} in cups".Dump();

            return tea;
        }

        public static string BoilWater()
        {
            "Start the kettle".Dump();

            "waiting for the kettle".Dump();
            Task.Delay(2000).GetAwaiter().GetResult();
            "kettle finished boiling".Dump();
            
            return "water";
        }

        public static async Task<string> MakeTeaAsync()
        {
            var boilingWater = BoilWaterAsync();

            "take the cups out".Dump();
          
            "put tea in cups".Dump();
           
            var water = await boilingWater;
           
            var tea = $"pour {water} in cups".Dump();
            
            return tea;
        }

        public static async Task<string> BoilWaterAsync()
        {
            "Start the kettle".Dump();

            "waiting for the kettle".Dump();
            
            await Task.Delay(2000);
            "kettle finished boiling".Dump();
            
            return "water";
        }
    }

    public static class StringExtensions
    {
        public static string Dump(this string message)
        {
            Console.WriteLine(message);
            return message;
        }
    }



}
