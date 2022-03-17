using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedUpAsync.Client.Contracts
{
   public class UserProfile
    {
        public UserProfile(string name, int twitterFollowers, int youtubeSubscribers, int githubFollowers)
        {
            Name = name;
            TwitterFollowers = twitterFollowers;
            YoutubeSubscribers = youtubeSubscribers;
            GithubFollowers = githubFollowers;
        }
        public string Name { get; set; }
        public int TwitterFollowers { get; set; }
        public int YoutubeSubscribers { get; set; }
        public int GithubFollowers { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\n Twitter Followers: {TwitterFollowers}\n Youtube Subscribers: {YoutubeSubscribers}\n Github Followers: {GithubFollowers}";
        }
    }
}
