using System.Text.Json.Serialization;

namespace backend.Entities.Types
{
    /// <summary>
    /// 
    /// </summary> 
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserEventType
    {
        /// <summary>
        /// 
        /// </summary>
        SignUp = 0,

        /// <summary>
        /// 
        /// </summary>
        SignIn = 1
    }
}