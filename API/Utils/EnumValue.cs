using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace API.Utils
{
    /// <summary>
    /// Utils for enums
    /// </summary>
    class EnumValue
    {
        /// <summary>
        /// Get string attribute by enum
        /// </summary>
        public static string GetValue<T>(T value)
            where T : struct, IConvertible
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }

        /// <summary>
        /// Get string attribute by enum and type
        /// </summary>
        public static string GetValue(Type type, object value)
        {
            return type
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }

        /// <summary>
        /// Get enum by string attribute
        /// </summary>
        public static T GetEnum<T>(string description) where T : struct
        {
            return (T)Enum.Parse(typeof(T), 
                typeof(T)
                .GetRuntimeFields()
                ?.FirstOrDefault(x => 
                    x.CustomAttributes.Count() > 0 && 
                    (x.CustomAttributes.FirstOrDefault().NamedArguments.FirstOrDefault().TypedValue.Value as string == description))
                    .Name
               );
        }
    }
}
