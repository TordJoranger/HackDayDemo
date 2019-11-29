using Newtonsoft.Json;

namespace DevTest.Models
{
    public class Start
    {
        [JsonProperty(PropertyName = "x")]
        public int X { get; set; }

        [JsonProperty(PropertyName = "y")]
        public int Y { get; set; }
    }
}