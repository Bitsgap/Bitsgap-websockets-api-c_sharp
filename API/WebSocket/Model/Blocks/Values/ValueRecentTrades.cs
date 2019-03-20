using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValueRecentTrades : ValueBase
    {
        public List<RecentTrades> Data { get; set; }
    }

    class RecentTrades
    {
        /// <summary>
        /// Timestamp, UTC +0:00
        /// </summary>
        [JsonProperty("u")]
        public decimal Time { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        [JsonProperty("am")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Side of the trade: "buy" or "sell"
        /// </summary>
        [JsonProperty("s")]
        public string Side { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("p")]
        public decimal Price { get; set; }
    }
}
