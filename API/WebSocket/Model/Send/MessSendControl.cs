using API.Enums;
using API.Model;
using API.WebSocket.Enums;
using API.WebSocket.Model.Blocks.Values;
using Newtonsoft.Json;

namespace API.WebSocket.Model.Send
{
    class MessSendControl : MessBase
    {
        /// <summary>
        /// Data by key
        /// </summary>
        [JsonProperty("value")]
        public ValueControl Value { get; set; }

        public MessSendControl() : base() {}

        public MessSendControl(ActionType action, MarketType market, Order order = null, string api_guid = null) : base(MessType.UserControl, ProcType.SendControl)
        {
            Value = new ValueControl(action, market, order, api_guid);
        }
    }
}
