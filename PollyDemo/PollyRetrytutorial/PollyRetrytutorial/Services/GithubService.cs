using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PollyRetrytutorial.Services
{
    public class GithubService : IGithubService
    {
        private const int MaxRetries = 3;
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly Random Random = new Random();
        private readonly AsyncRetryPolicy _retryPolicy;


        public GithubService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _retryPolicy = Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(MaxRetries,times => TimeSpan.FromMilliseconds(times*100));
        }
        public async Task<GithubUser> GetUserByUsernameAsync(string userName)
        {
            //return await GetUserFromGithubTraditional(userName);
            return await GetUserFromGithubUsingPolly(userName);


        }

        public async Task<List<GithubUser>> GetUsersFromOrgAsync(string orgName)
        {
            var client = _httpClientFactory.CreateClient("Github");

            return await _retryPolicy.ExecuteAsync(async () =>
            {
                var result = await client.GetAsync($"orgs/{orgName}");
                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                var resultString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GithubUser>>(resultString);
            });

        }

        private void ThrowRandomException()
        {
            if (Random.Next(1, 3) == 1)
                throw new HttpRequestException("This is a fake request exception");
        }

        private async Task<GithubUser> GetUserFromGithubUsingPolly(string userName)
        {
            var client = _httpClientFactory.CreateClient("Github");

           return await _retryPolicy.ExecuteAsync(async () =>
           {
                ThrowRandomException();

                var result = await client.GetAsync($"users/{userName}");
                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                var resultString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GithubUser>(resultString);


            });

        }

        private async Task<GithubUser> GetUserFromGithubTraditional(string userName)
        {
            var client = _httpClientFactory.CreateClient("Github");
            var retriesLeft = MaxRetries;

            GithubUser githubUser = null;
            while (retriesLeft > 0)
            {
                try
                {
                    ThrowRandomException();

                    var result = await client.GetAsync($"users/{userName}");

                    if (result.StatusCode == HttpStatusCode.NotFound)
                    {
                        break;
                    }

                    var resultString = await result.Content.ReadAsStringAsync();
                    githubUser = JsonConvert.DeserializeObject<GithubUser>(resultString);
                    break;
                }
                catch (HttpRequestException)
                {
                    retriesLeft--;
                    if (retriesLeft == 0)
                    {
                        throw;
                    }
                }
            }

            return githubUser;
        }


    }
}
