using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValuePairsDetail : ValueBase
    {
        public List<PairsDetail> Data { get; set; }
    }

    class PairsDetail
    {
        /// <summary>
        /// Bitsgap pair name
        /// </summary>
        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        public string Pair { get; set; }

        /// <summary>
        /// Market pair name
        /// </summary>
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public string MarketPair { get; set; }

        /// <summary>
        /// Minimum price for order
        /// </summary>
        [JsonProperty("pn", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PriceMin { get; set; }

        /// <summary>
        /// Maximum price for order
        /// </summary>
        [JsonProperty("px", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// Price step
        /// </summary>
        [JsonProperty("ps", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PriceStep { get; set; }

        /// <summary>
        /// Number of decimal places for price
        /// </summary>
        [JsonProperty("pd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PriceDecimal { get; set; }

        /// <summary>
        /// Minimum amount for order
        /// </summary>
        [JsonProperty("an", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? AmountMin { get; set; }

        /// <summary>
        /// Maximum amount for order
        /// </summary>
        [JsonProperty("ax", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? AmountMax { get; set; }

        /// <summary>
        /// Amount step
        /// </summary>
        [JsonProperty("as", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? AmountStep { get; set; }

        /// <summary>
        /// Number of decimal places for amount
        /// </summary>
        [JsonProperty("ad", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? AmountDecimal { get; set; }

        /// <summary>
        /// Minimum total for order
        /// </summary>
        [JsonProperty("tn", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalMin { get; set; }

        /// <summary>
        /// Maximum total for order
        /// </summary>
        [JsonProperty("tx", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalMax { get; set; }

        /// <summary>
        /// Total step
        /// </summary>
        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalStep { get; set; }

        /// <summary>
        /// Number of decimal places for total
        /// </summary>
        [JsonProperty("td", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalDecimal { get; set; }
    }
}
