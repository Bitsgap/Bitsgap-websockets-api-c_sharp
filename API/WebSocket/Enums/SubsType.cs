using System.Runtime.Serialization;

namespace API.WebSocket.Enums
{
    /// <summary>
    /// Subscription types
    /// </summary>
    public enum SubsType : short
    {
        /// <summary>
        /// Only get data
        /// </summary>
        [EnumMember(Value = null)]
        GetExist = 0,

        /// <summary>
        /// Subscribe and get data. "1" and "11"
        /// </summary>
        [EnumMember(Value = "1")]
        SubsAndGetExist,

        /// <summary>
        /// Subscribe and get data of the next change. "10"
        /// </summary>
        [EnumMember(Value = "10")]
        SubsAndGetNextChange,

        /// <summary>
        /// Unsubscribe. "0" and "00"
        /// </summary>
        [EnumMember(Value = "0")]
        UnSubs,

        /// <summary>
        /// Unsubscribe and get data. "01"
        /// </summary>
        [EnumMember(Value = "01")]
        UnSubsAndGetExist,

        /// <summary>
        /// Unsubscribe from all. "kill"
        /// </summary>
        [EnumMember(Value = "kill")]
        UnSubsAll,
    }
}
