namespace DisposableSample
{
    public class MyClass : IDisposable
    {
        private readonly CancellationTokenSource feedCancellationTokenSource = new CancellationTokenSource();
        private readonly Task feedTask;

        public MyClass()
        {
           feedTask = Task.Factory.StartNew(async () => await DoSomething(feedCancellationTokenSource.Token),
                                            feedCancellationTokenSource.Token,
                                            TaskCreationOptions.LongRunning,
                                            TaskScheduler.Default
                                           );
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                feedCancellationTokenSource.Cancel();
                feedTask.Wait();

                feedCancellationTokenSource.Dispose();
                feedTask.Dispose();
            }
        }

        private async Task DoSomething(CancellationToken token)
        {
            await Task.Delay(10000, token);
            Console.WriteLine("Do Something completed");
        }

        ~MyClass()
        {
            Console.WriteLine("Finalizer");
        }
    }
}
