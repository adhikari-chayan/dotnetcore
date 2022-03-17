using System.Text.Json.Serialization;

namespace SpeedUpAsync.Client.Contracts
{
    public class GithubDetails
    {
        [JsonPropertyName("followers")]
        public int Followers { get; set; }
    }
}
