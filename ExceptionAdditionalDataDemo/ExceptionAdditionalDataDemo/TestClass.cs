using System;
using System.Threading;

namespace ExceptionAdditionalDataDemo
{
    public class TestClass
    {
        public int TestMethod()
        {
            try
            {
                AnotherMethod();
                return 1;
            }
            catch (Exception ex)
            {
                ex.Data["BetPlacementContext"] = 2;
                throw;
            }
        }

        private void AnotherMethod()
        {
            Thread.Sleep(1000);
            throw new Exception("Test Exception");
        }
    }
}
