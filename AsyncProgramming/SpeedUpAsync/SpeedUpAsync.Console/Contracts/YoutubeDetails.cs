using System.Text.Json.Serialization;

namespace SpeedUpAsync.Client.Contracts
{
    public class YoutubeDetails
    {
        [JsonPropertyName("subscribers")]
        public int Subscribers { get; set; }
    }
}
