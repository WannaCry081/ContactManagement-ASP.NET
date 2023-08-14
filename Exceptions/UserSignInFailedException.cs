namespace backend.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class UserSignInFailedException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public UserSignInFailedException(string message) : base(message) { }
    }
}