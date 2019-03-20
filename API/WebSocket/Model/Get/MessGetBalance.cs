using API.WebSocket.Model.Blocks.Values;
using Newtonsoft.Json;

namespace API.WebSocket.Model.Get
{
    class MessGetBalance : MessGet
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public BalancesData Value { get; set; }
    }
}
