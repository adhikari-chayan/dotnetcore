using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieApi.Models
{
    public class ActorList
    {
        [JsonProperty("results")]
        public List<Actor> Actors { get; set; }
    }
}
