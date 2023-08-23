using System.Text.Json.Serialization;

namespace backend.Entities.Types
{
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContactEventType
    {
        /// <summary>
        /// 
        /// </summary>
        Create = 0,
        
        /// <summary>
        /// 
        /// </summary>
        Retrieve = 1,
        
        /// <summary>
        /// 
        /// </summary>
        Update = 2,
        
        /// <summary>
        /// 
        /// </summary>
        Delete = 3
    }
}