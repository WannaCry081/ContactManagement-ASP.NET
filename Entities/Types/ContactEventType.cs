using System.Text.Json.Serialization;

namespace backend.Entities.Types
{
    /// <summary>
    /// Represents the type of contact event.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContactEventType
    {
        /// <summary>
        /// Indicates a contact creation event.
        /// </summary>
        Create = 0,

        /// <summary>
        /// Indicates a contact retrieval event.
        /// </summary>
        Retrieve = 1,

        /// <summary>
        /// Indicates a contact update event.
        /// </summary>
        Update = 2,

        /// <summary>
        /// Indicates a contact deletion event.
        /// </summary>
        Delete = 3
    }
}
