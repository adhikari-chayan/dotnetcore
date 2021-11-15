using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DelayTaskSortedSetDemo
{
    public class SubscribeTaskBgTask : BackgroundService
    {
       
        private readonly ITaskServices _taskServices;

        public SubscribeTaskBgTask(ITaskServices taskServices)
        {
           
            this._taskServices = taskServices;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            await _taskServices.SubscribeToDo();
        }
    }
}
