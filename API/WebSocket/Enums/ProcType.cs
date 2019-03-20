using System.Runtime.Serialization;

namespace API.WebSocket.Enums
{
    /// <summary>
    /// Types of actions for subscriptions
    /// </summary>
    public enum ProcType : short
    {
        /// <summary>
        /// Get market pairs
        /// </summary>
        [EnumMember(Value = "v_conf_pairs_to")]
        Pairs,

        /// <summary>
        /// Get pairs details
        /// </summary>
        [EnumMember(Value = "v_conf_pairs")]
        PairsDetail,

        /// <summary>
        /// Get orderbook data
        /// </summary>
        [EnumMember(Value = "ob")]
        Orderbook,

        /// <summary>
        /// Get recent trades data
        /// </summary>
        [EnumMember(Value = "rt")]
        RecentTrades,

        /// <summary>
        /// Get the latest price
        /// </summary>
        [EnumMember(Value = "sym")]
        LastPrice,

        /// <summary>
        /// Get the price of the day
        /// </summary>
        [EnumMember(Value = "sym.1d")]
        PriceDay,

        /// <summary>
        /// Get the price of the week
        /// </summary>
        [EnumMember(Value = "sym.1w")]
        PriceWeek,

        /// <summary>
        /// Get the price of the month
        /// </summary>
        [EnumMember(Value = "sym.1m")]
        PriceMonth,

        /// <summary>
        /// Send control message
        /// </summary>
        [EnumMember(Value = "action.wstask")]
        SendControl,

        /// <summary>
        /// Get the status of user keys
        /// </summary>
        [EnumMember(Value = "box.state")]
        BoxState,

        /// <summary>
        /// Get balance for a specific market
        /// </summary>
        [EnumMember(Value = "user.balance")]
        Balance,

        /// <summary>
        /// Get all balance
        /// </summary>
        [EnumMember(Value = "app.markets.balance")]
        Balances,

        /// <summary>
        /// Get open orders for a specific market
        /// </summary>
        [EnumMember(Value = "app.openorders")]
        Orders,

        /// <summary>
        /// Get the last 20 deals for a specific market
        /// </summary>
        [EnumMember(Value = "app.ordershistory.current")]
        Deals,

        /// <summary>
        /// Get user messages
        /// </summary>
        [EnumMember(Value = "q.messages")]
        Messages,
    }
}
