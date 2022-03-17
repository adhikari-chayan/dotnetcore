using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebCrawlerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        async static Task MainAsync(string[] args)
        {
            const int MaxLinks = 8000;
            const int MaxThreadCount = 10;
            string[] links;
            int iteration = 0;

            // Start with a single URL (a Wikipedia page, in this example).
            await AddLinksForUrl("https://en.wikipedia.org/wiki/Web_crawler");

            while ((links = File.ReadAllLines("links.txt")).Length < MaxLinks)
            {
                int offset = (iteration * MaxThreadCount);

                var tasks = new List<Task>();
                for (int i = 0; i < MaxThreadCount && (offset + i) < links.Length - 1; i++)
                {
                    tasks.Add(Task.Run(async () => await AddLinksForUrl(links[offset + i])));
                }
                Task.WaitAll(tasks.ToArray());

                iteration++;
            }
        }

        static async Task AddLinksForUrl(string url)
        {
            string html = await GetHtmlFromUrl(url);
            List<string> links = ExtractLinksFromHtml(html);

            using (var fileStream = new FileStream("links.txt",
                   FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                List<string> existingLinks = File.ReadAllLines("links.txt").ToList();
                foreach (var link in links.Except(existingLinks))
                {
                    fileStream.Write(/* the link URL, as bytes, plus a new line */);
                }
            }
        }

        private static List<string> ExtractLinksFromHtml(string html)
        {
            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(html);
            var links = new List<string>();
            foreach (HtmlNode link in pageDocument.DocumentNode.SelectNodes("//a[@href]"))
            {
                links.Add(link.InnerText);
            }

            return links;
        }

        private static async Task<string> GetHtmlFromUrl(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var pageContents = await response.Content.ReadAsStringAsync();
            return pageContents;
        }
    }
}
