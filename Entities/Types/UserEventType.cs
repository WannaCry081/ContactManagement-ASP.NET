using System.Text.Json.Serialization;

namespace backend.Entities.Types
{
    /// <summary>
    /// Represents the type of user event.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserEventType
    {
        /// <summary>
        /// Indicates a user sign-up event.
        /// </summary>
        SignUp = 0,

        /// <summary>
        /// Indicates a user sign-in event.
        /// </summary>
        SignIn = 1
    }
}
