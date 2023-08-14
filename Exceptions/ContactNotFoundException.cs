namespace backend.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ContactNotFoundException(string message) : base(message) { }
    }
}