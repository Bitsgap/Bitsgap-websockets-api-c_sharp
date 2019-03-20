using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValuePairs : ValueBase
    {
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("t")]
        public string Time { get; set; }

        /// <summary>
        /// Markets and pairs
        /// </summary>
        [JsonProperty("markets")]
        public Dictionary<string, List<string>> Data { get; set; }
    }
}
