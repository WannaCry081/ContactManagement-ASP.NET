namespace backend.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class UserSignUpFailedException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public UserSignUpFailedException(string message) : base(message) { }
    }
}