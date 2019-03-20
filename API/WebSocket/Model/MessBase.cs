using API.Enums;
using API.WebSocket.Enums;
using API.WebSocket.Model.Blocks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace API.WebSocket.Model
{
    public class MessBase
    {
        /// <summary>
        /// Message type
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessType Type { get; set; }

        /// <summary>
        /// Message key
        /// </summary>
        [JsonProperty("skey", NullValueHandling = NullValueHandling.Ignore)]
        public SKey Key { get; set; }

        public MessBase() {}

        public MessBase(MessType type) : this()
        {
            Type = type;
            Key = null;
        }

        public MessBase(MessType type, ProcType proc, MarketType market = MarketType.Empty, string pair = null, SysType sys_type = SysType.Empty) : this()
        {
            Type = type;
            Key = new SKey(proc, market, pair, sys_type);
        }
    }
}
