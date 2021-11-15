using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelayTaskKeyspaceDemo
{
    public interface ITaskServices
    {
        void SubscribeToDo(string keyPrefix);
        Task DoTaskAsync();
    }
    public class TaskServices : ITaskServices
    {
        public async Task DoTaskAsync()
        {
            //do something here
            //....

            //this operation should be done after certain secs.
            var taskId = new Random().Next(1, 1000);
            int sec = 30;

            await RedisHelper.SetAsync($"task:{taskId}", "1", sec);
            await RedisHelper.SetAsync($"other:{taskId + 10000}", "1", sec);
        }

        public void SubscribeToDo(string keyPrefix)
        {
            RedisHelper.Subscribe(("__keyevent@0__:expired", arg =>
            {
                var msg = arg.Body;
                Console.WriteLine($"recived {msg}");
                if (msg.StartsWith(keyPrefix))
                {
                        // read the task id from expired key
                        var val = msg.Substring(keyPrefix.Length);
                        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Start processing task {val}");
                }
            }));
        }
    }
}
