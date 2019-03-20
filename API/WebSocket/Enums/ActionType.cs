using System.Runtime.Serialization;

namespace API.WebSocket.Enums
{
    /// <summary>
    /// Types of actions
    /// </summary>
    public enum ActionType : short
    {
        /// <summary>
        /// Place an order on the real market
        /// </summary>
        [EnumMember(Value = "trade@order_place")]
        OrderPlace,

        /// <summary>
        /// Cancel an order on the real market
        /// </summary>
        [EnumMember(Value = "trade@order_cancel")]
        OrderCancel,

        /// <summary>
        /// Moving an order on the real market
        /// </summary>
        [EnumMember(Value = "trade@order_move")]
        OrderMove,

        /// <summary>
        /// Place an order on the demo market
        /// </summary>
        [EnumMember(Value = "demo@order_place")]
        DemoPlace,

        /// <summary>
        /// Cancel an order on the demo market
        /// </summary>
        [EnumMember(Value = "demo@order_cancel")]
        DemoCancel,

        /// <summary>
        /// Moving an order on the demo market
        /// </summary>
        [EnumMember(Value = "demo@order_move")]
        DemoMove,

        /// <summary>
        /// Request a balance on the real market
        /// </summary>
        [EnumMember(Value = "trade@balance")]
        GetBalance,
    }
}
