using System;

namespace ExceptionAdditionalDataDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var tc = new TestClass();
                var result = tc.TestMethod();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data["BetPlacementContext"] ?? "EMPTY");
                Console.WriteLine(ex);
            }

        }
    }
}
