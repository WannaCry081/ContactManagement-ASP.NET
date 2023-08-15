namespace backend.Exceptions
{
    /// <summary>
    /// Exception class to represent a user already exists error.
    /// </summary>
    public class UserExistsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserExistsException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public UserExistsException(string message) : base(message) { }
    }
}
