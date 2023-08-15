namespace backend.Exceptions
{
    /// <summary>
    /// Exception class to represent a user not found error.
    /// </summary>
    public class UserNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotFoundException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public UserNotFoundException(string message) : base(message) { }
    }
}
