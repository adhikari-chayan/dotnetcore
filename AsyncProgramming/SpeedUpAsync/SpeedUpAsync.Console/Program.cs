using SpeedUpAsync.Client.Contracts;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpeedUpAsync.Client
{
    class Program
    {
        static async Task Main()
        {
            

            var httpClient = new HttpClient();

            var stopWatch = Stopwatch.StartNew();

            var youtubeSubscribersTask = GetYoutubeSubscribers(httpClient);
            var twitterFollowersTask = GetTwitterFollowers(httpClient);
            var githubFollowersTask = GetGithubFollowers(httpClient);

            //Throws only 1st exception
            //await Task.WhenAll(youtubeSubscribersTask, twitterFollowersTask, githubFollowersTask);

            //Throws an aggregate extension containing all exceptions
            await TaskExtensions.WhenAll(youtubeSubscribersTask, twitterFollowersTask, githubFollowersTask);

            //var youtubeSubscribers = await youtubeSubscribersTask;
            //var twitterFollowers = await twitterFollowersTask;
            //var githubFollowers = await githubFollowersTask;

            //Instead of await we can do a .Result. Though doing a .Result needs to be avoided in other cases to avoid a deadlock, in our case it is fine as the tasks have been already awaited as part of Task.WhwnAll and have the result ready so this wont block the threads
            var youtubeSubscribers = youtubeSubscribersTask.Result;
            var twitterFollowers = twitterFollowersTask.Result;
            var githubFollowers = githubFollowersTask.Result;



            Console.WriteLine($"Done in: {stopWatch.ElapsedMilliseconds}ms");

            var userProfile = new UserProfile("Chayan Adhikari", twitterFollowers, youtubeSubscribers, githubFollowers);

            Console.WriteLine(userProfile.ToString());

            await ExceptionDemo();
        }

        private static async Task ExceptionDemo()
        {
            var taskCompletionSource = new TaskCompletionSource<int>();
            taskCompletionSource.TrySetException(new Exception[]
            {
                new("This went wrong first"),
                new("This went wrong later"),
            });

            //Throws only 1st exception
            //await Task.WhenAll(taskCompletionSource.Task);

            //Throws an aggregate extension containing both exceptions
            await TaskExtensions.WhenAll(taskCompletionSource.Task);


        }

        

        private static async Task<int> GetYoutubeSubscribers(HttpClient httpClient)
        {
            var youtubeResponse = await httpClient.GetStringAsync($"https://localhost:44313/api/socialmedia/youtube");
            var youtubeDetails = JsonSerializer.Deserialize<YoutubeDetails>(youtubeResponse);
            return youtubeDetails.Subscribers;
        }

        private static async Task<int> GetTwitterFollowers(HttpClient httpClient)
        {
            var twitterResponse = await httpClient.GetStringAsync($"https://localhost:44313/api/socialmedia/twitter");
            var twitterDetails = JsonSerializer.Deserialize<TwitterDetails>(twitterResponse);

            return twitterDetails.Followers;
        }

        private static async Task<int> GetGithubFollowers(HttpClient httpClient)
        {
            var githubResponse = await httpClient.GetStringAsync($"https://localhost:44313/api/socialmedia/github");
            var githubDetails = JsonSerializer.Deserialize<GithubDetails>(githubResponse);

            return githubDetails.Followers;
        }
    }
}
