namespace backend.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class UserExistsException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public UserExistsException(string message) : base(message) { }
    }
}