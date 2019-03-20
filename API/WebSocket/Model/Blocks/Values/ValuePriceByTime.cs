using Newtonsoft.Json;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValuePriceByTime : ValueBase
    {
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
