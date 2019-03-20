using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValueBalances : ValueBase
    {
        /// <summary>
        /// Last update time, UTS with UTC+00:00
        /// </summary>
        [JsonProperty("uts")]
        public decimal Time { get; set; }

        /// <summary>
        /// Balance data
        /// </summary>
        [JsonProperty("markets")]
        public Dictionary<string, BalancesData> Balances { get; set; }
    }

    public class BalancesData
    {
        /// <summary>
        /// Last update time for the market, UTS with UTC+00:00
        /// </summary>
        [JsonProperty("uts")]
        public decimal Time { get; set; }

        /// <summary>
        /// Available balance for all data
        /// </summary>
        [JsonProperty("balance", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> AvailableBalance { get => Available; set => Available = value; }

        /// <summary>
        /// Available balance for single request
        /// </summary>
        [JsonProperty("available", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Available;

        /// <summary>
        /// Total balance
        /// </summary>
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Total;
    }
}
