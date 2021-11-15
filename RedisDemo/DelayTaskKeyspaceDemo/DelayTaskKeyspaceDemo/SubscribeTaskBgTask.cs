using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DelayTaskKeyspaceDemo
{
    public class SubscribeTaskBgTask : BackgroundService
    {
        private readonly ITaskServices _taskServices;

        public SubscribeTaskBgTask(ITaskServices taskServices)
        {
            
            this._taskServices = taskServices;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _taskServices.SubscribeToDo("task:");

            return Task.CompletedTask;
        }
    }
}
