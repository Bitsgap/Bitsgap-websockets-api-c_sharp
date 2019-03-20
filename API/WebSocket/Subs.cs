using API.Enums;
using API.WebSocket.Enums;
using API.WebSocket.Model.Send;
using Newtonsoft.Json;

namespace API.WebSocket
{
    /// <summary>
    /// Subscripion requests
    /// </summary>
    class Subs
    {
        /// <summary>
        /// Create a JSON-string for unsubs to all
        /// </summary>
        public static string UnsubsAll() => JsonConvert.SerializeObject(new MessSendSubs(SubsType.UnSubsAll));

        /// <summary>
        /// Create a JSON-string for subs to markets lists and pairs
        /// </summary>
        /// <param name="subs">Subscription type</param>
        public static string Pairs(SubsType subs) => JsonConvert.SerializeObject(new MessSendSubs(MessType.PublicSubs, ProcType.Pairs, subs));
        /// <summary>
        /// Create a JSON-string for subs to pair details
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        public static string PairsDetail(SubsType subs, MarketType market) => JsonConvert.SerializeObject(new MessSendSubs(MessType.PublicSubs, ProcType.PairsDetail, subs, market));
        /// <summary>
        /// Create a JSON-string for subs to orderbook
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        /// <param name="pair">Pair</param>
        public static string Orderbook(SubsType subs, MarketType market, string pair) => JsonConvert.SerializeObject(new MessSendSubs(MessType.PublicSubs, ProcType.Orderbook, subs, market, pair));
        /// <summary>
        /// Create a JSON-string for subs to recent trades
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        /// <param name="pair">Pair</param>
        public static string RecentTrades(SubsType subs, MarketType market, string pair) => JsonConvert.SerializeObject(new MessSendSubs(MessType.PublicSubs, ProcType.RecentTrades, subs, market, pair));
        /// <summary>
        /// Create a JSON-string for subs to last price
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        /// <param name="pair">Pair</param>
        public static string LastPrice(SubsType subs, MarketType market, string pair) => JsonConvert.SerializeObject(new MessSendSubs(MessType.PublicSubs, ProcType.LastPrice, subs, market, pair));
        /// <summary>
        /// Create a JSON-string for subs to price of the day
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        /// <param name="pair">Pair</param>
        public static string PriceDay(SubsType subs, MarketType market, string pair) => JsonConvert.SerializeObject(new MessSendSubs(MessType.PublicSubs, ProcType.PriceDay, subs, market, pair));
        /// <summary>
        /// Create a JSON-string for subs to price of the week
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        /// <param name="pair">Pair</param>
        public static string PriceWeek(SubsType subs, MarketType market, string pair) => JsonConvert.SerializeObject(new MessSendSubs(MessType.PublicSubs, ProcType.PriceWeek, subs, market, pair));
        /// <summary>
        /// Create a JSON-string for subs to price of the month
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        /// <param name="pair">Pair</param>
        public static string PriceMonth(SubsType subs, MarketType market, string pair) => JsonConvert.SerializeObject(new MessSendSubs(MessType.PublicSubs, ProcType.PriceMonth, subs, market, pair));

        /// <summary>
        /// Create a JSON-string for subs to status user API-keys
        /// </summary>
        /// <param name="subs">Subscription type</param>
        public static string BoxState(SubsType subs) => JsonConvert.SerializeObject(new MessSendSubs(MessType.UserSubs, ProcType.BoxState, subs));
        /// <summary>
        /// Create a JSON-string for subs to user balances
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="sys_type">Type of system</param>
        public static string Balances(SubsType subs, SysType sys_type) => JsonConvert.SerializeObject(new MessSendSubs(MessType.UserSubs, ProcType.Balances, subs, MarketType.Empty, null, sys_type));
        /// <summary>
        /// Create a JSON-string for subs to user balance of specific market
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        public static string Balance(SubsType subs, MarketType market) => JsonConvert.SerializeObject(new MessSendSubs(MessType.UserSubs, ProcType.Balance, subs, market));
        /// <summary>
        /// Create a JSON-string for subs to user open orders
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        /// <param name="sys_type">Type of system</param>
        public static string Orders(SubsType subs, MarketType market, SysType sys_type) => JsonConvert.SerializeObject(new MessSendSubs(MessType.UserSubs, ProcType.Orders, subs, market, null, sys_type));
        /// <summary>
        /// Create a JSON-string for subs to user last 20 deals
        /// </summary>
        /// <param name="subs">Subscription type</param>
        /// <param name="market">Market</param>
        /// <param name="sys_type">Type of system</param>
        public static string Deals(SubsType subs, MarketType market, SysType sys_type) => JsonConvert.SerializeObject(new MessSendSubs(MessType.UserSubs, ProcType.Deals, subs, market, null, sys_type));
        /// <summary>
        /// Create a JSON-string for subs to user messages
        /// </summary>
        /// <param name="subs">Subscription type</param>
        public static string Messages(SubsType subs) => JsonConvert.SerializeObject(new MessSendSubs(MessType.UserSubs, ProcType.Messages, subs));
    }
}