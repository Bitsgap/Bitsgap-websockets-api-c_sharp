using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValueOrderbook : ValueBase
    {
        /// <summary>
        /// Orderbook asks
        /// </summary>
        [JsonProperty("a")]
        public Dictionary<string, string> ASKs { get; set; }

        /// <summary>
        /// Orderbook bids
        /// </summary>
        [JsonProperty("b")]
        public Dictionary<string, string> BIDs { get; set; }
    }
}
