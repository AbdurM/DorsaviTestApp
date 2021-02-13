using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DorsaviTestApp.Models
{
    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
