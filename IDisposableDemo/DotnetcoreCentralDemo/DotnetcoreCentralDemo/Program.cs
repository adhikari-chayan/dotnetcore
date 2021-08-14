using System;

namespace DotnetcoreCentralDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var serviceProxy = new ServiceProxy(null);
            serviceProxy.Get();

            serviceProxy.Post("");
        }
    }
}
