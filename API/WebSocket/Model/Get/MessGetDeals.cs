using API.WebSocket.Model.Blocks.Values;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Get
{
    class MessGetDeals : MessGet
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public List<DataDeal> Value { get; set; }
    }
}
