using API.Utils;
using API.Enums;
using Newtonsoft.Json;
using API.WebSocket.Enums;

namespace API.WebSocket.Model.Send
{
    class MessSendSubs : MessBase
    {

        private SubsType _subs;

        /// <summary>
        /// Subscription type in string
        /// </summary>
        [JsonProperty("subs", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(StringEnumConverter))] invalid null attribute conversion
        public string Subs { get => EnumValue.GetValue(_subs); set { _subs = EnumValue.GetEnum<SubsType>(value); } }

        /// <summary>
        /// For unsubs
        /// </summary>
        public MessSendSubs(SubsType subs) : base(MessType.SubsKill)
        {
            _subs = subs;
        }

        /// <summary>
        /// For subs
        /// </summary>
        public MessSendSubs(MessType type, ProcType proc, SubsType subs, MarketType market = MarketType.Empty, string pair = null, SysType sys_type = SysType.Empty) : base(type, proc, market, pair, sys_type)
        {
            _subs = subs;
        }
    }
}
