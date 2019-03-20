using API.Enums;
using API.Utils;
using API.WebSocket.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace API.WebSocket.Model.Blocks
{
    /// <summary>
    /// Request key class
    /// </summary>
    public class SKey
    {
        [JsonIgnore]
        public static readonly string demo = ".demo";
        /// <summary>
        /// Market type
        /// </summary>
        [JsonIgnore]
        public MarketType Market;
        /// <summary>
        /// System type
        /// </summary>
        [JsonIgnore]
        public SysType SysType;

        /// <summary>
        /// Request key
        /// </summary>
        [JsonProperty("proc")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProcType Proc { get; set; }

        /// <summary>
        /// Market name
        /// </summary>
        [JsonProperty("market", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(StringEnumConverter))] invalid null attribute conversion
        public string MarketName {
            get => Market == MarketType.Empty ? null : EnumValue.GetValue(Market) + (SysType == SysType.Demo ? demo : string.Empty);
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Market = MarketType.Empty;
                }
                else
                {
                    string market_name = value;
                    SysType = market_name.EndsWith(demo) ? SysType.Demo : SysType.Real;
                    market_name = market_name.Replace(demo, string.Empty);
                    Market = EnumValue.GetEnum<MarketType>(market_name);
                }
            }
        }

        [JsonProperty("pair", NullValueHandling = NullValueHandling.Ignore)]
        public string Pair { get; set; }

        /// <summary>
        /// System type string
        /// </summary>
        [JsonProperty("trade", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(StringEnumConverter))] invalid null attribute conversion
        public string Trade { get => EnumValue.GetValue(SysType); set { SysType = EnumValue.GetEnum<SysType>(value); } }

        public SKey() {}

        public SKey(ProcType proc, MarketType market = MarketType.Empty, string pair = null, SysType sys_type = SysType.Empty) : this()
        {
            Proc = proc;
            Market = market;
            Pair = pair;
            SysType = sys_type;
        }
    }
}
