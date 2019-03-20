using System.Runtime.Serialization;

namespace API.WebSocket.Enums
{
    /// <summary>
    /// Message types
    /// </summary>
    public enum MessType : short
    {
        /// <summary>
        /// For unsubscribe to all
        /// </summary>
        [EnumMember(Value = "subs")]
        SubsKill,

        /// <summary>
        /// Subscription to public data
        /// </summary>
        [EnumMember(Value = "push_subs")]
        PublicSubs,

        /// <summary>
        /// Subscription to user data
        /// </summary>
        [EnumMember(Value = "users_push_subs")]
        UserSubs,

        /// <summary>
        /// Send control message
        /// </summary>
        [EnumMember(Value = "users_push")]
        UserControl,
    }
}
