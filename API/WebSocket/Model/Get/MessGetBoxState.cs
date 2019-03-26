using API.WebSocket.Model.Blocks.Values;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Get
{
    class MessGetBoxState : MessGet
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public Dictionary<string, DataAPIKey> Value { get; set; }
    }
}
