using API.WebSocket.Model.Blocks.Values;
using Newtonsoft.Json;

namespace API.WebSocket.Model.Get
{
    class MessGetDeals : MessGet
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public ValueDeals Value { get; set; }
    }
}
