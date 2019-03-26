using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValueBalances : ValueBase
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public Dictionary<string, DataBalances> Value { get; set; }
    }

    public class DataBalances
    {
        /// <summary>
        /// Last update time for the market, UTS with UTC+00:00
        /// </summary>
        [JsonProperty("uts")]
        public decimal Time { get; set; }

        /// <summary>
        /// Available balance
        /// </summary>
        [JsonProperty("available", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Available { get; set; }

        /// <summary>
        /// Total balance
        /// </summary>
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Total { get; set; }
    }
}
