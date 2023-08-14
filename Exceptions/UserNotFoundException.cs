namespace backend.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class UserNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public UserNotFoundException(string message) : base(message) { }
    }
}