using API.WebSocket.Model.Blocks.Values;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Get
{
    class MessGetBalances : MessGet
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public Dictionary<string, DataBalances> Value { get; set; }
    }
}
