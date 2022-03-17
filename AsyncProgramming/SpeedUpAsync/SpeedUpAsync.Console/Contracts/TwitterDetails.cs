using System.Text.Json.Serialization;

namespace SpeedUpAsync.Client.Contracts
{
    public class TwitterDetails
    {
        [JsonPropertyName("followers")]
        public int Followers { get; set; }
    }
}
