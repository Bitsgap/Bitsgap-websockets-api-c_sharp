using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValueBoxState : ValueBase
    {
        /// <summary>
        /// Last update time, UTS with UTC+00:00
        /// </summary>
        [JsonProperty("uts")]
        public decimal Time { get; set; }

        /// <summary>
        /// Dictionary for markets
        /// </summary>
        [JsonProperty("box")]
        public Dictionary<string, MarketKeys> Box { get; set; }
    }

    class MarketKeys
    {
        /// <summary>
        /// Service variable, used for bitsgap
        /// </summary>
        [JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        /// <summary>
        /// API key list
        /// </summary>
        [JsonProperty("keys")]
        public List<APIKey> Keys { get; set; }
    }

    class APIKey
    {
        /// <summary>
        /// Public API key
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Key is disable
        /// </summary>
        [JsonProperty("disable")]
        public bool Disable { get; set; }

        /// <summary>
        /// Key is checked
        /// </summary>
        [JsonProperty("check")]
        public bool IsCheck { get; set; }

        /// <summary>
        /// Last check time, UTS with UTC+00:00
        /// </summary>
        [JsonProperty("uts")]
        public decimal Time { get; set; }

        /// <summary>
        /// Invalid key
        /// </summary>
        [JsonProperty("bad")]
        public bool BadKey { get; set; }

        /// <summary>
        /// Key has invalid right
        /// </summary>
        [JsonProperty("bad_right")]
        public bool BadRight { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
