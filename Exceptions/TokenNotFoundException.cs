namespace backend.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public TokenNotFoundException(string message) : base(message) { }
    }
}