using BenchmarkDotNet.Running;
using System;

namespace BenchmarkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DateParserBenchmarks>();
        }
    }
}
