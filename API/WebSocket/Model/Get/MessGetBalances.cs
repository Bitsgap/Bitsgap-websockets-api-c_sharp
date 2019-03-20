using API.WebSocket.Model.Blocks.Values;
using Newtonsoft.Json;

namespace API.WebSocket.Model.Get
{
    class MessGetBalances : MessGet
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public ValueBalances Value { get; set; }
    }
}
