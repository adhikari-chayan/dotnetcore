using Newtonsoft.Json;

namespace MovieApi.Models
{
    public class Actor
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
