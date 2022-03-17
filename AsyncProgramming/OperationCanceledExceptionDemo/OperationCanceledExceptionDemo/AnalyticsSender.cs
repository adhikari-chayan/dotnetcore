using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OperationCanceledExceptionDemo
{
    internal class AnalyticsSender
    {
        private BlockingCollection<int> analyticsDataQueue;
        private readonly CancellationTokenSource cancellationSource;

        public AnalyticsSender(CancellationTokenSource cancellationSource)
        {
            this.cancellationSource = cancellationSource;

            analyticsDataQueue = CreateAnalyticsDataQueue();
        }

        public void QueueAnalyticsData(int data)
        {           
            analyticsDataQueue.Add(data);
        }

        private BlockingCollection<int> CreateAnalyticsDataQueue()
        {
            var queue = new BlockingCollection<int>(new ConcurrentQueue<int>());

            var token = cancellationSource.Token;

            Task.Factory.StartNew(() => StoreQueuedAnalyticsData(queue, token), token, TaskCreationOptions.LongRunning, TaskScheduler.Current);

            return queue;
        }

        private void StoreQueuedAnalyticsData(BlockingCollection<int> queue, CancellationToken token)
        {
            try
            {
                foreach (var analyticsObject in queue.GetConsumingEnumerable(token))
                {
                    StoreAnalyticsData(analyticsObject);
                }
            }
            catch (OperationCanceledException opex)
            {
                Console.WriteLine("The Operation was cancelled. Disposing the queue.", opex);
                analyticsDataQueue.Dispose();
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"StoreQueuedAnalyticsData : Error", ex);
            }
        }

        private void StoreAnalyticsData(int data)
        {
            try
            {
                Thread.Sleep(1000);
                //throw new ArgumentNullException("Test Exception");
                Console.WriteLine($"Saved data - {data}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception has occurred while storing the analytics chunk  in Redis", ex);
                //throw;
            }

            //Thread.Sleep(1000);
            //Console.WriteLine($"Saved data - {data}");
        }
    }
}