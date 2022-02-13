using System;
using System.Threading;

namespace TwoWaySignaling
{
    //Let’s say we want the main thread to signal a worker thread three times in a row. If the main thread simply calls Set on a wait handle several times in rapid succession, the second or third signal may get lost, since the worker may take time to process each signal.

    //The solution is for the main thread to wait until the worker’s ready before signaling it. This can be done with another AutoResetEvent
    internal class Program
    {
        static EventWaitHandle _ready = new AutoResetEvent(false);
        static EventWaitHandle _go = new AutoResetEvent(false);
        static readonly object _locker = new object();
        static string _message;
        static void Main(string[] args)
        {
            new Thread(Work).Start();

            _ready.WaitOne(); // Wait till we receive signal from the Worker thread that it is ready
            lock (_locker)
            {
                _message = "ooo";
            }
            _go.Set();// Tell worker to go ahed with processing
            
            _ready.WaitOne();
            lock (_locker) 
            { 
                _message = "ahhh"; // Give the worker another message
            }  
            _go.Set();
            
            _ready.WaitOne();
            lock (_locker) _message = null;    // Signal the worker to exit
            _go.Set();
        }

        static void Work()
        {
            while (true)
            {
                _ready.Set();// Indicate and send signal that worker thread is ready is process
                _go.WaitOne();// Waiting for signal from main thread to proceed further
                lock (_locker)
                {
                    if (_message == null) return;        // Gracefully exit
                    Console.WriteLine(_message);
                }
            }
        }
    }
}
