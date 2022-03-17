using System;
using System.Threading;

namespace OperationCanceledExceptionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                var sender = new AnalyticsSender(cts);
                for (var i = 1; i <= 10000; i++)
                    sender.QueueAnalyticsData(i);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main: error", ex);
            }
        }
    }
}
