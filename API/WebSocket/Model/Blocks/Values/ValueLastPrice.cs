using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValueLastPrice : ValueBase
    {
        [JsonIgnore]
        public List<decimal> Data { get; set; }

        /// <summary>
        /// Minimun ask
        /// </summary>
        [JsonProperty("ask")]
        public decimal Ask => Data == null || Data.Count < 2 ? 0M : Data[0];

        /// <summary>
        /// Maximum bid
        /// </summary>
        [JsonProperty("bid")]
        public decimal Bid => Data == null || Data.Count < 2 ? 0M : Data[1];
    }
}
