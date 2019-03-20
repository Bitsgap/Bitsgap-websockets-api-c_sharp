using API.Enums;
using API.Model;
using API.WebSocket.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace API.WebSocket.Model.Blocks.Values
{
    class ValueControl : ValueBase
    {
        /// <summary>
        /// Action type
        /// </summary>
        [JsonProperty("key")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionType Action { get; set; }

        /// <summary>
        /// Data for action
        /// </summary>
        [JsonProperty("params")]
        public ActionParams Params { get; set; }

        public ValueControl() { }

        public ValueControl(ActionType action, MarketType market, Order order = null, string api_guid = null)
        {
            Action = action;

            switch (action)
            {
                case ActionType.OrderPlace:
                case ActionType.DemoPlace:
                    if (market == MarketType.Empty) throw new ArgumentException("Market not specified", "market");
                    if (order == null) throw new ArgumentNullException("order");

                    Params = new ActionOrderPlace
                    {
                        Market = market,
                        Pair = order.Pair,
                        Side = order.Side,
                        Type = order.Type,
                        Amount = order.Amount,
                        Price = order.Price,
                        API_GUID = api_guid
                    };

                    break;
                case ActionType.OrderCancel:
                case ActionType.DemoCancel:
                    if (market == MarketType.Empty) throw new ArgumentException("Market not specified", "market");
                    if (order == null) throw new ArgumentNullException("order");

                    Params = new ActionOrderCancel
                    {
                        Market = market,
                        OrderID = order.OrderID
                    };

                    break;
                case ActionType.OrderMove:
                case ActionType.DemoMove:
                    if (market == MarketType.Empty) throw new ArgumentException("Market not specified", "market");
                    if (order == null) throw new ArgumentNullException("order");

                    Params = new ActionOrderMove
                    {
                        Market = market,
                        OrderID = order.OrderID,
                        MovePrice = order.Price
                    };

                    break;
                case ActionType.GetBalance:
                    if (market == MarketType.Empty) throw new ArgumentException("Market not specified", "market");

                    Params = new ActionParams
                    {
                        Market = market
                    };

                    break;
                default:
                    throw new ArgumentException("Unused action type", "action");
            }
        }
    }

    class ActionParams
    {
        /// <summary>
        /// Market type
        /// </summary>
        [JsonProperty("market")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MarketType Market { get; set; }
    }

    class ActionOrderPlace : ActionParams
    {
        /// <summary>
        /// Bitsgap pair
        /// </summary>
        [JsonProperty("pair")]
        public string Pair { get; set; }

        /// <summary>
        /// Order side
        /// </summary>
        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType Type { get; set; }

        /// <summary>
        /// Order amount
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }

        /// <summary>
        /// GUID to track an order placed
        /// </summary>
        [JsonProperty("api_guid", NullValueHandling = NullValueHandling.Ignore)]
        public string API_GUID { get; set; }
    }

    class ActionOrderCancel: ActionParams
    {
        /// <summary>
        /// Market order id
        /// </summary>
        [JsonProperty("id")]
        public string OrderID { get; set; }
    }

    class ActionOrderMove : ActionParams
    {
        /// <summary>
        /// Market order id
        /// </summary>
        [JsonProperty("id")]
        public string OrderID { get; set; }

        /// <summary>
        /// New order price
        /// </summary>
        [JsonProperty("price")]
        public string MovePrice { get; set; }
    }
}
