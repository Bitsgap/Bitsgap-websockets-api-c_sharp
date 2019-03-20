using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.WebSocket.Model.Get
{
    class MessGetLastPrice : MessGet
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public List<decimal> Value { get; set; }
    }
}
