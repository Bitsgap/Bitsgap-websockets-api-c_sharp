using API.WebSocket.Model.Blocks.Values;
using Newtonsoft.Json;

namespace API.WebSocket.Model.Get
{
    class MessGetOrders : MessGet
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public ValueOrders Value { get; set; }
    }
}
