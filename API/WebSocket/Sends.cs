using API.Enums;
using API.Model;
using API.WebSocket.Enums;
using API.WebSocket.Model.Send;
using Newtonsoft.Json;

namespace API.WebSocket
{
    /// <summary>
    /// Сontrol requests
    /// </summary>
    class Sends
    {
        /// <summary>
        /// Create a JSON-string for the order placement task
        /// </summary>
        /// <param name="sys_type">Type of system</param>
        /// <param name="market">Market</param>
        /// <param name="order">Order data</param>
        /// <param name="api_guid">GUID to track an order placed</param>
        public static string OrderPlace(SysType sys_type, MarketType market, Order order, string api_guid = null) =>
            sys_type == SysType.Real ?
                JsonConvert.SerializeObject(new MessSendControl(ActionType.OrderPlace, market, order, api_guid)) :
                JsonConvert.SerializeObject(new MessSendControl(ActionType.DemoPlace, market, order, api_guid));

        /// <summary>
        /// Create a JSON-string for the order cancellation task
        /// </summary>
        /// <param name="sys_type">Type of system</param>
        /// <param name="market">Market</param>
        /// <param name="order">Order data with order id</param>
        public static string OrderCancel(SysType sys_type, MarketType market, Order order) =>
            sys_type == SysType.Real ?
                JsonConvert.SerializeObject(new MessSendControl(ActionType.OrderCancel, market, order)) :
                JsonConvert.SerializeObject(new MessSendControl(ActionType.DemoCancel, market, order));

        /// <summary>
        /// Create a JSON-string for the order moving task
        /// </summary>
        /// <param name="sys_type">Type of system</param>
        /// <param name="market">Market</param>
        /// <param name="order">Order data with order id and new price</param>
        public static string OrderMove(SysType sys_type, MarketType market, Order order) =>
            sys_type == SysType.Real ?
                JsonConvert.SerializeObject(new MessSendControl(ActionType.OrderMove, market, order)) :
                JsonConvert.SerializeObject(new MessSendControl(ActionType.DemoMove, market, order));

        /// <summary>
        /// Create a JSON-string for the task to the re-read the balance
        /// </summary>
        /// <param name="market">Market</param>
        public static string GetBalance(MarketType market) => JsonConvert.SerializeObject(new MessSendControl(ActionType.GetBalance, market));
    }
}
