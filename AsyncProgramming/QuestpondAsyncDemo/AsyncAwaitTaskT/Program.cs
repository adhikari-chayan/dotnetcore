using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitTaskT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Start - {Thread.CurrentThread.ManagedThreadId}");
            GetContent();
            Console.WriteLine($"Main End - {Thread.CurrentThread.ManagedThreadId}");

            Console.ReadLine();
        }

        static async void GetContent()
        {
            Console.WriteLine($"GetContent() Start - {Thread.CurrentThread.ManagedThreadId}");
            var http = new HttpWrapper();
            var content = await http.GetUrlString("http://microsoft.com");
            Console.WriteLine(Environment.NewLine + content.Substring(15,45));
            Console.WriteLine();
            Console.WriteLine($"GetContent() End - {Thread.CurrentThread.ManagedThreadId}");
        }
    }

    class HttpWrapper
    {
        public async Task<string> GetUrlString(string url)
        {
            Console.WriteLine($"HttpWrapper.GetUrlString() Start - {Thread.CurrentThread.ManagedThreadId}");
            HttpClient http = new HttpClient();
            var response = await http.GetAsync(url);
            Console.WriteLine($"HttpWrapper.GetUrlString() End - {Thread.CurrentThread.ManagedThreadId}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
