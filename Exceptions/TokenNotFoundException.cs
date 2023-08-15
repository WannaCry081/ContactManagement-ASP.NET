namespace backend.Exceptions
{
    /// <summary>
    /// Exception class to represent a token not found error.
    /// </summary>
    public class TokenNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenNotFoundException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public TokenNotFoundException(string message) : base(message) { }
    }
}
