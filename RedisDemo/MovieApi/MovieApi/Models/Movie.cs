using Newtonsoft.Json;

namespace MovieApi.Models
{
    public class Movie
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
