using System;
using System.Threading;

namespace ProducerConsumerQueue
{
    //The advantage of this model is that you have precise control over how many worker threads execute at once. This can allow you to limit consumption of not only CPU time, but other resources as well. If the tasks perform intensive disk I/O, for instance, you might have just one worker thread to avoid starving the operating system and other applications. Another type of application may have 20. You can also dynamically add and remove workers throughout the queue’s life. The CLR’s thread pool itself is a kind of producer/consumer queue.

    //A producer/consumer queue typically holds items of data upon which (the same) task is performed. For example, the items of data may be filenames, and the task might be to encrypt those files.

    //In the example below, we use a single AutoResetEvent to signal a worker, which waits when it runs out of tasks (in other words, when the queue is empty). We end the worker by enqueing a null task

    internal class Program
    {
        static void Main(string[] args)
        {
            using (ProducerConsumerQueue q = new ProducerConsumerQueue())
            {
                q.EnqueueTask("Hello");
                for (int i = 0; i < 10; i++)
                {
                    q.EnqueueTask("Say " + i);
                }
                q.EnqueueTask("Goodbye!");

                //Thread.Sleep(20000); //To simulate when there are no items added to the queue in the scope of the lifetime of the ProducerConsumerQueue class

            }

            // Exiting the using statement calls q's Dispose method, which
            // enqueues a null task and waits until the consumer finishes.
        }
    }
}
