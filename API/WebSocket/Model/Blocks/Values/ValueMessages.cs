using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValueMessages : ValueBase
    {
        public List<MessageItem> Data { get; set; }
    }

    class MessageItem
    {
        /// <summary>
        /// Message Type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Message time, UTS with UTC+00:00
        /// </summary>
        [JsonProperty("uts")]
        public decimal UTS { get; set; }

        /// <summary>
        /// Message local time
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset Time { get => DateTimeOffset.FromUnixTimeMilliseconds((long)(UTS * 1000L)).ToLocalTime(); }

        /// <summary>
        /// Message text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
