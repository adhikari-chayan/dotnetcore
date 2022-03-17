﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedUpAsync.Client
{
    public static class TaskExtensions
    {
        public static async Task<IEnumerable<T>> WhenAll<T>( params Task<T>[] tasks)
        {
            var allTasks = Task.WhenAll(tasks);
            try
            {
                return await allTasks;
            }
            catch (Exception)
            {
                //ignore
            }

            throw allTasks.Exception ?? throw new Exception("This can't possibly happen");
        }
    }
}
