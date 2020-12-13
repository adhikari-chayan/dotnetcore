using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async.IEnumerable.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var result = await Test();
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static Task<IEnumerable<string>> Test()
        {
          
            return Task.FromResult(GetStrings());
        }

        private static IEnumerable<string> GetStrings()
        {
            for (var count = 0; count < 5; count++)
            {
                yield return $"Count {count}";
            }
        }
    }
}
