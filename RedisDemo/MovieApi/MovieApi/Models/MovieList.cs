using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class MovieList
    {
        [JsonProperty("cast")]
        public List<Movie> Movies { get; set; }
    }
}
