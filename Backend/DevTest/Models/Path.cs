using Newtonsoft.Json;
using System.Collections.Generic;

namespace DevTest.Models
{
    public class Path
    {
        [JsonProperty(PropertyName = "start")]
        public Start Start { get; set; }

        [JsonProperty(PropertyName = "commands")]
        public IList<Command> Commands { get; set; }
    }
}