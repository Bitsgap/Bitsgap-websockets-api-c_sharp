using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace API.WebSocket.Model.Get
{
    public class MessGet : MessBase
    {
        /// <summary>
        /// Error mess
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// All raw data
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JToken> Extra { get; set; }
    }
}
