using Newtonsoft.Json;

namespace DevTest.Models
{
    public class Command
    {
        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "steps")]
        public int Steps { get; set; }
    }
}