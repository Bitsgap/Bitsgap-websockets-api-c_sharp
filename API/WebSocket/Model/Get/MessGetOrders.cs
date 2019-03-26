using API.WebSocket.Model.Blocks.Values;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Get
{
    class MessGetOrders : MessGet
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public List<DataOrder> Value { get; set; }
    }
}
